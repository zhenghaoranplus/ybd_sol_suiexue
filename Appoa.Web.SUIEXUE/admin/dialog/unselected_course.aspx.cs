using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class unselected_course : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        protected int group = 0;
        protected int exaid = 0;
        protected int type = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量

            this.group = RequestHelper.GetQueryInt("group");
            this.exaid = RequestHelper.GetQueryInt("exaid");
            this.type = RequestHelper.GetQueryInt("type");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定

        private void BindSelect()
        {
            DataTable dt = new BLL.common_category().GetList(" group_id = " + (int)EnumCollection.category_group.精品微课 + " order by sort ");
            this.ddlCategory.Items.Clear();
            this.ddlCategory.DataSource = dt;
            this.ddlCategory.DataTextField = "name";
            this.ddlCategory.DataValueField = "id";
            this.ddlCategory.DataBind();
            this.ddlCategory.Items.Add(new ListItem("所属分类", "0"));
        }

        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " 1 = 1 ";
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (name like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("unselected_course.aspx", "keywords={0}&group={1}&exaid={2}", "", this.group + "", this.exaid + ""));
                    return;
                }
            }

            if (this.type > 0)
            {
                whereStr += " and category_id = " + this.type;
                this.ddlCategory.SelectedValue = this.type + "";
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.course_info bll = new BLL.course_info();
            this.rptList.DataSource = bll.GetListByPage("*", "View_CourseList", whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("View_CourseList", whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("unselected_course.aspx", "keywords={0}&page={1}&group={2}&exaid={3}", this.keywords, "__id__", this.group + "", this.exaid + "");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("unselected_course_page_size", "AppoaPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("unselected_course.aspx", "keywords={0}&group={1}&exaid={2}", txtKeywords.Text, this.group + "", this.exaid + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("unselected_course_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("unselected_course.aspx", "keywords={0}&type={1}&group={2}&exaid={3}", this.keywords, this.type + "", this.group + "", this.exaid + ""));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("unselected_course.aspx", "keywords={0}&type={1}&group={2}&exaid={3}", this.keywords, this.ddlCategory.SelectedValue, this.group + "", this.exaid + ""));
        }
    }
}