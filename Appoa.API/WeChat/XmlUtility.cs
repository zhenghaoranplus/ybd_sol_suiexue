using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Appoa.API.WeChat
{
    class XmlUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public static XDocument ParseJson(string json, string rootName)
        {
            return JsonConvert.DeserializeXNode(json, rootName);
        }
    }
}
