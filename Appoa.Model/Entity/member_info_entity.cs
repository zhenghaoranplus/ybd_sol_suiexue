using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class member_info_entity
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
        /// 学校名称
        /// </summary>
        public string school_name { get; set; }
        /// <summary>
        /// 课堂列表
        /// </summary>
        public List<classroom_info_entity> classroomList { get; set; }
    }
}
