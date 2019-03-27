using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class order_details_entity
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 订单状态名称
        /// </summary>
        public string status_name { get; set; }
        /// <summary>
        /// 商品总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal total_price { get; set; }
        /// <summary>
        /// 总积分
        /// </summary>
        public int total_integral { get; set; }
        /// <summary>
        /// 留言
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string express_no { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<order_goods_entity> goodsList { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string accept_name { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal express_money { get; set; }
    }
}
