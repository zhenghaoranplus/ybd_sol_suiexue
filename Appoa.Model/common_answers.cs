/*功能：生成实体类
 *编码日期:2017/8/16 15:10:16
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 选项信息实体类
    /// id:自增ID,question_id:题目ID,options:选项,contents:选项内容,score:分值,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_answers
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_answers()
        {
        }
		/// <summary>
        ///选项信息
        /// </summary>
		public const string TABLE_NAME = "ybd_common_answers";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,question_id,options,contents,score,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 题目ID
        /// </summary>
        public Int32 question_id { get; set; }
        
		/// <summary>
        /// 选项
        /// </summary>
        public String options { get; set; }
        
		/// <summary>
        /// 选项内容
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 分值
        /// </summary>
        public Int32 score { get; set; }
        
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
        /// 题目ID
        /// </summary>
		public const string FLD_question_id="question_id";        
		/// <summary>
        /// 题目ID参数字段
        /// </summary>
		public const string FAR_question_id="@question_id";        
		
		/// <summary>
        /// 选项
        /// </summary>
		public const string FLD_options="options";        
		/// <summary>
        /// 选项参数字段
        /// </summary>
		public const string FAR_options="@options";        
		
		/// <summary>
        /// 选项内容
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 选项内容参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 分值
        /// </summary>
		public const string FLD_score="score";        
		/// <summary>
        /// 分值参数字段
        /// </summary>
		public const string FAR_score="@score";        
		
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