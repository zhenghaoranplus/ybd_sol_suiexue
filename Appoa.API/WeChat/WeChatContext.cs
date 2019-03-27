using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Appoa.Common;
using System.Security.Cryptography;
using System.Xml;
using System.Configuration;

namespace Appoa.API.WeChat
{
    public class WeChatContext
    {
        public static string appId = ConfigurationManager.AppSettings["WechatAppID"];
        private static string appSecret = ConfigurationManager.AppSettings["WechatAppSecret"];
        public static string IP = ConfigurationManager.AppSettings["spbill_create_ip"];// 
        public static string partnerKey = ConfigurationManager.AppSettings["PartnerKey"];//商家私钥:微信商户平台(pay.weixin.qq.com)-->账户设置-->API安全-->密钥设置
        public static string callback_url = ConfigurationManager.AppSettings["callback_url"];//<!--微信支付回调路径-->
        private static string wechatDomain = ConfigurationManager.AppSettings["WechatDomain"]; //网站域名
        public static string WechatDomain { get { return wechatDomain; } }//公众号域名
        public static string Mch_ID = ConfigurationManager.AppSettings["Mch_ID"];//微信支付分配的商户号
        private static DateTime AccessToken_Time;
        private static DateTime Jsapi_ticket_Time;
        private static int Expires_Period = 7200;// 过期时间为7200秒
        private static int Expires_Period_jsapi_ticket = 7200;

        #region 公众号开发

        #region 获取access_token

        #region 公众号开发基础AccessToken
        /// <summary>
        /// 以静态变量形式获取access_token
        /// </summary>
        private static string access_token;
        /// <summary>
        /// 公众号开发基础AccessToken
        /// </summary>
        public static string AccessToken
        {
            get
            {
                //如果为空，或者过期，需要重新获取
                if (string.IsNullOrEmpty(access_token) || AccessTokenHasExpired())
                {
                    access_token = GetAccessToken(appId, appSecret);//获取
                }

                return access_token;
            }
        }
        //判断Access_token是否过期
        private static bool AccessTokenHasExpired()
        {
            if (AccessToken_Time != null)
            {
                //过期时间，允许有一定的误差，一分钟。获取时间消耗
                if (DateTime.Now > AccessToken_Time.AddSeconds(Expires_Period).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }
        //请求api获取AccessToken
        private static string GetAccessToken(string appId, string appSecret)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret);
            string result = HttpUtility.GetData(url);

            XDocument doc = XmlUtility.ParseJson(result, "root");
            XElement root = doc.Root;
            if (root != null)
            {
                XElement access_token = root.Element("access_token");
                if (access_token != null)
                {
                    AccessToken_Time = DateTime.Now;
                    if (root.Element("expires_in") != null)
                    {
                        Expires_Period = int.Parse(root.Element("expires_in").Value);
                    }
                    return access_token.Value;
                }
                else
                {
                    AccessToken_Time = DateTime.MinValue;
                }
            }
            return null;
        }
        #endregion

        #endregion

        #region 生成二维码（通过ticket换取二维码）
        /// <summary>
        /// 生成二维码（通过ticket换取二维码）
        /// </summary>
        /// <param name="json">POST数据例子：{"action_name": "QR_LIMIT_SCENE", "action_info": {"scene": {"scene_id": 123}}}
        /// action_info:二维码详细信息;
        /// action_name:二维码类型，QR_SCENE为临时,QR_LIMIT_SCENE为永久,QR_LIMIT_STR_SCENE为永久的字符串参数值
        /// scene_id:场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000） </param>
        /// <returns>正确：{"ticket":"gQH47joAAAAAAAAAASxodHRwOi8vd2VpeGluLnFxLmNvbS9xL2taZ2Z3TVRtNzJXV1Brb3ZhYmJJAAIEZ23sUwMEmm3sUw==","expire_seconds":60,"url":"http:\/\/weixin.qq.com\/q\/kZgfwMTm72WWPkovabbI"}
        ///          错误：{"errcode":40013,"errmsg":"invalid appid"}</returns>
        private static string getQRCODE_ticket(string json)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", WeChatContext.AccessToken);
            //string menu = FileUtility.Read(Menu_Data_Path);
            return HttpUtility.SendHttpRequest(url, json);
        }
        #endregion

