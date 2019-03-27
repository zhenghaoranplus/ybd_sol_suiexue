/*功能：生成实体类
 *编码日期:2017/7/5 14:12:11
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 课堂用户关系实体类
    /// id:自增ID,classroom_id:课堂ID,user_id:用户ID,contents:申请内容,status:审核状态,add_time:申请时间,
    /// </summary>
	[Serializable]
    public partial class classroom_user
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public classroom_user()
        {
        }
		/// <summary>
        ///课堂用户关系
        /// </summary>
		public const string TABLE_NAME = "ybd_classroom_user";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,classroom_id,user_id,contents,status,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 课堂ID
        /// </summary>
        public Int32 classroom_id { get; set; }
        
		/// <summary>
        /// 用户ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 申请内容
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 审核状态
        /// </summary>
        public Int32 status { get; set; }
        
		/// <summary>
        /// 申请时间
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
        /// 课堂ID
        /// </summary>
		public const string FLD_classroom_id="classroom_id";        
		/// <summary>
        /// 课堂ID参数字段
        /// </summary>
		public const string FAR_classroom_id="@classroom_id";        
		
		/// <summary>
        /// 用户ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 用户ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 申请内容
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 申请内容参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 审核状态
        /// </summary>
		public const string FLD_status="status";        
		/// <summary>
        /// 审核状态参数字段
        /// </summary>
		public const string FAR_status="@status";        
		
		/// <summary>
        /// 申请时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 申请时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}