using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class materials_entity
    {
        /// <summary>
        /// 课堂所有者
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 课件列表
        /// </summary>
        public List<course_resource_entity> fileList { get; set; }
        /// <summary>
        /// 视频列表
        /// </summary>
        public List<course_resource_entity> videoList { get; set; }
        /// <summary>
        /// 知识点列表
        /// </summary>
        public List<course_resource_entity> articleList { get; set; }
        /// <summary>
        /// 作业列表
        /// </summary>
        public List<course_chapter_entity> workList { get; set; }
    }
}
