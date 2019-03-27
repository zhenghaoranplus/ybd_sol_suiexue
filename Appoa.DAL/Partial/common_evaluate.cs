/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
 *编码人：阴华伟
 *QQ:508955560
 */
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Appoa.DBUtility;
using Appoa.Common;

namespace Appoa.DAL
{
    /// <summary>
    /// 全局评论数据访问类
    /// </summary>
    public partial class common_evaluate
    {
        public DataSet GetList(string field, string viewname, string where)
        {
            string sql = " select " + field + " from " + viewname;
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }

            return DbHelperSQL.Query(sql);
        }

        public int GetRecordCount(string viewname, string whereStr)
        {
            string sql = " select count(1) from " + viewname;
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }

            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public int GetRecordAvg(string viewname, string whereStr)
        {
            string sql = " select AVG(start) from " + viewname;
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }

            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
    }
}