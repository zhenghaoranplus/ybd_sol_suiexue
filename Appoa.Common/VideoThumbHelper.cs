using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Appoa.Common
{
    public class VideoThumbHelper
    {
        /// <summary>
        /// 截取视频缩略图(第1秒)
        /// </summary>
        /// <param name="FFmpegPath"></param>
        /// <param name="videoPath"></param>
        /// <returns></returns>
        public static bool cutVideoThumb(string FFmpegPath, string videoPath,decimal time)
        {
            if (!string.IsNullOrEmpty(videoPath))
            {
                string saveThumbnailTo = videoPath.Replace(".mp4", "_thumb.jpg");
                //videoPath = HttpContext.Current.Server.MapPath(videoPath);
                //saveThumbnailTo = HttpContext.Current.Server.MapPath(saveThumbnailTo);
                string Params = string.Format("-i {0} -y -f image2 -ss {2} -vframes 1 {1}", videoPath, saveThumbnailTo, time);
                string output = RunProcess(FFmpegPath, Params);

                if (File.Exists(saveThumbnailTo))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 执行CMD.EXE ffmpeg命令
        /// </summary>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        private static string RunProcess(string FFmpegPath, string Parameters)
        {
            //string FFmpegPath = Server.MapPath(ConfigurationManager.AppSettings["FFmpegPath"]);
            //create a process info
            ProcessStartInfo oInfo = new ProcessStartInfo(FFmpegPath, Parameters);
            oInfo.UseShellExecute = false;
            oInfo.CreateNoWindow = true;
            oInfo.RedirectStandardOutput = true;
            oInfo.RedirectStandardError = true;

            //Create the output and streamreader to get the output
            string output = null; StreamReader srOutput = null;

            //try the process
            try
            {
                //run the process
                Process proc = System.Diagnostics.Process.Start(oInfo);
                //加
                //proc.BeginOutputReadLine();
                //now put it in a string
                srOutput = proc.StandardError;//true; 必须放在WaitForExit()前面
                output = srOutput.ReadToEnd();//true; 必须放在WaitForExit()前面
                proc.WaitForExit();
                //这种方法也有问题
                //while (!proc.HasExited)
                //{
                //    Application.DoEvents();
                //    System.Threading.Thread.Sleep(1000);
                //}
                //get the output
                //srOutput = proc.StandardError;
                ////now put it in a string
                //output = srOutput.ReadToEnd();

                proc.Close();
            }
            catch (Exception)
            {
                output = string.Empty;
            }
            finally
            {
                //now, if we succeded, close out the streamreader
                if (srOutput != null)
                {
                    srOutput.Close();
                    srOutput.Dispose();
                }
            }
            return output;
        }
    }
}
