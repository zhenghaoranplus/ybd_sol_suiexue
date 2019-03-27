﻿/*功能：生成实体类
 *编码日期:2017/7/12 11:42:40
 *编码人：阴华伟
 *QQ:577372287
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;
using System.Data;

namespace Appoa.Manage.admin.user_info
{
    public partial class Modify : Web.UI.ManagePage
    {
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_info", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_info bll = new BLL.user_info();
            Model.user_info model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtuser_name.Text = model.user_name + "";
		        txtphone.Text = model.phone + "";
		        txtsalt.Text = model.salt + "";
		        txtuser_pwd.Text = model.user_pwd + "";
		        txtnick_name.Text = model.nick_name + "";
		        txtavatar.Text = model.avatar + "";
		        txtintegral.Text = model.integral + "";
		        txtschool_id.Text = model.school_id + "";
		        txtschool_name.Text = model.school_name + "";
		        txtcollege.Text = model.college + "";
		        txtjob.Text = model.job + "";
		        txtcourse.Text = model.course + "";
		        txtline_way.Text = model.line_way + "";
		        txtarea.Text = model.area + "";
		        txtaddress.Text = model.address + "";
		        txtreg_ip.Text = model.reg_ip + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_info", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_info bll = new BLL.user_info();
            Model.user_info model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_name = Convert.ToString(txtuser_name.Text);
		        model.phone = Convert.ToString(txtphone.Text);
		        model.salt = Convert.ToString(txtsalt.Text);
		        model.user_pwd = Convert.ToString(txtuser_pwd.Text);
		        model.nick_name = Convert.ToString(txtnick_name.Text);
		        model.avatar = Convert.ToString(txtavatar.Text);
		        model.integral = Convert.ToInt32(txtintegral.Text);
		        model.school_id = Convert.ToInt32(txtschool_id.Text);
		        model.school_name = Convert.ToString(txtschool_name.Text);
		        model.college = Convert.ToString(txtcollege.Text);
		        model.job = Convert.ToString(txtjob.Text);
		        model.course = Convert.ToString(txtcourse.Text);
		        model.line_way = Convert.ToString(txtline_way.Text);
		        model.area = Convert.ToString(txtarea.Text);
		        model.address = Convert.ToString(txtaddress.Text);
		        model.reg_ip = Convert.ToString(txtreg_ip.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改用户信息信息，主键:" + id); //记录日志
                JscriptMsg("修改用户信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}