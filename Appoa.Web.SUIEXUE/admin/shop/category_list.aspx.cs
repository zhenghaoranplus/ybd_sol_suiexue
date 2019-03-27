using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.shop
{
    public partial class category_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_goods_category", EnumCollection.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            BLL.common_category bll = new BLL.common_category();
            DataTable dt = bll.GetListNew("group_id=" + (int)EnumCollection.category_group.商城, "0");
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //美化列表
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

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_goods_category", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_category bll = new BLL.common_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(Convert.ToInt32(id), " sort = " + sortId.ToString());
            }
            AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "保存商品分类排序"); //记录日志
            JscriptMsg("保存排序成功！", "category_list.aspx");
        }


        //删除导航
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_goods_category", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            BLL.common_category bll = new BLL.common_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除分类"); //记录日志
            JscriptMsg("删除数据成功！", "category_list.aspx", "parent.loadMenuTree");
        }
    }
}