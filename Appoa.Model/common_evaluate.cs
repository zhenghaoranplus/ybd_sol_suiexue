/*功能：生成实体类
 *编码日期:2017/6/21 14:47:43
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 全局评论实体类
    /// id:自增ID,group_id:分组id,eval_type:评价类型id,parent_id:评价所属主体id,from_user_id:评价者id,to_user_id:被评价者id,start:评价星级,contents:评价内容,data_id:被评价的评价id,reply_id:被回复的回复ID,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_evaluate
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_evaluate()
        {
        }
		/// <summary>
        ///全局评论
        /// </summary>
		public const string TABLE_NAME = "ybd_common_evaluate";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,eval_type,parent_id,from_user_id,to_user_id,start,contents,data_id,reply_id,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组id
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 评价类型id
        /// </summary>
        public Int32 eval_type { get; set; }
        
		/// <summary>
        /// 评价所属主体id
        /// </summary>
        public Int32 parent_id { get; set; }
        
		/// <summary>
        /// 评价者id
        /// </summary>
        public Int32 from_user_id { get; set; }
        
		/// <summary>
        /// 被评价者id
        /// </summary>
        public Int32 to_user_id { get; set; }
        
		/// <summary>
        /// 评价星级
        /// </summary>
        public Int32 start { get; set; }
        
		/// <summary>
        /// 评价内容
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 被评价的评价id
        /// </summary>
        public Int32 data_id { get; set; }
        
		/// <summary>
        /// 被回复的回复ID
        /// </summary>
        public Int32 reply_id { get; set; }
        
		/// <summary>
        /// 添加时间
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
        /// 分组id
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组id参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 评价类型id
        /// </summary>
		public const string FLD_eval_type="eval_type";        
		/// <summary>
        /// 评价类型id参数字段
        /// </summary>
		public const string FAR_eval_type="@eval_type";        
		
		/// <summary>
        /// 评价所属主体id
        /// </summary>
		public const string FLD_parent_id="parent_id";        
		/// <summary>
        /// 评价所属主体id参数字段
        /// </summary>
		public const string FAR_parent_id="@parent_id";        
		
		/// <summary>
        /// 评价者id
        /// </summary>
		public const string FLD_from_user_id="from_user_id";        
		/// <summary>
        /// 评价者id参数字段
        /// </summary>
		public const string FAR_from_user_id="@from_user_id";        
		
		/// <summary>
        /// 被评价者id
        /// </summary>
		public const string FLD_to_user_id="to_user_id";        
		/// <summary>
        /// 被评价者id参数字段
        /// </summary>
		public const string FAR_to_user_id="@to_user_id";        
		
		/// <summary>
        /// 评价星级
        /// </summary>
		public const string FLD_start="start";        
		/// <summary>
        /// 评价星级参数字段
        /// </summary>
		public const string FAR_start="@start";        
		
		/// <summary>
        /// 评价内容
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 评价内容参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 被评价的评价id
        /// </summary>
		public const string FLD_data_id="data_id";        
		/// <summary>
        /// 被评价的评价id参数字段
        /// </summary>
		public const string FAR_data_id="@data_id";        
		
		/// <summary>
        /// 被回复的回复ID
        /// </summary>
		public const string FLD_reply_id="reply_id";        
		/// <summary>
        /// 被回复的回复ID参数字段
        /// </summary>
		public const string FAR_reply_id="@reply_id";        
		
		/// <summary>
        /// 添加时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 添加时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}