        #region 获取用户二维码的路径图片
        /// <summary>
        /// 获取用户二维码的路径图片
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string getQRCODE_url(string json)
        {
            string str = getQRCODE_ticket(json);
            if (str.IndexOf("ticket") > 0)
            {
                WeiXinQrcode_Ticket model = (WeiXinQrcode_Ticket)JsonConvert.DeserializeObject(str, typeof(WeiXinQrcode_Ticket));
                string ticket = model.Ticket;
                return "https://mp.weixin.qq.com/cgi-bin/showqrcode?&ticket=" + Appoa.Common.Utils.UrlEncode((model.Ticket));
            }
            else
            {
                WeiXin_Error model = (WeiXin_Error)JsonConvert.DeserializeObject(str, typeof(WeiXin_Error));
                return model.errcode + ":" + model.errmsg;
            }
        }
        #endregion
        
        #endregion

        #region Signature签名算法
        /// <summary>
        /// Signature签名算法
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature(string jsapi_ticket, string noncestr, long timestamp, string url, out string string1)
        {
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string1 = string1Builder.ToString();
            return SHA1Util.Sha1(string1);
        }
        #endregion

        #region 获取jsapi_ticket

        #region 以静态变量的形式获取jsapi_ticket
        private static string mJsapi_ticket;
        public static string JsApi_ticket
        {
            get
            {
                //如果为空，或者过期，需要重新获取
                if (string.IsNullOrEmpty(mJsapi_ticket) || Jsapi_ticket_HasExpired())
                {
                    //获取
                    mJsapi_ticket = GetJsapiTicket();
                }

                return mJsapi_ticket;
            }
        }
        //判断ticket是否过期
        private static bool Jsapi_ticket_HasExpired()
        {
            if (Jsapi_ticket_Time != null)
            {
                //过期时间，允许有一定的误差，一分钟。获取时间消耗
                if (DateTime.Now > Jsapi_ticket_Time.AddSeconds(Expires_Period_jsapi_ticket).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }
        //直接请求不加缓存
        public static string GetJsapi_ticket()
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + AccessToken + "&type=jsapi");
            string result = HttpUtility.GetData(url);

            XDocument doc = XmlUtility.ParseJson(result, "root");
            XElement root = doc.Root;
            if (root != null)
            {
                XElement ticket = root.Element("ticket");
                if (ticket != null)
                {
                    Jsapi_ticket_Time = DateTime.Now;
                    if (root.Element("expires_in") != null)
                    {
                        Expires_Period_jsapi_ticket = int.Parse(root.Element("expires_in").Value);
                    }
                    return ticket.Value;
                }
                else
                {
                    Jsapi_ticket_Time = DateTime.MinValue;
                }
            }
            return null;
        }
        #endregion

