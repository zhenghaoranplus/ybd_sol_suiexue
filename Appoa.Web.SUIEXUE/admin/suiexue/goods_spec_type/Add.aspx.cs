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

namespace Appoa.Manage.admin.goods_spec_type
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_goods_spec_type", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_goods_spec_type", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgoods_id.Text.Trim() == "" || txtgoods_id.Text.Trim().Length>4 ){ strError += "商品id为空或超出长度![br]"; }
                if (txtspec.Text.Trim() == "" || txtspec.Text.Trim().Length>4 ){ strError += "规格为空或超出长度![br]"; }
                if (txtstock.Text.Trim() == "" || txtstock.Text.Trim().Length>4 ){ strError += "库存为空或超出长度![br]"; }
                if (txtprice.Text.Trim() == "" || txtprice.Text.Trim().Length>9 ){ strError += "价格为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.goods_spec_type model = new Model.goods_spec_type();
            BLL.goods_spec_type bll = new BLL.goods_spec_type();
            
		        model.goods_id = Convert.ToInt32(txtgoods_id.Text);
		        model.spec = Convert.ToInt32(txtspec.Text);
		        model.stock = Convert.ToInt32(txtstock.Text);
		        model.price = Convert.ToDecimal(txtprice.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加商品规格种类信息，主键:" + id); //记录日志
                JscriptMsg("添加商品规格种类信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}