using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;

namespace Appoa.Common
{
    /// <summary>
    /// 二维码（两个图片合成)
    /// </summary>
    public class CombinImage
    {
        //byte[] 转图片  
        public Image ByteToImg(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            MemoryStream stream = new MemoryStream();
            stream.Write(data, 0, data.Length);
            Image image = null;
            try
            {
                image = Image.FromStream(stream);
            }
            catch
            {
            }
            stream.Close();
            return image;
        }

        //图片转byte[]   
        public byte[] BitmapToBytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }

        /// <summary>
        /// 将 Stream 转成 byte[]  
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始  
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        /// <summary>  
        /// 将 byte[] 转成 Stream  
        /// </summary>  
        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - -  
 * Stream 和 文件之间的转换 
 * - - - - - - - - - - - - - - - - - - - - - - - */
        /// <summary>  
        /// 将 Stream 写入文件  
        /// </summary>  
        public void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]  
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始  
            stream.Seek(0, SeekOrigin.Begin);

            // 把 byte[] 写入文件  
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        /// <summary>  
        /// 从文件读取 Stream  
        /// </summary>  
        public Stream FileToStream(string fileName)
        {
            // 打开文件  
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]  
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream  
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        /// <summary>
        /// 原文件
        /// </summary>
        /// <param name="sourceImage">原文件</param>
        /// <param name="destBitmap">背景图</param>
        /// <returns></returns>
        public Bitmap Combin(Bitmap sourceImage, Bitmap destBitmap)
        {
            //if (destBitmap.Height != 250 || destBitmap.Width != 250)
            //{
            //    destBitmap = KiResizeImage(destBitmap, 250, 250, 0);
            //}
            using (var g = Graphics.FromImage(sourceImage))
            {
                //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高); 
                g.DrawImage(sourceImage, 0, 0, sourceImage.Width, sourceImage.Height);
                //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框  
                g.DrawImage(destBitmap, sourceImage.Width / 2 - destBitmap.Width / 2, sourceImage.Width / 2 - destBitmap.Width / 2, destBitmap.Width, destBitmap.Height);
                //
                sourceImage.Dispose();
                destBitmap.Dispose();
                GC.Collect();
                return sourceImage;
            }
        }


        /// <summary>
        /// 图像合并
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="insertImage"></param>
        /// <param name="savePng"></param>
        /// <returns></returns>
        public static string Combin(string sourceImage, string insertImage, int insertSize, string savePng)
        {
            try
            {
                Image insert = Image.FromFile(insertImage);//粘贴的目标图片
                if (insert.Height != insertSize || insert.Width != insertSize)
                {
                    insert = KiResizeImage(insert, insertSize, insertSize, 0);
                }

                Bitmap source = new Bitmap(sourceImage);
                int border = 40;

                int backWidth = source.Width + border;
                int backHeight = source.Height + border;
                Image backgroud = new Bitmap(backWidth, backHeight);

                //创建空白的Graphics
                using (Graphics g = Graphics.FromImage(backgroud))
                {
                    //把backgroud涂成白色
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, backWidth, backHeight));

                    //把白色画到背景图片中
                    g.DrawImage(backgroud, 0, 0, backWidth, backHeight);

                    //把二维码图片画到图片中
                    g.DrawImage(source, border / 2, border / 2, source.Width, source.Height);

                    //给整个图片加扣一个白色正方形的中心
                    g.FillRectangle(Brushes.White, backWidth / 2 - insert.Width / 2 - border / 8, backHeight / 2 - insert.Width / 2 - border / 8, insert.Width + border / 4, insert.Height + border / 4);

                    //把logo放在这个白色正方形中心中
                    g.DrawImage(insert, backWidth / 2 - insert.Width / 2, backWidth / 2 - insert.Width / 2, insert.Width, insert.Height);

                    //if (!File.Exists(savePng))
                    //savePng = savePng.Replace(".png", ".bmp");
                    backgroud.Save(savePng, System.Drawing.Imaging.ImageFormat.Png);

                    //释放资源
                    backgroud.Dispose();
                    source.Dispose();
                    insert.Dispose();
                    GC.Collect();
                    return savePng;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>    
        /// 缩放图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Bitmap KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
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
