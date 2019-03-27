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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_cart", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_cart", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtct_id.Text.Trim() == "" || txtct_id.Text.Trim().Length>4 ){ strError += "商家id为空或超出长度![br]"; }
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组id为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "购买者id为空或超出长度![br]"; }
                if (txtgoods_sale_type.Text.Trim() == "" || txtgoods_sale_type.Text.Trim().Length>4 ){ strError += "商品销售类型为空或超出长度![br]"; }
                if (txtgoods_id.Text.Trim() == "" || txtgoods_id.Text.Trim().Length>4 ){ strError += "商品id为空或超出长度![br]"; }
                if (txtgoods_name.Text.Trim() == "" || txtgoods_name.Text.Trim().Length>200 ){ strError += "标题为空或超出长度![br]"; }
                if (txtgoods_subtitle.Text.Trim() == "" || txtgoods_subtitle.Text.Trim().Length>200 ){ strError += "副标题为空或超出长度![br]"; }
                if (txtgoods_img.Text.Trim() == "" || txtgoods_img.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtgoods_oprice.Text.Trim() == "" || txtgoods_oprice.Text.Trim().Length>8 ){ strError += "原价为空或超出长度![br]"; }
                if (txtgoods_price.Text.Trim() == "" || txtgoods_price.Text.Trim().Length>8 ){ strError += "现价为空或超出长度![br]"; }
                if (txtgoods_spec.Text.Trim() == "" || txtgoods_spec.Text.Trim().Length>4000 ){ strError += "规格值为空或超出长度![br]"; }
                if (txtgoods_spec_id.Text.Trim() == "" || txtgoods_spec_id.Text.Trim().Length>255 ){ strError += "规格id为空或超出长度![br]"; }
                if (txtnum.Text.Trim() == "" || txtnum.Text.Trim().Length>4 ){ strError += "数量为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_cart model = new Model.user_cart();
            BLL.user_cart bll = new BLL.user_cart();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加购物车表信息，主键:" + id); //记录日志
                JscriptMsg("添加购物车表信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}