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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_classroom_user", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_classroom_user", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtclassroom_id.Text.Trim() == "" || txtclassroom_id.Text.Trim().Length>4 ){ strError += "课堂ID为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "用户ID为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>200 ){ strError += "申请内容为空或超出长度![br]"; }
                if (txtstatus.Text.Trim() == "" || txtstatus.Text.Trim().Length>4 ){ strError += "审核状态为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "申请时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.classroom_user model = new Model.classroom_user();
            BLL.classroom_user bll = new BLL.classroom_user();
            
		        model.classroom_id = Convert.ToInt32(txtclassroom_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.status = Convert.ToInt32(txtstatus.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加课堂用户关系信息，主键:" + id); //记录日志
                JscriptMsg("添加课堂用户关系信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}