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
    /// 用户收藏数据访问类
    /// </summary>
    public partial class user_collection
    {
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteListByWhere(string whereStr)
        {
            string sql = " delete from ybd_user_collection where " + whereStr;
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