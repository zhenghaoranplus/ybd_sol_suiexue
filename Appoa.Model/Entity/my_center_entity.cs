using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class my_center_entity
    {
        /// <summary>
        /// 用户实体
        /// </summary>
        public user_info_entity user { get; set; }
        /// <summary>
        /// 是否签到
        /// </summary>
        public int is_signin { get; set; }
        /// <summary>
        /// 我的积分
        /// </summary>
        public int integral { get; set; }
        /// <summary>
        /// 我的收藏
        /// </summary>
        public int collection { get; set; }
        /// <summary>
        /// 购物车数量
        /// </summary>
        public int cart_num { get; set; }
        /// <summary>
        /// 待发货
        /// </summary>
        public int send { get; set; }
        /// <summary>
        /// 待收货
        /// </summary>
        public int receive { get; set; }
        /// <summary>
        /// 待评价
        /// </summary>
        public int eval { get; set; }
    }
}
