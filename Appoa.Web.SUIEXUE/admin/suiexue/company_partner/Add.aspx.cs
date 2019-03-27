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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_company_partner", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_company_partner", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtcompany_id.Text.Trim() == "" || txtcompany_id.Text.Trim().Length>4 ){ strError += "公司id为空或超出长度![br]"; }
                if (txtlogo.Text.Trim() == "" || txtlogo.Text.Trim().Length>255 ){ strError += "logo为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>50 ){ strError += "标题为空或超出长度![br]"; }
                if (txtvideo_url.Text.Trim() == "" || txtvideo_url.Text.Trim().Length>255 ){ strError += "视频地址为空或超出长度![br]"; }
                if (txtvideo_thumb_img.Text.Trim() == "" || txtvideo_thumb_img.Text.Trim().Length>255 ){ strError += "视频缩略图地址为空或超出长度![br]"; }
                if (txtdetails.Text.Trim() == "" || txtdetails.Text.Trim().Length>16 ){ strError += "案例详情为空或超出长度![br]"; }
                if (txtis_show.Text.Trim() == "" || txtis_show.Text.Trim().Length>4 ){ strError += "是否显示为空或超出长度![br]"; }
                if (txtsort.Text.Trim() == "" || txtsort.Text.Trim().Length>4 ){ strError += "排序为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.company_partner model = new Model.company_partner();
            BLL.company_partner bll = new BLL.company_partner();
            
		        model.company_id = Convert.ToInt32(txtcompany_id.Text);
		        model.logo = Convert.ToString(txtlogo.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.video_url = Convert.ToString(txtvideo_url.Text);
		        model.video_thumb_img = Convert.ToString(txtvideo_thumb_img.Text);
		        model.details = Convert.ToString(txtdetails.Text);
		        model.is_show = Convert.ToInt32(txtis_show.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加合作伙伴信息，主键:" + id); //记录日志
                JscriptMsg("添加合作伙伴信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}