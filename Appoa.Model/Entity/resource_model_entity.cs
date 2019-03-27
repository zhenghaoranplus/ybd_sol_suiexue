using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class resource_model_entity
    {
        /// <summary>
        /// 资源实体
        /// </summary>
        public Model.common_resource resource { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        public int is_collection { get; set; }
    }
}
