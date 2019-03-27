using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class shop_index_goods
    {
        /// <summary>
        /// 轮播图列表
        /// </summary>
        public List<banner_entity> bannerList { get; set; }
        /// <summary>
        /// 教育商品列表
        /// </summary>
        public List<index_goods_info> eduGoodsList { get; set; }
        /// <summary>
        /// 积分商品列表
        /// </summary>
        public List<index_goods_info> pointGoodsList { get; set; }
    }
    public class banner_entity
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url { get; set; }
        /// <summary>
        /// 店铺id
        /// </summary>
        public int data_id { get; set; }
        /// <summary>
        /// 外链地址
        /// </summary>
        public string data_url { get; set; }
    }

    public class index_goods_info
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品封面图
        /// </summary>
        public string img_src { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 外链
        /// </summary>
        public string subtitle { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal price { get; set; }
    }
}
