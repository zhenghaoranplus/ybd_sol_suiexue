/*功能：生成实体类
 *编码日期:2017/6/21 14:47:45
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 用户认证实体类
    /// id:自增ID,user_id:用户ID,type:第三方平台登录类型,name:第三方平台登录类型名称,appid:第三方appid,unionid:开放平台unionid,
    /// </summary>
	[Serializable]
    public partial class user_oauths
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_oauths()
        {
        }
		/// <summary>
        ///用户认证
        /// </summary>
		public const string TABLE_NAME = "ybd_user_oauths";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,user_id,type,name,appid,unionid";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 用户ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 第三方平台登录类型
        /// </summary>
        public Int32 type { get; set; }
        
		/// <summary>
        /// 第三方平台登录类型名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 第三方appid
        /// </summary>
        public String appid { get; set; }
        
		/// <summary>
        /// 开放平台unionid
        /// </summary>
        public String unionid { get; set; }
        
        
        
        
        #region extended
		/// <summary>
        /// 自增ID
        /// </summary>
		public const string FLD_id="id";        
		/// <summary>
        /// 自增ID参数字段
        /// </summary>
		public const string FAR_id="@id";        
		
		/// <summary>
        /// 用户ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 用户ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 第三方平台登录类型
        /// </summary>
		public const string FLD_type="type";        
		/// <summary>
        /// 第三方平台登录类型参数字段
        /// </summary>
		public const string FAR_type="@type";        
		
		/// <summary>
        /// 第三方平台登录类型名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 第三方平台登录类型名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 第三方appid
        /// </summary>
		public const string FLD_appid="appid";        
		/// <summary>
        /// 第三方appid参数字段
        /// </summary>
		public const string FAR_appid="@appid";        
		
		/// <summary>
        /// 开放平台unionid
        /// </summary>
		public const string FLD_unionid="unionid";        
		/// <summary>
        /// 开放平台unionid参数字段
        /// </summary>
		public const string FAR_unionid="@unionid";        
		
        
        #endregion
    }
}