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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_company_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_company_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtlogo.Text.Trim() == "" || txtlogo.Text.Trim().Length>255 ){ strError += "logo为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>50 ){ strError += "标题为空或超出长度![br]"; }
                if (txtimg_url.Text.Trim() == "" || txtimg_url.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtvideo_thumb_img.Text.Trim() == "" || txtvideo_thumb_img.Text.Trim().Length>255 ){ strError += "视频缩略图为空或超出长度![br]"; }
                if (txtvideo_url.Text.Trim() == "" || txtvideo_url.Text.Trim().Length>255 ){ strError += "视频为空或超出长度![br]"; }
                if (txtabout_us.Text.Trim() == "" || txtabout_us.Text.Trim().Length>16 ){ strError += "关于我们为空或超出长度![br]"; }
                if (txtwho_are_we_img.Text.Trim() == "" || txtwho_are_we_img.Text.Trim().Length>255 ){ strError += "我们是谁左侧图为空或超出长度![br]"; }
                if (txtwho_are_we.Text.Trim() == "" || txtwho_are_we.Text.Trim().Length>255 ){ strError += "我们是谁文字为空或超出长度![br]"; }
                if (txtwhat_can_we_do.Text.Trim() == "" || txtwhat_can_we_do.Text.Trim().Length>4000 ){ strError += "我们能做什么文字[[中文,英文],[中文,英文],[中文,英文],[中文,英文]]为空或超出长度![br]"; }
                if (txtwhat_can_we_do_img.Text.Trim() == "" || txtwhat_can_we_do_img.Text.Trim().Length>255 ){ strError += "我们能做什么右侧图为空或超出长度![br]"; }
                if (txtwe_team_img.Text.Trim() == "" || txtwe_team_img.Text.Trim().Length>255 ){ strError += "我们的团队左侧图为空或超出长度![br]"; }
                if (txtwe_team.Text.Trim() == "" || txtwe_team.Text.Trim().Length>500 ){ strError += "我们的团队文字为空或超出长度![br]"; }
                if (txtcontact_us.Text.Trim() == "" || txtcontact_us.Text.Trim().Length>16 ){ strError += "联系我们为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.company_info model = new Model.company_info();
            BLL.company_info bll = new BLL.company_info();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加集团子公司信息信息，主键:" + id); //记录日志
                JscriptMsg("添加集团子公司信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}