using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class answer_result_request
    {
        /// <summary>
        /// 问题ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 问题类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string answer { get; set; }
    }
}
