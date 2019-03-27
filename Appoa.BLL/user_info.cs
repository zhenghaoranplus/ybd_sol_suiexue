/*功能：业务逻辑层模板
 *编码日期:2017/7/12 11:42:39
 *编码人：阴华伟
 *QQ:577372287
 */
using System;
using System.Data;
using System.Collections.Generic;
using Appoa.Common;

namespace Appoa.BLL
{
    /// <summary>
    /// 用户信息业务逻辑类
    /// </summary>
	[Serializable]
    public partial class user_info
    {
        private readonly DAL.user_info dal = new DAL.user_info();
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_info()
        {
        }
        
        #region base
        
        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.user_info model)
		{
			return dal.Add(model);
		}
        
        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
        
        /// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist)
		{
        
            return dal.DeleteList(idlist);
		}
        
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.user_info model)
		{
			return dal.Update(model);
		}
        
        /// <summary>
        /// 得到一个对象实体（或者null）
        /// </summary>
        public Model.user_info GetModel(int ID)
        {
            DataSet ds = dal.GetModel(ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_info DataRowToModel(DataRow row)
        {
            Model.user_info model = new Model.user_info();
            if (row != null)
            {
                if (row["id"] != null )//&& row["id"].ToString() != ""
                {
                    model.id = Convert.ToInt32(row["id"]);
                }
                if (row["group_id"] != null )//&& row["group_id"].ToString() != ""
                {
                    model.group_id = Convert.ToInt32(row["group_id"]);
                }
                if (row["user_name"] != null )//&& row["user_name"].ToString() != ""
                {
                    model.user_name = Convert.ToString(row["user_name"]);
                }
                if (row["phone"] != null )//&& row["phone"].ToString() != ""
                {
                    model.phone = Convert.ToString(row["phone"]);
                }
                if (row["salt"] != null )//&& row["salt"].ToString() != ""
                {
                    model.salt = Convert.ToString(row["salt"]);
                }
                if (row["user_pwd"] != null )//&& row["user_pwd"].ToString() != ""
                {
                    model.user_pwd = Convert.ToString(row["user_pwd"]);
                }
                if (row["nick_name"] != null )//&& row["nick_name"].ToString() != ""
                {
                    model.nick_name = Convert.ToString(row["nick_name"]);
                }
                if (row["avatar"] != null )//&& row["avatar"].ToString() != ""
                {
                    model.avatar = Convert.ToString(row["avatar"]);
                }
                if (row["integral"] != null )//&& row["integral"].ToString() != ""
                {
                    model.integral = Convert.ToInt32(row["integral"]);
                }
                if (row["school_id"] != null )//&& row["school_id"].ToString() != ""
                {
                    model.school_id = Convert.ToInt32(row["school_id"]);
                }
                if (row["school_name"] != null )//&& row["school_name"].ToString() != ""
                {
                    model.school_name = Convert.ToString(row["school_name"]);
                }
                if (row["college"] != null )//&& row["college"].ToString() != ""
                {
                    model.college = Convert.ToString(row["college"]);
                }
                if (row["job"] != null )//&& row["job"].ToString() != ""
                {
                    model.job = Convert.ToString(row["job"]);
                }
                if (row["course"] != null )//&& row["course"].ToString() != ""
                {
                    model.course = Convert.ToString(row["course"]);
                }
                if (row["line_way"] != null )//&& row["line_way"].ToString() != ""
                {
                    model.line_way = Convert.ToString(row["line_way"]);
                }
                if (row["area"] != null )//&& row["area"].ToString() != ""
                {
                    model.area = Convert.ToString(row["area"]);
                }
                if (row["address"] != null )//&& row["address"].ToString() != ""
                {
                    model.address = Convert.ToString(row["address"]);
                }
                if (row["reg_ip"] != null )//&& row["reg_ip"].ToString() != ""
                {
                    model.reg_ip = Convert.ToString(row["reg_ip"]);
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = Convert.ToDateTime(row["add_time"]);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// 数据列表 table转List<T>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>      
		public List<Model.user_info> DataTableToList(DataTable dt)
		{
			List<Model.user_info> modelList = new List<Model.user_info>();
            if (dt != null)
            {
				Model.user_info model;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					model = DataRowToModel(dt.Rows[i]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}  
        
        /// <summary>
        /// 获得数据列表table
        /// </summary>
        public DataTable GetList(string whereStr)
        {
            return dal.GetList(whereStr).Tables[0];
        }
        
        /// <summary>
        /// 获得数据列表List<T>
        /// </summary>
        public List<Model.user_info> GetModelList(string whereStr)
        {
            return DataTableToList(dal.GetList(whereStr).Tables[0]);
        }
        
        /// <summary>
        /// 获得Model
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public Model.user_info GetModel(string whereStr)
        {
            DataTable dt = dal.GetList(whereStr).Tables[0];
            Model.user_info model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
            return model;
        }
        
		/// <summary>
        /// 获得前几行数据table
        /// </summary>
        /// <param name="Top">大于0取前几行数据，否则取全部</param>
        /// <param name="whereStr">where条件</param>
        /// <param name="filedOrder">排序字段Order By + filedOrder</param>
        /// <returns></returns>
        public DataTable GetList(int Top, string whereStr, string filedOrder)
        {
            return dal.GetList(Top, whereStr, filedOrder).Tables[0];
        }
        
        /// <summary>
        /// 获得前几行数据 List<T>
        /// </summary>
        /// <param name="Top">大于0取前几行数据，否则取全部</param>
        /// <param name="whereStr">where条件</param>
        /// <param name="filedOrder">排序字段Order By + filedOrder (不可为空)</param>
        /// <returns></returns>
        public List<Model.user_info> GetModelList(int Top, string whereStr, string filedOrder)
        {
            return DataTableToList(dal.GetList(Top, whereStr, filedOrder).Tables[0]);
        }
        
        /// <summary>
        /// 获得Model
        /// </summary>
        /// <param name="Top">大于0取前几行数据，否则取全部</param>
        /// <param name="whereStr">where条件</param>
        /// <param name="filedOrder">排序字段Order By + filedOrder (不可为空)</param>
        /// <returns></returns>
        public Model.user_info GetModel(int Top, string whereStr, string filedOrder)
        {
            DataTable dt = dal.GetList(Top, whereStr, filedOrder).Tables[0];
            Model.user_info model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
            return model;
        } 
        
        /// <summary>
		/// 分页获取数据列表1 table
		/// </summary>
        public DataTable GetListByPage(string whereStr, string orderby, int pageIndex, int pageSize)
        {    
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;
            
            return dal.GetListByPage(whereStr, orderby, startIndex, endIndex).Tables[0];
        }
        
        /// <summary>
		/// 分页获取数据列表2 table
		/// </summary>
        public DataTable GetListByPage(string DIY_FILED,string whereStr, string orderby, int pageIndex, int pageSize)
        {    
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;
            
            return dal.GetListByPage(DIY_FILED,whereStr, orderby, startIndex, endIndex).Tables[0];
        }
        
        /// <summary>
        /// 分页获取数据列表3 table
        /// </summary>
        /// <param name="DIY_FILED">[*|列名]</param>
        /// <param name="TABLE_NAME">[表名|视图名]</param>
        /// <param name="whereStr"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetListByPage(string DIY_FILED, string TABLE_NAME, string whereStr, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return dal.GetListByPage(DIY_FILED, TABLE_NAME, whereStr, orderby, startIndex, endIndex).Tables[0];
        }
        
        /// <summary>
        /// 分页获取数据列表list<T> 1
        /// </summary>
        public List<Model.user_info> GetModelListByPage(string whereStr, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return DataTableToList(dal.GetListByPage(whereStr, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表list<T> 2
        /// </summary>
        public List<Model.user_info> GetModelListByPage(string DIY_FILED, string whereStr, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return DataTableToList(dal.GetListByPage(DIY_FILED, whereStr, orderby, startIndex, endIndex).Tables[0]);
        }
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
		public int GetRecordCount(string whereStr)
		{
            return dal.GetRecordCount(whereStr);
		}
        #endregion
    }
}