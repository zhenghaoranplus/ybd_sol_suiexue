/*功能：生成实体类
 *编码日期:2017/10/17 13:49:55
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

namespace Appoa.Manage.admin.common_albums
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
                ChkAdminLevel("_ybd_common_albums", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_albums bll = new BLL.common_albums();
            Model.common_albums model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtrc_title.Text = model.rc_title + "";
		        txtrc_type.Text = model.rc_type + "";
		        txtrc_data_id.Text = model.rc_data_id + "";
		        txtthumb_path.Text = model.thumb_path + "";
		        txtoriginal_path.Text = model.original_path + "";
		        txtremark.Text = model.remark + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_albums", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_albums bll = new BLL.common_albums();
            Model.common_albums model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.rc_title = Convert.ToString(txtrc_title.Text);
		        model.rc_type = Convert.ToInt32(txtrc_type.Text);
		        model.rc_data_id = Convert.ToInt32(txtrc_data_id.Text);
		        model.thumb_path = Convert.ToString(txtthumb_path.Text);
		        model.original_path = Convert.ToString(txtoriginal_path.Text);
		        model.remark = Convert.ToString(txtremark.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改全局相册信息，主键:" + id); //记录日志
                JscriptMsg("修改全局相册信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}