using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.message
{
    public partial class send_message : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_message_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_message_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限

            #region
            string strError = string.Empty;
            if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length > 50) { strError += "标题为空或超出长度!<br />"; }
            if (txtsubtitle.Text.Trim() == "" || txtsubtitle.Text.Trim().Length > 200) { strError += "摘要为空或超出长度!<br />"; }
            if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length > 4000) { strError += "内容为空或超出长度!<br />"; }

            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_message model = new Model.common_message();
            BLL.common_message bll = new BLL.common_message();

            model.group_id = (int)EnumCollection.message_group.系统消息;
            model.cover = "";
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = Convert.ToString(txtsubtitle.Text);
            model.contents = Convert.ToString(txtcontents.Text);
            model.sender_id = 0;
            model.receiver_id = 0;
            model.add_time = System.DateTime.Now;
            model.is_read = (int)EnumCollection.YesOrNot.否;
            model.is_send = (int)EnumCollection.YesOrNot.否;
            model.send_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加消息信息，主键:" + id); //记录日志
                JscriptMsg("添加消息信息成功！", "message_list.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}