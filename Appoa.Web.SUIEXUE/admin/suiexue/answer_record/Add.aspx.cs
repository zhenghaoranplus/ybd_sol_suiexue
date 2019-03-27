/*功能：生成实体类
 *编码日期:2017/7/24 18:46:18
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

namespace Appoa.Manage.admin.answer_record
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_answer_record", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_answer_record", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "答题者ID为空或超出长度![br]"; }
                if (txtexa_id.Text.Trim() == "" || txtexa_id.Text.Trim().Length>4 ){ strError += "试卷ID为空或超出长度![br]"; }
                if (txtq_id.Text.Trim() == "" || txtq_id.Text.Trim().Length>4 ){ strError += "题目ID为空或超出长度![br]"; }
                if (txtanswer.Text.Trim() == "" || txtanswer.Text.Trim().Length>4000 ){ strError += "答案为空或超出长度![br]"; }
                if (txtis_truth.Text.Trim() == "" || txtis_truth.Text.Trim().Length>4 ){ strError += "结果为空或超出长度![br]"; }
                if (txtscore.Text.Trim() == "" || txtscore.Text.Trim().Length>4 ){ strError += "为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "完成时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.answer_record model = new Model.answer_record();
            BLL.answer_record bll = new BLL.answer_record();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.exa_id = Convert.ToInt32(txtexa_id.Text);
		        model.q_id = Convert.ToInt32(txtq_id.Text);
		        model.answer = Convert.ToString(txtanswer.Text);
		        model.is_truth = Convert.ToInt32(txtis_truth.Text);
		        model.score = Convert.ToInt32(txtscore.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加答题记录信息，主键:" + id); //记录日志
                JscriptMsg("添加答题记录信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}