
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
namespace Appoa.Common
{
    /// <summary>
    /// Summary description for NetLog
    /// </summary>
    public class NetLog
    {
        /// <summary>
        /// 写入日志到文本文件
        /// </summary>
        /// <param name="action">动作</param>
        /// <param name="strMessage">日志内容</param>
        /// <param name="time">时间</param>
        /// <param name="logType">日志类型</param>
        public static void WriteTextLog(string action, string strMessage, DateTime time, string logType)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";
            if (!string.IsNullOrEmpty(logType))
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\" + logType + @"\";
            }
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileFullPath = path + time.ToString("yyyy-MM-dd") + ".txt";
            StringBuilder str = new StringBuilder();
            str.Append("Time:    " + time.ToString() + "\r\n");
            str.Append("Action:  " + action + "\r\n");
            str.Append("Message: " + strMessage + "\r\n");
            str.Append("-----------------------------------------------------------\r\n\r\n");
            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
    }
}