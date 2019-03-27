using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class my_distribution_entity
    {
        /// <summary>
        /// 下级总人数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 总贡献积分
        /// </summary>
        public int sum { get; set; }
        /// <summary>
        /// 下级列表
        /// </summary>
        public List<next_level> nextList { get; set; }
        /// <summary>
        /// 贡献明细
        /// </summary>
        public List<next_level> recordList { get; set; }
    }

    public class next_level
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 贡献积分
        /// </summary>
        public int integral { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string add_time { get; set; }
    }
}
