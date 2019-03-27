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

namespace Appoa.Manage.admin.user_oauths
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_oauths", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_oauths", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "用户ID为空或超出长度![br]"; }
                if (txttype.Text.Trim() == "" || txttype.Text.Trim().Length>4 ){ strError += "第三方平台登录类型为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "第三方平台登录类型名称为空或超出长度![br]"; }
                if (txtappid.Text.Trim() == "" || txtappid.Text.Trim().Length>50 ){ strError += "第三方appid为空或超出长度![br]"; }
                if (txtunionid.Text.Trim() == "" || txtunionid.Text.Trim().Length>50 ){ strError += "开放平台unionid为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_oauths model = new Model.user_oauths();
            BLL.user_oauths bll = new BLL.user_oauths();
            
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.appid = Convert.ToString(txtappid.Text);
		        model.unionid = Convert.ToString(txtunionid.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加用户认证信息，主键:" + id); //记录日志
                JscriptMsg("添加用户认证信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}