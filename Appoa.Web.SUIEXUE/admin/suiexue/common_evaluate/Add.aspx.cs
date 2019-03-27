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

namespace Appoa.Manage.admin.common_evaluate
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_evaluate", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_evaluate", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组id为空或超出长度![br]"; }
                if (txteval_type.Text.Trim() == "" || txteval_type.Text.Trim().Length>4 ){ strError += "评价类型id为空或超出长度![br]"; }
                if (txtparent_id.Text.Trim() == "" || txtparent_id.Text.Trim().Length>4 ){ strError += "评价所属主体id为空或超出长度![br]"; }
                if (txtfrom_user_id.Text.Trim() == "" || txtfrom_user_id.Text.Trim().Length>4 ){ strError += "评价者id为空或超出长度![br]"; }
                if (txtto_user_id.Text.Trim() == "" || txtto_user_id.Text.Trim().Length>4 ){ strError += "被评价者id为空或超出长度![br]"; }
                if (txtstart.Text.Trim() == "" || txtstart.Text.Trim().Length>4 ){ strError += "评价星级为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>1000 ){ strError += "评价内容为空或超出长度![br]"; }
                if (txtdata_id.Text.Trim() == "" || txtdata_id.Text.Trim().Length>4 ){ strError += "被评价的评价id为空或超出长度![br]"; }
                if (txtreply_id.Text.Trim() == "" || txtreply_id.Text.Trim().Length>4 ){ strError += "被回复的回复ID为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_evaluate model = new Model.common_evaluate();
            BLL.common_evaluate bll = new BLL.common_evaluate();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.eval_type = Convert.ToInt32(txteval_type.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.from_user_id = Convert.ToInt32(txtfrom_user_id.Text);
		        model.to_user_id = Convert.ToInt32(txtto_user_id.Text);
		        model.start = Convert.ToInt32(txtstart.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.data_id = Convert.ToInt32(txtdata_id.Text);
		        model.reply_id = Convert.ToInt32(txtreply_id.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加全局评论信息，主键:" + id); //记录日志
                JscriptMsg("添加全局评论信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}