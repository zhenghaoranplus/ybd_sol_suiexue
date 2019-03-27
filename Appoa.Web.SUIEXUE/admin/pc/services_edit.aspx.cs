using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.pc
{
    public partial class services_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int page = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (this.id > 0)
            {
                if (!new BLL.common_article().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_services_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.YesOrNot), "title", "id");
            this.rbtnStatus.DataSource = dt;
            this.rbtnStatus.DataValueField = "id";
            this.rbtnStatus.DataTextField = "title";
            this.rbtnStatus.DataBind();
            this.rbtnStatus.SelectedIndex = 0;
        }

        private void ShowInfo(int _id)
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(_id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            this.rbtnStatus.SelectedValue = model.upvote + "";
            this.txttitle.Text = model.title;
            this.txtimg_src.Text = model.img_src;
            this.txtsubtitle.Text = model.subtitle;
            this.txtcontents.Text = model.contents;
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            Model.common_article model = new Model.common_article();
            BLL.common_article bll = new BLL.common_article();

            model.group_id = (int)EnumCollection.article_group.我们的服务;
            model.user_id = 0;
            model.category_id = 0;
            model.title = Convert.ToString(txttitle.Text.Trim());
            model.subtitle = txtsubtitle.Text.Trim();
            model.contents = Convert.ToString(txtcontents.Text.Trim());
            model.img_src = Convert.ToString(txtimg_src.Text.Trim());
            model.click = 0;
            model.upvote = Convert.ToInt32(this.rbtnStatus.SelectedValue);
            model.status = (int)EnumCollection.examine_status.审核通过;
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加服务项目，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(this.id);

            model.title = Convert.ToString(txttitle.Text.Trim());
            model.contents = Convert.ToString(txtcontents.Text.Trim());
            model.img_src = Convert.ToString(txtimg_src.Text.Trim());
            model.subtitle = txtsubtitle.Text.Trim();
            model.upvote = Convert.ToInt32(this.rbtnStatus.SelectedValue);

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改服务项目，主键:" + model.id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_services_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改服务项目成功！", "services_list.aspx?page=" + this.page);
            }
            else //添加
            {
                ChkAdminLevel("_services_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加服务项目成功！", "services_list.aspx");
            }
        }
    }
}