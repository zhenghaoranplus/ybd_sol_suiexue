using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class classroom_user_entity
    {
        /// <summary>
        /// 总人数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 成员人数
        /// </summary>
        public int member { get; set; }
        /// <summary>
        /// 老师信息
        /// </summary>
        public member_info teacher { get; set; }
        /// <summary>
        /// 成员列表
        /// </summary>
        public List<member_info> memberList { get; set; }
    }

    public class member_info
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nick_name { get; set; }
    }
}
