/*功能：生成实体类
 *编码日期:2017/6/21 16:35:50
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

namespace Appoa.Manage.admin.user_cart
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
                ChkAdminLevel("_ybd_user_cart", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_cart bll = new BLL.user_cart();
            Model.user_cart model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtct_id.Text = model.ct_id + "";
		        txtgroup_id.Text = model.group_id + "";
		        txtuser_id.Text = model.user_id + "";
		        txtgoods_sale_type.Text = model.goods_sale_type + "";
		        txtgoods_id.Text = model.goods_id + "";
		        txtgoods_name.Text = model.goods_name + "";
		        txtgoods_subtitle.Text = model.goods_subtitle + "";
		        txtgoods_img.Text = model.goods_img + "";
		        txtgoods_oprice.Text = model.goods_oprice + "";
		        txtgoods_price.Text = model.goods_price + "";
		        txtgoods_spec.Text = model.goods_spec + "";
		        txtgoods_spec_id.Text = model.goods_spec_id + "";
		        txtnum.Text = model.num + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_cart", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_cart bll = new BLL.user_cart();
            Model.user_cart model = bll.GetModel(this.id);
            
		        model.ct_id = Convert.ToInt32(txtct_id.Text);
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.goods_sale_type = Convert.ToInt32(txtgoods_sale_type.Text);
		        model.goods_id = Convert.ToInt32(txtgoods_id.Text);
		        model.goods_name = Convert.ToString(txtgoods_name.Text);
		        model.goods_subtitle = Convert.ToString(txtgoods_subtitle.Text);
		        model.goods_img = Convert.ToString(txtgoods_img.Text);
		        model.goods_oprice = Convert.ToDecimal(txtgoods_oprice.Text);
		        model.goods_price = Convert.ToDecimal(txtgoods_price.Text);
		        model.goods_spec = Convert.ToString(txtgoods_spec.Text);
		        model.goods_spec_id = Convert.ToString(txtgoods_spec_id.Text);
		        model.num = Convert.ToInt32(txtnum.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改购物车表信息，主键:" + id); //记录日志
                JscriptMsg("修改购物车表信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}