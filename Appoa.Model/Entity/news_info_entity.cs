using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class news_info_entity
    {
        public int prev_id { get; set; }

        public string prev_title { get; set; }

        public int next_id { get; set; }

        public string next_title { get; set; }

        public Model.common_article model { get; set; }
    }
}
