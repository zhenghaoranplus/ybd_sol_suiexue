/*功能：生成实体类
 *编码日期:2017/6/21 16:35:50
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

namespace Appoa.Manage.admin.user_integral
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_integral", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_integral", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "用户ID为空或超出长度![br]"; }
                if (txtintegral.Text.Trim() == "" || txtintegral.Text.Trim().Length>4 ){ strError += "积分值为空或超出长度![br]"; }
                if (txtget_or_use.Text.Trim() == "" || txtget_or_use.Text.Trim().Length>4 ){ strError += "获得或使用 1获得 2使用为空或超出长度![br]"; }
                if (txttype.Text.Trim() == "" || txttype.Text.Trim().Length>4 ){ strError += "积分类型为空或超出长度![br]"; }
                if (txttype_name.Text.Trim() == "" || txttype_name.Text.Trim().Length>50 ){ strError += "积分类型名称为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "操作时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_integral model = new Model.user_integral();
            BLL.user_integral bll = new BLL.user_integral();
            
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.integral = Convert.ToInt32(txtintegral.Text);
		        model.get_or_use = Convert.ToInt32(txtget_or_use.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.type_name = Convert.ToString(txttype_name.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加积分记录信息，主键:" + id); //记录日志
                JscriptMsg("添加积分记录信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}