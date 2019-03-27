/*功能：生成实体类
 *编码日期:2017/7/14 9:44:51
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

namespace Appoa.Manage.admin.user_ordergoods
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
                ChkAdminLevel("_ybd_user_ordergoods", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_ordergoods bll = new BLL.user_ordergoods();
            Model.user_ordergoods model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtorder_id.Text = model.order_id + "";
		        txtgoods_group.Text = model.goods_group + "";
		        txtgoods_id.Text = model.goods_id + "";
		        txtgoods_title.Text = model.goods_title + "";
		        txtgoods_subtitle.Text = model.goods_subtitle + "";
		        txtgoods_spec.Text = model.goods_spec + "";
		        txtgoods_stock.Text = model.goods_stock + "";
		        txtimg_url.Text = model.img_url + "";
		        txtgoods_oprice.Text = model.goods_oprice + "";
		        txtgoods_price.Text = model.goods_price + "";
		        txtquantity.Text = model.quantity + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_ordergoods", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_ordergoods bll = new BLL.user_ordergoods();
            Model.user_ordergoods model = bll.GetModel(this.id);
            
		        model.order_id = Convert.ToInt32(txtorder_id.Text);
		        model.goods_group = Convert.ToInt32(txtgoods_group.Text);
		        model.goods_id = Convert.ToInt32(txtgoods_id.Text);
		        model.goods_title = Convert.ToString(txtgoods_title.Text);
		        model.goods_subtitle = Convert.ToString(txtgoods_subtitle.Text);
		        model.goods_spec = Convert.ToString(txtgoods_spec.Text);
		        model.goods_stock = Convert.ToInt32(txtgoods_stock.Text);
		        model.img_url = Convert.ToString(txtimg_url.Text);
		        model.goods_oprice = Convert.ToDecimal(txtgoods_oprice.Text);
		        model.goods_price = Convert.ToDecimal(txtgoods_price.Text);
		        model.quantity = Convert.ToInt32(txtquantity.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改订单购买商品表信息，主键:" + id); //记录日志
                JscriptMsg("修改订单购买商品表信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}