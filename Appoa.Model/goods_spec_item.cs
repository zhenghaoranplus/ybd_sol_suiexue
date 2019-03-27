/*功能：生成实体类
 *编码日期:2017/6/21 14:47:44
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 商品规格项实体类
    /// id:自增ID,goods_id:商品id,name:规格名称,parent_id:父级规格,sort:排序,
    /// </summary>
	[Serializable]
    public partial class goods_spec_item
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public goods_spec_item()
        {
        }
		/// <summary>
        ///商品规格项
        /// </summary>
		public const string TABLE_NAME = "ybd_goods_spec_item";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,goods_id,name,parent_id,sort";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 商品id
        /// </summary>
        public Int32 goods_id { get; set; }
        
		/// <summary>
        /// 规格名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 父级规格
        /// </summary>
        public Int32 parent_id { get; set; }
        
		/// <summary>
        /// 排序
        /// </summary>
        public Int32 sort { get; set; }
        
        
        
        
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
        /// 商品id
        /// </summary>
		public const string FLD_goods_id="goods_id";        
		/// <summary>
        /// 商品id参数字段
        /// </summary>
		public const string FAR_goods_id="@goods_id";        
		
		/// <summary>
        /// 规格名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 规格名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 父级规格
        /// </summary>
		public const string FLD_parent_id="parent_id";        
		/// <summary>
        /// 父级规格参数字段
        /// </summary>
		public const string FAR_parent_id="@parent_id";        
		
		/// <summary>
        /// 排序
        /// </summary>
		public const string FLD_sort="sort";        
		/// <summary>
        /// 排序参数字段
        /// </summary>
		public const string FAR_sort="@sort";        
		
        
        #endregion
    }
}