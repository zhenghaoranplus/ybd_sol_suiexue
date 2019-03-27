/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 学校信息实体类
    /// id:自增ID,name:名称,sort:排序,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_school
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_school()
        {
        }
		/// <summary>
        ///学校信息
        /// </summary>
		public const string TABLE_NAME = "ybd_common_school";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,name,sort,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 排序
        /// </summary>
        public Int32 sort { get; set; }
        
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
        /// 名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 排序
        /// </summary>
		public const string FLD_sort="sort";        
		/// <summary>
        /// 排序参数字段
        /// </summary>
		public const string FAR_sort="@sort";        
		
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