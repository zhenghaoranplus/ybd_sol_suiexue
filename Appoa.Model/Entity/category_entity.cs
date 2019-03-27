using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
    public class category_entity
    {
        public int id { get; set; }

        public int category_level { get; set; }

        public string img_src { get; set; }

        public string title { get; set; }

        public List<category_entity> childrenList { get; set; }
    }
}
