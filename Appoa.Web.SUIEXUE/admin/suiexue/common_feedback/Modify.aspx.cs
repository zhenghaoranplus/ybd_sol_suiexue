/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
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

namespace Appoa.Manage.admin.common_feedback
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
                ChkAdminLevel("_ybd_common_feedback", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_feedback bll = new BLL.common_feedback();
            Model.common_feedback model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtuser_id.Text = model.user_id + "";
		        txtcontents.Text = model.contents + "";
		        txtadd_time.Text = model.add_time + "";
		        txtis_read.Text = model.is_read + "";
		        txtread_time.Text = model.read_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_feedback", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_feedback bll = new BLL.common_feedback();
            Model.common_feedback model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
		        model.is_read = Convert.ToInt32(txtis_read.Text);
		        model.read_time = Convert.ToDateTime(txtread_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改全局反馈记录信息，主键:" + id); //记录日志
                JscriptMsg("修改全局反馈记录信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}