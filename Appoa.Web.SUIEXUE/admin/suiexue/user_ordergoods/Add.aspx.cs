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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_ordergoods", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_ordergoods", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtorder_id.Text.Trim() == "" || txtorder_id.Text.Trim().Length>4 ){ strError += "订单id为空或超出长度![br]"; }
                if (txtgoods_group.Text.Trim() == "" || txtgoods_group.Text.Trim().Length>4 ){ strError += "商品分组为空或超出长度![br]"; }
                if (txtgoods_id.Text.Trim() == "" || txtgoods_id.Text.Trim().Length>4 ){ strError += "商品id为空或超出长度![br]"; }
                if (txtgoods_title.Text.Trim() == "" || txtgoods_title.Text.Trim().Length>100 ){ strError += "标题为空或超出长度![br]"; }
                if (txtgoods_subtitle.Text.Trim() == "" || txtgoods_subtitle.Text.Trim().Length>255 ){ strError += "副标题为空或超出长度![br]"; }
                if (txtgoods_spec.Text.Trim() == "" || txtgoods_spec.Text.Trim().Length>4000 ){ strError += "规格为空或超出长度![br]"; }
                if (txtgoods_stock.Text.Trim() == "" || txtgoods_stock.Text.Trim().Length>4 ){ strError += "库存为空或超出长度![br]"; }
                if (txtimg_url.Text.Trim() == "" || txtimg_url.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtgoods_oprice.Text.Trim() == "" || txtgoods_oprice.Text.Trim().Length>8 ){ strError += "原价为空或超出长度![br]"; }
                if (txtgoods_price.Text.Trim() == "" || txtgoods_price.Text.Trim().Length>8 ){ strError += "现价为空或超出长度![br]"; }
                if (txtquantity.Text.Trim() == "" || txtquantity.Text.Trim().Length>4 ){ strError += "数量为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_ordergoods model = new Model.user_ordergoods();
            BLL.user_ordergoods bll = new BLL.user_ordergoods();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加订单购买商品表信息，主键:" + id); //记录日志
                JscriptMsg("添加订单购买商品表信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}