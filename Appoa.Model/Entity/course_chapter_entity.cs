using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class course_chapter_entity
    {
        /// <summary>
        /// 章节ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 章节标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 资源列表
        /// </summary>
        public List<course_resource_entity> resourceList { get; set; }
        /// <summary>
        /// 子集
        /// </summary>
        public List<course_chapter_entity> childrenList { get; set; }
    }
}