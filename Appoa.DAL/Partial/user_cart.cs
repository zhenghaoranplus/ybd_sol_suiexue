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
    /// 购物车表数据访问类
    /// </summary>
    public partial class user_cart
    {
        public int GetRecordSum(string field, string whereStr)
        {
            string sql = " select sum(" + field + ") from ybd_user_cart ";
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

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteListByWhere(string whereStr)
        {
            string sql = " delete from ybd_user_cart where " + whereStr;
            int rows = DbHelperSQL.ExecuteSql(sql);
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