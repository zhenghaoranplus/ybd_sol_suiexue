/*功能：生成实体类
 *编码日期:2017/6/21 16:35:50
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
    /// 订单信息数据访问类
    /// </summary>
    public partial class user_order
    {
        public bool UpdateStatus(int status, string whereStr)
        {
            string sql = " update ybd_user_order set status = @status where " + whereStr;
            SqlParameter[] parameters = { new SqlParameter("@status", SqlDbType.Int, 4) };
            parameters[0].Value = status;

            int rows = DbHelperSQL.ExecuteSql(sql, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}