/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
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
    /// 课程章节数据访问类
    /// </summary>
    public partial class course_chapter
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string strWhere, string parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, group_id, course_id, course_name, name, tag, chapter_level, parent_id FROM (select cc.*,ci.name as course_name from ybd_course_chapter cc inner join ybd_course_info ci on cc.course_id = ci.id) as T ");
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
            newData.Columns.Add("group_id", typeof(string));
            newData.Columns.Add("course_id", typeof(string));
            newData.Columns.Add("course_name", typeof(string));
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
                row["group_id"] = dr[i]["group_id"].ToString();
                row["course_id"] = dr[i]["course_id"].ToString();
                row["course_name"] = dr[i]["course_name"].ToString();
                row["name"] = dr[i]["name"].ToString();
                row["tag"] = dr[i]["tag"].ToString();
                row["chapter_level"] = dr[i]["chapter_level"].ToString();
                row["parent_id"] = dr[i]["parent_id"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, dr[i]["id"].ToString());
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string viewname, string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM " + viewname);
            if (whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}