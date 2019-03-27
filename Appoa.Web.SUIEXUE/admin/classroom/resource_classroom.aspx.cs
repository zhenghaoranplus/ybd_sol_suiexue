using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class resource_classroom : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        protected Model.sys_manager adminInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量

            this.adminInfo = GetAdminInfo();
            if (this.adminInfo == null)
            {
                JscriptMsg("登录超时，请重新登录", "/admin/login.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindData();
            }
        }

        #region 数据绑定
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
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("resource_classroom.aspx", "keywords={0}", ""));
                    return;
                }
            }

            if (this.adminInfo.role_type == 2)
            {
                Model.user_info user = new BLL.user_info().GetModel(" phone = '" + this.adminInfo.user_name + "' ");
                if (user == null)
                {
                    JscriptMsg("此用户没有创建课堂，请确认后重新登录", "/admin/login.aspx");
                    return;
                }

                whereStr += " and user_id = " + user.id;
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.classroom_info bll = new BLL.classroom_info();
            this.rptList.DataSource = bll.GetListByPage("*", "View_ClassroomList", whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("resource_classroom.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("resource_classroom_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("resource_classroom.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("resource_classroom_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("resource_classroom.aspx", "keywords={0}", this.keywords));
        }
    }
}