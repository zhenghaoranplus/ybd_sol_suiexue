/*功能：生成实体类
 *编码日期:2017/6/21 14:47:44
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 商品规格种类实体类
    /// id:自增ID,goods_id:商品id,spec:规格,stock:库存,price:价格,
    /// </summary>
	[Serializable]
    public partial class goods_spec_type
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public goods_spec_type()
        {
        }
		/// <summary>
        ///商品规格种类
        /// </summary>
		public const string TABLE_NAME = "ybd_goods_spec_type";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,goods_id,spec,stock,price";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 商品id
        /// </summary>
        public Int32 goods_id { get; set; }
        
		/// <summary>
        /// 规格
        /// </summary>
        public Int32 spec { get; set; }
        
		/// <summary>
        /// 库存
        /// </summary>
        public Int32 stock { get; set; }
        
		/// <summary>
        /// 价格
        /// </summary>
        public Decimal price { get; set; }
        
        
        
        
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
        /// 规格
        /// </summary>
		public const string FLD_spec="spec";        
		/// <summary>
        /// 规格参数字段
        /// </summary>
		public const string FAR_spec="@spec";        
		
		/// <summary>
        /// 库存
        /// </summary>
		public const string FLD_stock="stock";        
		/// <summary>
        /// 库存参数字段
        /// </summary>
		public const string FAR_stock="@stock";        
		
		/// <summary>
        /// 价格
        /// </summary>
		public const string FLD_price="price";        
		/// <summary>
        /// 价格参数字段
        /// </summary>
		public const string FAR_price="@price";        
		
        
        #endregion
    }
}