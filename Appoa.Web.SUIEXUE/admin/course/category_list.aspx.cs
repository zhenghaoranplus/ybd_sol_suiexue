using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class category_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_category", EnumCollection.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("course_type_page_size", "AppoaPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //数据绑定
        private void RptBind()
        {
            this.page = RequestHelper.GetQueryInt("page", 1);

            BLL.common_category bll = new BLL.common_category();
            //DataTable dt = bll.GetListNew("group_id=" + (int)EnumCollection.category_group.精品微课, "0");
            DataTable dt = bll.GetListByPage("group_id=" + (int)EnumCollection.category_group.精品微课, " sort asc ", this.page, this.pageSize);
            this.rptList.DataSource = dt;
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("group_id = " + (int)EnumCollection.category_group.精品微课);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("category_list.aspx", "page={0}", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_course_category", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
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
            AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "保存微课分类排序"); //记录日志
            JscriptMsg("保存排序成功！", "category_list.aspx");
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("course_type_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("category_list.aspx", "", ""));
        }

        //删除导航
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_course_category", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
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
            //JscriptMsg("删除数据成功！", "category_list.aspx", "parent.loadMenuTree");
            JscriptMsg("删除数据成功！", Utils.CombUrlTxt("category_list.aspx", "", ""));
        }
    }
}