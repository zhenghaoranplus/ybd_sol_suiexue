using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.shop
{
    public partial class order_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        private int status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            this.status = RequestHelper.GetQueryInt("status");
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_order_list", EnumCollection.ActionEnum.Manage.ToString()); //检查权限
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定

        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.order_status), "key", "val");
            this.ddlStatus.DataSource = dt;
            this.ddlStatus.DataTextField = "key";
            this.ddlStatus.DataValueField = "val";
            this.ddlStatus.DataBind();
            this.ddlStatus.Items.Insert(0, new ListItem("全部订单", "0"));
        }

        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " del_status = " + (int)EnumCollection.order_delStatus.未删除;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (order_no like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("order_list.aspx", "keywords={0}", ""));
                    return;
                }
            }

            if (this.status != 0)
            {
                this.ddlStatus.SelectedValue = this.status + "";

                whereStr += " and status = " + this.status;
            }

            #endregion

            BLL.user_order bll = new BLL.user_order();
            DataTable dt = bll.GetList(" status = " + (int)EnumCollection.order_status.待收货 + " and confirm_time < getdate() ");
            string ids = string.Empty;
            foreach (DataRow item in dt.Rows)
            {
                ids += Convert.ToInt32(item["id"]) + ",";
            }
            if (!string.IsNullOrEmpty(ids))
            {
                ids = Utils.DelLastComma(ids);
                bll.UpdateStatus((int)EnumCollection.order_status.待评价, " id in (" + ids + ") ");
            }

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;

            this.rptList.DataSource = bll.GetListByPage(whereStr, " add_time desc ", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_list.aspx", "keywords={0}&page={1}&status={2}", this.keywords, "__id__", this.status + "");
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
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "keywords={0}", txtKeywords.Text));
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
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "keywords={0}&status={1}", this.keywords, this.status + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_order_list", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.user_order bll = new BLL.user_order();
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
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除订单信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("order_list.aspx", "keywords={0}&status={1}", this.keywords, this.status + ""));
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "keywords={0}&status={1}", this.keywords, this.ddlStatus.SelectedValue));
        }
    }
}