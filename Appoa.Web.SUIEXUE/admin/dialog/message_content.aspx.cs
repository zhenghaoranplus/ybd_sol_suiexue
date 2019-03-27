using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class message_content : Web.UI.ManagePage
    {
        protected string contents = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = RequestHelper.GetQueryInt("id");
                Model.common_message model = new BLL.common_message().GetModel(id);
                if (model == null)
                {
                    contents = "";
                }
                else
                {
                    contents = model.contents;
                }
            }
        }
    }
}