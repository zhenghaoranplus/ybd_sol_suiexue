using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class questions_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        private int chapter = 0;
        private int type = 0;
        private int group = 0;
        protected string chapter_name = string.Empty;
        protected string course_name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量

            this.chapter = RequestHelper.GetQueryInt("chapter");
            this.group = RequestHelper.GetQueryInt("group");
            this.type = RequestHelper.GetQueryInt("type");

            if (this.chapter == 0)
            {
                JscriptMsg("没有此章节", "back");
                return;
            }

            Model.course_chapter chapterModel = new BLL.course_chapter().GetModel(this.chapter);
            if (chapterModel != null)
            {
                chapter_name = chapterModel.name;
                Model.course_info course = new BLL.course_info().GetModel(chapterModel.course_id);
                if (course != null)
                {
                    course_name = course.name;
                }
            }

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
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.questions_group), "key", "val");
            this.ddlGroup.DataSource = dt;
            this.ddlGroup.DataTextField = "key";
            this.ddlGroup.DataValueField = "val";
            this.ddlGroup.DataBind();
            this.ddlGroup.Items.Insert(0, new ListItem("=试题分组=", "0"));

            dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.questions_type), "key", "val");
            this.ddlType.DataSource = dt;
            this.ddlType.DataTextField = "key";
            this.ddlType.DataValueField = "val";
            this.ddlType.DataBind();
            this.ddlType.Items.Insert(0, new ListItem("=试题类型=", "0"));
        }

        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " data_id = " + this.chapter;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&chapter={1}", "", this.chapter + ""));
                    return;
                }
            }

            if (this.group > 0)
            {
                this.ddlGroup.SelectedValue = this.group + "";
                whereStr += " and group_id = " + this.group;
            }

            if (this.type > 0)
            {
                this.ddlType.SelectedValue = this.type + "";
                whereStr += " and type = " + this.type;
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_questions bll = new BLL.common_questions();
            this.rptList.DataSource = bll.GetListByPage(whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&page={1}&type={2}&group={3}&chapter={4}", this.keywords, "__id__", this.type + "", this.group + "", this.chapter + "");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("questions_list_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&type={1}&group={2}&chapter={3}", txtKeywords.Text, this.type + "", this.group + "", this.chapter + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("questions_list_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&type={1}&group={2}&chapter={3}", this.keywords, this.type + "", this.group + "", this.chapter + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.common_questions bll = new BLL.common_questions();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        Appoa.DBUtility.DbHelperSQL.ExecuteSql(" delete from ybd_common_answers where question_id = " + id);
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除题目信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&type={1}&group={2}&chapter={3}", this.keywords, this.type + "", this.group + "", this.chapter + ""));
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&type={1}&group={2}&chapter={3}", this.keywords, this.type + "", this.ddlGroup.SelectedValue, this.chapter + ""));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("questions_list.aspx", "keywords={0}&type={1}&group={2}&chapter={3}", this.keywords, this.ddlType.SelectedValue, this.group + "", this.chapter + ""));
        }
    }
}