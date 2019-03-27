using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class resource_evaluate_entity
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 评论总数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 评论者ID
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
        /// 内容
        /// </summary>
        public string contents { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public string add_time { get; set; }

        /// <summary>
        /// 回复列表
        /// </summary>
        public List<reply_entity> replyList { get; set; }
    }

    public class reply_entity
    {
        /// <summary>
        /// 回复ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 回复者ID
        /// </summary>
        public int from_user_id { get; set; }
        /// <summary>
        /// 回复者昵称
        /// </summary>
        public string from_nick_name { get; set; }
        /// <summary>
        /// 被回复者ID
        /// </summary>
        public int to_user_id { get; set; }
        /// <summary>
        /// 被回复者昵称
        /// </summary>
        public string to_nick_name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string contents { get; set; }
    }
}
