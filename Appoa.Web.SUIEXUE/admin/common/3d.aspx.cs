using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class _3d : Web.UI.ManagePage
    {
        protected string path = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = RequestHelper.GetQueryInt("id");

            Model.common_resource model = new BLL.common_resource().GetModel(id);
            if (model!=null)
            {
                path = model.path;
            }
            else
            {
                path = "";
            }
        }
    }
}