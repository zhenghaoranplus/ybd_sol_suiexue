using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.pc
{
    public partial class news_list : System.Web.UI.Page
    {
        private int pageIndex = 1;
        private int pageSize = 8;
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

            DataTable dt = catebll.GetList(" group_id = " + (int)EnumCollection.category_group.新闻动态 + " order by sort asc ");
            this.rptCategory.DataSource = dt;
            this.rptCategory.DataBind();

            if (this.cate <= 0)
            {
                Model.common_category cateModel = catebll.GetModel(1, " group_id = " + (int)EnumCollection.category_group.新闻动态, " sort asc ");
                if (cateModel != null)
                {
                    this.cate = cateModel.id;
                }
            }

            this.pageIndex = RequestHelper.GetQueryInt("page", 1);

            BLL.common_article bll = new BLL.common_article();
            string whereStr = " group_id = " + (int)EnumCollection.article_group.新闻动态 + " and category_id = " + this.cate;

            dt = bll.GetListByPage("*", "View_NewsList", whereStr, " add_time desc ", pageIndex, pageSize);
            this.rptNews.DataSource = dt;
            this.rptNews.DataBind();

            int totalCount = bll.GetRecordCount("View_NewsList", whereStr);

            string pageUrl = Utils.CombUrlTxt("news_list.aspx", "page={0}", "__id__");

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