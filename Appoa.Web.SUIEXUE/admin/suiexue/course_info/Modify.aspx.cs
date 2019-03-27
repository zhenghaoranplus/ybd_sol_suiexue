/*功能：生成实体类
 *编码日期:2017/8/23 14:42:26
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

namespace Appoa.Manage.admin.course_info
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
                ChkAdminLevel("_ybd_course_info", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.course_info bll = new BLL.course_info();
            Model.course_info model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtcategory_id.Text = model.category_id + "";
		        txtname.Text = model.name + "";
		        txtcover.Text = model.cover + "";
		        txtinfo.Text = model.info + "";
		        txtnotice.Text = model.notice + "";
		        txtqrcode.Text = model.qrcode + "";
		        txtqrcode_logo.Text = model.qrcode_logo + "";
		        txtuser_id.Text = model.user_id + "";
		        txtis_show.Text = model.is_show + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_course_info", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.course_info bll = new BLL.course_info();
            Model.course_info model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.category_id = Convert.ToInt32(txtcategory_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.cover = Convert.ToString(txtcover.Text);
		        model.info = Convert.ToString(txtinfo.Text);
		        model.notice = Convert.ToString(txtnotice.Text);
		        model.qrcode = Convert.ToString(txtqrcode.Text);
		        model.qrcode_logo = Convert.ToString(txtqrcode_logo.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.is_show = Convert.ToInt32(txtis_show.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改课程信息信息，主键:" + id); //记录日志
                JscriptMsg("修改课程信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}