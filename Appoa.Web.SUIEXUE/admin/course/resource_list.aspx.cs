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
    public partial class resource_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        protected int type = 0;
        protected int chapter = 0;
        protected int group = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.page = RequestHelper.GetQueryInt("page", 1);
            this.pageSize = GetPageSize(10); //每页数量
            this.type = RequestHelper.GetQueryInt("type");
            this.chapter = RequestHelper.GetQueryInt("chapter");
            this.group = RequestHelper.GetQueryInt("group");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_chapter", EnumCollection.ActionEnum.View.ToString()); //检查权限
                Bind();
                BindData();
            }
        }

        #region 数据绑定
        private void Bind()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.resource_group), "key", "val");
            this.ddlGroup.DataSource = dt;
            this.ddlGroup.DataTextField = "key";
            this.ddlGroup.DataValueField = "val";
            this.ddlGroup.DataBind();
            this.ddlGroup.Items.Insert(0, new ListItem("=资源分组=", "0"));

            dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.resource_type), "key", "val");
            DataRow[] drs = dt.Select("val not in (5,7)", "val");

            if (drs.Length > 0)
            {
                this.ddlType.Items.Clear();
                foreach (DataRow item in drs)
                {
                    this.ddlType.Items.Add(new ListItem(item["key"].ToString(), item["val"].ToString()));
                }
                this.ddlType.Items.Insert(0, new ListItem("=资源类型=", "0"));
                this.ddlType.SelectedIndex = 0;
            }
        }

        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " from_id = " + (int)EnumCollection.resource_from.精品微课 + " and is_del = 0 and data_id = " + this.chapter;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&type={1}&chapter={2}", "", this.type + "", this.chapter + ""));
                    return;
                }
            }

            if (this.group > 0)
            {
                whereStr += " and group_id = " + this.group;
                this.ddlGroup.SelectedValue = this.group + "";
            }
            if (this.type > 0)
            {
                whereStr += " and type = " + this.type;
                this.ddlType.SelectedValue = this.type + "";
            }

            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_resource bll = new BLL.common_resource();
            this.rptList.DataSource = bll.GetListByPage("*", "View_ChapterResource", whereStr, " sort asc ", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("View_ChapterResource", whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}&page={4}", this.keywords, this.chapter + "", this.group + "", this.type + "", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}", txtKeywords.Text, this.chapter + "", this.group + "", this.type + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}", this.keywords, this.chapter + "", this.group + "", this.type + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_course_chapter", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.common_resource bll = new BLL.common_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.UpdateField(id, "is_del = 1"))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除资源信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}&page={4}", this.keywords, this.chapter + "", this.group + "", this.type + "", this.page + ""));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_course_chapter", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_resource bll = new BLL.common_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtsort")).Text.Trim(), out sortId))
                {
                    sortId = 1;
                }
                bll.UpdateField(id, "sort=" + sortId.ToString());
            }
            AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "保存资源排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}&page={4}", this.keywords, this.chapter + "", this.group + "", this.type + "", this.page + ""));
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}", this.keywords, this.chapter + "", this.ddlGroup.SelectedValue, this.type + ""));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("resource_list.aspx", "keywords={0}&chapter={1}&group={2}&type={3}", this.keywords, this.chapter + "", this.group + "", this.ddlType.SelectedValue + ""));
        }

        protected string ReturnHtmlPath(string path)
        {
            int index = path.LastIndexOf('.');
            string extend = path.Substring(0, index);
            return "/html/pdfjs/web/viewer.html?file=" + extend + ".pdf";
        }
    }
}