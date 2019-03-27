using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class order_goods_entity
    {
        /// <summary>
        /// 订单商品ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id { get; set; }
        /// <summary>
        /// 商品分组
        /// </summary>
        public int group { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        public string img_src { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 价格(积分)
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string spec { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 是否评价过
        /// </summary>
        public int is_eval { get; set; }
    }
}
