/*功能：生成实体类
 *编码日期:2017/10/18 16:06:34
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

namespace Appoa.Manage.admin.company_partner
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
                ChkAdminLevel("_ybd_company_partner", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.company_partner bll = new BLL.company_partner();
            Model.company_partner model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtcompany_id.Text = model.company_id + "";
		        txtlogo.Text = model.logo + "";
		        txttitle.Text = model.title + "";
		        txtvideo_url.Text = model.video_url + "";
		        txtvideo_thumb_img.Text = model.video_thumb_img + "";
		        txtdetails.Text = model.details + "";
		        txtis_show.Text = model.is_show + "";
		        txtsort.Text = model.sort + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_company_partner", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.company_partner bll = new BLL.company_partner();
            Model.company_partner model = bll.GetModel(this.id);
            
		        model.company_id = Convert.ToInt32(txtcompany_id.Text);
		        model.logo = Convert.ToString(txtlogo.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.video_url = Convert.ToString(txtvideo_url.Text);
		        model.video_thumb_img = Convert.ToString(txtvideo_thumb_img.Text);
		        model.details = Convert.ToString(txtdetails.Text);
		        model.is_show = Convert.ToInt32(txtis_show.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改合作伙伴信息，主键:" + id); //记录日志
                JscriptMsg("修改合作伙伴信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}