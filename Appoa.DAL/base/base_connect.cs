using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Appoa.DBUtility;

namespace Appoa.DAL
{
    [Serializable]
	public class base_connect
	{
        /// <summary>
        /// 分页获取数据列表2
        /// </summary>
        public DataSet GetViewListByPage(string DIY_FILED, string whereStr, string orderby, int startIndex, int endIndex,string viewName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT " + DIY_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM View_"+viewName+" T ");

            if (whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetViewRecordCount(string whereStr,string viewName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM View_" + viewName + " ");
            if (whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
	}
}
