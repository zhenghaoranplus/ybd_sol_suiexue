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
    /// 积分记录数据访问类
    /// </summary>
    public partial class user_integral
    {
        public int GetRecordSum(string field, string whereStr)
        {
            string sql = " select sum(" + field + ") from ybd_user_integral ";
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