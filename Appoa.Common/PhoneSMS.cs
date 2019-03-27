using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Web;

namespace Appoa.Common
{
    public static class PhoneSMS
    {
        #region base
        /************************************************************************/
        /* UrlEncode
        /* 对指定字符串进行URL标准化转码
        /************************************************************************/
        public static string UrlEncode(string text, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byData = encoding.GetBytes(text);
            for (int i = 0; i < byData.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byData[i], 16));
            }
            return sb.ToString();
        }
        /************************************************************************/
        /* sendQuery
        /* 向指定的接口地址POST数据并返回响应数据
        /************************************************************************/
        public static string sendQuery(string url, string param)
        {
            // 准备要POST的数据
            byte[] byData = Encoding.UTF8.GetBytes(param);

            // 设置发送的参数
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = "POST";
            req.Timeout = 5000;
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byData.Length;

            // 提交数据
            Stream rs = req.GetRequestStream();
            rs.Write(byData, 0, byData.Length);
            rs.Close();

            // 取响应结果
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);

            try
            {
                return sr.ReadToEnd();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sr.Close();
            return null;
        }
        /************************************************************************/
        /* 分析返回的结果值
        /************************************************************************/
        public static string parseResult(string sResult)
        {
            if (sResult != null)
            {
                try
                {
                    // 对返回值分析
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(sResult);
                    //读取节点
                    XmlNode snXmlNode = xml.SelectSingleNode("/returnsms/returnstatus");
                    return snXmlNode.InnerText;
                }
                catch (System.Exception e)
                {
                    return "Faild";
                }
            }
            return "Faild";
        }
        public static bool SendMsg(string tel, string msg)
        {
            string ACCOUNT = "fe979c";
            string AUTHKEY = "LEIming@6";
            string POST_URL = "http://send.18sms.com/msg/HttpBatchSendSM";
            StringBuilder sb = new StringBuilder();
            sb.Append("account=");
            sb.Append(ACCOUNT);
            sb.Append("&pswd=");
            sb.Append(AUTHKEY);
            sb.Append("&mobile=");
            sb.Append(tel);
            sb.Append("&msg=");
            sb.Append(UrlEncode(msg, Encoding.UTF8));
            sb.Append("&needstatus=true&extno=3276");
            string sResult = sendQuery(POST_URL, sb.ToString());
            string[] results = sResult.Split(',');
            WriteLog("PhoneSMS", "sResult", sResult);
            if (results[1].Substring(0, 1) == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 集成梦网平台短信
        public static bool SendMsg_montnets(string tel, string msg)
        {
            string ACCOUNT = "ja0667";
            string AUTHKEY = "456123";
            string POST_URL = "http://211.100.34.185:8016/MWGate/wmgw.asmx/MongateSendSubmit";
            StringBuilder sb = new StringBuilder();
            sb.Append("userid=");
            sb.Append(ACCOUNT);
            sb.Append("&password=");
            sb.Append(AUTHKEY);
            sb.Append("&pszMobis=");
            sb.Append(tel);
            sb.Append("&pszMsg=");
            sb.Append(UrlEncode(msg, Encoding.UTF8));
            sb.Append("&iMobiCount=1&pszSubPort=*&MsgId=");
            string sResult = sendQuery(POST_URL, sb.ToString());
            WriteLog("PhoneSMS", "sResult", sResult);
            string status = parseResult_montnets(sResult);
            WriteLog("PhoneSMS", "status", status);
            //Model.tb_sms_log log = new Model.tb_sms_log();
            //log.add_time = DateTime.Now;
            //log.contents = msg;
            //log.state = status;
            //log.tel = tel;
            //new DAL.tb_sms_log().Add(log);
            return status.ToLower() == "success";
        }

        /************************************************************************/
        /* 分析返回的结果值
        /************************************************************************/
        public static string parseResult_montnets(string sResult)
        {
            if (sResult != null)
            {
                try
                {
                    // 对返回值分析
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(sResult);
                    //读取节点
                    return xml.DocumentElement.InnerText;
                }
                catch (System.Exception e)
                {
                    return "Faild";
                }
            }
            return "Faild";
        }
        #endregion

        #region 短信宝
        public static bool SendMsg_COCSMS(string tel, string msg)
        {
            string ACCOUNT = "qhdwgsc";
            string AUTHKEY = Utils.MD5("mitoo1979");
            string POST_URL = "https://api.smsbao.com/sms";
            StringBuilder sb = new StringBuilder();
            sb.Append("u=");
            sb.Append(ACCOUNT);
            sb.Append("&p=");
            sb.Append(AUTHKEY);
            sb.Append("&m=");
            sb.Append(tel);
            sb.Append("&c=");
            sb.Append(HttpUtility.UrlEncode(msg, Encoding.UTF8));

            string sResult = Utils.HttpGet(POST_URL + "?" + sb.ToString());

            WriteLog("PhoneSMS", "sResult", sResult);
            if (sResult == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 日志

        /**
        * 实际的写日志操作
        * @param type 日志记录类型
        * @param className 类名
        * @param content 写入内容
        */
        private static void WriteLog(string type, string className, string content)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "/logs/PhoneSMS";
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
