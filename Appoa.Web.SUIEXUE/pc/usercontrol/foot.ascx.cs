using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.pc.usercontrol
{
    public partial class foot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.common_category bll = new BLL.common_category();
                this.rptCaseCategory.DataSource = bll.GetList(" group_id = " + (int)EnumCollection.category_group.客户案例 + " order by sort asc ");
                this.rptCaseCategory.DataBind();

                this.rptNewsCategory.DataSource = bll.GetList(" group_id = " + (int)EnumCollection.category_group.新闻动态 + " order by sort asc ");
                this.rptNewsCategory.DataBind();
            }
        }
    }
}