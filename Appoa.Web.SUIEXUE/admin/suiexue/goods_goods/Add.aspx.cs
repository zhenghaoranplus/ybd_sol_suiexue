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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_goods_goods", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_goods_goods", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtct_id.Text.Trim() == "" || txtct_id.Text.Trim().Length>4 ){ strError += "商家id为空或超出长度![br]"; }
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组id为空或超出长度![br]"; }
                if (txtcategory_id.Text.Trim() == "" || txtcategory_id.Text.Trim().Length>4 ){ strError += "商品分类id为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>200 ){ strError += "标题为空或超出长度![br]"; }
                if (txtsubtitle.Text.Trim() == "" || txtsubtitle.Text.Trim().Length>200 ){ strError += "副标题为空或超出长度![br]"; }
                if (txtimg_src.Text.Trim() == "" || txtimg_src.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtoprice.Text.Trim() == "" || txtoprice.Text.Trim().Length>8 ){ strError += "原价为空或超出长度![br]"; }
                if (txtprice.Text.Trim() == "" || txtprice.Text.Trim().Length>8 ){ strError += "现价为空或超出长度![br]"; }
                if (txtparameters.Text.Trim() == "" || txtparameters.Text.Trim().Length>4000 ){ strError += "商品参数为空或超出长度![br]"; }
                if (txtdetails.Text.Trim() == "" || txtdetails.Text.Trim().Length>4000 ){ strError += "信息详情为空或超出长度![br]"; }
                if (txtsales_num.Text.Trim() == "" || txtsales_num.Text.Trim().Length>4 ){ strError += "销量为空或超出长度![br]"; }
                if (txtstatus.Text.Trim() == "" || txtstatus.Text.Trim().Length>4 ){ strError += "商品销售状态为空或超出长度![br]"; }
                if (txtsj_time.Text.Trim() == "" || txtsj_time.Text.Trim().Length>8 ){ strError += "上架时间为空或超出长度![br]"; }
                if (txtxj_time.Text.Trim() == "" || txtxj_time.Text.Trim().Length>8 ){ strError += "下架时间为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.goods_goods model = new Model.goods_goods();
            BLL.goods_goods bll = new BLL.goods_goods();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加商品信息信息，主键:" + id); //记录日志
                JscriptMsg("添加商品信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}