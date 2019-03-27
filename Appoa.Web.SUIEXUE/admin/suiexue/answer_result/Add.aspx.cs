/*功能：生成实体类
 *编码日期:2017/7/10 15:13:42
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

namespace Appoa.Manage.admin.answer_result
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_answer_result", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_answer_result", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txtexa_id.Text.Trim() == "" || txtexa_id.Text.Trim().Length>4 ){ strError += "试卷ID为空或超出长度![br]"; }
                if (txtexa_title.Text.Trim() == "" || txtexa_title.Text.Trim().Length>50 ){ strError += "试卷标题为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "答题者ID为空或超出长度![br]"; }
                if (txtavatar.Text.Trim() == "" || txtavatar.Text.Trim().Length>50 ){ strError += "头像为空或超出长度![br]"; }
                if (txtnick_name.Text.Trim() == "" || txtnick_name.Text.Trim().Length>50 ){ strError += "昵称为空或超出长度![br]"; }
                if (txtuse_min.Text.Trim() == "" || txtuse_min.Text.Trim().Length>4 ){ strError += "用时-分钟为空或超出长度![br]"; }
                if (txtuse_sec.Text.Trim() == "" || txtuse_sec.Text.Trim().Length>4 ){ strError += "用时-秒钟为空或超出长度![br]"; }
                if (txttruth_num.Text.Trim() == "" || txttruth_num.Text.Trim().Length>4 ){ strError += "答对题数为空或超出长度![br]"; }
                if (txtcount.Text.Trim() == "" || txtcount.Text.Trim().Length>4 ){ strError += "总题数为空或超出长度![br]"; }
                if (txttruth_ratio.Text.Trim() == "" || txttruth_ratio.Text.Trim().Length>5 ){ strError += "正确率为空或超出长度![br]"; }
                if (txtscore.Text.Trim() == "" || txtscore.Text.Trim().Length>4 ){ strError += "总分为空或超出长度![br]"; }
                if (txtstatus.Text.Trim() == "" || txtstatus.Text.Trim().Length>4 ){ strError += "批改状态 1已批改 0未批改为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "完成时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.answer_result model = new Model.answer_result();
            BLL.answer_result bll = new BLL.answer_result();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.exa_id = Convert.ToInt32(txtexa_id.Text);
		        model.exa_title = Convert.ToString(txtexa_title.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.avatar = Convert.ToString(txtavatar.Text);
		        model.nick_name = Convert.ToString(txtnick_name.Text);
		        model.use_min = Convert.ToInt32(txtuse_min.Text);
		        model.use_sec = Convert.ToInt32(txtuse_sec.Text);
		        model.truth_num = Convert.ToInt32(txttruth_num.Text);
		        model.count = Convert.ToInt32(txtcount.Text);
		        model.truth_ratio = Convert.ToDecimal(txttruth_ratio.Text);
		        model.score = Convert.ToInt32(txtscore.Text);
		        model.status = Convert.ToInt32(txtstatus.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加答题结果信息，主键:" + id); //记录日志
                JscriptMsg("添加答题结果信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}