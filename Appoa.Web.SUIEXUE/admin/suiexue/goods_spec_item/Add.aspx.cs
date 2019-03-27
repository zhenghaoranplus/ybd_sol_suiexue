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

namespace Appoa.Manage.admin.goods_spec_item
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_goods_spec_item", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_goods_spec_item", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgoods_id.Text.Trim() == "" || txtgoods_id.Text.Trim().Length>4 ){ strError += "商品id为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "规格名称为空或超出长度![br]"; }
                if (txtparent_id.Text.Trim() == "" || txtparent_id.Text.Trim().Length>4 ){ strError += "父级规格为空或超出长度![br]"; }
                if (txtsort.Text.Trim() == "" || txtsort.Text.Trim().Length>4 ){ strError += "排序为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.goods_spec_item model = new Model.goods_spec_item();
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            
		        model.goods_id = Convert.ToInt32(txtgoods_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加商品规格项信息，主键:" + id); //记录日志
                JscriptMsg("添加商品规格项信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}