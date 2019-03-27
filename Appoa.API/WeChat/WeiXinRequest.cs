using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.API.WeChat
{
    #region WeiXinRequest 用户信息Model
    public class WeiXinRequest
    {
        private string toUserName;
        /// <summary>
        /// 消息接收方微信号，一般为公众平台账号微信号
        /// </summary>
        public string ToUserName
        {
            get { return toUserName; }
            set { toUserName = value; }
        }

        private string fromUserName;
        /// <summary>
        /// 消息发送方微信号
        /// </summary>
        public string FromUserName
        {
            get { return fromUserName; }
            set { fromUserName = value; }
        }

        private string createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private string msgType;
        /// <summary>
        /// 信息类型 地理位置:location,文本消息:text,消息类型:image，音频：voice，视频：video,取消关注：Action
        /// </summary>
        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }

        private string content;
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string msgId;
        /// <summary>
        /// 消息ID（文本）
        /// </summary>
        public string MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }

        private string wxevent;
        /// <summary>
        /// 取消关注时的Event节点
        /// </summary>
        public string Wxevent
        {
            get { return wxevent; }
            set { wxevent = value; }
        }

        private string eventKey;
        /// <summary>
        /// 取消关注时的EventKey节点
        /// </summary>
        public string EventKey
        {
            get { return eventKey; }
            set { eventKey = value; }
        }


        private string location_X;
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Location_X
        {
            get { return location_X; }
            set { location_X = value; }
        }

        private string location_Y;
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y
        {
            get { return location_Y; }
            set { location_Y = value; }
        }

        private string scale;
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private string label;
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        private string picUrl;
        /// <summary>
        /// 图片链接，开发者可以用HTTP GET获取
        /// </summary>
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }
    }
    #endregion

    #region WeiXin_Error 菜单信息Model
    public class WeiXin_Error
    {
        public WeiXin_Error()
        { }
        //{"errcode":0,"errmsg":"ok"}
        #region Model
        private int _errcode;
        private string _errmsg = "";
        public int errcode
        {
            set { _errcode = value; }
            get { return _errcode; }
        }

        public string errmsg
        {
            set { _errmsg = value; }
            get { return _errmsg; }
        }
        #endregion Model

    }
    #endregion

    #region WeiXin_Access_token
    /// <summary>
    /// 通过code换取网页授权access_token
    /// 首先请注意，这里通过code换取的是一个特殊的网页授权access_token,与基础支持中的access_token
    /// （该access_token用于调用其他接口）不同。公众号可通过下述接口来获取网页授权access_token。
    /// 如果网页授权的作用域为snsapi_base，则本步骤中获取到网页授权access_token的同时，
    /// 也获取到了openid，snsapi_base式的网页授权流程即到此为止。 
    /// </summary>
    public class WeiXin_Access_token
    {
        //    {
        //   "access_token":"ACCESS_TOKEN",
        //   "expires_in":7200,
        //   "refresh_token":"REFRESH_TOKEN",
        //   "openid":"OPENID",
        //   "scope":"SCOPE"
        //      }
        private string access_token;
        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同 
        /// </summary>
        public string Access_token
        {
            get { return access_token; }
            set { access_token = value; }
        }

        private string expires_in;
        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒） 
        /// </summary>
        public string Expires_in
        {
            get { return expires_in; }
            set { expires_in = value; }
        }

        private string refresh_token;
        /// <summary>
        /// 用户刷新access_token 
        /// </summary>
        public string Refresh_token
        {
            get { return refresh_token; }
            set { refresh_token = value; }
        }

        private string openid;
        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID 
        /// </summary>
        public string Openid
        {
            get { return openid; }
            set { openid = value; }
        }

        private string scope;
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string Scope
        {
            get { return scope; }
            set { scope = value; }
        }
    }
    #endregion

    #region 永久二维码请求,获取Ticket
    /// <summary>
    /// 永久二维码请求,获取Ticket
    /// </summary>
    public class WeiXinQrcode_Ticket
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        private string ticket;
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
        /// <summary>
        /// 该二维码有效时间，以秒为单位。 最大不超过604800（即7天）。 
        /// </summary>
        private string expire_seconds;
        /// <summary>
        /// 该二维码有效时间，以秒为单位。 最大不超过604800（即7天）。 
        /// </summary>
        public string Expire_seconds
        {
            get { return expire_seconds; }
            set { expire_seconds = value; }
        }
        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片 
        /// </summary>
        private string url;
        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片 
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
    #endregion

    #region 统一下单
    public class WeiXin_PrePay
    {
        private string _return_code;
        public string return_code
        {
            set { _return_code = value; }
            get { return _return_code; }
        }
        private string _return_msg;
        public string return_msg
        {
            set { _return_msg = value; }
            get { return _return_msg; }
        }
        private string _appid;
        public string appid
        {
            set { _appid = value; }
            get { return _appid; }
        }
        private string _nonce_str;
        public string nonce_str
        {
            set { _nonce_str = value; }
            get { return _nonce_str; }
        }
        private string _sign;
        public string sign
        {
            set { _sign = value; }
            get { return _sign; }
        }
        private string _prepay_id;
        public string prepay_id
        {
            set { _prepay_id = value; }
            get { return _prepay_id; }
        }
        private string _trade_type;
        public string trade_type
        {
            set { _trade_type = value; }
            get { return _trade_type; }
        }
    }
    #endregion

    #region 微信用户信息
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public partial class SnsapiUserInfo
    {
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        public List<string> privilege { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string unionid { get; set; }

    }
    #endregion

}
