/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
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

namespace Appoa.Manage.admin.common_message
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
                ChkAdminLevel("_ybd_common_message", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_message bll = new BLL.common_message();
            Model.common_message model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtcover.Text = model.cover + "";
		        txttitle.Text = model.title + "";
		        txtsubtitle.Text = model.subtitle + "";
		        txtcontents.Text = model.contents + "";
		        txtsender_id.Text = model.sender_id + "";
		        txtreceiver_id.Text = model.receiver_id + "";
		        txtadd_time.Text = model.add_time + "";
		        txtis_read.Text = model.is_read + "";
		        txtis_send.Text = model.is_send + "";
		        txtsend_time.Text = model.send_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_message", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_message bll = new BLL.common_message();
            Model.common_message model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.cover = Convert.ToString(txtcover.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.subtitle = Convert.ToString(txtsubtitle.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.sender_id = Convert.ToInt32(txtsender_id.Text);
		        model.receiver_id = Convert.ToInt32(txtreceiver_id.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
		        model.is_read = Convert.ToInt32(txtis_read.Text);
		        model.is_send = Convert.ToInt32(txtis_send.Text);
		        model.send_time = Convert.ToDateTime(txtsend_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改全局消息信息，主键:" + id); //记录日志
                JscriptMsg("修改全局消息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}