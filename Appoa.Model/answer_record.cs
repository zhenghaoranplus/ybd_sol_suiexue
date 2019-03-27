/*功能：生成实体类
 *编码日期:2017/7/24 18:46:11
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 答题记录实体类
    /// id:自增ID,group_id:分组ID,user_id:答题者ID,exa_id:试卷ID,q_id:题目ID,answer:答案,is_truth:结果,score:,add_time:完成时间,
    /// </summary>
	[Serializable]
    public partial class answer_record
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public answer_record()
        {
        }
		/// <summary>
        ///答题记录
        /// </summary>
		public const string TABLE_NAME = "ybd_answer_record";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,user_id,exa_id,q_id,answer,is_truth,score,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 答题者ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 试卷ID
        /// </summary>
        public Int32 exa_id { get; set; }
        
		/// <summary>
        /// 题目ID
        /// </summary>
        public Int32 q_id { get; set; }
        
		/// <summary>
        /// 答案
        /// </summary>
        public String answer { get; set; }
        
		/// <summary>
        /// 结果
        /// </summary>
        public Int32 is_truth { get; set; }
        
		/// <summary>
        /// 
        /// </summary>
        public Int32 score { get; set; }
        
		/// <summary>
        /// 完成时间
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
        /// 分组ID
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 答题者ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 答题者ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 试卷ID
        /// </summary>
		public const string FLD_exa_id="exa_id";        
		/// <summary>
        /// 试卷ID参数字段
        /// </summary>
		public const string FAR_exa_id="@exa_id";        
		
		/// <summary>
        /// 题目ID
        /// </summary>
		public const string FLD_q_id="q_id";        
		/// <summary>
        /// 题目ID参数字段
        /// </summary>
		public const string FAR_q_id="@q_id";        
		
		/// <summary>
        /// 答案
        /// </summary>
		public const string FLD_answer="answer";        
		/// <summary>
        /// 答案参数字段
        /// </summary>
		public const string FAR_answer="@answer";        
		
		/// <summary>
        /// 结果
        /// </summary>
		public const string FLD_is_truth="is_truth";        
		/// <summary>
        /// 结果参数字段
        /// </summary>
		public const string FAR_is_truth="@is_truth";        
		
		/// <summary>
        /// 
        /// </summary>
		public const string FLD_score="score";        
		/// <summary>
        /// 参数字段
        /// </summary>
		public const string FAR_score="@score";        
		
		/// <summary>
        /// 完成时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 完成时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}