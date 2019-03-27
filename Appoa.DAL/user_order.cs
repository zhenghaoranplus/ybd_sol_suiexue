/*功能：数据访问层模板
 *编码日期:2017/7/14 16:51:50
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
    /// 订单信息数据访问类
    /// </summary>
	[Serializable]
    public partial class user_order
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_order()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_user_order"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_user_order");
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
		public int Add(Model.user_order model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_user_order(
                order_no            
                            ,order_type            
                            ,trade_no            
                            ,user_id            
                            ,user_name            
                            ,payment_way            
                            ,payment_name            
                            ,payment_fee            
                            ,payment_time            
                            ,express_type            
                            ,express_man_name            
                            ,express_mobile            
                            ,express_name            
                            ,express_no            
                            ,express_money            
                            ,accept_name            
                            ,post_code            
                            ,mobile            
                            ,area            
                            ,address            
                            ,address_id            
                            ,message            
                            ,remark            
                            ,use_point            
                            ,order_amount            
                            ,order_coupon_money            
                            ,payable_amount            
                            ,status            
                            ,add_time            
                            ,confirm_time            
                            ,complete_time            
                            ,del_status            
             ) Values (
                @order_no               
                            ,@order_type               
                            ,@trade_no               
                            ,@user_id               
                            ,@user_name               
                            ,@payment_way               
                            ,@payment_name               
                            ,@payment_fee               
                            ,@payment_time               
                            ,@express_type               
                            ,@express_man_name               
                            ,@express_mobile               
                            ,@express_name               
                            ,@express_no               
                            ,@express_money               
                            ,@accept_name               
                            ,@post_code               
                            ,@mobile               
                            ,@area               
                            ,@address               
                            ,@address_id               
                            ,@message               
                            ,@remark               
                            ,@use_point               
                            ,@order_amount               
                            ,@order_coupon_money               
                            ,@payable_amount               
                            ,@status               
                            ,@add_time               
                            ,@confirm_time               
                            ,@complete_time               
                            ,@del_status               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@order_no",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@order_type",SqlDbType.Int,4)
                     ,new SqlParameter("@trade_no",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@user_id",SqlDbType.Int,4)
                     ,new SqlParameter("@user_name",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@payment_way",SqlDbType.Int,4)
                     ,new SqlParameter("@payment_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@payment_fee",SqlDbType.Money,8)
                     ,new SqlParameter("@payment_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@express_type",SqlDbType.Int,4)
                     ,new SqlParameter("@express_man_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@express_mobile",SqlDbType.NVarChar,20)
                     ,new SqlParameter("@express_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@express_no",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@express_money",SqlDbType.Money,8)
                     ,new SqlParameter("@accept_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@post_code",SqlDbType.NVarChar,20)
                     ,new SqlParameter("@mobile",SqlDbType.NVarChar,20)
                     ,new SqlParameter("@area",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@address",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@address_id",SqlDbType.Int,4)
                     ,new SqlParameter("@message",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@remark",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@use_point",SqlDbType.Int,4)
                     ,new SqlParameter("@order_amount",SqlDbType.Money,8)
                     ,new SqlParameter("@order_coupon_money",SqlDbType.Money,8)
                     ,new SqlParameter("@payable_amount",SqlDbType.Money,8)
                     ,new SqlParameter("@status",SqlDbType.Int,4)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@confirm_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@complete_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@del_status",SqlDbType.Int,4)
            };
            parameters[0].Value=model.order_no;
            parameters[1].Value=model.order_type;
            parameters[2].Value=model.trade_no;
            parameters[3].Value=model.user_id;
            parameters[4].Value=model.user_name;
            parameters[5].Value=model.payment_way;
            parameters[6].Value=model.payment_name;
            parameters[7].Value=model.payment_fee;
            parameters[8].Value=model.payment_time;
            parameters[9].Value=model.express_type;
            parameters[10].Value=model.express_man_name;
            parameters[11].Value=model.express_mobile;
            parameters[12].Value=model.express_name;
            parameters[13].Value=model.express_no;
            parameters[14].Value=model.express_money;
            parameters[15].Value=model.accept_name;
            parameters[16].Value=model.post_code;
            parameters[17].Value=model.mobile;
            parameters[18].Value=model.area;
            parameters[19].Value=model.address;
            parameters[20].Value=model.address_id;
            parameters[21].Value=model.message;
            parameters[22].Value=model.remark;
            parameters[23].Value=model.use_point;
            parameters[24].Value=model.order_amount;
            parameters[25].Value=model.order_coupon_money;
            parameters[26].Value=model.payable_amount;
            parameters[27].Value=model.status;
            parameters[28].Value=model.add_time;
            parameters[29].Value=model.confirm_time;
            parameters[30].Value=model.complete_time;
            parameters[31].Value=model.del_status;
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
            strSql.Append(@"DELETE from ybd_user_order
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
			strSql.Append("delete from ybd_user_order ");
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
		public bool Update(Model.user_order model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_user_order SET 
                order_no = @order_no
                ,order_type = @order_type
                ,trade_no = @trade_no
                ,user_id = @user_id
                ,user_name = @user_name
                ,payment_way = @payment_way
                ,payment_name = @payment_name
                ,payment_fee = @payment_fee
                ,payment_time = @payment_time
                ,express_type = @express_type
                ,express_man_name = @express_man_name
                ,express_mobile = @express_mobile
                ,express_name = @express_name
                ,express_no = @express_no
                ,express_money = @express_money
                ,accept_name = @accept_name
                ,post_code = @post_code
                ,mobile = @mobile
                ,area = @area
                ,address = @address
                ,address_id = @address_id
                ,message = @message
                ,remark = @remark
                ,use_point = @use_point
                ,order_amount = @order_amount
                ,order_coupon_money = @order_coupon_money
                ,payable_amount = @payable_amount
                ,status = @status
                ,add_time = @add_time
                ,confirm_time = @confirm_time
                ,complete_time = @complete_time
                ,del_status = @del_status
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@order_no",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@order_type",SqlDbType.Int,4)
                     ,new SqlParameter("@trade_no",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@user_id",SqlDbType.Int,4)
                     ,new SqlParameter("@user_name",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@payment_way",SqlDbType.Int,4)
                     ,new SqlParameter("@payment_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@payment_fee",SqlDbType.Money,8)
                     ,new SqlParameter("@payment_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@express_type",SqlDbType.Int,4)
                     ,new SqlParameter("@express_man_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@express_mobile",SqlDbType.NVarChar,20)
                     ,new SqlParameter("@express_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@express_no",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@express_money",SqlDbType.Money,8)
                     ,new SqlParameter("@accept_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@post_code",SqlDbType.NVarChar,20)
                     ,new SqlParameter("@mobile",SqlDbType.NVarChar,20)
                     ,new SqlParameter("@area",SqlDbType.NVarChar,100)
                     ,new SqlParameter("@address",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@address_id",SqlDbType.Int,4)
                     ,new SqlParameter("@message",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@remark",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@use_point",SqlDbType.Int,4)
                     ,new SqlParameter("@order_amount",SqlDbType.Money,8)
                     ,new SqlParameter("@order_coupon_money",SqlDbType.Money,8)
                     ,new SqlParameter("@payable_amount",SqlDbType.Money,8)
                     ,new SqlParameter("@status",SqlDbType.Int,4)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@confirm_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@complete_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@del_status",SqlDbType.Int,4)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.order_no;
            parameters[2].Value=model.order_type;
            parameters[3].Value=model.trade_no;
            parameters[4].Value=model.user_id;
            parameters[5].Value=model.user_name;
            parameters[6].Value=model.payment_way;
            parameters[7].Value=model.payment_name;
            parameters[8].Value=model.payment_fee;
            parameters[9].Value=model.payment_time;
            parameters[10].Value=model.express_type;
            parameters[11].Value=model.express_man_name;
            parameters[12].Value=model.express_mobile;
            parameters[13].Value=model.express_name;
            parameters[14].Value=model.express_no;
            parameters[15].Value=model.express_money;
            parameters[16].Value=model.accept_name;
            parameters[17].Value=model.post_code;
            parameters[18].Value=model.mobile;
            parameters[19].Value=model.area;
            parameters[20].Value=model.address;
            parameters[21].Value=model.address_id;
            parameters[22].Value=model.message;
            parameters[23].Value=model.remark;
            parameters[24].Value=model.use_point;
            parameters[25].Value=model.order_amount;
            parameters[26].Value=model.order_coupon_money;
            parameters[27].Value=model.payable_amount;
            parameters[28].Value=model.status;
            parameters[29].Value=model.add_time;
            parameters[30].Value=model.confirm_time;
            parameters[31].Value=model.complete_time;
            parameters[32].Value=model.del_status;
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
            strSql.Append("SELECT TOP 1 " + Model.user_order.ALL_FILED + " from ybd_user_order ");
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
            strSql.Append(@"SELECT " + Model.user_order.ALL_FILED + " FROM ybd_user_order ");
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
            strSql.Append(Model.user_order.ALL_FILED);
            strSql.Append(" FROM ybd_user_order ");
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
            strSql.Append("SELECT " + Model.user_order.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_user_order T ");
            
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
            strSql.Append(")AS Row, T.*  FROM ybd_user_order T ");
            
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
            strSql.Append("SELECT count(1) FROM ybd_user_order ");
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