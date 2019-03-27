using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class correct_work_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected int chapter = 0;
        protected string class_name = string.Empty;
        protected string parent_name = string.Empty;
        protected string chapter_name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            this.chapter = RequestHelper.GetQueryInt("chapter");

            if (this.chapter == 0)
            {
                JscriptMsg("传递参数错误", "back");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_work_materials", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindData();
            }
        }

        #region 数据绑定
        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " parent_id = " + this.chapter;
            //string whereStr = " 1 = 1 ";
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (name like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("correct_work_list.aspx", "keywords={0}", ""));
                    return;
                }
            }

            //if (this.chapter > 0)
            //{
            //    whereStr += " parent_id = " + this.chapter;
            //}

            #endregion

            Model.course_chapter ccModel = new BLL.course_chapter().GetModel(chapter);
            if (ccModel != null)
            {
                chapter_name = ccModel.name;
                Model.course_chapter pcModel = new BLL.course_chapter().GetModel(ccModel.parent_id);
                if (pcModel != null)
                {
                    parent_name = pcModel.name;
                }
                Model.classroom_info course = new BLL.classroom_info().GetModel(ccModel.course_id);
                if (course != null)
                {
                    class_name = course.name;
                }
                else
                {
                    JscriptMsg("传递参数错误", "back");
                    return;
                }
            }
            else
            {
                JscriptMsg("传递参数错误", "back");
                return;
            }

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_examination bll = new BLL.common_examination();
            this.rptList.DataSource = bll.GetListByPage(whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("correct_work_list.aspx", "keywords={0}&page={1}&chapter={2}", this.keywords, "__id__", this.chapter + "");
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
            Response.Redirect(Utils.CombUrlTxt("correct_work_list.aspx", "keywords={0}&chapter={1}", txtKeywords.Text, this.chapter + ""));
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
            Response.Redirect(Utils.CombUrlTxt("correct_work_list.aspx", "keywords={0}&chapter={1}", this.keywords, this.chapter + ""));
        }
    }
}