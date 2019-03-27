using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class course_info_entity
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 发布者ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string qrcode { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        public int is_collection { get; set; }
    }
}
