using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.shop
{
    public partial class order_detail : Web.UI.ManagePage
    {
        private int id = 0;
        private string action = EnumCollection.ActionEnum.Modify.ToString();
        protected Model.user_order model = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            model = new BLL.user_order().GetModel(this.id);

            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            if (this.action == EnumCollection.ActionEnum.Modify.ToString())
            {
                if (!new BLL.user_order().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_order_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                this.btnExpress.Visible = false;
                this.btnSubmit.Visible = false;
                this.txtexpress_name.Enabled = false;
                this.txtexpress_no.Enabled = false;
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_order bll = new BLL.user_order();
            
            txtorder_no.Text = model.order_no + "";
            txtuser_name.Text = model.user_name + "";
            txtexpress_name.Text = model.express_name + "";
            txtexpress_no.Text = model.express_no + "";
            txtexpress_money.Text = model.express_money.ToString("F2");
            txtaccept_name.Text = model.accept_name + "";
            txtmobile.Text = model.mobile + "";
            txtaddress.Text = model.area + model.address + "";
            txtmessage.Text = model.message + "";
            txtuse_point.Text = model.use_point.ToString("F0");
            txtorder_amount.Text = model.order_amount.ToString("F2");
            txtpayable_amount.Text = model.payable_amount.ToString("F2");
            txtstatus.Text = Enum.GetName(typeof(EnumCollection.order_status), model.status);
            txtadd_time.Text = model.add_time + "";
            txtconfirm_time.Text = model.confirm_time + "";
            txtcomplete_time.Text = model.complete_time + "";

            rptOrderGoods.DataSource = new BLL.user_ordergoods().GetListByPage("*", "View_OrderGoodsInfo", "order_id = " + model.id, "id desc", 1, 1000);
            rptOrderGoods.DataBind();

            switch (model.status)
            {
                case (int)EnumCollection.order_status.待发货:
                    this.btnExpress.Visible = true;
                    this.btnSubmit.Visible = false;
                    this.txtexpress_name.Enabled = true;
                    this.txtexpress_no.Enabled = true;
                    break;
                case (int)EnumCollection.order_status.待收货:
                    this.btnExpress.Visible = false;
                    this.btnSubmit.Visible = true;
                    this.txtexpress_name.Enabled = true;
                    this.txtexpress_no.Enabled = true;
                    break;
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_order_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_order bll = new BLL.user_order();
            Model.user_order model = bll.GetModel(this.id);

            model.express_name = Convert.ToString(txtexpress_name.Text);
            model.express_no = Convert.ToString(txtexpress_no.Text);

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改订单物流信息，主键:" + id); //记录日志
                JscriptMsg("修改订单物流信息成功！", "back");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }

        //确认发货
        protected void btnExpress_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_order_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_order bll = new BLL.user_order();
            Model.user_order model = bll.GetModel(this.id);

            model.express_name = Convert.ToString(txtexpress_name.Text);
            model.express_no = Convert.ToString(txtexpress_no.Text);
            model.status = (int)EnumCollection.order_status.待收货;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改订单物流信息，主键:" + id); //记录日志
                JscriptMsg("修改订单物流信息成功！", "back");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}