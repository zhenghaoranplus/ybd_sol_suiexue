/*功能：生成实体类
 *编码日期:2017/6/26 16:26:29
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 试卷题目关联实体类
    /// id:自增ID,exa_id:试卷ID,q_id:题目ID,
    /// </summary>
	[Serializable]
    public partial class examination_question
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public examination_question()
        {
        }
		/// <summary>
        ///试卷题目关联
        /// </summary>
		public const string TABLE_NAME = "ybd_examination_question";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,exa_id,q_id";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 试卷ID
        /// </summary>
        public Int32 exa_id { get; set; }
        
		/// <summary>
        /// 题目ID
        /// </summary>
        public Int32 q_id { get; set; }
        
        
        
        
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
		
        
        #endregion
    }
}