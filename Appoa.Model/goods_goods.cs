/*功能：生成实体类
 *编码日期:2017/6/21 14:47:44
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 商品信息实体类
    /// id:自增ID,ct_id:商家id,group_id:分组id,category_id:商品分类id,title:标题,subtitle:副标题,img_src:封面图,oprice:原价,price:现价,parameters:商品参数,details:信息详情,sales_num:销量,status:商品销售状态,sj_time:上架时间,xj_time:下架时间,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class goods_goods
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public goods_goods()
        {
        }
		/// <summary>
        ///商品信息
        /// </summary>
		public const string TABLE_NAME = "ybd_goods_goods";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,ct_id,group_id,category_id,title,subtitle,img_src,oprice,price,parameters,details,sales_num,status,sj_time,xj_time,add_time";
        
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
        /// 商品分类id
        /// </summary>
        public Int32 category_id { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
        public String subtitle { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String img_src { get; set; }
        
		/// <summary>
        /// 原价
        /// </summary>
        public Decimal oprice { get; set; }
        
		/// <summary>
        /// 现价
        /// </summary>
        public Decimal price { get; set; }
        
		/// <summary>
        /// 商品参数
        /// </summary>
        public String parameters { get; set; }
        
		/// <summary>
        /// 信息详情
        /// </summary>
        public String details { get; set; }
        
		/// <summary>
        /// 销量
        /// </summary>
        public Int32 sales_num { get; set; }
        
		/// <summary>
        /// 商品销售状态
        /// </summary>
        public Int32 status { get; set; }
        
		/// <summary>
        /// 上架时间
        /// </summary>
        public DateTime? sj_time { get; set; }
        
		/// <summary>
        /// 下架时间
        /// </summary>
        public DateTime? xj_time { get; set; }
        
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
        /// 商品分类id
        /// </summary>
		public const string FLD_category_id="category_id";        
		/// <summary>
        /// 商品分类id参数字段
        /// </summary>
		public const string FAR_category_id="@category_id";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_title="title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_title="@title";        
		
		/// <summary>
        /// 副标题
        /// </summary>
		public const string FLD_subtitle="subtitle";        
		/// <summary>
        /// 副标题参数字段
        /// </summary>
		public const string FAR_subtitle="@subtitle";        
		
		/// <summary>
        /// 封面图
        /// </summary>
		public const string FLD_img_src="img_src";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_img_src="@img_src";        
		
		/// <summary>
        /// 原价
        /// </summary>
		public const string FLD_oprice="oprice";        
		/// <summary>
        /// 原价参数字段
        /// </summary>
		public const string FAR_oprice="@oprice";        
		
		/// <summary>
        /// 现价
        /// </summary>
		public const string FLD_price="price";        
		/// <summary>
        /// 现价参数字段
        /// </summary>
		public const string FAR_price="@price";        
		
		/// <summary>
        /// 商品参数
        /// </summary>
		public const string FLD_parameters="parameters";        
		/// <summary>
        /// 商品参数参数字段
        /// </summary>
		public const string FAR_parameters="@parameters";        
		
		/// <summary>
        /// 信息详情
        /// </summary>
		public const string FLD_details="details";        
		/// <summary>
        /// 信息详情参数字段
        /// </summary>
		public const string FAR_details="@details";        
		
		/// <summary>
        /// 销量
        /// </summary>
		public const string FLD_sales_num="sales_num";        
		/// <summary>
        /// 销量参数字段
        /// </summary>
		public const string FAR_sales_num="@sales_num";        
		
		/// <summary>
        /// 商品销售状态
        /// </summary>
		public const string FLD_status="status";        
		/// <summary>
        /// 商品销售状态参数字段
        /// </summary>
		public const string FAR_status="@status";        
		
		/// <summary>
        /// 上架时间
        /// </summary>
		public const string FLD_sj_time="sj_time";        
		/// <summary>
        /// 上架时间参数字段
        /// </summary>
		public const string FAR_sj_time="@sj_time";        
		
		/// <summary>
        /// 下架时间
        /// </summary>
		public const string FLD_xj_time="xj_time";        
		/// <summary>
        /// 下架时间参数字段
        /// </summary>
		public const string FAR_xj_time="@xj_time";        
		
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