/*功能：生成实体类
 *编码日期:2017/7/19 9:30:55
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

namespace Appoa.Manage.admin.user_readrecord
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_readrecord", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_readrecord", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txtdata_id.Text.Trim() == "" || txtdata_id.Text.Trim().Length>4 ){ strError += "数据ID为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "用户ID为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_readrecord model = new Model.user_readrecord();
            BLL.user_readrecord bll = new BLL.user_readrecord();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.data_id = Convert.ToInt32(txtdata_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加用户阅读记录信息，主键:" + id); //记录日志
                JscriptMsg("添加用户阅读记录信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}