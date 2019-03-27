/*功能：数据访问层模板
 *编码日期:2017/11/29 11:05:04
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
    /// 集团子公司信息数据访问类
    /// </summary>
	[Serializable]
    public partial class company_info
    {		
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public company_info()
        {
        }
        
        #region
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("ID", "ybd_company_info"); 
		}
        
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ybd_company_info");
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
		public int Add(Model.company_info model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"Insert Into ybd_company_info(
                logo            
                            ,title            
                            ,img_url            
                            ,video_thumb_img            
                            ,video_url            
                            ,about_us            
                            ,who_are_we_img            
                            ,who_are_we            
                            ,what_can_we_do            
                            ,what_can_we_do_img            
                            ,we_team_img            
                            ,we_team            
                            ,contact_us            
                            ,add_time            
             ) Values (
                @logo               
                            ,@title               
                            ,@img_url               
                            ,@video_thumb_img               
                            ,@video_url               
                            ,@about_us               
                            ,@who_are_we_img               
                            ,@who_are_we               
                            ,@what_can_we_do               
                            ,@what_can_we_do_img               
                            ,@we_team_img               
                            ,@we_team               
                            ,@contact_us               
                            ,@add_time               
             );
            SELECT @@IDENTITY;");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@logo",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@title",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@img_url",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@video_thumb_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@video_url",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@about_us",SqlDbType.NText)
                     ,new SqlParameter("@who_are_we_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@who_are_we",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@what_can_we_do",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@what_can_we_do_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@we_team_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@we_team",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@contact_us",SqlDbType.NText)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.logo;
            parameters[1].Value=model.title;
            parameters[2].Value=model.img_url;
            parameters[3].Value=model.video_thumb_img;
            parameters[4].Value=model.video_url;
            parameters[5].Value=model.about_us;
            parameters[6].Value=model.who_are_we_img;
            parameters[7].Value=model.who_are_we;
            parameters[8].Value=model.what_can_we_do;
            parameters[9].Value=model.what_can_we_do_img;
            parameters[10].Value=model.we_team_img;
            parameters[11].Value=model.we_team;
            parameters[12].Value=model.contact_us;
            parameters[13].Value=model.add_time;
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
            strSql.Append(@"DELETE from ybd_company_info
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
			strSql.Append("delete from ybd_company_info ");
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
		public bool Update(Model.company_info model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(@"UPDATE ybd_company_info SET 
                logo = @logo
                ,title = @title
                ,img_url = @img_url
                ,video_thumb_img = @video_thumb_img
                ,video_url = @video_url
                ,about_us = @about_us
                ,who_are_we_img = @who_are_we_img
                ,who_are_we = @who_are_we
                ,what_can_we_do = @what_can_we_do
                ,what_can_we_do_img = @what_can_we_do_img
                ,we_team_img = @we_team_img
                ,we_team = @we_team
                ,contact_us = @contact_us
                ,add_time = @add_time
            WHERE id = @id");
            
            SqlParameter[] parameters = 
			{
                     new SqlParameter("@id",SqlDbType.Int,4)
                     ,new SqlParameter("@logo",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@title",SqlDbType.NVarChar,50)
                     ,new SqlParameter("@img_url",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@video_thumb_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@video_url",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@about_us",SqlDbType.NText)
                     ,new SqlParameter("@who_are_we_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@who_are_we",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@what_can_we_do",SqlDbType.NVarChar,4000)
                     ,new SqlParameter("@what_can_we_do_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@we_team_img",SqlDbType.NVarChar,255)
                     ,new SqlParameter("@we_team",SqlDbType.NVarChar,500)
                     ,new SqlParameter("@contact_us",SqlDbType.NText)
                     ,new SqlParameter("@add_time",SqlDbType.DateTime,8)
            };
            parameters[0].Value=model.id;
            parameters[1].Value=model.logo;
            parameters[2].Value=model.title;
            parameters[3].Value=model.img_url;
            parameters[4].Value=model.video_thumb_img;
            parameters[5].Value=model.video_url;
            parameters[6].Value=model.about_us;
            parameters[7].Value=model.who_are_we_img;
            parameters[8].Value=model.who_are_we;
            parameters[9].Value=model.what_can_we_do;
            parameters[10].Value=model.what_can_we_do_img;
            parameters[11].Value=model.we_team_img;
            parameters[12].Value=model.we_team;
            parameters[13].Value=model.contact_us;
            parameters[14].Value=model.add_time;
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
            strSql.Append("SELECT TOP 1 " + Model.company_info.ALL_FILED + " from ybd_company_info ");
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
            strSql.Append(@"SELECT " + Model.company_info.ALL_FILED + " FROM ybd_company_info ");
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
            strSql.Append(Model.company_info.ALL_FILED);
            strSql.Append(" FROM ybd_company_info ");
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
            strSql.Append("SELECT " + Model.company_info.ALL_FILED + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM ybd_company_info T ");
            
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
            strSql.Append(")AS Row, T.*  FROM ybd_company_info T ");
            
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
            strSql.Append("SELECT count(1) FROM ybd_company_info ");
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