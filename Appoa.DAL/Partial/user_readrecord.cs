/*功能：生成实体类
 *编码日期:2017/7/19 9:30:55
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
    /// 用户阅读记录数据访问类
    /// </summary>
    public partial class user_readrecord
    {
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteListByWhere(string whereStr)
        {
            string sql = " delete from ybd_user_readrecord where " + whereStr;
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