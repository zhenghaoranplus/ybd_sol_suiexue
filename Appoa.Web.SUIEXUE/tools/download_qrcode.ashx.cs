using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Appoa.Common;
using Appoa.Common.ZipLib;
using Appoa.Common.ZipLib.Zip;

namespace Appoa.Manage.tools
{
    /// <summary>
    /// download_qrcode 的摘要说明
    /// </summary>
    public class download_qrcode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = RequestHelper.GetQueryString("action");

            switch (action)
            {
                case "DownCourseQrCode":
                    DownCourseQrCode();
                    break;
            }
        }

        private void DownCourseQrCode()
        {
            var Server = HttpContext.Current.Server;

            int course_id = RequestHelper.GetFormInt("course_id");
            string WebPath = System.Configuration.ConfigurationManager.AppSettings["WebPath"];
            string webApi_address = WebPath + "/QrCode.aspx";

            BLL.course_info bll = new BLL.course_info();
            Model.course_info course = bll.GetModel(course_id);
            if (course != null)
            {
                string course_name = course.name.Trim();
                //1、生成书籍的二维码文件夹
                string virualRootPath = string.Format("/tempDown/{0}", course.name.Trim());
                string tempRootPath = Server.MapPath(string.Format("/tempDown/{0}", course_name)).Trim();

                if (Directory.Exists(tempRootPath))
                {
                    Directory.Delete(tempRootPath, true);
                }
                if (!Directory.Exists(tempRootPath))
                {
                    Directory.CreateDirectory(tempRootPath);
                }

                if (string.IsNullOrWhiteSpace(webApi_address))
                {
                    writeMsgError(-1, "没有配置WebPath地址!");
                    return;
                }

                string bookQrCodePath = System.IO.Path.Combine(tempRootPath, string.Format("{0}_书籍资源.png", course_name)).Trim();

                string course_qrcode = string.Format("{0}/html/course_details.html?id={1}", WebPath, course.id); //要根据各个的生成规则生成二维码

                string logoPath = course.qrcode_logo;//二维码logo
                if (string.IsNullOrEmpty(logoPath))
                {
                    Model.common_albums defaultlogo = new BLL.common_albums().GetModel(" group_id = " + (int)Appoa.Common.EnumCollection.img_group.系统默认二维码logo);
                    if (defaultlogo != null)
                    {
                        logoPath = defaultlogo.original_path;
                    }
                    else
                    {
                        logoPath = "/html/images/Logo.png";
                    }
                }
                using (var ms = new MemoryStream())
                {
                    QrCodeHelper.GetRQCodeCombin(course_qrcode, ms, bookQrCodePath, Server.MapPath(logoPath));
                }
                //2、生成章的文件夹
                BLL.course_chapter ccBll = new BLL.course_chapter();
                BLL.common_resource crBll = new BLL.common_resource();
                List<Model.course_chapter> firstChapterList = ccBll.GetModelList(" group_id = 1 and chapter_level = 1 and course_id = " + course.id);
                foreach (Model.course_chapter chapter in firstChapterList)
                {
                    string chapterPath = System.IO.Path.Combine(tempRootPath, string.Format("章_{0}", chapter.name)).Trim();
                    if (Directory.Exists(chapterPath))
                    {
                        Directory.Delete(chapterPath, true);
                    }
                    if (!Directory.Exists(chapterPath))
                    {
                        Directory.CreateDirectory(chapterPath);
                    }

                    //3、生成节的文件夹
                    //List<Model.course_chapter> secondChapterList = ccBll.GetModelList(" group_id = 1 and chapter_level = 2 and course_id = " + course.id + " and parent_id = " + chapter.id);
                    //foreach (Model.course_chapter part in secondChapterList)
                    //{
                    //    string partPath = System.IO.Path.Combine(chapterPath, string.Format("节_{0}", part.name)).Trim();
                    //    if (Directory.Exists(partPath))
                    //    {
                    //        Directory.Delete(partPath, true);
                    //    }
                    //    if (!Directory.Exists(partPath))
                    //    {
                    //        Directory.CreateDirectory(partPath);
                    //    }

                    //4、生成章下所有资源二维码图片
                    List<Model.common_resource> resourceList = crBll.GetModelList(" is_del = 0 and from_id = " + (int)EnumCollection.resource_from.精品微课 + " and data_id = " + chapter.id);
                    foreach (Model.common_resource item in resourceList)
                    {
                        string resCode = string.Empty;
                        switch (item.type)
                        {
                            case (int)EnumCollection.resource_type.图文资源:
                                if (item.from_id == (int)EnumCollection.resource_from.精品微课)
                                {
                                    resCode = WebPath + "/html/article_details.html?id=" + item.id;
                                }
                                else
                                {
                                    resCode = WebPath + "/html/knowledge_details.html?id=" + item.id;
                                }
                                break;
                            case (int)EnumCollection.resource_type.文档资源:
                                item.path = item.path.Substring(0, item.path.LastIndexOf('.'));
                                //resCode = WebPath + item.path + ".html";
                                resCode = "/html/doc_detail.html?id=" + item.id;
                                break;
                            case (int)EnumCollection.resource_type.音频资源:
                                resCode = WebPath + "/html/video_details.html?id=" + item.id;
                                break;
                            case (int)EnumCollection.resource_type.视频资源:
                                resCode = WebPath + "/html/video_details.html?id=" + item.id;
                                break;
                            case (int)EnumCollection.resource_type.英文发音:
                                resCode = WebPath + "/html/voice_detail.html?id=" + item.id;
                                break;
                            case (int)EnumCollection.resource_type.三维模型:
                                resCode = WebPath + "/html/3d.html?id=" + item.id;
                                break;
                        }
                        //生成明细资源
                        //string resPath = System.IO.Path.Combine(partPath, string.Format("{0}_{1}_资源_{2}.png", chapter.name, part.name, item.title.Trim())).Trim();
                        string resPath = System.IO.Path.Combine(chapterPath, item.title.Trim() + ".png").Trim();

                        using (var ms = new MemoryStream())
                        {
                            QrCodeHelper.GetRQCodeCombin(resCode, ms, resPath, Server.MapPath(logoPath));
                        }
                    }
                    //}
                }

                //打包—下载
                FastZip fz = new FastZip();
                fz.CreateEmptyDirectories = true;
                fz.CreateZip(string.Format("{0}.zip", tempRootPath), tempRootPath, true, "");
                // ZFiles.DownLoadFile(Server.MapPath(string.Format("{0}.zip", virualRootPath)));
                ZFiles.DownloadFile(System.Web.HttpContext.Current, Server.MapPath(string.Format("{0}.zip", virualRootPath)), 1024 * 50);
            }
        }

        #region 输出json

        #region 失败输出
        /// <summary>
        /// 失败输出
        /// </summary>
        /// <param name="msg">消息</param>
        private void writeMsgError(int code, string msg)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.error(code, msg));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 成功输出
        /// <summary>
        /// 成功输出
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="o">不返回数据为null,其他位数组对象</param>
        private void writeMsgSuccess(string msg, object o)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.success(msg, o));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            HttpContext.Current.Response.End();
        }
        #endregion

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}