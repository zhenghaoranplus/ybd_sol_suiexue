/*功能：业务逻辑层模板
 *编码日期:2017/6/21 16:35:49
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
    /// 全局消息业务逻辑类
    /// </summary>
	[Serializable]
    public partial class common_message
    {
        private readonly DAL.common_message dal = new DAL.common_message();
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_message()
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
		public int Add(Model.common_message model)
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
		public bool Update(Model.common_message model)
		{
			return dal.Update(model);
		}
        
        /// <summary>
        /// 得到一个对象实体（或者null）
        /// </summary>
        public Model.common_message GetModel(int ID)
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
        public Model.common_message DataRowToModel(DataRow row)
        {
            Model.common_message model = new Model.common_message();
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
                if (row["cover"] != null )//&& row["cover"].ToString() != ""
                {
                    model.cover = Convert.ToString(row["cover"]);
                }
                if (row["title"] != null )//&& row["title"].ToString() != ""
                {
                    model.title = Convert.ToString(row["title"]);
                }
                if (row["subtitle"] != null )//&& row["subtitle"].ToString() != ""
                {
                    model.subtitle = Convert.ToString(row["subtitle"]);
                }
                if (row["contents"] != null )//&& row["contents"].ToString() != ""
                {
                    model.contents = Convert.ToString(row["contents"]);
                }
                if (row["sender_id"] != null )//&& row["sender_id"].ToString() != ""
                {
                    model.sender_id = Convert.ToInt32(row["sender_id"]);
                }
                if (row["receiver_id"] != null )//&& row["receiver_id"].ToString() != ""
                {
                    model.receiver_id = Convert.ToInt32(row["receiver_id"]);
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = Convert.ToDateTime(row["add_time"]);
                }
                if (row["is_read"] != null )//&& row["is_read"].ToString() != ""
                {
                    model.is_read = Convert.ToInt32(row["is_read"]);
                }
                if (row["is_send"] != null )//&& row["is_send"].ToString() != ""
                {
                    model.is_send = Convert.ToInt32(row["is_send"]);
                }
                if (row["send_time"] != null && row["send_time"].ToString() != "")
                {
                    model.send_time = Convert.ToDateTime(row["send_time"]);
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
		public List<Model.common_message> DataTableToList(DataTable dt)
		{
			List<Model.common_message> modelList = new List<Model.common_message>();
            if (dt != null)
            {
				Model.common_message model;
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
        public List<Model.common_message> GetModelList(string whereStr)
        {
            return DataTableToList(dal.GetList(whereStr).Tables[0]);
        }
        
        /// <summary>
        /// 获得Model
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public Model.common_message GetModel(string whereStr)
        {
            DataTable dt = dal.GetList(whereStr).Tables[0];
            Model.common_message model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
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
        public List<Model.common_message> GetModelList(int Top, string whereStr, string filedOrder)
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
        public Model.common_message GetModel(int Top, string whereStr, string filedOrder)
        {
            DataTable dt = dal.GetList(Top, whereStr, filedOrder).Tables[0];
            Model.common_message model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
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
        public List<Model.common_message> GetModelListByPage(string whereStr, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return DataTableToList(dal.GetListByPage(whereStr, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表list<T> 2
        /// </summary>
        public List<Model.common_message> GetModelListByPage(string DIY_FILED, string whereStr, string orderby, int pageIndex, int pageSize)
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