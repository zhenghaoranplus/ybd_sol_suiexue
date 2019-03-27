/*功能：生成实体类
 *编码日期:2017/6/26 16:26:29
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

namespace Appoa.Manage.admin.examination_question
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_examination_question", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_examination_question", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtexa_id.Text.Trim() == "" || txtexa_id.Text.Trim().Length>4 ){ strError += "试卷ID为空或超出长度![br]"; }
                if (txtq_id.Text.Trim() == "" || txtq_id.Text.Trim().Length>4 ){ strError += "题目ID为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.examination_question model = new Model.examination_question();
            BLL.examination_question bll = new BLL.examination_question();
            
		        model.exa_id = Convert.ToInt32(txtexa_id.Text);
		        model.q_id = Convert.ToInt32(txtq_id.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加试卷题目关联信息，主键:" + id); //记录日志
                JscriptMsg("添加试卷题目关联信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}