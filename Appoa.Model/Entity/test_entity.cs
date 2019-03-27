using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class test_entity
    {
        /// <summary>
        /// 排序ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 题目ID
        /// </summary>
        public int q_id { get; set; }
        /// <summary>
        /// 题目类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string type_name { get; set; }
        /// <summary>
        /// 题目标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 题目分值
        /// </summary>
        public int score { get; set; }
        /// <summary>
        /// 选项列表
        /// </summary>
        public List<options_entity> optionsList { get; set; }
    }

    public class options_entity
    {
        /// <summary>
        /// 选项ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 选项
        /// </summary>
        public string no { get; set; }
        /// <summary>
        /// 选项内容
        /// </summary>
        public string title { get; set; }
    }
}
