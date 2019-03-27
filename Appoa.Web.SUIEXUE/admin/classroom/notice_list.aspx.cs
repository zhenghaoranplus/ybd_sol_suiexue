using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class notice_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected int class_id = 0;
        protected Model.sys_manager adminInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            this.class_id = RequestHelper.GetQueryInt("class_id");

            this.adminInfo = GetAdminInfo();
            if (this.adminInfo == null)
            {
                JscriptMsg("登录超时，请重新登录!", "/admin/login.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_notice", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定
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
        }

        private void BindData()
        {
            #region 组装查询条件

            if (this.class_id > 0)
            {
                this.ddlClassroom.SelectedValue = this.class_id + "";
            }
            else
            {
                this.class_id = Convert.ToInt32(this.ddlClassroom.SelectedValue);
            }

            string whereStr = " group_id = " + (int)EnumCollection.article_group.课堂公告 + " and category_id = " + this.class_id;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("notice_list.aspx", "keywords={0}&class_id={1}", "", this.class_id + ""));
                    return;
                }
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_article bll = new BLL.common_article();
            this.rptList.DataSource = bll.GetListByPage("*", "View_ClassroomNotice", whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("View_ClassroomNotice", whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("notice_list.aspx", "keywords={0}&page={1}&chass_id={2}", this.keywords, "__id__", this.class_id + "");
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
            Response.Redirect(Utils.CombUrlTxt("notice_list.aspx", "keywords={0}&class_id={1}", txtKeywords.Text, this.class_id + ""));
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
            Response.Redirect(Utils.CombUrlTxt("notice_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_classroom_notice", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
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
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除课堂公告" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("notice_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id + ""));
        }

        protected void ddlClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("notice_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.ddlClassroom.SelectedValue));
        }
    }
}