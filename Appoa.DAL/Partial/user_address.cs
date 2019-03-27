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
    /// 收货地址数据访问类
    /// </summary>
    public partial class user_address
    {
        public bool SetDefault(int user_id, int aid)
        {
            string sql = " update ybd_user_address set is_default = 2 where user_id = @userid and id <> @id;update ybd_user_address set is_default = 1 where id=@id;";
            SqlParameter[] parameters = { new SqlParameter("@userid", SqlDbType.Int, 4), new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = user_id;
            parameters[1].Value = aid;

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