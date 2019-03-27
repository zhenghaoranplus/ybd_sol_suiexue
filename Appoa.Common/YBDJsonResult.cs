using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Data;

namespace Appoa.Common
{
    public class YBDConvertToJson
    {
        public static string ObjectToJson(object o)
        {
            string rlt = string.Empty;
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            string result = JsonConvert.SerializeObject(o, Formatting.Indented, timeConverter);
            rlt = result.Replace("null", "\"\"");
            //rlt = result.Replace("/upload/", System.Configuration.ConfigurationManager.AppSettings["WebPath"] + "/upload/");
            return rlt;
        }
        public static string success(string message, object o)
        {
            string rlt = string.Empty;
            YBDJsonResult YBDjr = new YBDJsonResult();
            YBDjr.code = 200;
            YBDjr.message = message;
            if (o != null)
            {
                YBDjr.data = o;
            }
            return YBDConvertToJson.ObjectToJson(YBDjr);
        }
        public static string error(string message)
        {
            string rlt = string.Empty;
            YBDJsonResult YBDjr = new YBDJsonResult();
            YBDjr.code = 400;
            YBDjr.message = message;
            return YBDConvertToJson.ObjectToJson(YBDjr);
        }
        public static string error(int code, string message)
        {
            string rlt = string.Empty;
            YBDJsonResult YBDjr = new YBDJsonResult();
            YBDjr.code = code;
            YBDjr.message = message;
            return YBDConvertToJson.ObjectToJson(YBDjr);
        }
    }

    public class YBDJsonResult
    {
        public YBDJsonResult()
        {
            this.code = 400;
            if (this.data == null)
            {
                this.data = new List<string>();
            }
        }
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 数据(必须为集合数据(数组))
        /// </summary>
        public object data { get; set; }

    }

}
