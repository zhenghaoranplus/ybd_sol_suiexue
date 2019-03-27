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
                ChkAdminLevel("_ybd_goods_spec_item", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            Model.goods_spec_item model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgoods_id.Text = model.goods_id + "";
		        txtname.Text = model.name + "";
		        txtparent_id.Text = model.parent_id + "";
		        txtsort.Text = model.sort + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_goods_spec_item", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            Model.goods_spec_item model = bll.GetModel(this.id);
            
		        model.goods_id = Convert.ToInt32(txtgoods_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改商品规格项信息，主键:" + id); //记录日志
                JscriptMsg("修改商品规格项信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}