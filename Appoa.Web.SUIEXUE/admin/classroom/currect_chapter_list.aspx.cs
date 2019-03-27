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
    public partial class currect_chapter_list : Web.UI.ManagePage
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
            Model.classroom_info ciModel = new BLL.classroom_info().GetModel(this.class_id);
            if (ciModel == null)
            {
                JscriptMsg("没有此课堂", "back");
                return;
            }
            else
            {
                this.lblName.Text = ciModel.name;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_chapter", EnumCollection.ActionEnum.View.ToString()); //检查权限

                BindData();
            }
        }

        #region 数据绑定

        private void BindData()
        {
            string whereStr = " group_id = " + (int)EnumCollection.chapter_group.课堂 + " and course_id = " + class_id;

            BLL.classroom_info bll = new BLL.classroom_info();
            this.rptList.DataSource = bll.GetListNew(whereStr, "0");
            this.rptList.DataBind();
        }
        #endregion

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
    }
}