/*功能：生成实体类
 *编码日期:2017/8/15 10:38:58
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 试卷信息实体类
    /// id:自增ID,group_id:分组ID,name:试卷名称,parent_id:主体ID,nums:试题数量,score:总分,info:描述,descript:结果解析,qrcode:二维码,add_time:创建时间,
    /// </summary>
	[Serializable]
    public partial class common_examination
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_examination()
        {
        }
		/// <summary>
        ///试卷信息
        /// </summary>
		public const string TABLE_NAME = "ybd_common_examination";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,name,parent_id,nums,score,info,descript,qrcode,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 试卷名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 主体ID
        /// </summary>
        public Int32 parent_id { get; set; }
        
		/// <summary>
        /// 试题数量
        /// </summary>
        public Int32 nums { get; set; }
        
		/// <summary>
        /// 总分
        /// </summary>
        public Int32 score { get; set; }
        
		/// <summary>
        /// 描述
        /// </summary>
        public String info { get; set; }
        
		/// <summary>
        /// 结果解析
        /// </summary>
        public String descript { get; set; }
        
		/// <summary>
        /// 二维码
        /// </summary>
        public String qrcode { get; set; }
        
		/// <summary>
        /// 创建时间
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
        /// 试卷名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 试卷名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 主体ID
        /// </summary>
		public const string FLD_parent_id="parent_id";        
		/// <summary>
        /// 主体ID参数字段
        /// </summary>
		public const string FAR_parent_id="@parent_id";        
		
		/// <summary>
        /// 试题数量
        /// </summary>
		public const string FLD_nums="nums";        
		/// <summary>
        /// 试题数量参数字段
        /// </summary>
		public const string FAR_nums="@nums";        
		
		/// <summary>
        /// 总分
        /// </summary>
		public const string FLD_score="score";        
		/// <summary>
        /// 总分参数字段
        /// </summary>
		public const string FAR_score="@score";        
		
		/// <summary>
        /// 描述
        /// </summary>
		public const string FLD_info="info";        
		/// <summary>
        /// 描述参数字段
        /// </summary>
		public const string FAR_info="@info";        
		
		/// <summary>
        /// 结果解析
        /// </summary>
		public const string FLD_descript="descript";        
		/// <summary>
        /// 结果解析参数字段
        /// </summary>
		public const string FAR_descript="@descript";        
		
		/// <summary>
        /// 二维码
        /// </summary>
		public const string FLD_qrcode="qrcode";        
		/// <summary>
        /// 二维码参数字段
        /// </summary>
		public const string FAR_qrcode="@qrcode";        
		
		/// <summary>
        /// 创建时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 创建时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}