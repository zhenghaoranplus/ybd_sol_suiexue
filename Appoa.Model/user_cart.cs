/*功能：生成实体类
 *编码日期:2017/6/21 14:47:45
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 购物车表实体类
    /// id:自增ID,ct_id:商家id,group_id:分组id,user_id:购买者id,goods_sale_type:商品销售类型,goods_id:商品id,goods_name:标题,goods_subtitle:副标题,goods_img:封面图,goods_oprice:原价,goods_price:现价,goods_spec:规格值,goods_spec_id:规格id,num:数量,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class user_cart
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_cart()
        {
        }
		/// <summary>
        ///购物车表
        /// </summary>
		public const string TABLE_NAME = "ybd_user_cart";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,ct_id,group_id,user_id,goods_sale_type,goods_id,goods_name,goods_subtitle,goods_img,goods_oprice,goods_price,goods_spec,goods_spec_id,num,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 商家id
        /// </summary>
        public Int32 ct_id { get; set; }
        
		/// <summary>
        /// 分组id
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 购买者id
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 商品销售类型
        /// </summary>
        public Int32 goods_sale_type { get; set; }
        
		/// <summary>
        /// 商品id
        /// </summary>
        public Int32 goods_id { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String goods_name { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
        public String goods_subtitle { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String goods_img { get; set; }
        
		/// <summary>
        /// 原价
        /// </summary>
        public Decimal goods_oprice { get; set; }
        
		/// <summary>
        /// 现价
        /// </summary>
        public Decimal goods_price { get; set; }
        
		/// <summary>
        /// 规格值
        /// </summary>
        public String goods_spec { get; set; }
        
		/// <summary>
        /// 规格id
        /// </summary>
        public String goods_spec_id { get; set; }
        
		/// <summary>
        /// 数量
        /// </summary>
        public Int32 num { get; set; }
        
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
        /// 商家id
        /// </summary>
		public const string FLD_ct_id="ct_id";        
		/// <summary>
        /// 商家id参数字段
        /// </summary>
		public const string FAR_ct_id="@ct_id";        
		
		/// <summary>
        /// 分组id
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组id参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 购买者id
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 购买者id参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 商品销售类型
        /// </summary>
		public const string FLD_goods_sale_type="goods_sale_type";        
		/// <summary>
        /// 商品销售类型参数字段
        /// </summary>
		public const string FAR_goods_sale_type="@goods_sale_type";        
		
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
		public const string FLD_goods_name="goods_name";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_goods_name="@goods_name";        
		
		/// <summary>
        /// 副标题
        /// </summary>
		public const string FLD_goods_subtitle="goods_subtitle";        
		/// <summary>
        /// 副标题参数字段
        /// </summary>
		public const string FAR_goods_subtitle="@goods_subtitle";        
		
		/// <summary>
        /// 封面图
        /// </summary>
		public const string FLD_goods_img="goods_img";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_goods_img="@goods_img";        
		
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
        /// 规格值
        /// </summary>
		public const string FLD_goods_spec="goods_spec";        
		/// <summary>
        /// 规格值参数字段
        /// </summary>
		public const string FAR_goods_spec="@goods_spec";        
		
		/// <summary>
        /// 规格id
        /// </summary>
		public const string FLD_goods_spec_id="goods_spec_id";        
		/// <summary>
        /// 规格id参数字段
        /// </summary>
		public const string FAR_goods_spec_id="@goods_spec_id";        
		
		/// <summary>
        /// 数量
        /// </summary>
		public const string FLD_num="num";        
		/// <summary>
        /// 数量参数字段
        /// </summary>
		public const string FAR_num="@num";        
		
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