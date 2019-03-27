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
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_article", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_article", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "发布者id为空或超出长度![br]"; }
                if (txtcategory_id.Text.Trim() == "" || txtcategory_id.Text.Trim().Length>4 ){ strError += "分类id为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>200 ){ strError += "标题为空或超出长度![br]"; }
                if (txtsubtitle.Text.Trim() == "" || txtsubtitle.Text.Trim().Length>200 ){ strError += "副标题为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>4000 ){ strError += "内容为空或超出长度![br]"; }
                if (txtimg_src.Text.Trim() == "" || txtimg_src.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtclick.Text.Trim() == "" || txtclick.Text.Trim().Length>4 ){ strError += "点击量为空或超出长度![br]"; }
                if (txtupvote.Text.Trim() == "" || txtupvote.Text.Trim().Length>4 ){ strError += "点赞数为空或超出长度![br]"; }
                if (txtstatus.Text.Trim() == "" || txtstatus.Text.Trim().Length>4 ){ strError += "审核状态为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_article model = new Model.common_article();
            BLL.common_article bll = new BLL.common_article();
            
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
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加全局文章信息，主键:" + id); //记录日志
                JscriptMsg("添加全局文章信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}