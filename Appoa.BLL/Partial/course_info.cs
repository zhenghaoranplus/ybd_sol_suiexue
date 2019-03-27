/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
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
    /// 课程信息业务逻辑类
    /// </summary>
    public partial class course_info
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string viewname, string whereStr, string orderby)
        {
            return dal.GetList(viewname, whereStr, orderby).Tables[0];
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string viewname, string whereStr)
        {
            return dal.GetRecordCount(viewname, whereStr);
        }
    }
}