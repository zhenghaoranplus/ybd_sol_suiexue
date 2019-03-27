using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class confirm_order_entity
    {
        /// <summary>
        /// 地址实体
        /// </summary>
        public user_address_entity defaultAddress { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<order_goods_entity> goodsList { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal total_price { get; set; }
        /// <summary>
        /// 总积分
        /// </summary>
        public decimal total_integral { get; set; }
        /// <summary>
        /// 拥有积分
        /// </summary>
        public int has_integral { get; set; }
        /// <summary>
        /// 总商品数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal express_money { get; set; }
    }
}
