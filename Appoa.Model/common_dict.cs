/*功能：生成实体类
 *编码日期:2017/6/21 14:47:43
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 字典项配置实体类
    /// id:自增ID,name:名称,contents:字典项值,type:类型,type_name:类型名称,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_dict
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_dict()
        {
        }
		/// <summary>
        ///字典项配置
        /// </summary>
		public const string TABLE_NAME = "ybd_common_dict";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,name,contents,type,type_name,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 字典项值
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 类型
        /// </summary>
        public Int32 type { get; set; }
        
		/// <summary>
        /// 类型名称
        /// </summary>
        public String type_name { get; set; }
        
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
        /// 字典项值
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 字典项值参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 类型
        /// </summary>
		public const string FLD_type="type";        
		/// <summary>
        /// 类型参数字段
        /// </summary>
		public const string FAR_type="@type";        
		
		/// <summary>
        /// 类型名称
        /// </summary>
		public const string FLD_type_name="type_name";        
		/// <summary>
        /// 类型名称参数字段
        /// </summary>
		public const string FAR_type_name="@type_name";        
		
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