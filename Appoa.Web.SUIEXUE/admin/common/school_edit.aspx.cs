using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class school_edit : Web.UI.ManagePage
    {
        protected string action = EnumCollection.ActionEnum.Add.ToString();
        private int id = 0;
        private int page = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumCollection.ActionEnum.Modify.ToString())
            {
                this.action = EnumCollection.ActionEnum.Modify.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                this.page = RequestHelper.GetQueryInt("page");

                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.common_school().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_common_school_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo();
                }
            }
        }

        #region 赋值操作
        private void ShowInfo()
        {
            BLL.common_school bll = new BLL.common_school();
            Model.common_school model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
            txtname.Text = model.name + "";
            txtsort.Text = model.sort + "";
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            BLL.common_school bll = new BLL.common_school();
            Model.common_school model = new Model.common_school();

            model.name = Convert.ToString(txtname.Text);
            model.sort = Convert.ToInt32(txtsort.Text);
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "添加学校信息，主键:" + id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit()
        {
            bool result = false;
            BLL.common_school bll = new BLL.common_school();
            Model.common_school model = bll.GetModel(this.id);

            model.name = Convert.ToString(txtname.Text);
            model.sort = Convert.ToInt32(txtsort.Text);

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改学校信息，主键:" + this.id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_common_school_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改学校信息成功！", "school_list.aspx?page=" + this.page);
            }
            else //添加
            {
                ChkAdminLevel("_common_school_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加学校信息成功！", "school_list.aspx");
            }
        }
    }
}