﻿/*功能：数据访问层模板
 *编码日期:2017/7/12 11:42:39
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
    /// 用户信息数据访问类
    /// </summary>
	[Serializable]
    public partial class user_info
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_info()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_user_info"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_user_info");
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
		public int Add(Model.user_info model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_user_info(
                group_id            
                            ,user_name            
                            ,phone            
                            ,salt            
                            ,user_pwd            
                            ,nick_name            
                            ,avatar            
                            ,integral            
                            ,school_id            
                            ,school_name            
                            ,college            
                            ,job            
                            ,course            
                            ,line_way            
                            ,area            
                            ,address            
                            ,reg_ip            
                            ,add_time            
             ) Values (
                @group_id               
                            ,@user_name               
                            ,@phone               
                            ,@salt               
                            ,@user_pwd               
                            ,@nick_name               
                            ,@avatar               
                            ,@integral               
                            ,@school_id               
                            ,@school_name               
                            ,@college               
                            ,@job               
                            ,@course               
                            ,@line_way               
                            ,@area               
                            ,@address               
                            ,@reg_ip               
                            ,@add_time               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@group_id",SqlDbType.Int,4)
                     ,new SqlParameter("@user_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@phone",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@salt",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@user_pwd",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@nick_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@avatar",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@integral",SqlDbType.Int,4)
                     ,new SqlParameter("@school_id",SqlDbType.Int,4)
                     ,new SqlParameter("@school_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@college",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@job",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@course",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@line_way",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@area",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@address",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@reg_ip",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.group_id;
            parameters[1].Value=model.user_name;
            parameters[2].Value=model.phone;
            parameters[3].Value=model.salt;
            parameters[4].Value=model.user_pwd;
            parameters[5].Value=model.nick_name;
            parameters[6].Value=model.avatar;
            parameters[7].Value=model.integral;
            parameters[8].Value=model.school_id;
            parameters[9].Value=model.school_name;
            parameters[10].Value=model.college;
            parameters[11].Value=model.job;
            parameters[12].Value=model.course;
            parameters[13].Value=model.line_way;
            parameters[14].Value=model.area;
            parameters[15].Value=model.address;
            parameters[16].Value=model.reg_ip;
            parameters[17].Value=model.add_time;
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
            strSql.Append(@"DELETE from ybd_user_info
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
			strSql.Append("delete from ybd_user_info ");
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
		public bool Update(Model.user_info model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_user_info SET 
                group_id = @group_id
                ,user_name = @user_name
                ,phone = @phone
                ,salt = @salt
                ,user_pwd = @user_pwd
                ,nick_name = @nick_name
                ,avatar = @avatar
                ,integral = @integral
                ,school_id = @school_id
                ,school_name = @school_name
                ,college = @college
                ,job = @job
                ,course = @course
                ,line_way = @line_way
                ,area = @area
                ,address = @address
                ,reg_ip = @reg_ip
                ,add_time = @add_time
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@group_id",SqlDbType.Int,4)
                     ,new SqlParameter("@user_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@phone",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@salt",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@user_pwd",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@nick_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@avatar",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@integral",SqlDbType.Int,4)
                     ,new SqlParameter("@school_id",SqlDbType.Int,4)
                     ,new SqlParameter("@school_name",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@college",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@job",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@course",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@line_way",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@area",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@address",SqlDbType.NVarChar,200)
                     ,new SqlParameter("@reg_ip",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.group_id;
            parameters[2].Value=model.user_name;
            parameters[3].Value=model.phone;
            parameters[4].Value=model.salt;
            parameters[5].Value=model.user_pwd;
            parameters[6].Value=model.nick_name;
            parameters[7].Value=model.avatar;
            parameters[8].Value=model.integral;
            parameters[9].Value=model.school_id;
            parameters[10].Value=model.school_name;
            parameters[11].Value=model.college;
            parameters[12].Value=model.job;
            parameters[13].Value=model.course;
            parameters[14].Value=model.line_way;
            parameters[15].Value=model.area;
            parameters[16].Value=model.address;
            parameters[17].Value=model.reg_ip;
            parameters[18].Value=model.add_time;
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
            strSql.Append("SELECT TOP 1 " + Model.user_info.ALL_FILED + " from ybd_user_info ");
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
            strSql.Append(@"SELECT " + Model.user_info.ALL_FILED + " FROM ybd_user_info ");
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
            strSql.Append(Model.user_info.ALL_FILED);
            strSql.Append(" FROM ybd_user_info ");
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
            strSql.Append("SELECT " + Model.user_info.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_user_info T ");
            
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
            strSql.Append(")AS Row, T.*  FROM ybd_user_info T ");
            
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
            strSql.Append("SELECT count(1) FROM ybd_user_info ");
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