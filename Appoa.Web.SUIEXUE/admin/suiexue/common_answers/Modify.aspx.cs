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
                ChkAdminLevel("_ybd_common_answers", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.common_answers bll = new BLL.common_answers();
            Model.common_answers model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtquestion_id.Text = model.question_id + "";
		        txtoptions.Text = model.options + "";
		        txtcontents.Text = model.contents + "";
		        txtscore.Text = model.score + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_answers", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_answers bll = new BLL.common_answers();
            Model.common_answers model = bll.GetModel(this.id);
            
		        model.question_id = Convert.ToInt32(txtquestion_id.Text);
		        model.options = Convert.ToString(txtoptions.Text);
		        model.contents = Convert.ToString(txtcontents.Text);
		        model.score = Convert.ToInt32(txtscore.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改选项信息信息，主键:" + id); //记录日志
                JscriptMsg("修改选项信息信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}