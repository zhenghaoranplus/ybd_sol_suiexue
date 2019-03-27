/*功能：生成实体类
 *编码日期:2017/11/29 9:33:49
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

namespace Appoa.Manage.admin.company_info
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
                ChkAdminLevel("_ybd_company_info", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.company_info bll = new BLL.company_info();
            Model.company_info model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtlogo.Text = model.logo + "";
		        txttitle.Text = model.title + "";
		        txtimg_url.Text = model.img_url + "";
		        txtvideo_thumb_img.Text = model.video_thumb_img + "";
		        txtvideo_url.Text = model.video_url + "";
		        txtabout_us.Text = model.about_us + "";
		        txtwho_are_we_img.Text = model.who_are_we_img + "";
		        txtwho_are_we.Text = model.who_are_we + "";
		        txtwhat_can_we_do.Text = model.what_can_we_do + "";
		        txtwhat_can_we_do_img.Text = model.what_can_we_do_img + "";
		        txtwe_team_img.Text = model.we_team_img + "";
		        txtwe_team.Text = model.we_team + "";
		        txtcontact_us.Text = model.contact_us + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_company_info", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.company_info bll = new BLL.company_info();
            Model.company_info model = bll.GetModel(this.id);
            
		        model.logo = Convert.ToString(txtlogo.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.img_url = Convert.ToString(txtimg_url.Text);
		        model.video_thumb_img = Convert.ToString(txtvideo_thumb_img.Text);
		        model.video_url = Convert.ToString(txtvideo_url.Text);
		        model.about_us = Convert.ToString(txtabout_us.Text);
		        model.who_are_we_img = Convert.ToString(txtwho_are_we_img.Text);
		        model.who_are_we = Convert.ToString(txtwho_are_we.Text);
		        model.what_can_we_do = Convert.ToString(txtwhat_can_we_do.Text);
		        model.what_can_we_do_img = Convert.ToString(txtwhat_can_we_do_img.Text);
		        model.we_team_img = Convert.ToString(txtwe_team_img.Text);
		        model.we_team = Convert.ToString(txtwe_team.Text);
		        model.contact_us = Convert.ToString(txtcontact_us.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改集团子公司信息信息，主键:" + id); //记录日志
                JscriptMsg("修改集团子公司信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}