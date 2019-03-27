/*功能：生成实体类
 *编码日期:2017/6/21 16:35:47
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
    /// 全局相册数据访问类
    /// </summary>
    public partial class common_albums
    {
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"DELETE from ybd_common_albums");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
                if (rows > 0)
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
    }
}