/*功能：生成实体类
 *编码日期:2017/7/5 14:12:11
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

namespace Appoa.Manage.admin.classroom_user
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
                ChkAdminLevel("_ybd_classroom_user", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.classroom_user bll = new BLL.classroom_user();
            Model.classroom_user model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtclassroom_id.Text = model.classroom_id + "";
		        txtuser_id.Text = model.user_id + "";
		        txtcontents.Text = model.contents + "";
		        txtstatus.Text = model.status + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_classroom_user", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.classroom_user bll = new BLL.classroom_user();
            Model.classroom_user model = bll.GetModel(this.id);
            
		        model.classroom_id = Convert.ToInt32(txtclassroom_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.status = Convert.ToInt32(txtstatus.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改课堂用户关系信息，主键:" + id); //记录日志
                JscriptMsg("修改课堂用户关系信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}