/*功能：生成实体类
 *编码日期:2017/10/18 13:51:30
 *编码人：阴华伟
 *QQ:508955560
 */
using System;
using System.Data;
using System.Collections.Generic;
using Appoa.Common;

namespace Appoa.BLL
{
    /// <summary>
    /// 合作伙伴业务逻辑类
    /// </summary>
    public partial class company_partner
    {
        public bool UpdateField(int id, string field)
        {
            return dal.UpdateField(id, field);
        }

        public int GetRecordCount(string viewname, string whereStr)
        {
            return dal.GetRecordCount(viewname, whereStr);
        }

        public bool DeleteByWhere(string whereStr)
        {
            return dal.DeleteByWhere(whereStr);
        }
    }
}