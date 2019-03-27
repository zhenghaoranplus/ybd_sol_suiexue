using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class goods_detail_entity
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品分组
        /// </summary>
        public int group_id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string details { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public string parameters { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public int express_money { get; set; }
        /// <summary>
        /// 当前拥有积分
        /// </summary>
        public int integral { get; set; }
        /// <summary>
        /// 购物车数量
        /// </summary>
        public int cart_num { get; set; }
        /// <summary>
        /// 商品轮播图
        /// </summary>
        public List<img_entity> imgList { get; set; }
        /// <summary>
        /// 规格列表
        /// </summary>
        public List<goods_spec> specItemList { get; set; }
    }

    public class goods_spec
    {
        /// <summary>
        /// 规格ID
        /// </summary>
        public int spec_id { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string spec_name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 子项
        /// </summary>
        public List<goods_spec> itemList { get; set; }
    }
}
