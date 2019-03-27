using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class img_entity
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string thumb_path { get; set; }
        /// <summary>
        /// 原图
        /// </summary>
        public string original_path { get; set; }
    }
}
