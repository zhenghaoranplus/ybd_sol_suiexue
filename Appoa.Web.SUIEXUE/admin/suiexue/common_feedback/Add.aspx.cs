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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_feedback", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_feedback", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组id为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "反馈者id为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>255 ){ strError += "反馈内容为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "反馈时间为空或超出长度![br]"; }
                if (txtis_read.Text.Trim() == "" || txtis_read.Text.Trim().Length>4 ){ strError += "是否读取为空或超出长度![br]"; }
                if (txtread_time.Text.Trim() == "" || txtread_time.Text.Trim().Length>8 ){ strError += "读取时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_feedback model = new Model.common_feedback();
            BLL.common_feedback bll = new BLL.common_feedback();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
		        model.is_read = Convert.ToInt32(txtis_read.Text);
		        model.read_time = Convert.ToDateTime(txtread_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加全局反馈记录信息，主键:" + id); //记录日志
                JscriptMsg("添加全局反馈记录信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}