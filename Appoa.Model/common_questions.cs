/*功能：生成实体类
 *编码日期:2017/8/16 10:53:58
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 题目信息实体类
    /// id:自增ID,group_id:分组ID,type:题型,data_id:关联数据ID,number:序号,title:标题,answer:参考答案,score:分值,analysis:解析,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_questions
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_questions()
        {
        }
		/// <summary>
        ///题目信息
        /// </summary>
		public const string TABLE_NAME = "ybd_common_questions";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,type,data_id,number,title,answer,score,analysis,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 题型
        /// </summary>
        public Int32 type { get; set; }
        
		/// <summary>
        /// 关联数据ID
        /// </summary>
        public Int32 data_id { get; set; }
        
		/// <summary>
        /// 序号
        /// </summary>
        public Int32 number { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 参考答案
        /// </summary>
        public String answer { get; set; }
        
		/// <summary>
        /// 分值
        /// </summary>
        public Decimal score { get; set; }
        
		/// <summary>
        /// 解析
        /// </summary>
        public String analysis { get; set; }
        
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
        /// 分组ID
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 题型
        /// </summary>
		public const string FLD_type="type";        
		/// <summary>
        /// 题型参数字段
        /// </summary>
		public const string FAR_type="@type";        
		
		/// <summary>
        /// 关联数据ID
        /// </summary>
		public const string FLD_data_id="data_id";        
		/// <summary>
        /// 关联数据ID参数字段
        /// </summary>
		public const string FAR_data_id="@data_id";        
		
		/// <summary>
        /// 序号
        /// </summary>
		public const string FLD_number="number";        
		/// <summary>
        /// 序号参数字段
        /// </summary>
		public const string FAR_number="@number";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_title="title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_title="@title";        
		
		/// <summary>
        /// 参考答案
        /// </summary>
		public const string FLD_answer="answer";        
		/// <summary>
        /// 参考答案参数字段
        /// </summary>
		public const string FAR_answer="@answer";        
		
		/// <summary>
        /// 分值
        /// </summary>
		public const string FLD_score="score";        
		/// <summary>
        /// 分值参数字段
        /// </summary>
		public const string FAR_score="@score";        
		
		/// <summary>
        /// 解析
        /// </summary>
		public const string FLD_analysis="analysis";        
		/// <summary>
        /// 解析参数字段
        /// </summary>
		public const string FAR_analysis="@analysis";        
		
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