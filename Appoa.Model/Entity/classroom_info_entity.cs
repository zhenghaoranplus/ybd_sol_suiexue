using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class classroom_info_entity
    {
        /// <summary>
        /// 课堂ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 课堂名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string add_time { get; set; }
        /// <summary>
        /// 课堂简介
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 课堂二维码
        /// </summary>
        public string qrcode { get; set; }
        /// <summary>
        /// 是否公开
        /// </summary>
        public int is_show { get; set; }
        /// <summary>
        /// 是否加入 1创建者 2已加入 3未加入 4申请审核中
        /// </summary>
        public int is_join { get; set; }
    }
}
