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
    public partial class questions_edit : Web.UI.ManagePage
    {
        private string action = RequestHelper.GetQueryString("action");
        private int id = 0;
        private int page = 1;

        protected int chapter = 0;
        protected string chapter_name = string.Empty;
        protected string course_name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.chapter = RequestHelper.GetQueryInt("chapter");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (this.chapter == 0)
            {
                JscriptMsg("没有此章节", "back");
                return;
            }

            Model.course_chapter ccModel = new BLL.course_chapter().GetModel(chapter);
            if (ccModel != null)
            {
                chapter_name = ccModel.name;
                Model.course_info course = new BLL.course_info().GetModel(ccModel.course_id);
                if (course != null)
                {
                    course_name = course.name;
                }
            }

            if (!string.IsNullOrEmpty(_action) && _action == EnumCollection.ActionEnum.Modify.ToString())
            {
                this.action = EnumCollection.ActionEnum.Modify.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.common_questions().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindSelect();
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo();
                }
            }
        }

        #region 赋值操作

        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.questions_group), "key", "val");
            this.rbtnGroup.DataSource = dt;
            this.rbtnGroup.DataTextField = "key";
            this.rbtnGroup.DataValueField = "val";
            this.rbtnGroup.DataBind();
            this.rbtnGroup.SelectedIndex = 0;

            dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.questions_type), "key", "val");
            this.rbtnType.DataSource = dt;
            this.rbtnType.DataTextField = "key";
            this.rbtnType.DataValueField = "val";
            this.rbtnType.DataBind();
            this.rbtnType.SelectedIndex = 0;
        }

        private void ShowInfo()
        {
            BLL.common_questions bll = new BLL.common_questions();
            Model.common_questions model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            this.rbtnGroup.SelectedValue = model.group_id + "";
            this.rbtnType.SelectedValue = model.type + "";
            this.txttitle.Text = model.title + "";
            this.txtAnswers.Text = model.answer + "";
            this.txtscore.Text = Convert.ToInt32(model.score) + "";
            this.txtanalysis.Text = model.analysis + "";
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            BLL.common_questions bll = new BLL.common_questions();
            Model.common_questions model = new Model.common_questions();

            model.group_id = Convert.ToInt32(this.rbtnGroup.SelectedValue);
            model.type = Convert.ToInt32(this.rbtnType.SelectedValue);
            model.data_id = this.chapter;
            model.number = 0;
            model.title = Convert.ToString(this.txttitle.Text.Trim());
            model.answer = (model.type == (int)EnumCollection.questions_type.单选题 || model.type == (int)EnumCollection.questions_type.多选题
                || model.type == (int)EnumCollection.questions_type.判断题) ? this.txtAnswers.Text.Trim().ToUpper() : this.txtAnswers.Text.Trim();
            model.score = Convert.ToDecimal(this.txtscore.Text.Trim());
            model.analysis = Convert.ToString(this.txtanalysis.Text.Trim());
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加试题信息，主键:" + id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit()
        {
            bool result = false;
            BLL.common_questions bll = new BLL.common_questions();
            Model.common_questions model = bll.GetModel(this.id);

            model.group_id = Convert.ToInt32(this.rbtnGroup.SelectedValue);
            model.type = Convert.ToInt32(this.rbtnType.SelectedValue);
            model.data_id = this.chapter;
            model.number = 0;
            model.title = Convert.ToString(this.txttitle.Text.Trim());
            model.answer = (model.type == (int)EnumCollection.questions_type.单选题 || model.type == (int)EnumCollection.questions_type.多选题
                || model.type == (int)EnumCollection.questions_type.判断题) ? this.txtAnswers.Text.Trim().ToUpper() : this.txtAnswers.Text.Trim();
            model.score = Convert.ToDecimal(this.txtscore.Text.Trim());
            model.analysis = Convert.ToString(this.txtanalysis.Text.Trim());
            model.add_time = System.DateTime.Now;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改试题信息，主键:" + id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改试题信息成功！", "questions_list.aspx?page=" + this.page + "&chapter=" + this.chapter);
            }
            else //添加
            {
                ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加试题信息成功！", "questions_list.aspx?chapter=" + this.chapter);
            }
        }
    }
}