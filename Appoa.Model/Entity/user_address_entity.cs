using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appoa.Model.Entity
{
   public class user_address_entity
    {
       /// <summary>
       /// 地址ID
       /// </summary>
       public int id { get; set; }
       /// <summary>
       /// 收件人
       /// </summary>
       public string name { get; set; }
       /// <summary>
       /// 电话
       /// </summary>
       public string phone { get; set; }
       /// <summary>
       /// 详细地址
       /// </summary>
       public string address { get; set; }
       /// <summary>
       /// 是否是默认地址
       /// </summary>
       public int is_default { get; set; }
    }
}
