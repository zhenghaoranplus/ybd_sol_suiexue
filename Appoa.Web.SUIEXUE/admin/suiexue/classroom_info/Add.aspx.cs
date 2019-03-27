/*功能：生成实体类
 *编码日期:2017/8/23 14:42:20
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

namespace Appoa.Manage.admin.classroom_info
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_classroom_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_classroom_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "课堂名称为空或超出长度![br]"; }
                if (txtavatar.Text.Trim() == "" || txtavatar.Text.Trim().Length>255 ){ strError += "课堂头像/背景图为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "创建者ID为空或超出长度![br]"; }
                if (txtuser_name.Text.Trim() == "" || txtuser_name.Text.Trim().Length>50 ){ strError += "创建者姓名为空或超出长度![br]"; }
                if (txtinfo.Text.Trim() == "" || txtinfo.Text.Trim().Length>4000 ){ strError += "课堂简介为空或超出长度![br]"; }
                if (txtqrcode.Text.Trim() == "" || txtqrcode.Text.Trim().Length>255 ){ strError += "课堂二维码为空或超出长度![br]"; }
                if (txtis_show.Text.Trim() == "" || txtis_show.Text.Trim().Length>4 ){ strError += "是否公开为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "创建时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.classroom_info model = new Model.classroom_info();
            BLL.classroom_info bll = new BLL.classroom_info();
            
		        model.name = Convert.ToString(txtname.Text);
		        model.avatar = Convert.ToString(txtavatar.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.user_name = Convert.ToString(txtuser_name.Text);
		        model.info = Convert.ToString(txtinfo.Text);
		        model.qrcode = Convert.ToString(txtqrcode.Text);
		        model.is_show = Convert.ToInt32(txtis_show.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加课堂信息信息，主键:" + id); //记录日志
                JscriptMsg("添加课堂信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}