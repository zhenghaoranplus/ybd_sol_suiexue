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
    public partial class course_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected int type = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            this.type = RequestHelper.GetQueryInt("type");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定

        private void BindSelect()
        {
            //DataTable dt = new BLL.common_category().GetListNew(" group_id = " + (int)EnumCollection.category_group.精品微课, "0");
            DataTable dt = new BLL.common_category().GetList(" group_id = " + (int)EnumCollection.category_group.精品微课 + " order by sort ");
            this.ddlCategory.Items.Clear();
            this.ddlCategory.DataSource = dt;
            this.ddlCategory.DataTextField = "name";
            this.ddlCategory.DataValueField = "id";
            this.ddlCategory.DataBind();
            this.ddlCategory.SelectedIndex = 0;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string Id = dr["id"].ToString();
            //    int ClassLayer = int.Parse(dr["category_level"].ToString());
            //    string Title = dr["name"].ToString().Trim();

            //    if (ClassLayer == 1)
            //    {
            //        this.ddlCategory.Items.Add(new ListItem(Title, Id));
            //    }
            //    else
            //    {
            //        Title = "├ " + Title;
            //        Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
            //        this.ddlCategory.Items.Add(new ListItem(Title, Id));
            //    }
            //}
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
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("course_list.aspx", "keywords={0}", ""));
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
            string pageUrl = Utils.CombUrlTxt("course_list.aspx", "keywords={0}&page={1}&type={2}", this.keywords, "__id__", this.type + "");
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
            Response.Redirect(Utils.CombUrlTxt("course_list.aspx", "keywords={0}&type={1}", txtKeywords.Text, this.type + ""));
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
            Response.Redirect(Utils.CombUrlTxt("course_list.aspx", "keywords={0}&type={1}", this.keywords, this.type + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_course_list", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.course_info bll = new BLL.course_info();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        DBUtility.DbHelperSQL.ExecuteSql(" delete from ybd_course_chapter where group_id = 1 and course_id = " + id);
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除课程信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("course_list.aspx", "keywords={0}&type={1}", this.keywords, this.type + ""));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("course_list.aspx", "keywords={0}&type={1}", this.keywords, this.ddlCategory.SelectedValue));
        }
    }
}