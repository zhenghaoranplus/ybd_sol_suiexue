/*功能：生成实体类
 *编码日期:2017/7/24 18:46:19
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
                ChkAdminLevel("_ybd_answer_record", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.answer_record bll = new BLL.answer_record();
            Model.answer_record model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtuser_id.Text = model.user_id + "";
		        txtexa_id.Text = model.exa_id + "";
		        txtq_id.Text = model.q_id + "";
		        txtanswer.Text = model.answer + "";
		        txtis_truth.Text = model.is_truth + "";
		        txtscore.Text = model.score + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_answer_record", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.answer_record bll = new BLL.answer_record();
            Model.answer_record model = bll.GetModel(this.id);
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.exa_id = Convert.ToInt32(txtexa_id.Text);
		        model.q_id = Convert.ToInt32(txtq_id.Text);
		        model.answer = Convert.ToString(txtanswer.Text);
		        model.is_truth = Convert.ToInt32(txtis_truth.Text);
		        model.score = Convert.ToInt32(txtscore.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改答题记录信息，主键:" + id); //记录日志
                JscriptMsg("修改答题记录信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}