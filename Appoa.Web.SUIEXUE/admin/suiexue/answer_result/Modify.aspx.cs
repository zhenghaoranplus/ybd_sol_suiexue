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
                ChkAdminLevel("_ybd_answer_result", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.answer_result bll = new BLL.answer_result();
            Model.answer_result model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtgroup_id.Text = model.group_id + "";
		        txtexa_id.Text = model.exa_id + "";
		        txtexa_title.Text = model.exa_title + "";
		        txtuser_id.Text = model.user_id + "";
		        txtavatar.Text = model.avatar + "";
		        txtnick_name.Text = model.nick_name + "";
		        txtuse_min.Text = model.use_min + "";
		        txtuse_sec.Text = model.use_sec + "";
		        txttruth_num.Text = model.truth_num + "";
		        txtcount.Text = model.count + "";
		        txttruth_ratio.Text = model.truth_ratio + "";
		        txtscore.Text = model.score + "";
		        txtstatus.Text = model.status + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_answer_result", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.answer_result bll = new BLL.answer_result();
            Model.answer_result model = bll.GetModel(this.id);
            
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
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改答题结果信息，主键:" + id); //记录日志
                JscriptMsg("修改答题结果信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}