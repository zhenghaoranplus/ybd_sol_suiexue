/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
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
    /// 全局文章业务逻辑类
    /// </summary>
    public partial class common_article
    {
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