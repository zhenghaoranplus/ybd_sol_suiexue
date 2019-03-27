/*功能：业务逻辑层模板
 *编码日期:2017/7/10 9:25:47
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
    /// 课程章节业务逻辑类
    /// </summary>
	[Serializable]
    public partial class course_chapter
    {
        private readonly DAL.course_chapter dal = new DAL.course_chapter();
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public course_chapter()
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
		public int Add(Model.course_chapter model)
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
		public bool Update(Model.course_chapter model)
		{
			return dal.Update(model);
		}
        
        /// <summary>
        /// 得到一个对象实体（或者null）
        /// </summary>
        public Model.course_chapter GetModel(int ID)
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
        public Model.course_chapter DataRowToModel(DataRow row)
        {
            Model.course_chapter model = new Model.course_chapter();
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
                if (row["course_id"] != null )//&& row["course_id"].ToString() != ""
                {
                    model.course_id = Convert.ToInt32(row["course_id"]);
                }
                if (row["name"] != null )//&& row["name"].ToString() != ""
                {
                    model.name = Convert.ToString(row["name"]);
                }
                if (row["tag"] != null )//&& row["tag"].ToString() != ""
                {
                    model.tag = Convert.ToString(row["tag"]);
                }
                if (row["chapter_level"] != null )//&& row["chapter_level"].ToString() != ""
                {
                    model.chapter_level = Convert.ToInt32(row["chapter_level"]);
                }
                if (row["parent_id"] != null )//&& row["parent_id"].ToString() != ""
                {
                    model.parent_id = Convert.ToInt32(row["parent_id"]);
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
		public List<Model.course_chapter> DataTableToList(DataTable dt)
		{
			List<Model.course_chapter> modelList = new List<Model.course_chapter>();
            if (dt != null)
            {
				Model.course_chapter model;
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
        public List<Model.course_chapter> GetModelList(string whereStr)
        {
            return DataTableToList(dal.GetList(whereStr).Tables[0]);
        }
        
        /// <summary>
        /// 获得Model
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public Model.course_chapter GetModel(string whereStr)
        {
            DataTable dt = dal.GetList(whereStr).Tables[0];
            Model.course_chapter model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
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
        public List<Model.course_chapter> GetModelList(int Top, string whereStr, string filedOrder)
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
        public Model.course_chapter GetModel(int Top, string whereStr, string filedOrder)
        {
            DataTable dt = dal.GetList(Top, whereStr, filedOrder).Tables[0];
            Model.course_chapter model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
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
        public List<Model.course_chapter> GetModelListByPage(string whereStr, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return DataTableToList(dal.GetListByPage(whereStr, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表list<T> 2
        /// </summary>
        public List<Model.course_chapter> GetModelListByPage(string DIY_FILED, string whereStr, string orderby, int pageIndex, int pageSize)
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