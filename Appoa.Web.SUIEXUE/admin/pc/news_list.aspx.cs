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
    public partial class news_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        private int cate = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.page = RequestHelper.GetQueryInt("page", 1);
            this.pageSize = GetPageSize(20); //每页数量

            this.cate = RequestHelper.GetQueryInt("cate");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_news_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                Bind();

                BindData();
            }
        }

        #region 数据绑定

        private void Bind()
        {
            this.ddlCategory.DataSource = new BLL.common_category().GetList(" group_id = " + (int)EnumCollection.category_group.新闻动态);
            this.ddlCategory.DataTextField = "name";
            this.ddlCategory.DataValueField = "id";
            this.ddlCategory.DataBind();
            this.ddlCategory.Items.Insert(0, new ListItem("全部分类", "0") { });
        }

        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " group_id = " + (int)EnumCollection.article_group.新闻动态;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and ((title like  '%" + _keywords + "%') or (subtitle like '%" + _keywords + "%') or (content like '%" + _keywords + "%'))";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("news_list.aspx", "keywords={0}&cate={1}", "", this.cate + ""));
                    return;
                }
            }

            if (this.cate > 0)
            {
                whereStr += " and category_id = " + this.cate;
                this.ddlCategory.SelectedValue = this.cate + "";
            }

            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_article bll = new BLL.common_article();
            this.rptList.DataSource = bll.GetListByPage("*", "View_NewsList", whereStr, "add_time desc", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("View_NewsList", whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("news_list.aspx", "keywords={0}&page={1}&cate={2}", this.keywords, "__id__", this.cate + "");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("news_list_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}&cate={1}", txtKeywords.Text, this.cate + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("news_list_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}&cate={1}", this.keywords, this.cate + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_news_list", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.common_article bll = new BLL.common_article();
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
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除新闻" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("news_list.aspx", "keywords={0}&cate={1}", this.keywords, this.cate + ""));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}&cate={1}", this.keywords, this.ddlCategory.SelectedValue));
        }
    }
}