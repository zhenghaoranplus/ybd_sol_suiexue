/*功能：生成实体类
 *编码日期:2017/7/5 10:19:38
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
    /// 课堂用户关系业务逻辑类
    /// </summary>
    public partial class classroom_user
    {
        public bool DeleteByWhere(string whereStr)
        {
            return dal.DeleteByWhere(whereStr);
        }

        /// <summary>
        /// 获取视图记录总数
        /// </summary>
        public int GetRecordCount(string viewname, string whereStr)
        {
            return dal.GetRecordCount(viewname, whereStr);
        }
    }
}