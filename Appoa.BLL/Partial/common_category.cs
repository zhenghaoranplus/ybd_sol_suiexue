/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
 *编码人：阴华伟
 *QQ:508955560
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Appoa.Common;
using Appoa.DBUtility;

namespace Appoa.BLL
{
    /// <summary>
    /// 全局分类业务逻辑类
    /// </summary>
    public partial class common_category
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string strWhere, string parentId)
        {
            return dal.GetListNew(strWhere, parentId);
        }

        public DataTable GetViewList(string DIY_FILED, string viewname, string whereStr, string orderby)
        {
            return dal.GetViewList(DIY_FILED, viewname, whereStr, orderby).Tables[0];
        }


        public bool UpdateField(int id, string field)
        {
            return dal.UpdateField(id, field);
        }
    }
}