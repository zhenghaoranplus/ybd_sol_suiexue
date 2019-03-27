using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class file_info_entity
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string extend { get; set; }
        /// <summary>
        /// 文件新名称
        /// </summary>
        public string newName { get; set; }
        /// <summary>
        /// 文件存储虚拟路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 视频文件缩略图虚拟路径
        /// </summary>
        public string thumb_path { get; set; }
    }
}
