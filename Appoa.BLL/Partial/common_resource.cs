/*功能：生成实体类
 *编码日期:2017/6/23 15:08:33
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
    /// 资源信息业务逻辑类
    /// </summary>
    public partial class common_resource
    {
        public bool UpdateField(int id, string field)
        {
            return dal.UpdateField(id, field);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
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