/*功能：生成实体类
 *编码日期:2017/10/18 10:18:12
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

namespace Appoa.Manage.admin.common_resource
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
                ChkAdminLevel("_ybd_common_resource", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtfrom_id.Text = model.from_id + "";
		        txtgroup_id.Text = model.group_id + "";
		        txttype.Text = model.type + "";
		        txtschool_id.Text = model.school_id + "";
		        txtschool_name.Text = model.school_name + "";
		        txtdata_id.Text = model.data_id + "";
		        txtuser_id.Text = model.user_id + "";
		        txttitle.Text = model.title + "";
		        txtcover.Text = model.cover + "";
		        txtpath.Text = model.path + "";
		        txtqrcode.Text = model.qrcode + "";
		        txtfile_name.Text = model.file_name + "";
		        txtextend.Text = model.extend + "";
		        txtlikn_url.Text = model.likn_url + "";
		        txtshare_user.Text = model.share_user + "";
		        txtsort.Text = model.sort + "";
		        txtadd_time.Text = model.add_time + "";
		        txtis_del.Text = model.is_del + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_resource", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(this.id);
            
		        model.from_id = Convert.ToInt32(txtfrom_id.Text);
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.school_id = Convert.ToInt32(txtschool_id.Text);
		        model.school_name = Convert.ToString(txtschool_name.Text);
		        model.data_id = Convert.ToInt32(txtdata_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.cover = Convert.ToString(txtcover.Text);
		        model.path = Convert.ToString(txtpath.Text);
		        model.qrcode = Convert.ToString(txtqrcode.Text);
		        model.file_name = Convert.ToString(txtfile_name.Text);
		        model.extend = Convert.ToString(txtextend.Text);
		        model.likn_url = Convert.ToString(txtlikn_url.Text);
		        model.share_user = Convert.ToString(txtshare_user.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
		        model.is_del = Convert.ToInt32(txtis_del.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改资源信息信息，主键:" + id); //记录日志
                JscriptMsg("修改资源信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}