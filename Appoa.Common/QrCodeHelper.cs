using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace Appoa.Common
{
    public class QrCodeHelper
    {
        /// <summary>
        /// 获取合成后的二维码图片
        /// </summary>
        /// <param name="strContent">二维码内容</param>
        /// <param name="ms">内存流</param>
        /// <param name="saveFile">保存文件名</param>
        /// <param name="iconImage">Logo图标路径</param>
        /// <param name="isDelete">自动删除</param>
        /// <returns></returns>
        public static bool GetRQCodeCombin(string strContent, MemoryStream ms, string saveFile, string iconImage, bool isDelete = true)
        {
            if (!File.Exists(iconImage))
            {
                return false;
            }
            string onePng = string.Empty;

            onePng = Path.Combine(Path.GetTempPath(), DateTime.Now.Ticks.ToString() + "_" + Guid.NewGuid().ToString() + ".png");//Path.GetTempFileName() + ".png";
            GetQRCode(strContent, ms, onePng);

            //如果存在则删除
            if (File.Exists(saveFile))
                File.Delete(saveFile);

            CombinImage.Combin(onePng, iconImage, 80, saveFile);

            if (isDelete)
            {
                if (File.Exists(onePng))
                    File.Delete(onePng);
            }
            return true;
        }


        /// <summary>  
        /// 获取二维码  
        /// </summary>  
        /// <param name="strContent">待编码的字符</param>  
        /// <param name="ms">输出流</param>  
        ///<returns>True if the encoding succeeded, false if the content is empty or too large to fit in a QR code</returns>  
        public static void GetQRCode(string strContent, MemoryStream ms, string saveFile)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 13;

            //将字符串生成二维码图片
            Bitmap image = qrCodeEncoder.Encode(strContent, Encoding.Default);

            //保存为PNG到内存流  
            image.Save(ms, ImageFormat.Png);

            Bitmap bmp = new Bitmap(image);
            bmp.Save(saveFile, ImageFormat.Png);
            bmp.Dispose();
            image.Dispose();
            ms.Dispose();
        }
    }
}
