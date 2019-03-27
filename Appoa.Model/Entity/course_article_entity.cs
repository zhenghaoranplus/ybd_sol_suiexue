using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class course_article_entity
    {
        /// <summary>
        /// 问题ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int course_id { get; set; }
        /// <summary>
        /// 发布者ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 发布者头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 发布者昵称
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string contents { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string add_time { get; set; }
        /// <summary>
        /// 评论总数
        /// </summary>
        public int eval_count { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public List<img_entity> imgList { get; set; }
        /// <summary>
        /// 视频
        /// </summary>
        public List<img_entity> videoList { get; set; }
    }
}
