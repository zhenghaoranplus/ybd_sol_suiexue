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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_category", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_category", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txtcategory_level.Text.Trim() == "" || txtcategory_level.Text.Trim().Length>4 ){ strError += "分类级别为空或超出长度![br]"; }
                if (txtparent_id.Text.Trim() == "" || txtparent_id.Text.Trim().Length>4 ){ strError += "父级分类ID为空或超出长度![br]"; }
                if (txtimg_src.Text.Trim() == "" || txtimg_src.Text.Trim().Length>255 ){ strError += "分类配图为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "分类名称为空或超出长度![br]"; }
                if (txtsort.Text.Trim() == "" || txtsort.Text.Trim().Length>4 ){ strError += "排序为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_category model = new Model.common_category();
            BLL.common_category bll = new BLL.common_category();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.category_level = Convert.ToInt32(txtcategory_level.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.img_src = Convert.ToString(txtimg_src.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加全局分类信息，主键:" + id); //记录日志
                JscriptMsg("添加全局分类信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}