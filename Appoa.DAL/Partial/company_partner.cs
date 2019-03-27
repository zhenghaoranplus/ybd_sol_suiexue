/*功能：生成实体类
 *编码日期:2017/10/18 13:51:30
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
    /// 合作伙伴数据访问类
    /// </summary>
    public partial class company_partner
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

        public bool DeleteByWhere(string whereStr)
        {
            if (!string.IsNullOrEmpty(whereStr))
            {
                string sql = " delete from " + Model.company_partner.TABLE_NAME + " where " + whereStr;
                return true;
            }
            return false;
        }
    }
}