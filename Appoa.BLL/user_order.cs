/*功能：业务逻辑层模板
 *编码日期:2017/7/14 16:51:50
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
    /// 订单信息业务逻辑类
    /// </summary>
	[Serializable]
    public partial class user_order
    {
        private readonly DAL.user_order dal = new DAL.user_order();
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_order()
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
		public int Add(Model.user_order model)
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
		public bool Update(Model.user_order model)
		{
			return dal.Update(model);
		}
        
        /// <summary>
        /// 得到一个对象实体（或者null）
        /// </summary>
        public Model.user_order GetModel(int ID)
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
        public Model.user_order DataRowToModel(DataRow row)
        {
            Model.user_order model = new Model.user_order();
            if (row != null)
            {
                if (row["id"] != null )//&& row["id"].ToString() != ""
                {
                    model.id = Convert.ToInt32(row["id"]);
                }
                if (row["order_no"] != null )//&& row["order_no"].ToString() != ""
                {
                    model.order_no = Convert.ToString(row["order_no"]);
                }
                if (row["order_type"] != null )//&& row["order_type"].ToString() != ""
                {
                    model.order_type = Convert.ToInt32(row["order_type"]);
                }
                if (row["trade_no"] != null )//&& row["trade_no"].ToString() != ""
                {
                    model.trade_no = Convert.ToString(row["trade_no"]);
                }
                if (row["user_id"] != null )//&& row["user_id"].ToString() != ""
                {
                    model.user_id = Convert.ToInt32(row["user_id"]);
                }
                if (row["user_name"] != null )//&& row["user_name"].ToString() != ""
                {
                    model.user_name = Convert.ToString(row["user_name"]);
                }
                if (row["payment_way"] != null )//&& row["payment_way"].ToString() != ""
                {
                    model.payment_way = Convert.ToInt32(row["payment_way"]);
                }
                if (row["payment_name"] != null )//&& row["payment_name"].ToString() != ""
                {
                    model.payment_name = Convert.ToString(row["payment_name"]);
                }
                if (row["payment_fee"] != null )//&& row["payment_fee"].ToString() != ""
                {
                    model.payment_fee = Convert.ToDecimal(row["payment_fee"]);
                }
                if (row["payment_time"] != null && row["payment_time"].ToString() != "")
                {
                    model.payment_time = Convert.ToDateTime(row["payment_time"]);
                }
                if (row["express_type"] != null )//&& row["express_type"].ToString() != ""
                {
                    model.express_type = Convert.ToInt32(row["express_type"]);
                }
                if (row["express_man_name"] != null )//&& row["express_man_name"].ToString() != ""
                {
                    model.express_man_name = Convert.ToString(row["express_man_name"]);
                }
                if (row["express_mobile"] != null )//&& row["express_mobile"].ToString() != ""
                {
                    model.express_mobile = Convert.ToString(row["express_mobile"]);
                }
                if (row["express_name"] != null )//&& row["express_name"].ToString() != ""
                {
                    model.express_name = Convert.ToString(row["express_name"]);
                }
                if (row["express_no"] != null )//&& row["express_no"].ToString() != ""
                {
                    model.express_no = Convert.ToString(row["express_no"]);
                }
                if (row["express_money"] != null )//&& row["express_money"].ToString() != ""
                {
                    model.express_money = Convert.ToDecimal(row["express_money"]);
                }
                if (row["accept_name"] != null )//&& row["accept_name"].ToString() != ""
                {
                    model.accept_name = Convert.ToString(row["accept_name"]);
                }
                if (row["post_code"] != null )//&& row["post_code"].ToString() != ""
                {
                    model.post_code = Convert.ToString(row["post_code"]);
                }
                if (row["mobile"] != null )//&& row["mobile"].ToString() != ""
                {
                    model.mobile = Convert.ToString(row["mobile"]);
                }
                if (row["area"] != null )//&& row["area"].ToString() != ""
                {
                    model.area = Convert.ToString(row["area"]);
                }
                if (row["address"] != null )//&& row["address"].ToString() != ""
                {
                    model.address = Convert.ToString(row["address"]);
                }
                if (row["address_id"] != null )//&& row["address_id"].ToString() != ""
                {
                    model.address_id = Convert.ToInt32(row["address_id"]);
                }
                if (row["message"] != null )//&& row["message"].ToString() != ""
                {
                    model.message = Convert.ToString(row["message"]);
                }
                if (row["remark"] != null )//&& row["remark"].ToString() != ""
                {
                    model.remark = Convert.ToString(row["remark"]);
                }
                if (row["use_point"] != null )//&& row["use_point"].ToString() != ""
                {
                    model.use_point = Convert.ToInt32(row["use_point"]);
                }
                if (row["order_amount"] != null )//&& row["order_amount"].ToString() != ""
                {
                    model.order_amount = Convert.ToDecimal(row["order_amount"]);
                }
                if (row["order_coupon_money"] != null )//&& row["order_coupon_money"].ToString() != ""
                {
                    model.order_coupon_money = Convert.ToDecimal(row["order_coupon_money"]);
                }
                if (row["payable_amount"] != null )//&& row["payable_amount"].ToString() != ""
                {
                    model.payable_amount = Convert.ToDecimal(row["payable_amount"]);
                }
                if (row["status"] != null )//&& row["status"].ToString() != ""
                {
                    model.status = Convert.ToInt32(row["status"]);
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = Convert.ToDateTime(row["add_time"]);
                }
                if (row["confirm_time"] != null && row["confirm_time"].ToString() != "")
                {
                    model.confirm_time = Convert.ToDateTime(row["confirm_time"]);
                }
                if (row["complete_time"] != null && row["complete_time"].ToString() != "")
                {
                    model.complete_time = Convert.ToDateTime(row["complete_time"]);
                }
                if (row["del_status"] != null )//&& row["del_status"].ToString() != ""
                {
                    model.del_status = Convert.ToInt32(row["del_status"]);
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
		public List<Model.user_order> DataTableToList(DataTable dt)
		{
			List<Model.user_order> modelList = new List<Model.user_order>();
            if (dt != null)
            {
				Model.user_order model;
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
        public List<Model.user_order> GetModelList(string whereStr)
        {
            return DataTableToList(dal.GetList(whereStr).Tables[0]);
        }
        
        /// <summary>
        /// 获得Model
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public Model.user_order GetModel(string whereStr)
        {
            DataTable dt = dal.GetList(whereStr).Tables[0];
            Model.user_order model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
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
        public List<Model.user_order> GetModelList(int Top, string whereStr, string filedOrder)
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
        public Model.user_order GetModel(int Top, string whereStr, string filedOrder)
        {
            DataTable dt = dal.GetList(Top, whereStr, filedOrder).Tables[0];
            Model.user_order model = dt.Rows.Count > 0 ? DataRowToModel(dt.Rows[0]) : null;
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
        public List<Model.user_order> GetModelListByPage(string whereStr, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return DataTableToList(dal.GetListByPage(whereStr, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表list<T> 2
        /// </summary>
        public List<Model.user_order> GetModelListByPage(string DIY_FILED, string whereStr, string orderby, int pageIndex, int pageSize)
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