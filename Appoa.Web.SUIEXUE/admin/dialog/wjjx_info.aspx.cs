using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class wjjx_info : Web.UI.ManagePage
    {
        protected string contents = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = RequestHelper.GetQueryInt("id");
            Model.common_examination model = new BLL.common_examination().GetModel(id);
            if (model == null)
            {
                contents = "";
            }
            else
            {
                contents = model.descript;
            }
        }
    }
}