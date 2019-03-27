using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
using System.Web;

namespace Appoa.Common
{
    public class JPush
    {
        //极光
        private static readonly string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static readonly string APIMasterSecret = ConfigurationManager.AppSettings["APIMasterSecret"];

        #region diy
        #endregion

        #region base

        /// <summary>
        /// 激光推送
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string PushMsg(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            string resCode = GetPostRequest(data, "", "");
            return resCode;
        }
        public static string PushMsg(string msg, string key, string secret)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            string resCode = GetPostRequest(data, key, secret);
            return resCode;
        }
        /// <summary>
        /// Post方式请求获取返回值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string GetPostRequest(byte[] data, string par_key, string par_secret)
        {
            string result = string.Empty;
            string ApiKey = par_key == "" ? ConfigurationManager.AppSettings["ApiKey"].ToString() : par_key;
            string APIMasterSecret = par_secret == "" ? ConfigurationManager.AppSettings["APIMasterSecret"].ToString() : par_secret;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://api.jpush.cn/v3/push");
                byte[] bytes = Encoding.UTF8.GetBytes(ApiKey + ":" + APIMasterSecret);
                string code = Convert.ToBase64String(bytes);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/json";
                myRequest.ContentLength = data.Length;
                myRequest.Headers.Add(HttpRequestHeader.Authorization, "Basic " + code);
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                var response = (HttpWebResponse)myRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                }
            }
            catch (Exception e)
            {
                WriteLog("JPush", "error", e.ToString());
                return "error";
            }
            WriteLog("JPush", "success", result);
            return result;
        }
        #endregion

        #region log
        /**
        * 实际的写日志操作
        * @param type 日志记录类型
        * @param className 类名
        * @param content 写入内容
        */
        public static void WriteLog(string type, string className, string content)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "/logs/JPush";
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

    }
}
