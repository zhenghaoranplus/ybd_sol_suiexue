/*功能：生成实体类
 *编码日期:2017/8/16 10:53:59
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

namespace Appoa.Manage.admin.common_questions
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_questions", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_questions", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txttype.Text.Trim() == "" || txttype.Text.Trim().Length>4 ){ strError += "题型为空或超出长度![br]"; }
                if (txtdata_id.Text.Trim() == "" || txtdata_id.Text.Trim().Length>4 ){ strError += "关联数据ID为空或超出长度![br]"; }
                if (txtnumber.Text.Trim() == "" || txtnumber.Text.Trim().Length>4 ){ strError += "序号为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>200 ){ strError += "标题为空或超出长度![br]"; }
                if (txtanswer.Text.Trim() == "" || txtanswer.Text.Trim().Length>4000 ){ strError += "参考答案为空或超出长度![br]"; }
                if (txtscore.Text.Trim() == "" || txtscore.Text.Trim().Length>5 ){ strError += "分值为空或超出长度![br]"; }
                if (txtanalysis.Text.Trim() == "" || txtanalysis.Text.Trim().Length>2000 ){ strError += "解析为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_questions model = new Model.common_questions();
            BLL.common_questions bll = new BLL.common_questions();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.data_id = Convert.ToInt32(txtdata_id.Text);
		        model.number = Convert.ToInt32(txtnumber.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.answer = Convert.ToString(txtanswer.Text);
		        model.score = Convert.ToDecimal(txtscore.Text);
		        model.analysis = Convert.ToString(txtanalysis.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加题目信息信息，主键:" + id); //记录日志
                JscriptMsg("添加题目信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}