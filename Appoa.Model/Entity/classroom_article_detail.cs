using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
   public class classroom_article_detail
    {
       /// <summary>
       /// 知识点详情
       /// </summary>
       public Model.common_resource model { get; set; }
       /// <summary>
       /// 图片集合
       /// </summary>
       public List<img_entity> imgList { get; set; }
    }
}
