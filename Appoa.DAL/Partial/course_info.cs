/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
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
    /// 课程信息数据访问类
    /// </summary>
    public partial class course_info
    {
        /// <summary>
        /// 获得数据列表3
        /// </summary>
        public DataSet GetList(string viewname, string whereStr, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM " + viewname);
            if (whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            if (orderby.Length > 0)
            {
                strSql.Append(" ORDER BY " + orderby);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string viewname, string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM " + viewname);
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