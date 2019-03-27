/*功能：生成实体类
 *编码日期:2017/7/14 9:44:50
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 订单购买商品表实体类
    /// id:自增ID,order_id:订单id,goods_group:商品分组,goods_id:商品id,goods_title:标题,goods_subtitle:副标题,goods_spec:规格,goods_stock:库存,img_url:封面图,goods_oprice:原价,goods_price:现价,quantity:数量,
    /// </summary>
	[Serializable]
    public partial class user_ordergoods
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_ordergoods()
        {
        }
		/// <summary>
        ///订单购买商品表
        /// </summary>
		public const string TABLE_NAME = "ybd_user_ordergoods";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,order_id,goods_group,goods_id,goods_title,goods_subtitle,goods_spec,goods_stock,img_url,goods_oprice,goods_price,quantity";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 订单id
        /// </summary>
        public Int32 order_id { get; set; }
        
		/// <summary>
        /// 商品分组
        /// </summary>
        public Int32 goods_group { get; set; }
        
		/// <summary>
        /// 商品id
        /// </summary>
        public Int32 goods_id { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String goods_title { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
        public String goods_subtitle { get; set; }
        
		/// <summary>
        /// 规格
        /// </summary>
        public String goods_spec { get; set; }
        
		/// <summary>
        /// 库存
        /// </summary>
        public Int32 goods_stock { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String img_url { get; set; }
        
		/// <summary>
        /// 原价
        /// </summary>
        public Decimal goods_oprice { get; set; }
        
		/// <summary>
        /// 现价
        /// </summary>
        public Decimal goods_price { get; set; }
        
		/// <summary>
        /// 数量
        /// </summary>
        public Int32 quantity { get; set; }
        
        
        
        
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
        /// 订单id
        /// </summary>
		public const string FLD_order_id="order_id";        
		/// <summary>
        /// 订单id参数字段
        /// </summary>
		public const string FAR_order_id="@order_id";        
		
		/// <summary>
        /// 商品分组
        /// </summary>
		public const string FLD_goods_group="goods_group";        
		/// <summary>
        /// 商品分组参数字段
        /// </summary>
		public const string FAR_goods_group="@goods_group";        
		
		/// <summary>
        /// 商品id
        /// </summary>
		public const string FLD_goods_id="goods_id";        
		/// <summary>
        /// 商品id参数字段
        /// </summary>
		public const string FAR_goods_id="@goods_id";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_goods_title="goods_title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_goods_title="@goods_title";        
		
		/// <summary>
        /// 副标题
        /// </summary>
		public const string FLD_goods_subtitle="goods_subtitle";        
		/// <summary>
        /// 副标题参数字段
        /// </summary>
		public const string FAR_goods_subtitle="@goods_subtitle";        
		
		/// <summary>
        /// 规格
        /// </summary>
		public const string FLD_goods_spec="goods_spec";        
		/// <summary>
        /// 规格参数字段
        /// </summary>
		public const string FAR_goods_spec="@goods_spec";        
		
		/// <summary>
        /// 库存
        /// </summary>
		public const string FLD_goods_stock="goods_stock";        
		/// <summary>
        /// 库存参数字段
        /// </summary>
		public const string FAR_goods_stock="@goods_stock";        
		
		/// <summary>
        /// 封面图
        /// </summary>
		public const string FLD_img_url="img_url";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_img_url="@img_url";        
		
		/// <summary>
        /// 原价
        /// </summary>
		public const string FLD_goods_oprice="goods_oprice";        
		/// <summary>
        /// 原价参数字段
        /// </summary>
		public const string FAR_goods_oprice="@goods_oprice";        
		
		/// <summary>
        /// 现价
        /// </summary>
		public const string FLD_goods_price="goods_price";        
		/// <summary>
        /// 现价参数字段
        /// </summary>
		public const string FAR_goods_price="@goods_price";        
		
		/// <summary>
        /// 数量
        /// </summary>
		public const string FLD_quantity="quantity";        
		/// <summary>
        /// 数量参数字段
        /// </summary>
		public const string FAR_quantity="@quantity";        
		
        
        #endregion
    }
}