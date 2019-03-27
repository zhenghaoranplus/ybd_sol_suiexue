/*功能：生成实体类
 *编码日期:2017/7/14 16:51:48
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 订单信息实体类
    /// id:订单id,order_no:订单编号,order_type:订单来源,trade_no:交易号,user_id:购买者id,user_name:用户名,payment_way:支付方式 1货到付款,payment_name:支付方式名称,payment_fee:支付手续费,payment_time:支付时间,express_type:配送方式 1 快递配送,express_man_name:快递员,express_mobile:快递员电话,express_name:快递公司名称,express_no:快递单号,express_money:运费,accept_name:收件人姓名,post_code:邮政编码,mobile:手机号,area:区域,address:详细地址,address_id:用户收货地址id,message:订单留言,remark:订单备注,use_point:订单使用的积分,order_amount:订单总金额,order_coupon_money:订单优惠总金额,payable_amount:需付商品总金额,status:订单状态,add_time:下单时间,confirm_time:确认时间,complete_time:订单完成时间,del_status:删除状态0未删除1用户删除,
    /// </summary>
	[Serializable]
    public partial class user_order
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_order()
        {
        }
		/// <summary>
        ///订单信息
        /// </summary>
		public const string TABLE_NAME = "ybd_user_order";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,order_no,order_type,trade_no,user_id,user_name,payment_way,payment_name,payment_fee,payment_time,express_type,express_man_name,express_mobile,express_name,express_no,express_money,accept_name,post_code,mobile,area,address,address_id,message,remark,use_point,order_amount,order_coupon_money,payable_amount,status,add_time,confirm_time,complete_time,del_status";
        
		/// <summary>
        /// 订单id
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 订单编号
        /// </summary>
        public String order_no { get; set; }
        
		/// <summary>
        /// 订单来源
        /// </summary>
        public Int32 order_type { get; set; }
        
		/// <summary>
        /// 交易号
        /// </summary>
        public String trade_no { get; set; }
        
		/// <summary>
        /// 购买者id
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 用户名
        /// </summary>
        public String user_name { get; set; }
        
		/// <summary>
        /// 支付方式 1货到付款
        /// </summary>
        public Int32 payment_way { get; set; }
        
		/// <summary>
        /// 支付方式名称
        /// </summary>
        public String payment_name { get; set; }
        
		/// <summary>
        /// 支付手续费
        /// </summary>
        public Decimal payment_fee { get; set; }
        
		/// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? payment_time { get; set; }
        
		/// <summary>
        /// 配送方式 1 快递配送
        /// </summary>
        public Int32 express_type { get; set; }
        
		/// <summary>
        /// 快递员
        /// </summary>
        public String express_man_name { get; set; }
        
		/// <summary>
        /// 快递员电话
        /// </summary>
        public String express_mobile { get; set; }
        
		/// <summary>
        /// 快递公司名称
        /// </summary>
        public String express_name { get; set; }
        
		/// <summary>
        /// 快递单号
        /// </summary>
        public String express_no { get; set; }
        
		/// <summary>
        /// 运费
        /// </summary>
        public Decimal express_money { get; set; }
        
		/// <summary>
        /// 收件人姓名
        /// </summary>
        public String accept_name { get; set; }
        
		/// <summary>
        /// 邮政编码
        /// </summary>
        public String post_code { get; set; }
        
		/// <summary>
        /// 手机号
        /// </summary>
        public String mobile { get; set; }
        
		/// <summary>
        /// 区域
        /// </summary>
        public String area { get; set; }
        
		/// <summary>
        /// 详细地址
        /// </summary>
        public String address { get; set; }
        
		/// <summary>
        /// 用户收货地址id
        /// </summary>
        public Int32 address_id { get; set; }
        
		/// <summary>
        /// 订单留言
        /// </summary>
        public String message { get; set; }
        
		/// <summary>
        /// 订单备注
        /// </summary>
        public String remark { get; set; }
        
		/// <summary>
        /// 订单使用的积分
        /// </summary>
        public Int32 use_point { get; set; }
        
		/// <summary>
        /// 订单总金额
        /// </summary>
        public Decimal order_amount { get; set; }
        
		/// <summary>
        /// 订单优惠总金额
        /// </summary>
        public Decimal order_coupon_money { get; set; }
        
		/// <summary>
        /// 需付商品总金额
        /// </summary>
        public Decimal payable_amount { get; set; }
        
		/// <summary>
        /// 订单状态
        /// </summary>
        public Int32 status { get; set; }
        
		/// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
		/// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? confirm_time { get; set; }
        
		/// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime? complete_time { get; set; }
        
		/// <summary>
        /// 删除状态0未删除1用户删除
        /// </summary>
        public Int32 del_status { get; set; }
        
        
        
        
        #region extended
		/// <summary>
        /// 订单id
        /// </summary>
		public const string FLD_id="id";        
		/// <summary>
        /// 订单id参数字段
        /// </summary>
		public const string FAR_id="@id";        
		
		/// <summary>
        /// 订单编号
        /// </summary>
		public const string FLD_order_no="order_no";        
		/// <summary>
        /// 订单编号参数字段
        /// </summary>
		public const string FAR_order_no="@order_no";        
		
		/// <summary>
        /// 订单来源
        /// </summary>
		public const string FLD_order_type="order_type";        
		/// <summary>
        /// 订单来源参数字段
        /// </summary>
		public const string FAR_order_type="@order_type";        
		
		/// <summary>
        /// 交易号
        /// </summary>
		public const string FLD_trade_no="trade_no";        
		/// <summary>
        /// 交易号参数字段
        /// </summary>
		public const string FAR_trade_no="@trade_no";        
		
		/// <summary>
        /// 购买者id
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 购买者id参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 用户名
        /// </summary>
		public const string FLD_user_name="user_name";        
		/// <summary>
        /// 用户名参数字段
        /// </summary>
		public const string FAR_user_name="@user_name";        
		
		/// <summary>
        /// 支付方式 1货到付款
        /// </summary>
		public const string FLD_payment_way="payment_way";        
		/// <summary>
        /// 支付方式 1货到付款参数字段
        /// </summary>
		public const string FAR_payment_way="@payment_way";        
		
		/// <summary>
        /// 支付方式名称
        /// </summary>
		public const string FLD_payment_name="payment_name";        
		/// <summary>
        /// 支付方式名称参数字段
        /// </summary>
		public const string FAR_payment_name="@payment_name";        
		
		/// <summary>
        /// 支付手续费
        /// </summary>
		public const string FLD_payment_fee="payment_fee";        
		/// <summary>
        /// 支付手续费参数字段
        /// </summary>
		public const string FAR_payment_fee="@payment_fee";        
		
		/// <summary>
        /// 支付时间
        /// </summary>
		public const string FLD_payment_time="payment_time";        
		/// <summary>
        /// 支付时间参数字段
        /// </summary>
		public const string FAR_payment_time="@payment_time";        
		
		/// <summary>
        /// 配送方式 1 快递配送
        /// </summary>
		public const string FLD_express_type="express_type";        
		/// <summary>
        /// 配送方式 1 快递配送参数字段
        /// </summary>
		public const string FAR_express_type="@express_type";        
		
		/// <summary>
        /// 快递员
        /// </summary>
		public const string FLD_express_man_name="express_man_name";        
		/// <summary>
        /// 快递员参数字段
        /// </summary>
		public const string FAR_express_man_name="@express_man_name";        
		
		/// <summary>
        /// 快递员电话
        /// </summary>
		public const string FLD_express_mobile="express_mobile";        
		/// <summary>
        /// 快递员电话参数字段
        /// </summary>
		public const string FAR_express_mobile="@express_mobile";        
		
		/// <summary>
        /// 快递公司名称
        /// </summary>
		public const string FLD_express_name="express_name";        
		/// <summary>
        /// 快递公司名称参数字段
        /// </summary>
		public const string FAR_express_name="@express_name";        
		
		/// <summary>
        /// 快递单号
        /// </summary>
		public const string FLD_express_no="express_no";        
		/// <summary>
        /// 快递单号参数字段
        /// </summary>
		public const string FAR_express_no="@express_no";        
		
		/// <summary>
        /// 运费
        /// </summary>
		public const string FLD_express_money="express_money";        
		/// <summary>
        /// 运费参数字段
        /// </summary>
		public const string FAR_express_money="@express_money";        
		
		/// <summary>
        /// 收件人姓名
        /// </summary>
		public const string FLD_accept_name="accept_name";        
		/// <summary>
        /// 收件人姓名参数字段
        /// </summary>
		public const string FAR_accept_name="@accept_name";        
		
		/// <summary>
        /// 邮政编码
        /// </summary>
		public const string FLD_post_code="post_code";        
		/// <summary>
        /// 邮政编码参数字段
        /// </summary>
		public const string FAR_post_code="@post_code";        
		
		/// <summary>
        /// 手机号
        /// </summary>
		public const string FLD_mobile="mobile";        
		/// <summary>
        /// 手机号参数字段
        /// </summary>
		public const string FAR_mobile="@mobile";        
		
		/// <summary>
        /// 区域
        /// </summary>
		public const string FLD_area="area";        
		/// <summary>
        /// 区域参数字段
        /// </summary>
		public const string FAR_area="@area";        
		
		/// <summary>
        /// 详细地址
        /// </summary>
		public const string FLD_address="address";        
		/// <summary>
        /// 详细地址参数字段
        /// </summary>
		public const string FAR_address="@address";        
		
		/// <summary>
        /// 用户收货地址id
        /// </summary>
		public const string FLD_address_id="address_id";        
		/// <summary>
        /// 用户收货地址id参数字段
        /// </summary>
		public const string FAR_address_id="@address_id";        
		
		/// <summary>
        /// 订单留言
        /// </summary>
		public const string FLD_message="message";        
		/// <summary>
        /// 订单留言参数字段
        /// </summary>
		public const string FAR_message="@message";        
		
		/// <summary>
        /// 订单备注
        /// </summary>
		public const string FLD_remark="remark";        
		/// <summary>
        /// 订单备注参数字段
        /// </summary>
		public const string FAR_remark="@remark";        
		
		/// <summary>
        /// 订单使用的积分
        /// </summary>
		public const string FLD_use_point="use_point";        
		/// <summary>
        /// 订单使用的积分参数字段
        /// </summary>
		public const string FAR_use_point="@use_point";        
		
		/// <summary>
        /// 订单总金额
        /// </summary>
		public const string FLD_order_amount="order_amount";        
		/// <summary>
        /// 订单总金额参数字段
        /// </summary>
		public const string FAR_order_amount="@order_amount";        
		
		/// <summary>
        /// 订单优惠总金额
        /// </summary>
		public const string FLD_order_coupon_money="order_coupon_money";        
		/// <summary>
        /// 订单优惠总金额参数字段
        /// </summary>
		public const string FAR_order_coupon_money="@order_coupon_money";        
		
		/// <summary>
        /// 需付商品总金额
        /// </summary>
		public const string FLD_payable_amount="payable_amount";        
		/// <summary>
        /// 需付商品总金额参数字段
        /// </summary>
		public const string FAR_payable_amount="@payable_amount";        
		
		/// <summary>
        /// 订单状态
        /// </summary>
		public const string FLD_status="status";        
		/// <summary>
        /// 订单状态参数字段
        /// </summary>
		public const string FAR_status="@status";        
		
		/// <summary>
        /// 下单时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 下单时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
		/// <summary>
        /// 确认时间
        /// </summary>
		public const string FLD_confirm_time="confirm_time";        
		/// <summary>
        /// 确认时间参数字段
        /// </summary>
		public const string FAR_confirm_time="@confirm_time";        
		
		/// <summary>
        /// 订单完成时间
        /// </summary>
		public const string FLD_complete_time="complete_time";        
		/// <summary>
        /// 订单完成时间参数字段
        /// </summary>
		public const string FAR_complete_time="@complete_time";        
		
		/// <summary>
        /// 删除状态0未删除1用户删除
        /// </summary>
		public const string FLD_del_status="del_status";        
		/// <summary>
        /// 删除状态0未删除1用户删除参数字段
        /// </summary>
		public const string FAR_del_status="@del_status";        
		
        
        #endregion
    }
}