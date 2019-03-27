/*功能：生成实体类
 *编码日期:2017/7/14 16:51:50
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

namespace Appoa.Manage.admin.user_order
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
                ChkAdminLevel("_ybd_user_order", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_order bll = new BLL.user_order();
            Model.user_order model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtorder_no.Text = model.order_no + "";
		        txtorder_type.Text = model.order_type + "";
		        txttrade_no.Text = model.trade_no + "";
		        txtuser_id.Text = model.user_id + "";
		        txtuser_name.Text = model.user_name + "";
		        txtpayment_way.Text = model.payment_way + "";
		        txtpayment_name.Text = model.payment_name + "";
		        txtpayment_fee.Text = model.payment_fee + "";
		        txtpayment_time.Text = model.payment_time + "";
		        txtexpress_type.Text = model.express_type + "";
		        txtexpress_man_name.Text = model.express_man_name + "";
		        txtexpress_mobile.Text = model.express_mobile + "";
		        txtexpress_name.Text = model.express_name + "";
		        txtexpress_no.Text = model.express_no + "";
		        txtexpress_money.Text = model.express_money + "";
		        txtaccept_name.Text = model.accept_name + "";
		        txtpost_code.Text = model.post_code + "";
		        txtmobile.Text = model.mobile + "";
		        txtarea.Text = model.area + "";
		        txtaddress.Text = model.address + "";
		        txtaddress_id.Text = model.address_id + "";
		        txtmessage.Text = model.message + "";
		        txtremark.Text = model.remark + "";
		        txtuse_point.Text = model.use_point + "";
		        txtorder_amount.Text = model.order_amount + "";
		        txtorder_coupon_money.Text = model.order_coupon_money + "";
		        txtpayable_amount.Text = model.payable_amount + "";
		        txtstatus.Text = model.status + "";
		        txtadd_time.Text = model.add_time + "";
		        txtconfirm_time.Text = model.confirm_time + "";
		        txtcomplete_time.Text = model.complete_time + "";
		        txtdel_status.Text = model.del_status + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_order", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_order bll = new BLL.user_order();
            Model.user_order model = bll.GetModel(this.id);
            
		        model.order_no = Convert.ToString(txtorder_no.Text);
		        model.order_type = Convert.ToInt32(txtorder_type.Text);
		        model.trade_no = Convert.ToString(txttrade_no.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.user_name = Convert.ToString(txtuser_name.Text);
		        model.payment_way = Convert.ToInt32(txtpayment_way.Text);
		        model.payment_name = Convert.ToString(txtpayment_name.Text);
		        model.payment_fee = Convert.ToDecimal(txtpayment_fee.Text);
		        model.payment_time = Convert.ToDateTime(txtpayment_time.Text);
		        model.express_type = Convert.ToInt32(txtexpress_type.Text);
		        model.express_man_name = Convert.ToString(txtexpress_man_name.Text);
		        model.express_mobile = Convert.ToString(txtexpress_mobile.Text);
		        model.express_name = Convert.ToString(txtexpress_name.Text);
		        model.express_no = Convert.ToString(txtexpress_no.Text);
		        model.express_money = Convert.ToDecimal(txtexpress_money.Text);
		        model.accept_name = Convert.ToString(txtaccept_name.Text);
		        model.post_code = Convert.ToString(txtpost_code.Text);
		        model.mobile = Convert.ToString(txtmobile.Text);
		        model.area = Convert.ToString(txtarea.Text);
		        model.address = Convert.ToString(txtaddress.Text);
		        model.address_id = Convert.ToInt32(txtaddress_id.Text);
		        model.message = Convert.ToString(txtmessage.Text);
		        model.remark = Convert.ToString(txtremark.Text);
		        model.use_point = Convert.ToInt32(txtuse_point.Text);
		        model.order_amount = Convert.ToDecimal(txtorder_amount.Text);
		        model.order_coupon_money = Convert.ToDecimal(txtorder_coupon_money.Text);
		        model.payable_amount = Convert.ToDecimal(txtpayable_amount.Text);
		        model.status = Convert.ToInt32(txtstatus.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
		        model.confirm_time = Convert.ToDateTime(txtconfirm_time.Text);
		        model.complete_time = Convert.ToDateTime(txtcomplete_time.Text);
		        model.del_status = Convert.ToInt32(txtdel_status.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改订单信息信息，主键:" + id); //记录日志
                JscriptMsg("修改订单信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}