using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.pc
{
    public partial class case_list : System.Web.UI.Page
    {
        private int pageIndex = 1;
        private int pageSize = 12;
        private int cate = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageIndex = RequestHelper.GetQueryInt("page", 1);
            this.cate = RequestHelper.GetQueryInt("cate");

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            BLL.common_category catebll = new BLL.common_category();

            DataTable dt = catebll.GetList(" group_id = " + (int)EnumCollection.category_group.客户案例 + " order by sort asc ");
            this.rptCategory.DataSource = dt;
            this.rptCategory.DataBind();

            if (this.cate <= 0)
            {
                Model.common_category cateModel = catebll.GetModel(1, " group_id = " + (int)EnumCollection.category_group.客户案例, " sort asc ");
                if (cateModel != null)
                {
                    this.cate = cateModel.id;
                }
            }

            this.pageIndex = RequestHelper.GetQueryInt("page", 1);

            BLL.common_article bll = new BLL.common_article();

            string whereStr = " group_id = " + (int)EnumCollection.article_group.客户案例 + " and category_id = " + this.cate;
            dt = bll.GetListByPage("*", "View_CaseList", whereStr, "add_time desc", 1, 12);

            this.rptCase.DataSource = dt;
            this.rptCase.DataBind();

            int totalCount = bll.GetRecordCount("View_CaseList", whereStr);

            string pageUrl = Utils.CombUrlTxt("case_list.aspx", "page={0}&cate={1}", "__id__", this.cate + "");

            PageContent.InnerHtml = PageListHelper.OutPageList(totalCount, pageIndex, pageSize, pageUrl);
        }

        protected string GetClass(int id)
        {
            int cateid = RequestHelper.GetQueryInt("cate");

            if (this.cate == id)
            {
                return "class='mycur'";
            }
            return "";
        }
    }
}