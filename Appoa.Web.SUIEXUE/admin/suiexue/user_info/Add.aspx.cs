/*功能：生成实体类
 *编码日期:2017/7/12 11:42:39
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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "用户分组为空或超出长度![br]"; }
                if (txtuser_name.Text.Trim() == "" || txtuser_name.Text.Trim().Length>50 ){ strError += "用户名为空或超出长度![br]"; }
                if (txtphone.Text.Trim() == "" || txtphone.Text.Trim().Length>50 ){ strError += "手机号为空或超出长度![br]"; }
                if (txtsalt.Text.Trim() == "" || txtsalt.Text.Trim().Length>50 ){ strError += "随机加密字符串为空或超出长度![br]"; }
                if (txtuser_pwd.Text.Trim() == "" || txtuser_pwd.Text.Trim().Length>200 ){ strError += "密码为空或超出长度![br]"; }
                if (txtnick_name.Text.Trim() == "" || txtnick_name.Text.Trim().Length>50 ){ strError += "昵称为空或超出长度![br]"; }
                if (txtavatar.Text.Trim() == "" || txtavatar.Text.Trim().Length>255 ){ strError += "头像为空或超出长度![br]"; }
                if (txtintegral.Text.Trim() == "" || txtintegral.Text.Trim().Length>4 ){ strError += "积分为空或超出长度![br]"; }
                if (txtschool_id.Text.Trim() == "" || txtschool_id.Text.Trim().Length>4 ){ strError += "学校ID为空或超出长度![br]"; }
                if (txtschool_name.Text.Trim() == "" || txtschool_name.Text.Trim().Length>50 ){ strError += "学校姓名为空或超出长度![br]"; }
                if (txtcollege.Text.Trim() == "" || txtcollege.Text.Trim().Length>50 ){ strError += "院系为空或超出长度![br]"; }
                if (txtjob.Text.Trim() == "" || txtjob.Text.Trim().Length>50 ){ strError += "职位为空或超出长度![br]"; }
                if (txtcourse.Text.Trim() == "" || txtcourse.Text.Trim().Length>50 ){ strError += "所授课程为空或超出长度![br]"; }
                if (txtline_way.Text.Trim() == "" || txtline_way.Text.Trim().Length>50 ){ strError += "联系方式为空或超出长度![br]"; }
                if (txtarea.Text.Trim() == "" || txtarea.Text.Trim().Length>200 ){ strError += "区域为空或超出长度![br]"; }
                if (txtaddress.Text.Trim() == "" || txtaddress.Text.Trim().Length>200 ){ strError += "详细地址为空或超出长度![br]"; }
                if (txtreg_ip.Text.Trim() == "" || txtreg_ip.Text.Trim().Length>50 ){ strError += "注册IP为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "注册时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_info model = new Model.user_info();
            BLL.user_info bll = new BLL.user_info();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加用户信息信息，主键:" + id); //记录日志
                JscriptMsg("添加用户信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}