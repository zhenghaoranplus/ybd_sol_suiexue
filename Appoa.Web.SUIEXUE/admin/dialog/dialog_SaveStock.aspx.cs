using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class dialog_SaveStock : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int id;
        protected string type;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.id = RequestHelper.GetQueryInt("id");

            if (id <= 0)
            {
                JscriptMsg("参数传递出错", "");
                return;
            }
            if (!new BLL.goods_goods().Exists(this.id))
            {
                JscriptMsg("商品信息不存在或已删除", "");
                return;
            }

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                RptBind("1=1 and goods_id=" + this.id.ToString(), "id desc");
            }
        }

        #region 数据绑定=========================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            BLL.goods_spec_type bll = new BLL.goods_spec_type();
            this.totalCount = bll.GetRecordCount("View_SpecTypeInfo", _strWhere);
            this.rptList.DataSource = bll.GetListByPage("*", "View_SpecTypeInfo", _strWhere, _orderby, page, pageSize);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("dialog_SaveStock.aspx", "keywords={0}&page={1}&id={2}",
                this.keywords, "__id__", this.id.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回用户每页数量=================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("dialog_SaveStock_page_size", "DTcmsPage"), out _pagesize))
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
        #region 关健字查询=======================
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_SaveStock.aspx", "keywords={0}&id={1}", "", this.id.ToString()));
        }
        #endregion

        //设置分页数量
        #region 设置分页数量====================
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("dialog_SaveStock_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("dialog_SaveStock.aspx", "keywords={0}&id={1}",
                this.keywords, this.id.ToString()));
        }
        #endregion
    }
}