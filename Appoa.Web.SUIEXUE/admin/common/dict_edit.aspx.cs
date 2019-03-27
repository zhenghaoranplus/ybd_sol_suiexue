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
    public partial class dict_edit : Web.UI.ManagePage
    {
        private string action = RequestHelper.GetQueryString("action");
        private int id = 0;
        private int page = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");

            if (this.action == EnumCollection.ActionEnum.Modify.ToString())
            {
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.common_dict().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_common_dict", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindSelect();
                if (this.action == EnumCollection.ActionEnum.Modify.ToString())
                {
                    BindInfo();
                }
            }
        }

        #region 赋值操作

        private void BindSelect()
        {
            this.ddlType.DataSource = EnumCollection.EnumToDataTable(typeof(EnumCollection.dict_type), "key", "val");
            this.ddlType.DataTextField = "key";
            this.ddlType.DataValueField = "val";
            this.ddlType.DataBind();
        }

        private void BindInfo()
        {
            BLL.common_dict bll = new BLL.common_dict();
            Model.common_dict model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            ddlType.SelectedValue = model.type + "";
            txtcontents.Text = model.contents + "";
        }
        #endregion

        private bool DoAdd()
        {
            BLL.common_dict bll = new BLL.common_dict();
            Model.common_dict model = new Model.common_dict();

            model.name = ddlType.SelectedItem.Text;
            model.contents = Convert.ToString(txtcontents.Text);
            model.type = Convert.ToInt32(ddlType.SelectedValue);
            model.type_name = ddlType.SelectedItem.Text;
            model.add_time = System.DateTime.Now;

            int row = bll.Add(model);
            if (row > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加字典项配置信息，主键:" + row); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DoEdit()
        {
            BLL.common_dict bll = new BLL.common_dict();
            Model.common_dict model = bll.GetModel(this.id);

            model.name = ddlType.SelectedItem.Text;
            model.contents = Convert.ToString(txtcontents.Text);
            model.type = Convert.ToInt32(ddlType.SelectedValue);
            model.type_name = ddlType.SelectedItem.Text;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改字典项配置信息，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Add.ToString())
            {
                ChkAdminLevel("_common_dict", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("添加字典项配置信息成功！", "dict_list.aspx");
            }
            if (action == EnumCollection.ActionEnum.Modify.ToString())
            {
                ChkAdminLevel("_common_dict", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改字典项配置信息成功！", "dict_list.aspx?page=" + this.page);
            }
        }
    }
}