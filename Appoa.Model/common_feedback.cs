/*功能：生成实体类
 *编码日期:2017/6/21 14:47:43
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 全局反馈记录实体类
    /// id:自增ID,group_id:分组id,user_id:反馈者id,contents:反馈内容,add_time:反馈时间,is_read:是否读取,read_time:读取时间,
    /// </summary>
	[Serializable]
    public partial class common_feedback
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_feedback()
        {
        }
		/// <summary>
        ///全局反馈记录
        /// </summary>
		public const string TABLE_NAME = "ybd_common_feedback";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,user_id,contents,add_time,is_read,read_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组id
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 反馈者id
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 反馈内容
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 反馈时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
		/// <summary>
        /// 是否读取
        /// </summary>
        public Int32 is_read { get; set; }
        
		/// <summary>
        /// 读取时间
        /// </summary>
        public DateTime? read_time { get; set; }
        
        
        
        
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
        /// 分组id
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组id参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 反馈者id
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 反馈者id参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 反馈内容
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 反馈内容参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 反馈时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 反馈时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
		/// <summary>
        /// 是否读取
        /// </summary>
		public const string FLD_is_read="is_read";        
		/// <summary>
        /// 是否读取参数字段
        /// </summary>
		public const string FAR_is_read="@is_read";        
		
		/// <summary>
        /// 读取时间
        /// </summary>
		public const string FLD_read_time="read_time";        
		/// <summary>
        /// 读取时间参数字段
        /// </summary>
		public const string FAR_read_time="@read_time";        
		
        
        #endregion
    }
}