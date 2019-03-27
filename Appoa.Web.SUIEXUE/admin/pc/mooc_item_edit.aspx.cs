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
    public partial class mooc_item_edit : Web.UI.ManagePage
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
                ChkAdminLevel("_mooc_item", EnumCollection.ActionEnum.View.ToString()); //检查权限
                Bind();

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void Bind()
        {
            this.ddlCategory.DataSource = EnumCollection.EnumToDataTable(typeof(EnumCollection.mooc_item), "name", "id");
            this.ddlCategory.DataTextField = "name";
            this.ddlCategory.DataValueField = "id";
            this.ddlCategory.DataBind();
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

            this.ddlCategory.SelectedValue = model.category_id + "";
            this.txtcontents.Text = model.contents.Replace("<br>", "\r\n");
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            Model.common_article model = new Model.common_article();
            BLL.common_article bll = new BLL.common_article();

            model.group_id = (int)EnumCollection.article_group.微课慕课项目简介;
            model.user_id = 0;
            model.category_id = Convert.ToInt32(ddlCategory.SelectedValue);
            model.title = "";
            model.subtitle = "";
            model.contents = Convert.ToString(txtcontents.Text.Trim()).Replace("\r\n", "<br>");
            model.img_src = "";
            model.click = 0;
            model.upvote = 0;
            model.status = (int)EnumCollection.examine_status.审核通过;
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加微课慕课项目简介，主键:" + id); //记录日志
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

            model.category_id = Convert.ToInt32(ddlCategory.SelectedValue);
            model.contents = Convert.ToString(txtcontents.Text.Trim()).Replace("\r\n", "<br>");

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改微课慕课项目简介，主键:" + model.id); //记录日志
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
                ChkAdminLevel("_mooc_item", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改微课慕课项目简介成功！", "mooc_item.aspx?page=" + this.page);
            }
            else //添加
            {
                ChkAdminLevel("_mooc_item", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加微课慕课项目简介成功！", "mooc_item.aspx");
            }
        }
    }
}