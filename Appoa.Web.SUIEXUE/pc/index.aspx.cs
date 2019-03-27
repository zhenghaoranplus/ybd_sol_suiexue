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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = new BLL.common_adR().GetList("ad_group_id = " + (int)EnumCollection.adR_group.梧桐花轮播图 + " order by ad_group_id,ad_sort_id");

            this.rptBanner.DataSource = dt;
            this.rptBanner.DataBind();

            BLL.common_article bll = new BLL.common_article();
            dt = bll.GetListByPage(" group_id = " + (int)EnumCollection.article_group.我们的服务, "add_time desc", 1, 4);

            this.rptService.DataSource = dt;
            this.rptService.DataBind();

            dt = bll.GetListByPage(" group_id = " + (int)EnumCollection.article_group.客户案例, "add_time desc", 1, 8);

            this.rptCase.DataSource = dt;
            this.rptCase.DataBind();
            if (bll.GetRecordCount(" group_id = " + (int)EnumCollection.article_group.客户案例) <= 8)
            {
                this.more_i.Visible = false;
            }

            dt = bll.GetListByPage(" group_id = " + (int)EnumCollection.article_group.新闻动态, " add_time desc ", 1, 4);
            this.rptNews.DataSource = dt;
            this.rptNews.DataBind();
            if (bll.GetRecordCount(" group_id = " + (int)EnumCollection.article_group.新闻动态) <= 4)
            {
                this.news_more.Visible = false;
            }
        }
    }
}