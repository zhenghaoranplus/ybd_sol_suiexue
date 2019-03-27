using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.user
{
    public partial class share_user_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (this.action == EnumCollection.ActionEnum.Modify.ToString())
            {
                if (!new BLL.user_info().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_share_user_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo();
                }
            }
        }

        #region 赋值操作

        private void ShowInfo()
        {
            BLL.user_info bll = new BLL.user_info();
            Model.user_info model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            txtuser_name.Text = model.user_name + "";
            txtphone.Text = model.phone + "";
            txtuser_pwd.Text = DESEncrypt.Decrypt(model.user_pwd, model.salt.Trim());
            txtnick_name.Text = model.nick_name + "";
            txtavatar.Text = model.avatar + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.user_info bll = new BLL.user_info();

            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_share_user_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                Model.user_info model = bll.GetModel(this.id);

                model.group_id = (int)EnumCollection.user_group.资源分享用户;
                model.user_name = Convert.ToString(txtuser_name.Text);
                model.phone = Convert.ToString(txtphone.Text);
                model.salt = Utils.GetCheckCode(6);
                model.user_pwd = DESEncrypt.Encrypt(txtuser_pwd.Text.Trim().ToUpper(), model.salt.Trim());
                model.nick_name = Convert.ToString(txtnick_name.Text);
                model.avatar = Convert.ToString(txtavatar.Text);
                model.school_id = 0;
                model.school_name = "";
                model.college = "";
                model.job = "";
                model.course = "";
                model.line_way = "";
                model.area = "";
                model.address = "";
                model.reg_ip = RequestHelper.GetIP();

                if (bll.Update(model))
                {
                    AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改用户信息，主键:" + id); //记录日志
                    JscriptMsg("修改用户信息成功！", "share_user_list.aspx?page=" + this.page);
                }
                else
                {
                    JscriptMsg("保存过程中发生错误！", "");
                }
            }
            else //添加
            {
                ChkAdminLevel("_course_adR", EnumCollection.ActionEnum.Add.ToString()); //检查权限

                Model.user_info model = bll.GetModel(" phone = '" + this.txtphone.Text.Trim() + "'");
                if (model != null)
                {
                    JscriptMsg("此手机号已被注册", "");
                    return;
                }

                model = new Model.user_info();
                model.group_id = (int)EnumCollection.user_group.资源分享用户;
                model.user_name = Convert.ToString(txtuser_name.Text);
                model.phone = Convert.ToString(txtphone.Text);
                model.salt = Utils.GetCheckCode(6);
                model.user_pwd = DESEncrypt.Encrypt(Utils.MD5(txtuser_pwd.Text.Trim()).ToUpper(), model.salt.Trim());
                model.nick_name = Convert.ToString(txtnick_name.Text);
                model.avatar = Convert.ToString(txtavatar.Text);
                model.school_id = 0;
                model.school_name = "";
                model.college = "";
                model.job = "";
                model.course = "";
                model.line_way = "";
                model.area = "";
                model.address = "";
                model.reg_ip = RequestHelper.GetIP();
                model.add_time = System.DateTime.Now;

                int id = bll.Add(model);
                if (id > 0)
                {
                    AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加用户信息，主键:" + id); //记录日志
                    JscriptMsg("添加用户信息成功！", "share_user_list.aspx");
                }
                else
                {
                    JscriptMsg("保存过程中发生错误！", "");
                }
            }
        }
    }
}