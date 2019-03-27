/*功能：生成实体类
 *编码日期:2017/6/23 15:08:33
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
    /// 资源信息数据访问类
    /// </summary>
    public partial class common_resource
    {
        public bool UpdateField(int id, string field)
        {
            string sql = " update ybd_common_resource set " + field + " where id=@id";
            SqlParameter[] paramters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            paramters[0].Value = id;

            int row = DbHelperSQL.ExecuteSql(sql, paramters);
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

        public bool DeleteByWhere(string whereStr)
        {
            if (!string.IsNullOrEmpty(whereStr))
            {
                string sql = " delete from " + Model.common_resource.TABLE_NAME + " where " + whereStr;
                return true;
            }
            return false;
        }
    }
}