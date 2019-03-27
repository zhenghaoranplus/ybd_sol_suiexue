/*功能：生成实体类
 *编码日期:2017/6/21 14:47:43
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 全局消息实体类
    /// id:自增ID,group_id:分组ID,cover:封面图,title:标题,subtitle:副标题,contents:内容,sender_id:发送者ID,receiver_id:接收者ID,add_time:添加时间,is_read:是否读取,is_send:是否已推送,send_time:推送时间,
    /// </summary>
	[Serializable]
    public partial class common_message
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_message()
        {
        }
		/// <summary>
        ///全局消息
        /// </summary>
		public const string TABLE_NAME = "ybd_common_message";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,cover,title,subtitle,contents,sender_id,receiver_id,add_time,is_read,is_send,send_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String cover { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
        public String subtitle { get; set; }
        
		/// <summary>
        /// 内容
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 发送者ID
        /// </summary>
        public Int32 sender_id { get; set; }
        
		/// <summary>
        /// 接收者ID
        /// </summary>
        public Int32 receiver_id { get; set; }
        
		/// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
		/// <summary>
        /// 是否读取
        /// </summary>
        public Int32 is_read { get; set; }
        
		/// <summary>
        /// 是否已推送
        /// </summary>
        public Int32 is_send { get; set; }
        
		/// <summary>
        /// 推送时间
        /// </summary>
        public DateTime? send_time { get; set; }
        
        
        
        
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
        /// 分组ID
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 封面图
        /// </summary>
		public const string FLD_cover="cover";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_cover="@cover";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_title="title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_title="@title";        
		
		/// <summary>
        /// 副标题
        /// </summary>
		public const string FLD_subtitle="subtitle";        
		/// <summary>
        /// 副标题参数字段
        /// </summary>
		public const string FAR_subtitle="@subtitle";        
		
		/// <summary>
        /// 内容
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 内容参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 发送者ID
        /// </summary>
		public const string FLD_sender_id="sender_id";        
		/// <summary>
        /// 发送者ID参数字段
        /// </summary>
		public const string FAR_sender_id="@sender_id";        
		
		/// <summary>
        /// 接收者ID
        /// </summary>
		public const string FLD_receiver_id="receiver_id";        
		/// <summary>
        /// 接收者ID参数字段
        /// </summary>
		public const string FAR_receiver_id="@receiver_id";        
		
		/// <summary>
        /// 添加时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 添加时间参数字段
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
        /// 是否已推送
        /// </summary>
		public const string FLD_is_send="is_send";        
		/// <summary>
        /// 是否已推送参数字段
        /// </summary>
		public const string FAR_is_send="@is_send";        
		
		/// <summary>
        /// 推送时间
        /// </summary>
		public const string FLD_send_time="send_time";        
		/// <summary>
        /// 推送时间参数字段
        /// </summary>
		public const string FAR_send_time="@send_time";        
		
        
        #endregion
    }
}