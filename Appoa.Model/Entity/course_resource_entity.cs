using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class course_resource_entity
    {
        /// <summary>
        /// 资源ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public string add_time { get; set; }
    }
}
