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
    public partial class chapter_list : Web.UI.ManagePage
    {
        protected int class_id = 0;
        protected Model.sys_manager adminInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.class_id = RequestHelper.GetQueryInt("class_id", 0);
            this.adminInfo = GetAdminInfo();

            if (this.adminInfo == null)
            {
                JscriptMsg("登录超时，请重新登录", "/admin/login.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_chapter", EnumCollection.ActionEnum.View.ToString()); //检查权限
                Bind();
                BindData();
            }
        }

        #region 数据绑定
        private void Bind()
        {
            string where = "";
            if (adminInfo.role_type == 2)//课堂教师
            {
                Model.user_info user = new BLL.user_info().GetModel(" phone = '" + adminInfo.user_name + "' ");
                where += " user_id = " + user.id;
            }

            DataTable dt = new BLL.classroom_info().GetList(where);
            this.ddlClass.DataSource = dt;
            this.ddlClass.DataTextField = "name";
            this.ddlClass.DataValueField = "id";
            this.ddlClass.DataBind();
        }

        private void BindData()
        {
            string whereStr = " 1 = 1 ";
            if (this.class_id > 0)
            {
                this.ddlClass.SelectedValue = this.class_id + "";
            }
            else
            {
                class_id = Convert.ToInt32(this.ddlClass.SelectedValue);
            }

            whereStr += " and group_id = " + (int)EnumCollection.chapter_group.课堂 + " and course_id = " + class_id + " and chapter_level = 1 ";

            BLL.classroom_info bll = new BLL.classroom_info();
            this.rptList.DataSource = bll.GetListNew(whereStr, "0");
            this.rptList.DataBind();
        }
        #endregion

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_classroom_chapter", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.course_chapter bll = new BLL.course_chapter();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除课程章节" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("chapter_list.aspx", "", ""));
        }

        //protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {
        //        Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
        //        HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
        //        string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
        //        string LitImg1 = "<span class=\"folder-open\"></span>";
        //        string LitImg2 = "<span class=\"folder-line\"></span>";

        //        string classLayer = hidLayer.Value;
        //        if (classLayer == "0")
        //        {
        //            LitFirst.Text = LitImg1;
        //        }
        //        else
        //        {
        //            int count = Convert.ToInt32(hidLayer.Value);
        //            LitFirst.Text = string.Format(LitStyle, (count - 1) * 40, LitImg2, LitImg1);
        //        }
        //    }
        //}

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("chapter_list.aspx", "class_id={0}", this.ddlClass.SelectedValue));
        }
    }
}