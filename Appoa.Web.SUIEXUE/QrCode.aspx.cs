using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using Appoa.Common;

namespace Appoa.Manage
{
    public partial class QrCode : System.Web.UI.Page
    {
        public string WebPath = System.Configuration.ConfigurationManager.AppSettings["WebPath"];

        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                GetQrCode(type);
            }
        }

        private void GetQrCode(string type)
        {
            string str = string.Empty;
            string id = Request.QueryString["id"];
            string logopath = string.Empty;
            bool is_logo = true;
            Model.course_info course = null;

            switch (type)
            {
                case "course"://课程
                    is_logo = true;
                    course = new BLL.course_info().GetModel(Convert.ToInt32(id));
                    if (course != null)
                    {
                        str = WebPath + "/html/course_details.html?id=" + id;
                        logopath = course.qrcode_logo;
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "re"://资源
                    is_logo = true;
                    Model.common_resource resource = new BLL.common_resource().GetModel(Convert.ToInt32(id));
                    if (resource != null)
                    {
                        course = new BLL.course_info().GetModel(" id = (select course_id from ybd_course_chapter where id = " + resource.data_id + ")");
                        if (course != null)
                        {
                            logopath = course.qrcode_logo;
                        }

                        switch (resource.type)
                        {
                            case (int)Appoa.Common.EnumCollection.resource_type.图文资源:
                                if (resource.from_id == (int)EnumCollection.resource_from.精品微课)
                                {
                                    str = WebPath + "/html/article_details.html?id=" + id;
                                }
                                else
                                {
                                    str = WebPath + "/html/knowledge_details.html?id=" + id;
                                }
                                break;
                            case (int)Appoa.Common.EnumCollection.resource_type.文档资源:
                                resource.path = resource.path.Substring(0, resource.path.LastIndexOf('.'));
                                //str = WebPath + resource.path + ".html";
                                str = WebPath + "/html/doc_detail.html?id=" + id;
                                break;
                            case (int)Appoa.Common.EnumCollection.resource_type.音频资源:
                                str = WebPath + "/html/video_details.html?id=" + id;
                                break;
                            case (int)Appoa.Common.EnumCollection.resource_type.视频资源:
                                str = WebPath + "/html/video_details.html?id=" + id;
                                break;
                            case (int)Appoa.Common.EnumCollection.resource_type.英文发音:
                                str = WebPath + "/html/voice_detail.html?id=" + id;
                                break;
                            case (int)Appoa.Common.EnumCollection.resource_type.三维模型:
                                str = WebPath + "/html/3d.html?id=" + id;
                                break;
                        }
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "test"://测验
                    Model.common_examination exam = new BLL.common_examination().GetModel(Convert.ToInt32(id));
                    if (exam != null)
                    {
                        str = WebPath + "/html/test.html?id=" + id;
                        is_logo = true;
                        //course = new BLL.course_info().GetModel(" id = (select course_id from ybd_course_chapter where id = " + exam.parent_id + ")");
                        //if (course != null)
                        //{
                        //    logopath = course.qrcode_logo;
                        //}
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "talk"://讨论
                    Model.common_article article = new BLL.common_article().GetModel(Convert.ToInt32(id));
                    if (article != null)
                    {
                        str = WebPath + "/html/discuss_details.html?id=" + id;
                        is_logo = true;
                        //course = new BLL.course_info().GetModel(" id = (select course_id from ybd_course_chapter where user_id = 0 and id = " + article.category_id + ")");
                        //if (course != null)
                        //{
                        //    logopath = course.qrcode_logo;
                        //}
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "quest"://心理测试
                    str = WebPath + "/html/questionnaire.html?id=" + id;
                    break;
                case "classroom"://课堂
                    str = WebPath + "/html/join_class.html?id=" + id;
                    break;
            }

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 13;

            //将字符串生成二维码图片
            Bitmap image = qrCodeEncoder.Encode(str, Encoding.Default);

            //保存为PNG到内存流  
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);

            if (is_logo)
            {
                if (string.IsNullOrEmpty(logopath))
                {
                    Model.common_albums defaultlogo = new BLL.common_albums().GetModel(" group_id = " + (int)Appoa.Common.EnumCollection.img_group.系统默认二维码logo);
                    if (defaultlogo != null)
                    {
                        logopath = defaultlogo.original_path;
                    }
                    else
                    {
                        logopath = "/html/images/Logo.png";
                    }
                }

                //logopath = "/html/images/Logo.png";

                MemoryStream ms1 = new MemoryStream();
                CombinImage(image, Server.MapPath("~" + logopath), 80).Save(ms1, System.Drawing.Imaging.ImageFormat.Png);

                //输出二维码图片
                Response.ClearContent();
                Response.ContentType = "image/Png";
                Response.BinaryWrite(ms1.ToArray());

                ms.Dispose();
                ms1.Dispose();

                Response.Flush();
                Response.End();
            }
            else
            {
                //输出二维码图片
                Response.ClearContent();
                Response.ContentType = "image/Png";
                Response.BinaryWrite(ms.ToArray());

                ms.Dispose();

                Response.Flush();
                Response.End();
            }
        }

        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, string destImg, int destSize)
        {
            try
            {
                Image img = Image.FromFile(destImg);//粘贴的目标图片
                if (img.Height != destSize || img.Width != destSize)
                {
                    img = KiResizeImage(img, destSize, destSize, 0);
                }

                int border = 40;

                int backWidth = imgBack.Width + border;
                int backHeight = imgBack.Height + border;
                Image backgroud = new Bitmap(backWidth, backHeight);

                //创建空白的Graphics
                using (Graphics g = Graphics.FromImage(backgroud))
                {
                    //把backgroud涂成白色
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, backWidth, backHeight));

                    //把白色画到背景图片中
                    g.DrawImage(backgroud, 0, 0, backWidth, backHeight);

                    //把二维码图片画到图片中
                    g.DrawImage(imgBack, border / 2, border / 2, imgBack.Width, imgBack.Height);

                    //给整个图片加扣一个白色正方形的中心
                    g.FillRectangle(Brushes.White, backWidth / 2 - img.Width / 2 - border / 8, backHeight / 2 - img.Width / 2 - border / 8, img.Width + border / 4, img.Height + border / 4);

                    //把logo放在这个白色正方形中心中
                    g.DrawImage(img, backWidth / 2 - img.Width / 2, backWidth / 2 - img.Width / 2, img.Width, img.Height);

                    GC.Collect();
                    img.Dispose();
                    imgBack.Dispose();
                    return backgroud;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}