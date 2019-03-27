using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.pc
{
    public partial class news_info : System.Web.UI.Page
    {
        protected int cate = 0;
        protected string cate_name = string.Empty;
        protected string title = string.Empty;
        protected string subtitle = string.Empty;
        protected string add_time = string.Empty;
        protected string contents = string.Empty;

        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = RequestHelper.GetQueryInt("id", 0);
            this.cate = RequestHelper.GetQueryInt("cate", 0);

            if (!new BLL.common_category().Exists(this.cate))
            {
                Response.Write("<script>alert('没有此分类');history.back(-1);</script>");
                Response.End();
                return;
            }

            if (!IsPostBack)
            {
                Model.common_category cateModel = new BLL.common_category().GetModel(this.cate);
                if (cateModel != null)
                {
                    this.cate_name = cateModel.name;
                }

                Model.common_article model = new BLL.common_article().GetModel(this.id);
                if (model == null)
                {
                    Response.Write("<script>alert('没有此新闻');history.back(-1);</script>");
                    Response.End();
                    return;
                }

                title = model.title;
                subtitle = model.subtitle;
                add_time = Convert.ToDateTime(model.add_time).ToString("yyyy-MM-dd");
                contents = model.contents;
            }
        }
    }
}