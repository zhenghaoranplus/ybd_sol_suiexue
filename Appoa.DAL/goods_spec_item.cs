/*功能：数据访问层模板
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
	[Serializable]
    public partial class goods_spec_item
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public goods_spec_item()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_goods_spec_item"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_goods_spec_item");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.goods_spec_item model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_goods_spec_item(
                goods_id            
                            ,name            
                            ,parent_id            
                            ,sort            
             ) Values (
                @goods_id               
                            ,@name               
                            ,@parent_id               
                            ,@sort               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@goods_id",SqlDbType.Int,4)
                     ,new SqlParameter("@name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@parent_id",SqlDbType.Int,4)
                     ,new SqlParameter("@sort",SqlDbType.Int,4)
            };
            parameters[0].Value=model.goods_id;
            parameters[1].Value=model.name;
            parameters[2].Value=model.parent_id;
            parameters[3].Value=model.sort;
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"DELETE from ybd_goods_spec_item
            WHERE id = @id");
            
            SqlParameter[] parameters = {
					new SqlParameter("@id", id)
			};

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ybd_goods_spec_item ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.goods_spec_item model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_goods_spec_item SET 
                goods_id = @goods_id
                ,name = @name
                ,parent_id = @parent_id
                ,sort = @sort
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_id",SqlDbType.Int,4)
                     ,new SqlParameter("@name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@parent_id",SqlDbType.Int,4)
                     ,new SqlParameter("@sort",SqlDbType.Int,4)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.goods_id;
            parameters[2].Value=model.name;
            parameters[3].Value=model.parent_id;
            parameters[4].Value=model.sort;
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 " + Model.goods_spec_item.ALL_FILED + " from ybd_goods_spec_item ");
            strSql.Append("WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                new SqlParameter("@id",id)
            };
            
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string whereStr)
        {            
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT " + Model.goods_spec_item.ALL_FILED + " FROM ybd_goods_spec_item ");
            if(whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string whereStr, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(Model.goods_spec_item.ALL_FILED);
            strSql.Append(" FROM ybd_goods_spec_item ");
            if(whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            strSql.Append(" order by " + filedOrder);
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表1
        /// </summary>
        public DataSet GetListByPage(string whereStr, string orderby, int startIndex, int endIndex)
        {            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT " + Model.goods_spec_item.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_goods_spec_item T ");
            
            if(whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 分页获取数据列表2
        /// </summary>
        public DataSet GetListByPage(string DIY_FILED,string whereStr, string orderby, int startIndex, int endIndex)
        {            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT " + DIY_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_goods_spec_item T ");
            
            if(whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 分页获取数据列表3
        /// </summary>
        /// <param name="DIY_FILED">[*|列名]</param>
        /// <param name="TABLE_NAME">[表名|视图名]</param>
        /// <param name="whereStr"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string DIY_FILED, string TABLE_NAME, string whereStr, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT " + DIY_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM " + TABLE_NAME + " T ");

            if (whereStr.Length > 0)
            {
                strSql.Append(" WHERE " + whereStr);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);

            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM ybd_goods_spec_item ");
            if(whereStr.Length > 0)
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
        #endregion
    }
}