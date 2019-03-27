using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class goods_evaluate_entity
    {
        /// <summary>
        /// 总评论数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 平均分
        /// </summary>
        public decimal avg_star { get; set; }
        /// <summary>
        /// 评论列表
        /// </summary>
        public List<goods_evaluate> evalList { get; set; }
    }

    public class goods_evaluate
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string contents { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string add_time { get; set; }
        /// <summary>
        /// 星级
        /// </summary>
        public int star { get; set; }
    }
}
