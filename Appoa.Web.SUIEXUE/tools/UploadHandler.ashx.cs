using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Configuration;
using Newtonsoft.Json;
using Appoa.Common;
using Appoa.Model.Entity;
using Microsoft.Office.Core;

namespace Appoa.Manage.tools
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            string thumb = RequestHelper.GetQueryString("thumb");

            List<string> extendList = new List<string>();
            extendList.Add("doc");
            extendList.Add("docx");
            extendList.Add("ppt");
            extendList.Add("pptx");
            extendList.Add("pdf");
            extendList.Add("mp3");
            extendList.Add("mp4");
            extendList.Add("obj");

            HttpPostedFile file = context.Request.Files["Filedata"];
            string fileName = file.FileName;
            string extend = Utils.GetFileExt(fileName);
            if (!extendList.Contains(extend.ToLower()))
            {
                context.Response.Write("{\"code\":1,\"message\":\"文件格式错误\"}");
                return;
            }

            //物理路径
            string uploadPath = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + "\\";
            string RootDir = uploadPath.Replace("\\", "/");
            string pat_url_name = "/upload/resource/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
            string pathName = RootDir + pat_url_name;

            if (!System.IO.Directory.Exists(pathName))
                System.IO.Directory.CreateDirectory(pathName); // 不存在创建文件夹

            string docPath = DateTime.Now.ToString("MMddhhmmssfff") + Utils.GetCheckCode(4) + "." + extend;

            pathName += docPath;
            if (System.IO.File.Exists(pathName))
                File.Delete(pathName);//删除之前的文件

            uploadPath += pat_url_name;
            if (file != null)
            {
                try
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    file.SaveAs(uploadPath + docPath);

                    string path = pat_url_name + docPath;//文件保存的虚拟路径
                    if (extend == "mp4")
                    {
                        if (thumb == "true")
                        {
                            VideoThumbHelper.cutVideoThumb(context.Server.MapPath(ConfigurationManager.AppSettings["FFmpegPath"]), context.Server.MapPath(path), 1);
                        }
                    }
                    if (extend == "doc" || extend == "docx")
                    {
                        WordToPDF(path, "." + extend);
                        //FileToPDF(path, "." + extend);
                    }
                    if (extend == "ppt" || extend == "pptx")
                    {
                        PPTToPDF(path, "." + extend);
                    }

                    file_info_entity entity = new file_info_entity();
                    entity.fileName = fileName;
                    entity.extend = extend;
                    entity.newName = docPath;
                    entity.path = path;
                    entity.thumb_path = path.Replace(".mp4", "_thumb.jpg");

                    context.Response.Write(JsonConvert.SerializeObject(entity));
                    return;
                }
                catch (Exception e)
                {
                    WriteLog(this.GetType().ToString(), "", e.Message);
                    context.Response.Write("{\"code\":-1,\"message\":\"" + e.Message + "\"}");
                    return;
                }
            }
            else
            {
                context.Response.Write("{\"code\":0,\"message\":\"没有文件\"}");
                return;
            }
        }

        #region 日志

        /**
        * 实际的写日志操作
        * @param type 日志记录类型
        * @param className 类名
        * @param content 写入内容
        */
        private static void WriteLog(string type, string className, string content)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "/logs/syx";
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //创建或打开日志文件，向日志文件末尾追加记录
            StreamWriter mySw = File.AppendText(filename);

            //向日志文件写入内容
            string write_content = time + " " + type + " " + className + ": " + content;
            mySw.WriteLine(write_content);

            //关闭日志文件
            mySw.Close();
        }

        #endregion
        
        public void WordToPDF(string path, string extend)
        {
            string filePath = HttpContext.Current.Server.MapPath(path);
            string outPath = HttpContext.Current.Server.MapPath(path).Replace(extend, ".pdf");

            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = null;
            try
            {
                application.Visible = false;
                document = application.Documents.Open(filePath);
                document.ExportAsFixedFormat(outPath, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (document != null)
                {
                    document.Close();
                    document = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void PPTToPDF(string path, string extend)
        {
            string filePath = HttpContext.Current.Server.MapPath(path);
            string outPath = HttpContext.Current.Server.MapPath(path).Replace(extend, ".pdf");

            Microsoft.Office.Interop.PowerPoint.ApplicationClass application = null;
            Microsoft.Office.Interop.PowerPoint.Presentation presentation = null;
            try
            {
                application = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
                presentation = application.Presentations.Open(filePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                presentation.SaveAs(outPath, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPDF, MsoTriState.msoTrue);

                Utils.StringToTxt("UploadHandler.ashx=>PPTToPDF：成功");
            }
            catch (Exception ex)
            {
                Utils.StringToTxt("UploadHandler.ashx=>PPTToPDF：失败。" + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Close();
                    presentation = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}