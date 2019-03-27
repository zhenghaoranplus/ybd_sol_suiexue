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
                ChkAdminLevel("_ybd_common_adR", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_adR bll = new BLL.common_adR();
            Model.common_adR model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtad_group_id.Text = model.ad_group_id + "";
		        txtad_group_name.Text = model.ad_group_name + "";
		        txtad_type_id.Text = model.ad_type_id + "";
		        txtad_type_name.Text = model.ad_type_name + "";
		        txtad_data_id.Text = model.ad_data_id + "";
		        txtad_data_title.Text = model.ad_data_title + "";
		        txtad_data_subtitle.Text = model.ad_data_subtitle + "";
		        txtad_data_img.Text = model.ad_data_img + "";
		        txtad_data_url.Text = model.ad_data_url + "";
		        txtad_sort_id.Text = model.ad_sort_id + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_adR", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_adR bll = new BLL.common_adR();
            Model.common_adR model = bll.GetModel(this.id);
            
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
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改广告位与数据对应信息，主键:" + id); //记录日志
                JscriptMsg("修改广告位与数据对应信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}