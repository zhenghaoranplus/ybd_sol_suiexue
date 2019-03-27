using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Appoa.Common;

namespace Appoa.Manage.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Uri Url = HttpContext.Current.Request.UrlReferrer;
                txtUserName.Text = Utils.GetCookie("DTRememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "请输入用户名或密码";
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            //if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            //{
            //    msgtip.InnerHtml = "错误超过5次，关闭浏览器重新登录！";
            //    return;
            //}
            BLL.sys_manager bll = new BLL.sys_manager();
            Model.sys_manager model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }
            
            //写入登录日志
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.manager_log().Add(model.id, model.user_name, EnumCollection.ActionEnum.Login.ToString(), "用户登录");
            }

            //写入Cookies
            Utils.WriteCookie("DTRememberName", model.user_name, 14400);
            Session[AppoaKeys.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;

            Utils.WriteCookie("AdminName", "DTcms", model.user_name);
            Utils.WriteCookie("AdminPwd", "DTcms", model.password);
            Response.Redirect("index.aspx");
            return;

            //if (model.role_type == 1)
            //{
            //    Session[AppoaKeys.SESSION_ADMIN_INFO] = model;
            //    Session.Timeout = 45;

            //    Utils.WriteCookie("AdminName", "DTcms", model.user_name);
            //    Utils.WriteCookie("AdminPwd", "DTcms", model.password);
            //    Response.Redirect("index.aspx");
            //    return;
            //}
            //if (model.role_type == 2)
            //{
            //    Session[AppoaKeys.SESSION_USER_INFO] = model;
            //    Session.Timeout = 45;

            //    Utils.WriteCookie("UserName", "DTcms", model.user_name);
            //    Utils.WriteCookie("UserPwd", "DTcms", model.password);
            //    Response.Redirect("index_user.aspx");
            //    return;
            //}
        }

    }
}