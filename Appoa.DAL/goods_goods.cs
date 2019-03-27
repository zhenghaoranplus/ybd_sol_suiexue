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
    /// 商品信息数据访问类
    /// </summary>
	[Serializable]
    public partial class goods_goods
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public goods_goods()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_goods_goods"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_goods_goods");
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
		public int Add(Model.goods_goods model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_goods_goods(
                ct_id            
                            ,group_id            
                            ,category_id            
                            ,title            
                            ,subtitle            
                            ,img_src            
                            ,oprice            
                            ,price            
                            ,parameters            
                            ,details            
                            ,sales_num            
                            ,status            
                            ,sj_time            
                            ,xj_time            
                            ,add_time            
             ) Values (
                @ct_id               
                            ,@group_id               
                            ,@category_id               
                            ,@title               
                            ,@subtitle               
                            ,@img_src               
                            ,@oprice               
                            ,@price               
                            ,@parameters               
                            ,@details               
                            ,@sales_num               
                            ,@status               
                            ,@sj_time               
                            ,@xj_time               
                            ,@add_time               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@ct_id",SqlDbType.Int,4)
                     ,new SqlParameter("@group_id",SqlDbType.Int,4)
                     ,new SqlParameter("@category_id",SqlDbType.Int,4)
                     ,new SqlParameter("@title",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@subtitle",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@img_src",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@oprice",SqlDbType.Money,8)
                     ,new SqlParameter("@price",SqlDbType.Money,8)
                     ,new SqlParameter("@parameters",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@details",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@sales_num",SqlDbType.Int,4)
                     ,new SqlParameter("@status",SqlDbType.Int,4)
                     ,new SqlParameter("@sj_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@xj_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.ct_id;
            parameters[1].Value=model.group_id;
            parameters[2].Value=model.category_id;
            parameters[3].Value=model.title;
            parameters[4].Value=model.subtitle;
            parameters[5].Value=model.img_src;
            parameters[6].Value=model.oprice;
            parameters[7].Value=model.price;
            parameters[8].Value=model.parameters;
            parameters[9].Value=model.details;
            parameters[10].Value=model.sales_num;
            parameters[11].Value=model.status;
            parameters[12].Value=model.sj_time;
            parameters[13].Value=model.xj_time;
            parameters[14].Value=model.add_time;
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
            strSql.Append(@"DELETE from ybd_goods_goods
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
			strSql.Append("delete from ybd_goods_goods ");
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
		public bool Update(Model.goods_goods model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_goods_goods SET 
                ct_id = @ct_id
                ,group_id = @group_id
                ,category_id = @category_id
                ,title = @title
                ,subtitle = @subtitle
                ,img_src = @img_src
                ,oprice = @oprice
                ,price = @price
                ,parameters = @parameters
                ,details = @details
                ,sales_num = @sales_num
                ,status = @status
                ,sj_time = @sj_time
                ,xj_time = @xj_time
                ,add_time = @add_time
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@ct_id",SqlDbType.Int,4)
                     ,new SqlParameter("@group_id",SqlDbType.Int,4)
                     ,new SqlParameter("@category_id",SqlDbType.Int,4)
                     ,new SqlParameter("@title",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@subtitle",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@img_src",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@oprice",SqlDbType.Money,8)
                     ,new SqlParameter("@price",SqlDbType.Money,8)
                     ,new SqlParameter("@parameters",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@details",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@sales_num",SqlDbType.Int,4)
                     ,new SqlParameter("@status",SqlDbType.Int,4)
                     ,new SqlParameter("@sj_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@xj_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.ct_id;
            parameters[2].Value=model.group_id;
            parameters[3].Value=model.category_id;
            parameters[4].Value=model.title;
            parameters[5].Value=model.subtitle;
            parameters[6].Value=model.img_src;
            parameters[7].Value=model.oprice;
            parameters[8].Value=model.price;
            parameters[9].Value=model.parameters;
            parameters[10].Value=model.details;
            parameters[11].Value=model.sales_num;
            parameters[12].Value=model.status;
            parameters[13].Value=model.sj_time;
            parameters[14].Value=model.xj_time;
            parameters[15].Value=model.add_time;
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
            strSql.Append("SELECT TOP 1 " + Model.goods_goods.ALL_FILED + " from ybd_goods_goods ");
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
            strSql.Append(@"SELECT " + Model.goods_goods.ALL_FILED + " FROM ybd_goods_goods ");
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
            strSql.Append(Model.goods_goods.ALL_FILED);
            strSql.Append(" FROM ybd_goods_goods ");
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
            strSql.Append("SELECT " + Model.goods_goods.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_goods_goods T ");
            
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
            strSql.Append(")AS Row, T.*  FROM ybd_goods_goods T ");
            
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
            strSql.Append("SELECT count(1) FROM ybd_goods_goods ");
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