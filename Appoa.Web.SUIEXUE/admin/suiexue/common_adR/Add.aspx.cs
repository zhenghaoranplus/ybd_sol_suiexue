/*功能：生成实体类
 *编码日期:2017/6/21 16:35:47
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

namespace Appoa.Manage.admin.common_adR
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_adR", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_adR", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtad_group_id.Text.Trim() == "" || txtad_group_id.Text.Trim().Length>4 ){ strError += "广告分组id为空或超出长度![br]"; }
                if (txtad_group_name.Text.Trim() == "" || txtad_group_name.Text.Trim().Length>50 ){ strError += "广告分组名称为空或超出长度![br]"; }
                if (txtad_type_id.Text.Trim() == "" || txtad_type_id.Text.Trim().Length>4 ){ strError += "广告类型id为空或超出长度![br]"; }
                if (txtad_type_name.Text.Trim() == "" || txtad_type_name.Text.Trim().Length>50 ){ strError += "广告类型name为空或超出长度![br]"; }
                if (txtad_data_id.Text.Trim() == "" || txtad_data_id.Text.Trim().Length>4 ){ strError += "广告数据id为空或超出长度![br]"; }
                if (txtad_data_title.Text.Trim() == "" || txtad_data_title.Text.Trim().Length>50 ){ strError += "广告数据标题为空或超出长度![br]"; }
                if (txtad_data_subtitle.Text.Trim() == "" || txtad_data_subtitle.Text.Trim().Length>500 ){ strError += "广告数据副标题为空或超出长度![br]"; }
                if (txtad_data_img.Text.Trim() == "" || txtad_data_img.Text.Trim().Length>500 ){ strError += "广告数据图片为空或超出长度![br]"; }
                if (txtad_data_url.Text.Trim() == "" || txtad_data_url.Text.Trim().Length>500 ){ strError += "广告位链接为空或超出长度![br]"; }
                if (txtad_sort_id.Text.Trim() == "" || txtad_sort_id.Text.Trim().Length>4 ){ strError += "排序为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_adR model = new Model.common_adR();
            BLL.common_adR bll = new BLL.common_adR();
            
		        model.ad_group_id = Convert.ToInt32(txtad_group_id.Text);
		        model.ad_group_name = Convert.ToString(txtad_group_name.Text);
		        model.ad_type_id = Convert.ToInt32(txtad_type_id.Text);
		        model.ad_type_name = Convert.ToString(txtad_type_name.Text);
		        model.ad_data_id = Convert.ToInt32(txtad_data_id.Text);
		        model.ad_data_title = Convert.ToString(txtad_data_title.Text);
		        model.ad_data_subtitle = Convert.ToString(txtad_data_subtitle.Text);
		        model.ad_data_img = Convert.ToString(txtad_data_img.Text);
		        model.ad_data_url = Convert.ToString(txtad_data_url.Text);
		        model.ad_sort_id = Convert.ToInt32(txtad_sort_id.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加广告位与数据对应信息，主键:" + id); //记录日志
                JscriptMsg("添加广告位与数据对应信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}