using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class question_options_edit : Web.UI.ManagePage
    {
        private string action = RequestHelper.GetQueryString("action");
        private int id = 0;
        private int qid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.qid = RequestHelper.GetQueryInt("qid");
            if (!string.IsNullOrEmpty(_action) && _action == EnumCollection.ActionEnum.Modify.ToString())
            {
                this.action = EnumCollection.ActionEnum.Modify.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.common_answers().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_common_answers", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                this.lbltitle.Text = new BLL.common_questions().GetModel(this.qid).title;
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo();
                }
            }
        }

        #region 赋值操作
        private void ShowInfo()
        {
            BLL.common_answers bll = new BLL.common_answers();
            Model.common_answers model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            txtoptions.Text = model.options + "";
            txtcontents.Text = model.contents + "";
            txtscore.Text = model.score + "";
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            BLL.common_answers bll = new BLL.common_answers();
            Model.common_answers model = new Model.common_answers();

            model.question_id = this.qid;
            model.options = Convert.ToString(txtoptions.Text.Trim());
            model.contents = Convert.ToString(txtcontents.Text.Trim());
            model.score = Convert.ToInt32(txtscore.Text.Trim());
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加选项信息，主键:" + id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit()
        {
            bool result = false;
            BLL.common_answers bll = new BLL.common_answers();
            Model.common_answers model = bll.GetModel(this.id);

            model.options = Convert.ToString(txtoptions.Text.Trim());
            model.contents = Convert.ToString(txtcontents.Text.Trim());
            model.score = Convert.ToInt32(txtscore.Text.Trim());

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改选项信息，主键:" + id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_common_answers", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                }

                JscriptMsg("修改选项信息成功！", "question_options.aspx?qid=" + this.qid);
            }
            else //添加
            {
                ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("添加选项信息成功！", "question_options.aspx?qid=" + this.qid);
            }
        }
    }
}