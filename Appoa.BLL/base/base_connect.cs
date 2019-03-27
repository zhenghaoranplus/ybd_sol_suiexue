using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Appoa.BLL
{
    /// <summary>
    /// 查询试图方法
    /// </summary>
    [Serializable]
    public class base_connect
    {
        private readonly DAL.base_connect dal = new DAL.base_connect();
        /// <summary>
        /// 分页获取试图数据列表
        /// </summary>
        public DataTable GetViewListByPage(string DIY_FILED, string whereStr, string orderby, int pageIndex, int pageSize, string viewName)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return dal.GetViewListByPage(DIY_FILED, whereStr, orderby, startIndex, endIndex, viewName).Tables[0];
        }

        /// <summary>
        /// 获取试图记录总数
        /// </summary>
        public int GetViewRecordCount(string whereStr, string viewName)
        {
            return dal.GetViewRecordCount(whereStr, viewName);
        }
    }
}
