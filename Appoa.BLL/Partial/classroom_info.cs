/*功能：生成实体类
 *编码日期:2017/7/5 15:12:57
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
    /// 课堂信息业务逻辑类
    /// </summary>
    public partial class classroom_info
    {
        public DataTable GetList(string viewname, string whereStr, string orderby)
        {
            return dal.GetList(viewname, whereStr, orderby).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string strWhere, string parentId)
        {
            return dal.GetListNew(strWhere, parentId);
        }
    }
}