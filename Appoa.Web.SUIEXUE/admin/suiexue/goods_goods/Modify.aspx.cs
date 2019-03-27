/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
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

namespace Appoa.Manage.admin.goods_goods
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
                ChkAdminLevel("_ybd_goods_goods", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.goods_goods bll = new BLL.goods_goods();
            Model.goods_goods model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtct_id.Text = model.ct_id + "";
		        txtgroup_id.Text = model.group_id + "";
		        txtcategory_id.Text = model.category_id + "";
		        txttitle.Text = model.title + "";
		        txtsubtitle.Text = model.subtitle + "";
		        txtimg_src.Text = model.img_src + "";
		        txtoprice.Text = model.oprice + "";
		        txtprice.Text = model.price + "";
		        txtparameters.Text = model.parameters + "";
		        txtdetails.Text = model.details + "";
		        txtsales_num.Text = model.sales_num + "";
		        txtstatus.Text = model.status + "";
		        txtsj_time.Text = model.sj_time + "";
		        txtxj_time.Text = model.xj_time + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_goods_goods", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.goods_goods bll = new BLL.goods_goods();
            Model.goods_goods model = bll.GetModel(this.id);
            
		        model.ct_id = Convert.ToInt32(txtct_id.Text);
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.category_id = Convert.ToInt32(txtcategory_id.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.subtitle = Convert.ToString(txtsubtitle.Text);
		        model.img_src = Convert.ToString(txtimg_src.Text);
		        model.oprice = Convert.ToDecimal(txtoprice.Text);
		        model.price = Convert.ToDecimal(txtprice.Text);
		        model.parameters = Convert.ToString(txtparameters.Text);
		        model.details = Convert.ToString(txtdetails.Text);
		        model.sales_num = Convert.ToInt32(txtsales_num.Text);
		        model.status = Convert.ToInt32(txtstatus.Text);
		        model.sj_time = Convert.ToDateTime(txtsj_time.Text);
		        model.xj_time = Convert.ToDateTime(txtxj_time.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改商品信息信息，主键:" + id); //记录日志
                JscriptMsg("修改商品信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}