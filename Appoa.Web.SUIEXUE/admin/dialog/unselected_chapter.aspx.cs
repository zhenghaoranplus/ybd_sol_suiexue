using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class unselected_chapter : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        protected int group = 0;
        protected int exaid = 0;
        protected int course = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量

            this.course = RequestHelper.GetQueryInt("course");

            if (this.course == 0 || !new BLL.course_info().Exists(this.course))
            {
                JscriptMsg("没有此课程", "back");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_chapter", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindData();
            }
        }

        #region 数据绑定
        private void BindData()
        {
            #region 组装查询条件

            string whereStr = " group_id = " + (int)EnumCollection.chapter_group.精品微课 + " and course_id = " + this.course + " and chapter_level = 1 ";
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (name like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("unselected_chapter.aspx", "keywords={0}&course={1}&group={2}&exaid={3}", "", this.course + "", this.group + "", this.exaid + ""));
                    return;
                }
            }

            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.course_chapter bll = new BLL.course_chapter();
            this.rptList.DataSource = bll.GetListByPage("*", "View_ChapterList", whereStr, "ID ASC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("View_ChapterList", whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("unselected_chapter.aspx", "keywords={0}&page={1}&course={2}&group={3}&exaid={4}", this.keywords, "__id__", this.course + "", this.group + "", this.exaid + "");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("unselected_chapter_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("unselected_chapter.aspx", "keywords={0}&course={1}&group={2}&exaid={3}", txtKeywords.Text, this.course + "", this.group + "", this.exaid + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("unselected_chapter_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("unselected_chapter.aspx", "keywords={0}&course={1}&group={2}&exaid={3}", this.keywords, this.course + "", this.group + "", this.exaid + ""));
        }
    }
}