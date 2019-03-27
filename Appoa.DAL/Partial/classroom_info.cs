/*功能：生成实体类
 *编码日期:2017/7/5 15:12:57
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
    /// 课堂信息数据访问类
    /// </summary>
    public partial class classroom_info
    {
        public DataSet GetList(string viewname, string whereStr, string orderby)
        {
            string sql = " select * from " + viewname;
            if (!string.IsNullOrEmpty(whereStr))
            {
                sql += " where " + whereStr;
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                sql += " order by " + orderby;
            }

            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string strWhere, string parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, course_id, classroom_name, name, tag, chapter_level, parent_id FROM (select cc.*,ci.name as classroom_name from ybd_course_chapter cc inner join ybd_classroom_info ci on cc.course_id = ci.id) as T ");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append(" where " + strWhere);
            strSql.Append(" order by parent_id asc,id asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //创建一个新的DataTable增加一个深度字段
            DataTable newData = new DataTable();
            newData.Columns.Add("id", typeof(string));
            newData.Columns.Add("classroom_id", typeof(string));
            newData.Columns.Add("classroom_name", typeof(string));
            newData.Columns.Add("name", typeof(string));
            newData.Columns.Add("tag", typeof(string));
            newData.Columns.Add("chapter_level", typeof(int));
            newData.Columns.Add("parent_id", typeof(int));
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parentId);
            return newData;
        }

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, string parent_id)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = dr[i]["id"].ToString();
                row["classroom_id"] = dr[i]["course_id"].ToString();
                row["classroom_name"] = dr[i]["classroom_name"].ToString();
                row["name"] = dr[i]["name"].ToString();
                row["tag"] = dr[i]["tag"].ToString();
                row["chapter_level"] = dr[i]["chapter_level"].ToString();
                row["parent_id"] = dr[i]["parent_id"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, dr[i]["id"].ToString());
            }
        }
    }
}