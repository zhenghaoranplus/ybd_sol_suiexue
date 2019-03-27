/*功能：生成实体类
 *编码日期:2017/6/21 14:47:45
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 签到记录实体类
    /// id:自增ID,user_id:用户ID,add_time:签到时间,
    /// </summary>
	[Serializable]
    public partial class user_signin
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_signin()
        {
        }
		/// <summary>
        ///签到记录
        /// </summary>
		public const string TABLE_NAME = "ybd_user_signin";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,user_id,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 用户ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 签到时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
        
        
        
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
        /// 签到时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 签到时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}