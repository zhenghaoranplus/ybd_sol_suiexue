/*功能：生成实体类
 *编码日期:2017/7/20 8:50:22
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

namespace Appoa.Manage.admin.user_tree
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_tree", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_tree", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "用户ID为空或超出长度![br]"; }
                if (txtcode.Text.Trim() == "" || txtcode.Text.Trim().Length>10 ){ strError += "唯一标识code为空或超出长度![br]"; }
                if (txtparent_code.Text.Trim() == "" || txtparent_code.Text.Trim().Length>10 ){ strError += "父级code为空或超出长度![br]"; }
                if (txtgrand_code.Text.Trim() == "" || txtgrand_code.Text.Trim().Length>10 ){ strError += "父级的父级code为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_tree model = new Model.user_tree();
            BLL.user_tree bll = new BLL.user_tree();
            
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.code = Convert.ToString(txtcode.Text);
		        model.parent_code = Convert.ToString(txtparent_code.Text);
		        model.grand_code = Convert.ToString(txtgrand_code.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加用户关系信息，主键:" + id); //记录日志
                JscriptMsg("添加用户关系信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}