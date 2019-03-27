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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_order", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_order", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtorder_no.Text.Trim() == "" || txtorder_no.Text.Trim().Length>100 ){ strError += "订单编号为空或超出长度![br]"; }
                if (txtorder_type.Text.Trim() == "" || txtorder_type.Text.Trim().Length>4 ){ strError += "订单来源为空或超出长度![br]"; }
                if (txttrade_no.Text.Trim() == "" || txttrade_no.Text.Trim().Length>100 ){ strError += "交易号为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "购买者id为空或超出长度![br]"; }
                if (txtuser_name.Text.Trim() == "" || txtuser_name.Text.Trim().Length>100 ){ strError += "用户名为空或超出长度![br]"; }
                if (txtpayment_way.Text.Trim() == "" || txtpayment_way.Text.Trim().Length>4 ){ strError += "支付方式 1货到付款为空或超出长度![br]"; }
                if (txtpayment_name.Text.Trim() == "" || txtpayment_name.Text.Trim().Length>50 ){ strError += "支付方式名称为空或超出长度![br]"; }
                if (txtpayment_fee.Text.Trim() == "" || txtpayment_fee.Text.Trim().Length>8 ){ strError += "支付手续费为空或超出长度![br]"; }
                if (txtpayment_time.Text.Trim() == "" || txtpayment_time.Text.Trim().Length>8 ){ strError += "支付时间为空或超出长度![br]"; }
                if (txtexpress_type.Text.Trim() == "" || txtexpress_type.Text.Trim().Length>4 ){ strError += "配送方式 1 快递配送为空或超出长度![br]"; }
                if (txtexpress_man_name.Text.Trim() == "" || txtexpress_man_name.Text.Trim().Length>50 ){ strError += "快递员为空或超出长度![br]"; }
                if (txtexpress_mobile.Text.Trim() == "" || txtexpress_mobile.Text.Trim().Length>20 ){ strError += "快递员电话为空或超出长度![br]"; }
                if (txtexpress_name.Text.Trim() == "" || txtexpress_name.Text.Trim().Length>50 ){ strError += "快递公司名称为空或超出长度![br]"; }
                if (txtexpress_no.Text.Trim() == "" || txtexpress_no.Text.Trim().Length>50 ){ strError += "快递单号为空或超出长度![br]"; }
                if (txtexpress_money.Text.Trim() == "" || txtexpress_money.Text.Trim().Length>8 ){ strError += "运费为空或超出长度![br]"; }
                if (txtaccept_name.Text.Trim() == "" || txtaccept_name.Text.Trim().Length>50 ){ strError += "收件人姓名为空或超出长度![br]"; }
                if (txtpost_code.Text.Trim() == "" || txtpost_code.Text.Trim().Length>20 ){ strError += "邮政编码为空或超出长度![br]"; }
                if (txtmobile.Text.Trim() == "" || txtmobile.Text.Trim().Length>20 ){ strError += "手机号为空或超出长度![br]"; }
                if (txtarea.Text.Trim() == "" || txtarea.Text.Trim().Length>100 ){ strError += "区域为空或超出长度![br]"; }
                if (txtaddress.Text.Trim() == "" || txtaddress.Text.Trim().Length>500 ){ strError += "详细地址为空或超出长度![br]"; }
                if (txtaddress_id.Text.Trim() == "" || txtaddress_id.Text.Trim().Length>4 ){ strError += "用户收货地址id为空或超出长度![br]"; }
                if (txtmessage.Text.Trim() == "" || txtmessage.Text.Trim().Length>500 ){ strError += "订单留言为空或超出长度![br]"; }
                if (txtremark.Text.Trim() == "" || txtremark.Text.Trim().Length>500 ){ strError += "订单备注为空或超出长度![br]"; }
                if (txtuse_point.Text.Trim() == "" || txtuse_point.Text.Trim().Length>4 ){ strError += "订单使用的积分为空或超出长度![br]"; }
                if (txtorder_amount.Text.Trim() == "" || txtorder_amount.Text.Trim().Length>8 ){ strError += "订单总金额为空或超出长度![br]"; }
                if (txtorder_coupon_money.Text.Trim() == "" || txtorder_coupon_money.Text.Trim().Length>8 ){ strError += "订单优惠总金额为空或超出长度![br]"; }
                if (txtpayable_amount.Text.Trim() == "" || txtpayable_amount.Text.Trim().Length>8 ){ strError += "需付商品总金额为空或超出长度![br]"; }
                if (txtstatus.Text.Trim() == "" || txtstatus.Text.Trim().Length>4 ){ strError += "订单状态为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "下单时间为空或超出长度![br]"; }
                if (txtconfirm_time.Text.Trim() == "" || txtconfirm_time.Text.Trim().Length>8 ){ strError += "确认时间为空或超出长度![br]"; }
                if (txtcomplete_time.Text.Trim() == "" || txtcomplete_time.Text.Trim().Length>8 ){ strError += "订单完成时间为空或超出长度![br]"; }
                if (txtdel_status.Text.Trim() == "" || txtdel_status.Text.Trim().Length>4 ){ strError += "删除状态0未删除1用户删除为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_order model = new Model.user_order();
            BLL.user_order bll = new BLL.user_order();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加订单信息信息，主键:" + id); //记录日志
                JscriptMsg("添加订单信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}