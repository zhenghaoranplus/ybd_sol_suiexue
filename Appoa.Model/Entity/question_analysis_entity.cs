using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class question_analysis_entity
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
        /// <summary>
        /// 是否正确
        /// </summary>
        public int is_truth { get; set; }
        /// <summary>
        /// 正确答案
        /// </summary>
        public string truth_answer { get; set; }
        /// <summary>
        /// 用户回答答案
        /// </summary>
        public string user_answer { get; set; }
        /// <summary>
        /// 参与人数
        /// </summary>
        public int join_count { get; set; }
        /// <summary>
        /// 正确率
        /// </summary>
        public decimal truth_ratio { get; set; }
        /// <summary>
        /// 解析
        /// </summary>
        public string analysis { get; set; }
    }
}
