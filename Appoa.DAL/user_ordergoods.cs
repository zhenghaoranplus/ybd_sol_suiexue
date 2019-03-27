/*功能：数据访问层模板
 *编码日期:2017/7/14 9:44:51
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
    /// 订单购买商品表数据访问类
    /// </summary>
	[Serializable]
    public partial class user_ordergoods
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_ordergoods()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_user_ordergoods"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_user_ordergoods");
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
		public int Add(Model.user_ordergoods model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_user_ordergoods(
                order_id            
                            ,goods_group            
                            ,goods_id            
                            ,goods_title            
                            ,goods_subtitle            
                            ,goods_spec            
                            ,goods_stock            
                            ,img_url            
                            ,goods_oprice            
                            ,goods_price            
                            ,quantity            
             ) Values (
                @order_id               
                            ,@goods_group               
                            ,@goods_id               
                            ,@goods_title               
                            ,@goods_subtitle               
                            ,@goods_spec               
                            ,@goods_stock               
                            ,@img_url               
                            ,@goods_oprice               
                            ,@goods_price               
                            ,@quantity               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@order_id",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_group",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_id",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_title",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@goods_subtitle",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@goods_spec",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@goods_stock",SqlDbType.Int,4)
                     ,new SqlParameter("@img_url",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@goods_oprice",SqlDbType.Money,8)
                     ,new SqlParameter("@goods_price",SqlDbType.Money,8)
                     ,new SqlParameter("@quantity",SqlDbType.Int,4)
            };
            parameters[0].Value=model.order_id;
            parameters[1].Value=model.goods_group;
            parameters[2].Value=model.goods_id;
            parameters[3].Value=model.goods_title;
            parameters[4].Value=model.goods_subtitle;
            parameters[5].Value=model.goods_spec;
            parameters[6].Value=model.goods_stock;
            parameters[7].Value=model.img_url;
            parameters[8].Value=model.goods_oprice;
            parameters[9].Value=model.goods_price;
            parameters[10].Value=model.quantity;
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
            strSql.Append(@"DELETE from ybd_user_ordergoods
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
			strSql.Append("delete from ybd_user_ordergoods ");
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
		public bool Update(Model.user_ordergoods model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_user_ordergoods SET 
                order_id = @order_id
                ,goods_group = @goods_group
                ,goods_id = @goods_id
                ,goods_title = @goods_title
                ,goods_subtitle = @goods_subtitle
                ,goods_spec = @goods_spec
                ,goods_stock = @goods_stock
                ,img_url = @img_url
                ,goods_oprice = @goods_oprice
                ,goods_price = @goods_price
                ,quantity = @quantity
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@order_id",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_group",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_id",SqlDbType.Int,4)
                     ,new SqlParameter("@goods_title",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@goods_subtitle",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@goods_spec",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@goods_stock",SqlDbType.Int,4)
                     ,new SqlParameter("@img_url",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@goods_oprice",SqlDbType.Money,8)
                     ,new SqlParameter("@goods_price",SqlDbType.Money,8)
                     ,new SqlParameter("@quantity",SqlDbType.Int,4)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.order_id;
            parameters[2].Value=model.goods_group;
            parameters[3].Value=model.goods_id;
            parameters[4].Value=model.goods_title;
            parameters[5].Value=model.goods_subtitle;
            parameters[6].Value=model.goods_spec;
            parameters[7].Value=model.goods_stock;
            parameters[8].Value=model.img_url;
            parameters[9].Value=model.goods_oprice;
            parameters[10].Value=model.goods_price;
            parameters[11].Value=model.quantity;
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
            strSql.Append("SELECT TOP 1 " + Model.user_ordergoods.ALL_FILED + " from ybd_user_ordergoods ");
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
            strSql.Append(@"SELECT " + Model.user_ordergoods.ALL_FILED + " FROM ybd_user_ordergoods ");
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
            strSql.Append(Model.user_ordergoods.ALL_FILED);
            strSql.Append(" FROM ybd_user_ordergoods ");
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
            strSql.Append("SELECT " + Model.user_ordergoods.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_user_ordergoods T ");
            
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
            strSql.Append(")AS Row, T.*  FROM ybd_user_ordergoods T ");
            
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
            strSql.Append("SELECT count(1) FROM ybd_user_ordergoods ");
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