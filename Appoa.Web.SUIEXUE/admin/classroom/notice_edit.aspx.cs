using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class notice_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected int class_id = 0;
        protected int page = 1;

        protected Model.sys_manager adminInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.class_id = RequestHelper.GetQueryInt("class_id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            this.adminInfo = GetAdminInfo();
            if (adminInfo == null)
            {
                JscriptMsg("登录超时，请重新登录!", "/admin/login.aspx");
                return;
            }

            if (this.action == EnumCollection.ActionEnum.Modify.ToString())
            {
                if (!new BLL.common_article().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_notice", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    BindInfo();
                }
            }
        }

        #region 赋值操作
        private void BindSelect()
        {
            string where = "";
            if (adminInfo.role_type == 2)
            {
                Model.user_info user = new BLL.user_info().GetModel(" phone = '" + adminInfo.user_name + "' ");
                where += " user_id = " + user.id;
            }

            this.ddlClassroom.DataSource = new BLL.classroom_info().GetList(where);
            this.ddlClassroom.DataTextField = "name";
            this.ddlClassroom.DataValueField = "id";
            this.ddlClassroom.DataBind();

            this.ddlClassroom.SelectedValue = this.class_id + "";
            //Model.classroom_info model = new BLL.classroom_info().GetModel(class_id);
            //if (model != null)
            //{
            //    this.lblClass.Text = model.name;
            //    this.lblCreator.Text = model.user_name;
            //}
            //else
            //{
            //    this.lblClass.Text = "";
            //}
        }

        private void BindInfo()
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            ddlClassroom.SelectedValue = model.category_id + "";
            txttitle.Text = model.title + "";
            txtcontents.Text = model.contents + "";
            txtimg_src.Text = model.img_src + "";
        }
        #endregion

        private bool DoAdd()
        {
            Model.common_article model = new Model.common_article();
            BLL.common_article bll = new BLL.common_article();

            model.group_id = (int)EnumCollection.article_group.课堂公告;

            if (adminInfo.role_type == 2)//教师
            {
                Model.user_info user = new BLL.user_info().GetModel(" phone = '" + adminInfo.user_name + "' ");
                model.user_id = user.id;
            }
            else if (adminInfo.role_type == 1)//超管
            {
                Model.classroom_info ciModel = new BLL.classroom_info().GetModel(this.class_id);
                if (ciModel != null)
                {
                    model.user_id = ciModel.user_id;
                }
            }

            model.category_id = Convert.ToInt32(ddlClassroom.SelectedValue);
            //model.category_id = this.class_id;
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = "";
            model.contents = Convert.ToString(txtcontents.Text);
            model.img_src = Convert.ToString(txtimg_src.Text);
            model.click = 0;
            model.upvote = 0;
            model.status = 1;
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加课堂公告信息，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DoEdit()
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(this.id);

            model.group_id = (int)EnumCollection.article_group.课堂公告;
            if (adminInfo != null)
            {
                if (adminInfo.role_type == 2)//教师
                {
                    Model.user_info user = new BLL.user_info().GetModel(" phone = '" + adminInfo.user_name + "' ");
                    model.user_id = user.id;
                }
                else if (adminInfo.role_type == 1)//超管
                {
                    Model.classroom_info ciModel = new BLL.classroom_info().GetModel(this.class_id);
                    if (ciModel != null)
                    {
                        model.user_id = ciModel.user_id;
                    }
                }
            }

            model.category_id = Convert.ToInt32(ddlClassroom.SelectedValue);
            //model.category_id = this.class_id;
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = "";
            model.contents = Convert.ToString(txtcontents.Text);
            model.img_src = Convert.ToString(txtimg_src.Text);
            model.click = 0;
            model.upvote = 0;
            model.status = 1;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改课堂公告信息，主键:" + id); //记录日志
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

            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_classroom_notice", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改课堂公告成功！", "notice_list.aspx?page=" + this.page + "&class_id=" + this.class_id);
            }
            else //添加
            {
                ChkAdminLevel("_classroom_notice", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加课堂公告成功！", "notice_list.aspx?class_id=" + this.class_id);
            }

        }
    }
}