        #region 以System.Web.Caching.Cache缓存的形式获取jsapi_ticket
        public static string GetJsapiTicket()
        {
            if (Common.DataCache.GetCache("jsapi_ticket") == null)
            {
                string res = HttpUtility.GetData("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + AccessToken + "&type=jsapi");
                var reslist = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(res);
                if (reslist.ContainsKey("errmsg") && reslist["errmsg"].ToString() == "ok")
                {
                    Common.DataCache.SetCache("jsapi_ticket", reslist["ticket"], DateTime.Now.AddMinutes(60), TimeSpan.Zero);
                    return reslist["ticket"].ToString();
                }
                return "";
            }
            return Common.DataCache.GetCache("jsapi_ticket").ToString();
        }
        #endregion

        #endregion

        #region 微信网页授权登录开发

        #region 获取授权或者非授权code
        /// <summary>
        /// 获取授权或者非授权code
        /// </summary>
        /// <param name="redirectPath">回调地址</param>
        /// <param name="sourceUrl">验证登录的源页面（encode后的字符串）</param>
        /// <param name="needGrant">是否需要用户授权</param>
        public static string GetRedirectCode(string redirectPath, string sourceUrl, bool needGrant)
        {
            string redirectUrl = Utils.UrlEncode(wechatDomain + redirectPath);
            string scope = needGrant ? "snsapi_userinfo" : "snsapi_base";

            string url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect", appId, redirectUrl, scope, sourceUrl);

            return url;
        }
        #endregion

        #region 通过code换取网页授权access_token
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="code">code说明 ：code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <returns>WeiXin_Access_token 对象：{"access_token":"ACCESS_TOKEN","expires_in":7200,"refresh_token":"REFRESH_TOKEN", "openid":"OPENID","scope":"SCOPE"}</returns>
        public static WeiXin_Access_token GetAccessModel(string code)
        {
            #region 参数说明
            //参数 	        是否必须 	说明
            //appid 	    是 	        公众号的唯一标识
            //secret 	    是 	        公众号的appsecret
            //code 	        是 	        填写第一步获取的code参数
            //grant_type 	是 	        填写为authorization_code  
            #endregion
            string getUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            getUrl = string.Format(getUrl, appId, appSecret, code);
            try
            {
                #region 返回格式
                //{"access_token":"vQwnN2W44YHG5zCzw-TflCjZu0oO4GxG6Rx50Uhhpy8YvDhu6KLJ-ytGAWdGTR4YuM58slwOBibfjxNF3tdQZ77nd6aEtgCtlOTZIncmQP8",
                //"expires_in":7200,
                //"refresh_token":"w4U5IXhmoeGo5IdyucFm-e2syGN90apRFOqe1gQ0l9qgK04X4SRCo6ptLNy466TKRFcr0xS12CNODXw9M5G3mf8dLIH04Jwe-Lg1q67q52k",
                //"openid":"o4AvEs7LEOD4AndCeCoRRNPsaKLw",
                //"scope":"snsapi_base"} 
                #endregion
                string returnJason = HttpUtility.GetData(getUrl);
                Utils.StringToTxt("GetAccessModel————returnJason=" + returnJason);
                WeiXin_Access_token model = (WeiXin_Access_token)JsonConvert.DeserializeObject(returnJason, typeof(WeiXin_Access_token));
                if (string.IsNullOrEmpty(model.Openid)) return null;

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过OpenId获取用户信息(snsapi_base)
        /// <summary>
        /// 通过OpenId获取用户信息(snsapi_base)
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static SnsapiUserInfo GetSnsapiBase(string openid)
        {
            //string access_token = GetAccessToken(AppID, AppSecret);
            if (string.IsNullOrEmpty(access_token)) return null;
            string getUrl = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}";
            getUrl = string.Format(getUrl, access_token, openid);
            try
            {
                string returnJason = HttpUtility.GetData(getUrl);
                Utils.StringToTxt("GetSnsapiBase————cgi-bin/user/info：" + returnJason);
                SnsapiUserInfo model = (SnsapiUserInfo)JsonConvert.DeserializeObject(returnJason, typeof(SnsapiUserInfo));
                if (string.IsNullOrEmpty(model.openid)) return null;
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过OpenId获取用户信息(snsapi_userinfo )
        /// <summary>
        /// 通过OpenId获取用户信息(snsapi_userinfo )
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static SnsapiUserInfo GetSnsapiUserInfo(string access_token, string openid)
        {
            string getUrl = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";
            getUrl = string.Format(getUrl, access_token, openid);
            try
            {
                string returnJason = HttpUtility.GetData(getUrl);
                Utils.StringToTxt("GetSnsapiUserInfo————sns/userinfo：" + returnJason);
                SnsapiUserInfo model = (SnsapiUserInfo)JsonConvert.DeserializeObject(returnJason, typeof(SnsapiUserInfo));
                if (string.IsNullOrEmpty(model.openid)) return null;
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region 发起微信支付
        ///// <summary>
        ///// 统一下单--应用场景:商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易回话标识后再在APP里面调起支付。
        ///// </summary>
        ///// <param name="orders"></param>
        ///// <param name="openid"></param>
        ///// <returns></returns>
        //public static WeiXin_PrePay getPrepay(Model.tb_orders orders, string openid)
        //{
        //    WeiXin_PrePay model = new WeiXin_PrePay();
        //    try
        //    {
        //        Dictionary<string, string> dic = new Dictionary<string, string>();
        //        dic.Add("appid", Context.AppID);//微信开放平台审核通过的应用APPID
        //        dic.Add("mch_id", Context.Mch_ID);//微信支付分配的商户号
        //        dic.Add("nonce_str", Guid.NewGuid().ToString("N"));//随机字符串，不长于32位。推荐随机数生成算法
        //        //商品描述交易字段格式根据不同的应用场景按照以下格式：
        //        //APP——需传入应用市场上的APP名字-实际商品名称，天天爱消除-游戏充值。
        //        dic.Add("body", "太原机动车检测");
        //        dic.Add("out_trade_no", orders.order_no);
        //        dic.Add("total_fee", Utils.ObjToInt(orders.real_amount * 100, 0) + ""); //订单总金额，单位为分，详见支付金额
        //        dic.Add("spbill_create_ip", Context.IP); //用户端实际ip
        //        dic.Add("notify_url", Context.callback_url); //接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
        //        dic.Add("trade_type", "JSAPI"); //交易类型
        //        dic.Add("openid", openid);//trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识
        //        string getUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        //        var request = WebRequest.Create(getUrl);
        //        request.Method = "post";
        //        request.ContentType = "text/xml";
        //        request.Headers.Add("charset:utf-8");
        //        var encoding = Encoding.GetEncoding("utf-8");
        //        var sign = Sign(dic, partnerKey);//生成签名字符串
        //        string data = general_postdata(dic, sign);
        //        if (data != null)
        //        {
        //            byte[] buffer = encoding.GetBytes(data);
        //            request.ContentLength = buffer.Length;
        //            request.GetRequestStream().Write(buffer, 0, buffer.Length);
        //        }
        //        else
        //        {
        //            request.ContentLength = 0;
        //        }
        //        using (HttpWebResponse wr = request.GetResponse() as HttpWebResponse)
        //        {
        //            using (StreamReader reader = new StreamReader(wr.GetResponseStream(), encoding))
        //            {
        //                //--------成功--------------------
        //                //<xml>
        //                //<return_code><![CDATA[SUCCESS]]></return_code>
        //                //<return_msg><![CDATA[OK]]></return_msg>
        //                //<appid><![CDATA[wx9ba059239aa3c731]]></appid>
        //                //<mch_id><![CDATA[1364622902]]></mch_id>
        //                //<nonce_str><![CDATA[Pv4Q6UZd1sdytJOq]]></nonce_str>
        //                //<sign><![CDATA[249333613B238562EC817E1FBC11D978]]></sign>
        //                //<result_code><![CDATA[SUCCESS]]></result_code>
        //                //<prepay_id><![CDATA[wx2016072313432800b0eec2290220292696]]></prepay_id>
        //                //<trade_type><![CDATA[JSAPI]]></trade_type>
        //                //</xml>
        //                //--------失败--------------------
        //                //<xml><return_code><![CDATA[FAIL]]></return_code>
        //                //<return_msg><![CDATA[trade_type参数长度有误]]></return_msg>
        //                //</xml>

        //                //<xml>
        //                //<return_code><![CDATA[SUCCESS]]></return_code>
        //                //<return_msg><![CDATA[OK]]></return_msg>
        //                //<appid><![CDATA[wxe8bd9f1698e80905]]></appid>
        //                //<mch_id><![CDATA[1375547202]]></mch_id>
        //                //<nonce_str><![CDATA[V5x1m2fmM9Thm2Nh]]></nonce_str>
        //                //<sign><![CDATA[E6434C0BDC73CD9DCA526CF719FE6BD7]]></sign>
        //                //<result_code><![CDATA[FAIL]]></result_code>
        //                //<err_code><![CDATA[OUT_TRADE_NO_USED]]></err_code>
        //                //<err_code_des><![CDATA[商户订单号重复]]></err_code_des>
        //                //</xml>

        //                string retxml = reader.ReadToEnd();
        //                Utils.StringToTxt("getPrepay：" + retxml);
        //                retxml = retxml.Replace("<![CDATA[", "").Replace("]]>", "");
        //                XmlDocument doc = new XmlDocument();
        //                doc.LoadXml(retxml);
        //                XmlElement rootElement = doc.DocumentElement;
        //                model.return_code = rootElement.SelectSingleNode("return_code").InnerText;
        //                model.return_msg = rootElement.SelectSingleNode("return_msg").InnerText;
        //                if (model.return_code == "SUCCESS")
        //                {
        //                    if (retxml.IndexOf("prepay_id") > 0)
        //                    {
        //                        model.appid = rootElement.SelectSingleNode("appid").InnerText;
        //                        model.nonce_str = rootElement.SelectSingleNode("nonce_str").InnerText; ;
        //                        model.prepay_id = rootElement.SelectSingleNode("prepay_id").InnerText; ;
        //                        model.sign = rootElement.SelectSingleNode("sign").InnerText;
        //                        model.trade_type = rootElement.SelectSingleNode("trade_type").InnerText;
        //                        model.return_code = "SUCCESS";
        //                        model.return_msg = "";
        //                    }
        //                    else
        //                    {
        //                        model.appid = rootElement.SelectSingleNode("appid").InnerText;
        //                        model.nonce_str = rootElement.SelectSingleNode("nonce_str").InnerText;
        //                        model.prepay_id = "";
        //                        model.sign = rootElement.SelectSingleNode("sign").InnerText;
        //                        model.return_code = "FAIL";
        //                        model.return_msg = rootElement.SelectSingleNode("err_code_des").InnerText;
        //                    }
        //                }
        //                return model;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.StringToTxt("错误信息：" + ex.Message);
        //        model.return_code = "FAIL";
        //        model.return_msg = ex.Message;
        //        return model;
        //    }


        //} 
        #endregion

        #region 公用方法
        /// <summary>
        /// 生成POST的xml数据字符串
        /// </summary>
        /// <param name="postdataDict">>参与生成的参数列表</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        private static string general_postdata(IDictionary<string, string> postdataDict, string sign)
        {
            var sb2 = new StringBuilder();
            sb2.Append("<xml>");
            foreach (var sA in postdataDict.OrderBy(x => x.Key))//参数名ASCII码从小到大排序（字典序）；
            {
                sb2.Append("<" + sA.Key + ">")
                   .Append(Common.Utils.Transfer(sA.Value))//参数值用XML转义即可，CDATA标签用于说明数据不被XML解析器解析。 
                   .Append("</" + sA.Key + ">");
            }
            sb2.Append("<sign>").Append(sign).Append("</sign>");
            sb2.Append("</xml>");
            return sb2.ToString();
        }

        /// <summary>
        /// 客服接口-发消息(文本)
        /// </summary>
        /// <returns></returns>
        public static string sendMsg(string openid, string content)
        {
            string json = "{\"touser\":\"" + openid + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + content + "\"}}";
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, json);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="stringADict">参与签名生成的参数列表</param>
        /// <param name="partnerKey">商家私钥</param>
        /// <returns></returns>
        public static string Sign(IDictionary<string, string> stringADict, string partnerKey)
        {
            var sb = new StringBuilder();
            foreach (var sA in stringADict.OrderBy(x => x.Key))//参数名ASCII码从小到大排序（字典序）；
            {
                if (string.IsNullOrEmpty(sA.Value)) continue;//参数的值为空不参与签名；
                sb.Append(sA.Key).Append("=").Append(sA.Value).Append("&");
            }
            var string1 = sb.ToString();
            string1 = string1.Remove(string1.Length - 1, 1);
            sb.Append("key=").Append(partnerKey);//在stringA最后拼接上key=(API密钥的值)得到stringSignTemp字符串
            var stringSignTemp = sb.ToString();
            var sign = MD5(stringSignTemp, "UTF-8").ToUpper();//对stringSignTemp进行MD5运算，再将得到的字符串所有字符转换为大写，得到sign值signValue。 
            return sign;
        }

        public static string MD5(string encypStr, string charset = "UTF-8")
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();
            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
        #endregion
    }
}
