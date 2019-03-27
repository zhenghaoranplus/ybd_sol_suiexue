/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
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

namespace Appoa.Manage.admin.common_category
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
                ChkAdminLevel("_ybd_common_category", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_category bll = new BLL.common_category();
            Model.common_category model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtcategory_level.Text = model.category_level + "";
		        txtparent_id.Text = model.parent_id + "";
		        txtimg_src.Text = model.img_src + "";
		        txtname.Text = model.name + "";
		        txtsort.Text = model.sort + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_category", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_category bll = new BLL.common_category();
            Model.common_category model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.category_level = Convert.ToInt32(txtcategory_level.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.img_src = Convert.ToString(txtimg_src.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改全局分类信息，主键:" + id); //记录日志
                JscriptMsg("修改全局分类信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}