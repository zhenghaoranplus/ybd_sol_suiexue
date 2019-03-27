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
    /// 全局分类数据访问类
    /// </summary>
    public partial class common_category
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string strWhere, string parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from (select cc.*,isnull(cp.name,'') as parent_name FROM ybd_common_category cc left join ybd_common_category cp on cp.id = cc.parent_id ) as t ");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append(" where " + strWhere);
            strSql.Append(" order by sort asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //创建一个新的DataTable增加一个深度字段
            DataTable newData = new DataTable();
            newData.Columns.Add("Id", typeof(string));
            newData.Columns.Add("name", typeof(string));
            newData.Columns.Add("img_src", typeof(string));
            newData.Columns.Add("category_level", typeof(int));
            newData.Columns.Add("sort", typeof(int));
            newData.Columns.Add("parent_id", typeof(int));
            newData.Columns.Add("parent_name", typeof(string));
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
                row["Id"] = dr[i]["Id"].ToString();
                row["name"] = dr[i]["name"].ToString();
                row["img_src"] = dr[i]["img_src"].ToString();
                row["category_level"] = dr[i]["category_level"].ToString();
                row["sort"] = dr[i]["sort"].ToString();
                row["parent_id"] = dr[i]["parent_id"].ToString();
                row["parent_name"] = dr[i]["parent_name"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, dr[i]["Id"].ToString());
            }
        }

        public DataSet GetViewList(string DIY_FILED, string viewname, string whereStr, string orderby)
        {
            string sql = "select " + DIY_FILED + " from " + viewname;
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

        public bool UpdateField(int id, string field)
        {
            string sql = " update ybd_common_category set " + field + " where id = " + id;

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