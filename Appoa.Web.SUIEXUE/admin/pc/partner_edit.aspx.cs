using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;
using System.Data;

namespace Appoa.Manage.admin.pc
{
    public partial class partner_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected int page = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (this.id > 0)
            {
                if (!new BLL.company_partner().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_partner_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindSelect();

                if (action == EnumCollection.ActionEnum.Modify.ToString())
                {
                    BindInfo();
                }
            }
        }

        #region 赋值操作
        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.YesOrNot), "name", "id");
            this.rbtnIsShow.DataSource = dt;
            this.rbtnIsShow.DataValueField = "id";
            this.rbtnIsShow.DataTextField = "name";
            this.rbtnIsShow.DataBind();
            this.rbtnIsShow.SelectedIndex = 0;
        }

        private void BindInfo()
        {
            BLL.company_partner bll = new BLL.company_partner();
            Model.company_partner model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            txtlogo.Text = model.logo + "";
            txttitle.Text = model.title + "";
            txtvideo_url.Text = model.video_url + "";
            this.rbtnIsShow.SelectedValue = model.is_show + "";
            txtsort.Text = model.sort + "";
        }
        #endregion

        private bool DoAdd()
        {
            Model.company_partner model = new Model.company_partner();
            BLL.company_partner bll = new BLL.company_partner();

            model.company_id = 0;
            model.logo = Convert.ToString(txtlogo.Text);
            model.title = Convert.ToString(txttitle.Text);
            model.video_url = Convert.ToString(txtvideo_url.Text);
            model.details = "";
            model.is_show = Convert.ToInt32(this.rbtnIsShow.SelectedValue);
            model.sort = Convert.ToInt32(txtsort.Text);
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加合作伙伴信息，主键:" + id); //记录日志
                return true;
            }
            return false;
        }

        private bool DoEdit()
        {
            BLL.company_partner bll = new BLL.company_partner();
            Model.company_partner model = bll.GetModel(this.id);

            model.logo = Convert.ToString(txtlogo.Text);
            model.title = Convert.ToString(txttitle.Text);
            model.video_url = Convert.ToString(txtvideo_url.Text);
            model.details = "";
            model.is_show = Convert.ToInt32(this.rbtnIsShow.SelectedValue);
            model.sort = Convert.ToInt32(txtsort.Text);

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改合作伙伴信息，主键:" + id); //记录日志

                return true;
            }
            return false;
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString())
            {
                ChkAdminLevel("_partner_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改合作伙伴信息成功！", "partner_list.aspx?page=" + this.page);
            }
            if (action == EnumCollection.ActionEnum.Add.ToString())
            {
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加合作伙伴信息成功！", "partner_list.aspx");
            }
        }
    }
}