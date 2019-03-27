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

namespace Appoa.Manage.admin.common_article
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
                ChkAdminLevel("_ybd_common_article", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtuser_id.Text = model.user_id + "";
		        txtcategory_id.Text = model.category_id + "";
		        txttitle.Text = model.title + "";
		        txtsubtitle.Text = model.subtitle + "";
		        txtcontents.Text = model.contents + "";
		        txtimg_src.Text = model.img_src + "";
		        txtclick.Text = model.click + "";
		        txtupvote.Text = model.upvote + "";
		        txtstatus.Text = model.status + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_article", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.category_id = Convert.ToInt32(txtcategory_id.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.subtitle = Convert.ToString(txtsubtitle.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.img_src = Convert.ToString(txtimg_src.Text);
		        model.click = Convert.ToInt32(txtclick.Text);
		        model.upvote = Convert.ToInt32(txtupvote.Text);
		        model.status = Convert.ToInt32(txtstatus.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改全局文章信息，主键:" + id); //记录日志
                JscriptMsg("修改全局文章信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}