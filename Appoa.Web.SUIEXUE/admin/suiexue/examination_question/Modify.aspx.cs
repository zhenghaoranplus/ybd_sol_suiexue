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
                ChkAdminLevel("_ybd_examination_question", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.examination_question bll = new BLL.examination_question();
            Model.examination_question model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtexa_id.Text = model.exa_id + "";
		        txtq_id.Text = model.q_id + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_examination_question", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.examination_question bll = new BLL.examination_question();
            Model.examination_question model = bll.GetModel(this.id);
            
		        model.exa_id = Convert.ToInt32(txtexa_id.Text);
		        model.q_id = Convert.ToInt32(txtq_id.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改试卷题目关联信息，主键:" + id); //记录日志
                JscriptMsg("修改试卷题目关联信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}