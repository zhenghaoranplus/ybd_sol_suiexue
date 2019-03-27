/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
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
    /// 试卷信息数据访问类
    /// </summary>
    public partial class common_examination
    {
        /// <summary>
        /// 查询我的错题试卷
        /// </summary>
        /// <returns></returns>
        public DataSet GetMyQuestionByPage(int userid, string orderby, int startIndex, int endIndex)
        {
            StringBuilder stb = new StringBuilder();
            stb.Append("SELECT * FROM ( ");
            stb.Append(" SELECT ROW_NUMBER() OVER (");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                stb.Append("ORDER BY T." + orderby);
            }
            else
            {
                stb.Append("ORDER BY T.ID desc");
            }

            stb.Append(")AS Row, T.*  FROM ");
            stb.Append("(select * from ybd_common_examination where id in (");
            stb.Append("select distinct exa_id from ybd_answer_record where is_truth = 2 and user_id = @userid)) T");
            stb.Append(" ) TT");
            stb.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);

            SqlParameter[] parameters = { new SqlParameter("@userid", SqlDbType.Int, 4) };
            parameters[0].Value = userid;

            return DbHelperSQL.Query(stb.ToString(), parameters);
        }
    }
}