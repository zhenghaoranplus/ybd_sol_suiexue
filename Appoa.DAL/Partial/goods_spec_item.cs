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
    /// 商品规格项数据访问类
    /// </summary>
    public partial class goods_spec_item
    {
        /// <summary>
        /// 根据父级分类id查询分类
        /// </summary>
        public DataSet GetListByParentId(int goodsid, int parentid)
        {
            string sql = "SELECT * FROM ybd_goods_spec_item WHERE goods_id = @goodsid and parent_id = @parentid order by sort";
            SqlParameter[] parameters = { new SqlParameter("@goodsid", SqlDbType.Int, 4), new SqlParameter("@parentid", SqlDbType.Int, 4) };
            parameters[0].Value = goodsid;
            parameters[1].Value = parentid;

            return DbHelperSQL.Query(sql, parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,goods_id,name,parent_id,sort ");
            strSql.Append(" FROM ybd_goods_spec_item where goods_id=" + goodsId + " order by parent_id asc,sort asc");
            DataSet ds = DBUtility.DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //创建一个新的DataTable增加一个深度字段
            DataTable newData = new DataTable();
            newData.Columns.Add("id", typeof(string));
            newData.Columns.Add("goods_id", typeof(string));
            newData.Columns.Add("name", typeof(string));
            newData.Columns.Add("parent_id", typeof(string));
            newData.Columns.Add("sort", typeof(int));
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, goodsId, "0", 0);
            return newData;
        }

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, string goods_id, string parend_id, int class_layer)
        {
            class_layer++;
            DataRow[] dr = oldData.Select("goods_id=" + goods_id + " and parent_id=" + parend_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = dr[i]["id"].ToString();
                row["name"] = dr[i]["name"].ToString();
                row["parent_id"] = dr[i]["parent_id"].ToString();
                row["sort"] = dr[i]["sort"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, goods_id, dr[i]["id"].ToString(), class_layer);
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteNew(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("delete from ybd_goods_spec_type where spec={0} ", id.ToString()));
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            strSql.Append(string.Format("delete from ybd_goods_spec_item where parent_id={0}", id.ToString()));
            rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            strSql.Append("delete from ybd_goods_spec_item ");
            strSql.Append(" where id=" + id);
            rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateField(int id, string field)
        {
            string sql = " update ybd_goods_spec_item set " + field + " where id=@id ";
            SqlParameter[] paramters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            paramters[0].Value = id;

            int row = DbHelperSQL.ExecuteSql(sql, paramters);
            if (row > 0)
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