/*功能：生成实体类
 *编码日期:2017/8/16 15:10:16
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

namespace Appoa.Manage.admin.common_answers
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_answers", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_answers", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtquestion_id.Text.Trim() == "" || txtquestion_id.Text.Trim().Length>4 ){ strError += "题目ID为空或超出长度![br]"; }
                if (txtoptions.Text.Trim() == "" || txtoptions.Text.Trim().Length>50 ){ strError += "选项为空或超出长度![br]"; }
                if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length>4000 ){ strError += "选项内容为空或超出长度![br]"; }
                if (txtscore.Text.Trim() == "" || txtscore.Text.Trim().Length>4 ){ strError += "分值为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_answers model = new Model.common_answers();
            BLL.common_answers bll = new BLL.common_answers();
            
		        model.question_id = Convert.ToInt32(txtquestion_id.Text);
		        model.options = Convert.ToString(txtoptions.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.score = Convert.ToInt32(txtscore.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加选项信息信息，主键:" + id); //记录日志
                JscriptMsg("添加选项信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}