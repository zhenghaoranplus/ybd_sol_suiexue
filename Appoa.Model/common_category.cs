/*功能：生成实体类
 *编码日期:2017/6/21 14:47:42
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 全局分类实体类
    /// id:自增ID,group_id:分组ID,category_level:分类级别,parent_id:父级分类ID,img_src:分类配图,name:分类名称,sort:排序,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_category
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_category()
        {
        }
		/// <summary>
        ///全局分类
        /// </summary>
		public const string TABLE_NAME = "ybd_common_category";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,category_level,parent_id,img_src,name,sort,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 分类级别
        /// </summary>
        public Int32 category_level { get; set; }
        
		/// <summary>
        /// 父级分类ID
        /// </summary>
        public Int32 parent_id { get; set; }
        
		/// <summary>
        /// 分类配图
        /// </summary>
        public String img_src { get; set; }
        
		/// <summary>
        /// 分类名称
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
        /// 分组ID
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 分类级别
        /// </summary>
		public const string FLD_category_level="category_level";        
		/// <summary>
        /// 分类级别参数字段
        /// </summary>
		public const string FAR_category_level="@category_level";        
		
		/// <summary>
        /// 父级分类ID
        /// </summary>
		public const string FLD_parent_id="parent_id";        
		/// <summary>
        /// 父级分类ID参数字段
        /// </summary>
		public const string FAR_parent_id="@parent_id";        
		
		/// <summary>
        /// 分类配图
        /// </summary>
		public const string FLD_img_src="img_src";        
		/// <summary>
        /// 分类配图参数字段
        /// </summary>
		public const string FAR_img_src="@img_src";        
		
		/// <summary>
        /// 分类名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 分类名称参数字段
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