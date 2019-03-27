using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class user_info_entity
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public Model.user_info UserInfo { get; set; }
        /// <summary>
        /// 用户关系
        /// </summary>
        public Model.user_tree UserTree { get; set; }
        /// <summary>
        /// 第三方登录信息
        /// </summary>
        public Model.user_oauths UserOAuths { get; set; }
    }
}
