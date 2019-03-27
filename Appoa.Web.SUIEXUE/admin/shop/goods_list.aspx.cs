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
    public partial class goods_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        private int group = 0;
        private int type = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            this.group = RequestHelper.GetQueryInt("group");
            this.type = RequestHelper.GetQueryInt("type");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定
        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.goods_group), "key", "val");
            this.ddlGroup.DataSource = dt;
            this.ddlGroup.DataTextField = "key";
            this.ddlGroup.DataValueField = "val";
            this.ddlGroup.DataBind();
            this.ddlGroup.Items.Insert(0, new ListItem("所属分组", "0"));

            dt = new BLL.common_category().GetListNew(" group_id = " + (int)EnumCollection.category_group.商城, "0");

            this.ddlCategory.Items.Add(new ListItem("所属分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["category_level"].ToString());
                string Title = dr["name"].ToString().Trim();
                string parent_name = dr["parent_name"].ToString().Trim();

                if (ClassLayer == 2)
                {
                    if (!string.IsNullOrEmpty(parent_name))
                    {
                        Title = parent_name + " ├ " + Title;
                        //Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                        this.ddlCategory.Items.Add(new ListItem(Title, Id));
                    }
                }
            }
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
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("goods_list.aspx", "keywords={0}", ""));
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
                Model.common_category cate = new BLL.common_category().GetModel(this.type);
                if (cate != null)
                {
                    if (cate.category_level == 1)
                    {

                    }
                    else
                    {
                        whereStr += " and category_id = " + this.type;
                    }
                }
                else
                {
                    whereStr += " and category_id = " + this.type;
                }

                this.ddlCategory.SelectedValue = this.type + "";
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.goods_goods bll = new BLL.goods_goods();
            this.rptList.DataSource = bll.GetListByPage("*", "View_GoodsList", whereStr, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("goods_list.aspx", "keywords={0}&page={1}&group={2}&type={3}", this.keywords, "__id__", this.group + "", this.type + "");
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
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "keywords={0}&group={1}&type={2}", txtKeywords.Text, this.group + "", this.type + ""));
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
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "keywords={0}&group={1}&type={2}", this.keywords, this.group + "", this.type + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.goods_goods bll = new BLL.goods_goods();
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
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除商品信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("goods_list.aspx", "keywords={0}", this.keywords));
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "keywords={0}&group={1}&type={2}", this.keywords, this.ddlGroup.SelectedValue, this.type + ""));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("goods_list.aspx", "keywords={0}&group={1}&type={2}", this.keywords, this.group + "", this.ddlCategory.SelectedValue));
        }
    }
}