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
                ChkAdminLevel("_ybd_common_questions", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_questions bll = new BLL.common_questions();
            Model.common_questions model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txttype.Text = model.type + "";
		        txtdata_id.Text = model.data_id + "";
		        txtnumber.Text = model.number + "";
		        txttitle.Text = model.title + "";
		        txtanswer.Text = model.answer + "";
		        txtscore.Text = model.score + "";
		        txtanalysis.Text = model.analysis + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_questions", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_questions bll = new BLL.common_questions();
            Model.common_questions model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.data_id = Convert.ToInt32(txtdata_id.Text);
		        model.number = Convert.ToInt32(txtnumber.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.answer = Convert.ToString(txtanswer.Text);
		        model.score = Convert.ToDecimal(txtscore.Text);
		        model.analysis = Convert.ToString(txtanalysis.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改题目信息信息，主键:" + id); //记录日志
                JscriptMsg("修改题目信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}