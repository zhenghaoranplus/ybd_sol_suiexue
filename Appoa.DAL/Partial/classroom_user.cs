/*功能：生成实体类
 *编码日期:2017/7/5 10:19:38
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
    /// 课堂用户关系数据访问类
    /// </summary>
    public partial class classroom_user
    {
        public bool DeleteByWhere(string wherStr)
        {
            string sql = " delete from ybd_classroom_user where " + wherStr;

            int row = DbHelperSQL.ExecuteSql(sql);

            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取视图记录总数
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