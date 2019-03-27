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

namespace Appoa.Manage.admin.common_dict
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_dict", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_dict", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "名称为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>500 ){ strError += "字典项值为空或超出长度![br]"; }
                if (txttype.Text.Trim() == "" || txttype.Text.Trim().Length>4 ){ strError += "类型为空或超出长度![br]"; }
                if (txttype_name.Text.Trim() == "" || txttype_name.Text.Trim().Length>50 ){ strError += "类型名称为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_dict model = new Model.common_dict();
            BLL.common_dict bll = new BLL.common_dict();
            
		        model.name = Convert.ToString(txtname.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.type_name = Convert.ToString(txttype_name.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加字典项配置信息，主键:" + id); //记录日志
                JscriptMsg("添加字典项配置信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}