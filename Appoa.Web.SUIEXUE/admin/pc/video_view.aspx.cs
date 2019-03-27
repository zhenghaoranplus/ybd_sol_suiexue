using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.pc
{
    public partial class video_view : Web.UI.ManagePage
    {
        protected string src = "";
        protected string thumb = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = RequestHelper.GetQueryInt("id");
                string f = RequestHelper.GetQueryString("f");
                switch (f)
                {
                    case "cp":
                        Model.company_info cp = new BLL.company_info().GetModel(id);
                        if (cp != null)
                        {
                            src = cp.video_url;
                            thumb = cp.video_thumb_img;
                        }
                        break;
                    case "case":
                        Model.common_resource re = new BLL.common_resource().GetModel(id);
                        if (re != null)
                        {
                            src = re.path;
                            thumb = re.cover;
                        }
                        break;
                    case "partner":
                        Model.company_partner partner = new BLL.company_partner().GetModel(id);
                        if (partner != null)
                        {
                            src = partner.video_url;
                            thumb = partner.video_thumb_img;
                        }
                        break;
                }
            }
        }
    }
}