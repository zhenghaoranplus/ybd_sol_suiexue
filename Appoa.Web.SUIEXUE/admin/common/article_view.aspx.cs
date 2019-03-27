using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class article_view : Web.UI.ManagePage
    {
        protected string contents = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = RequestHelper.GetQueryInt("id");

                Model.common_resource model = new BLL.common_resource().GetModel(id);
                if (model != null)
                {
                    contents = model.path;
                }
            }
        }
    }
}