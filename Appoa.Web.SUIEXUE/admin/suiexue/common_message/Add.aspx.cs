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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_message", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_message", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txtcover.Text.Trim() == "" || txtcover.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>50 ){ strError += "标题为空或超出长度![br]"; }
                if (txtsubtitle.Text.Trim() == "" || txtsubtitle.Text.Trim().Length>200 ){ strError += "副标题为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>4000 ){ strError += "内容为空或超出长度![br]"; }
                if (txtsender_id.Text.Trim() == "" || txtsender_id.Text.Trim().Length>4 ){ strError += "发送者ID为空或超出长度![br]"; }
                if (txtreceiver_id.Text.Trim() == "" || txtreceiver_id.Text.Trim().Length>4 ){ strError += "接收者ID为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
                if (txtis_read.Text.Trim() == "" || txtis_read.Text.Trim().Length>4 ){ strError += "是否读取为空或超出长度![br]"; }
                if (txtis_send.Text.Trim() == "" || txtis_send.Text.Trim().Length>4 ){ strError += "是否已推送为空或超出长度![br]"; }
                if (txtsend_time.Text.Trim() == "" || txtsend_time.Text.Trim().Length>8 ){ strError += "推送时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_message model = new Model.common_message();
            BLL.common_message bll = new BLL.common_message();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加全局消息信息，主键:" + id); //记录日志
                JscriptMsg("添加全局消息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}