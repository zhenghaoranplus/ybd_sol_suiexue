using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;
using System.Data;

namespace Appoa.Common
{
    public class ImageUtil
    {

        #region 创建验证码的图片
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="validateNum">验证码</param>
        public static byte[] getCaptchaImageStream(int width, int height, string validateCode)
        {
            //Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 4);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        #endregion


        #region  base64编码的字符串转为图片
        /// <summary>
        /// base64编码的字符串转为图片
        /// </summary>
        /// <param name="strbase64"></param>
        /// <param name="strurl"></param>
        /// <returns></returns>
        public static bool UploadImg(string strbase64, string strurl)
        {
            bool up = true;
            try
            {
                strbase64 = strbase64.Replace(' ', '+');
                strbase64 = strbase64.Replace(" ", "");
                byte[] b = System.Text.Encoding.UTF8.GetBytes(strbase64);

                sbyte[] bSByte = new sbyte[b.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] > 127)
                        bSByte[i] = (sbyte)(b[i] - 256);
                    else
                        bSByte[i] = (sbyte)b[i];
                }

                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bitmap = new Bitmap(ms);
                ms.Close();

                Bitmap bmp = new Bitmap(bitmap);
                bmp.Save(strurl, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp.Dispose();
                bitmap.Dispose();
                up = true;
            }
            catch (Exception e)
            {
                up = false;
                throw e;
            }
            return up;
        }
        #endregion


        public static DataSet HandleImage(DataSet ds, string colum, int l, int w)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i][colum] = ds.Tables[0].Rows[i][colum] + "?l=" + l + "&w=" + w;
            }
            return ds;
        }

    }
}
