﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin
{
    public partial class right : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.sys_manager admin_info = GetAdminInfo(); //管理员信息
                //登录信息
                if (admin_info != null)
                {
                    BLL.manager_log bll = new BLL.manager_log();
                    Model.manager_log model1 = bll.GetModel(admin_info.user_name, 1, EnumCollection.ActionEnum.Login.ToString());
                    if (model1 != null)
                    {
                        //本次登录
                        litIP.Text = model1.user_ip;
                    }
                    Model.manager_log model2 = bll.GetModel(admin_info.user_name, 2, EnumCollection.ActionEnum.Login.ToString());
                    if (model2 != null)
                    {
                        //上一次登录
                        litBackIP.Text = model2.user_ip;
                        litBackTime.Text = model2.add_time.ToString();
                    }
                }
            }
        }
    }
}