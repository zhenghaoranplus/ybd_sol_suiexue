using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Appoa.Common;
using System.Web.UI;

namespace Appoa.Web.UI
{
    public class UPage : System.Web.UI.Page
    {
        protected internal Model.siteconfig siteConfig;

        public UPage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            siteConfig = new BLL.siteconfig().loadConfig();
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!isLogin())
            {
                //Response.Write("<script>parent.location.href='/login.aspx'</script>");
                //Response.Write("<script>$('.toregister').click();</script>");
                //Response.End();
                //string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";
                //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            }
        }

        public static bool isLogin()
        {
            //如果Session为Null
            if (HttpContext.Current.Session[AppoaKeys.SESSION_USER_INFO] != null)
            {
                return true;
            }
            return false;
        }

        ///// <summary>
        ///// 取得用户信息
        ///// </summary>
        //public static Model.user_info GetUserInfo()
        //{
        //    if (isLogin())
        //    {
        //        Model.user_info model = HttpContext.Current.Session[AppoaKeys.SESSION_USER_INFO] as Model.user_info;
        //        if (model != null)
        //        {
        //            //为了能查询到最新的用户信息，必须查询最新的用户资料
        //            model = new BLL.user_info().GetModel(model.id);
        //            return model;
        //        }
        //    }
        //    return null;
        //}

        public static void alertMsg(Page page, string content)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + content + "');</script>", false);
        }

        public static void alertMsgUrl(Page page, string content, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + content + "');window.location.href=" + url + ";</script>", false);
        }

        public static void alertMsgFun(Page page, string content, string func)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + content + "');" + func + "();</script>", false);
        }
    }
}
