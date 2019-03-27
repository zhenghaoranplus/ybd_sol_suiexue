/*功能：生成实体类
 *编码日期:2017/7/10 15:13:41
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 答题结果实体类
    /// id:自增ID,group_id:分组ID,exa_id:试卷ID,exa_title:试卷标题,user_id:答题者ID,avatar:头像,nick_name:昵称,use_min:用时-分钟,use_sec:用时-秒钟,truth_num:答对题数,count:总题数,truth_ratio:正确率,score:总分,status:批改状态 1已批改 0未批改,add_time:完成时间,
    /// </summary>
	[Serializable]
    public partial class answer_result
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public answer_result()
        {
        }
		/// <summary>
        ///答题结果
        /// </summary>
		public const string TABLE_NAME = "ybd_answer_result";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,exa_id,exa_title,user_id,avatar,nick_name,use_min,use_sec,truth_num,count,truth_ratio,score,status,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 试卷ID
        /// </summary>
        public Int32 exa_id { get; set; }
        
		/// <summary>
        /// 试卷标题
        /// </summary>
        public String exa_title { get; set; }
        
		/// <summary>
        /// 答题者ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 头像
        /// </summary>
        public String avatar { get; set; }
        
		/// <summary>
        /// 昵称
        /// </summary>
        public String nick_name { get; set; }
        
		/// <summary>
        /// 用时-分钟
        /// </summary>
        public Int32 use_min { get; set; }
        
		/// <summary>
        /// 用时-秒钟
        /// </summary>
        public Int32 use_sec { get; set; }
        
		/// <summary>
        /// 答对题数
        /// </summary>
        public Int32 truth_num { get; set; }
        
		/// <summary>
        /// 总题数
        /// </summary>
        public Int32 count { get; set; }
        
		/// <summary>
        /// 正确率
        /// </summary>
        public Decimal truth_ratio { get; set; }
        
		/// <summary>
        /// 总分
        /// </summary>
        public Int32 score { get; set; }
        
		/// <summary>
        /// 批改状态 1已批改 0未批改
        /// </summary>
        public Int32 status { get; set; }
        
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
        /// 试卷ID
        /// </summary>
		public const string FLD_exa_id="exa_id";        
		/// <summary>
        /// 试卷ID参数字段
        /// </summary>
		public const string FAR_exa_id="@exa_id";        
		
		/// <summary>
        /// 试卷标题
        /// </summary>
		public const string FLD_exa_title="exa_title";        
		/// <summary>
        /// 试卷标题参数字段
        /// </summary>
		public const string FAR_exa_title="@exa_title";        
		
		/// <summary>
        /// 答题者ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 答题者ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 头像
        /// </summary>
		public const string FLD_avatar="avatar";        
		/// <summary>
        /// 头像参数字段
        /// </summary>
		public const string FAR_avatar="@avatar";        
		
		/// <summary>
        /// 昵称
        /// </summary>
		public const string FLD_nick_name="nick_name";        
		/// <summary>
        /// 昵称参数字段
        /// </summary>
		public const string FAR_nick_name="@nick_name";        
		
		/// <summary>
        /// 用时-分钟
        /// </summary>
		public const string FLD_use_min="use_min";        
		/// <summary>
        /// 用时-分钟参数字段
        /// </summary>
		public const string FAR_use_min="@use_min";        
		
		/// <summary>
        /// 用时-秒钟
        /// </summary>
		public const string FLD_use_sec="use_sec";        
		/// <summary>
        /// 用时-秒钟参数字段
        /// </summary>
		public const string FAR_use_sec="@use_sec";        
		
		/// <summary>
        /// 答对题数
        /// </summary>
		public const string FLD_truth_num="truth_num";        
		/// <summary>
        /// 答对题数参数字段
        /// </summary>
		public const string FAR_truth_num="@truth_num";        
		
		/// <summary>
        /// 总题数
        /// </summary>
		public const string FLD_count="count";        
		/// <summary>
        /// 总题数参数字段
        /// </summary>
		public const string FAR_count="@count";        
		
		/// <summary>
        /// 正确率
        /// </summary>
		public const string FLD_truth_ratio="truth_ratio";        
		/// <summary>
        /// 正确率参数字段
        /// </summary>
		public const string FAR_truth_ratio="@truth_ratio";        
		
		/// <summary>
        /// 总分
        /// </summary>
		public const string FLD_score="score";        
		/// <summary>
        /// 总分参数字段
        /// </summary>
		public const string FAR_score="@score";        
		
		/// <summary>
        /// 批改状态 1已批改 0未批改
        /// </summary>
		public const string FLD_status="status";        
		/// <summary>
        /// 批改状态 1已批改 0未批改参数字段
        /// </summary>
		public const string FAR_status="@status";        
		
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