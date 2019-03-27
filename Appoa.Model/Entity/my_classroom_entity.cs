using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class my_classroom_entity
    {
        /// <summary>
        /// 我加入的
        /// </summary>
        public List<classroom_info_entity> joinList { get; set; }

        /// <summary>
        /// 我创建的
        /// </summary>
        public List<classroom_info_entity> createList { get; set; }
    }
}
