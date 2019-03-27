using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.user
{
    public partial class user_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_user_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindData();
            }
        }

        #region 数据绑定
        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " group_id = " + (int)EnumCollection.user_group.普通用户;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (phone like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("user_list.aspx", "keywords={0}", ""));
                    return;
                }
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.user_info bll = new BLL.user_info();
            this.rptList.DataSource = bll.GetListByPage(whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("user_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "keywords={0}", txtKeywords.Text));
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
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_user_list", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.user_info bll = new BLL.user_info();
            BLL.user_oauths oBll = new BLL.user_oauths();
            BLL.user_tree tBll = new BLL.user_tree();
            Model.user_oauths uoModel = null;
            Model.user_tree utModel = null;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                uoModel = oBll.GetModel(" user_id = " + id);
                utModel = tBll.GetModel(" user_id = " + id);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        if (uoModel != null)
                        {
                            oBll.Delete(uoModel.id);
                        }
                        if (utModel != null)
                        {
                            tBll.Delete(utModel.id);
                        }
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除用户信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("user_list.aspx", "keywords={0}", this.keywords));
        }
    }
}