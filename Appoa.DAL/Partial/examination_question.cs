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
    /// 试卷题目关联数据访问类
    /// </summary>
    public partial class examination_question
    {
        public DataSet GetQuestionByExa(string whereStr)
        {
            string sql = @"select * from View_TestList ";
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }

            return DbHelperSQL.Query(sql);
        }

        public bool Delete(string whereStr)
        {
            string sql = " delete from ybd_examination_question where " + whereStr;

            object obj = DbHelperSQL.ExecuteSql(sql);
            if (obj != null)
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int GetSumCount(string field, string viewname, string where)
        {
            string sql = " select sum(" + field + ") from " + viewname;
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
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

        public DataSet GetViewList(string viewname, string whereStr)
        {
            string sql = "select * from " + viewname;
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }
            return DbHelperSQL.Query(sql);
        }
    }
}