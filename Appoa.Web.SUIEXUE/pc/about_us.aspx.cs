using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.pc
{
    public partial class about_us : System.Web.UI.Page
    {
        protected string contents = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.common_article model = new BLL.common_article().GetModel(" group_id = " + (int)EnumCollection.article_group.PC站关于我们);
                if (model != null)
                {
                    contents = model.contents;
                }

                BindData();
            }
        }

        private void BindData()
        {
            this.rptCustomer.DataSource = new BLL.company_partner().GetList(" 1 = 1 order by sort asc ");
            this.rptCustomer.DataBind();

            //this.rptTeam.DataSource = new BLL.common_article().GetList(" group_id = " + (int)EnumCollection.article_group.我们的团队 + " order by id asc ");
            //this.rptTeam.DataBind();
        }
    }
}