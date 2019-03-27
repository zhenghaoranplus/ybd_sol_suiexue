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
                ChkAdminLevel("_ybd_user_integral", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_integral bll = new BLL.user_integral();
            Model.user_integral model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtuser_id.Text = model.user_id + "";
		        txtintegral.Text = model.integral + "";
		        txtget_or_use.Text = model.get_or_use + "";
		        txttype.Text = model.type + "";
		        txttype_name.Text = model.type_name + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_integral", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_integral bll = new BLL.user_integral();
            Model.user_integral model = bll.GetModel(this.id);
            
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.integral = Convert.ToInt32(txtintegral.Text);
		        model.get_or_use = Convert.ToInt32(txtget_or_use.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.type_name = Convert.ToString(txttype_name.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改积分记录信息，主键:" + id); //记录日志
                JscriptMsg("修改积分记录信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}