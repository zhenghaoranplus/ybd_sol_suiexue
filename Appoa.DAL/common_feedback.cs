﻿/*功能：数据访问层模板
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
    /// 全局反馈记录数据访问类
    /// </summary>
	[Serializable]
    public partial class common_feedback
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_feedback()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_common_feedback"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_common_feedback");
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
		public int Add(Model.common_feedback model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_common_feedback(
                group_id            
                            ,user_id            
                            ,contents            
                            ,add_time            
                            ,is_read            
                            ,read_time            
             ) Values (
                @group_id               
                            ,@user_id               
                            ,@contents               
                            ,@add_time               
                            ,@is_read               
                            ,@read_time               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@group_id",SqlDbType.Int,4)
                     ,new SqlParameter("@user_id",SqlDbType.Int,4)
                     ,new SqlParameter("@contents",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@is_read",SqlDbType.Int,4)
                     ,new SqlParameter("@read_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.group_id;
            parameters[1].Value=model.user_id;
            parameters[2].Value=model.contents;
            parameters[3].Value=model.add_time;
            parameters[4].Value=model.is_read;
            parameters[5].Value=model.read_time;
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
            strSql.Append(@"DELETE from ybd_common_feedback
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
			strSql.Append("delete from ybd_common_feedback ");
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
		public bool Update(Model.common_feedback model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_common_feedback SET 
                group_id = @group_id
                ,user_id = @user_id
                ,contents = @contents
                ,add_time = @add_time
                ,is_read = @is_read
                ,read_time = @read_time
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@group_id",SqlDbType.Int,4)
                     ,new SqlParameter("@user_id",SqlDbType.Int,4)
                     ,new SqlParameter("@contents",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
                     ,new SqlParameter("@is_read",SqlDbType.Int,4)
                     ,new SqlParameter("@read_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.group_id;
            parameters[2].Value=model.user_id;
            parameters[3].Value=model.contents;
            parameters[4].Value=model.add_time;
            parameters[5].Value=model.is_read;
            parameters[6].Value=model.read_time;
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
            strSql.Append("SELECT TOP 1 " + Model.common_feedback.ALL_FILED + " from ybd_common_feedback ");
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
            strSql.Append(@"SELECT " + Model.common_feedback.ALL_FILED + " FROM ybd_common_feedback ");
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
            strSql.Append(Model.common_feedback.ALL_FILED);
            strSql.Append(" FROM ybd_common_feedback ");
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
            strSql.Append("SELECT " + Model.common_feedback.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_common_feedback T ");
            
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
            strSql.Append(")AS Row, T.*  FROM ybd_common_feedback T ");
            
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
            strSql.Append("SELECT count(1) FROM ybd_common_feedback ");
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