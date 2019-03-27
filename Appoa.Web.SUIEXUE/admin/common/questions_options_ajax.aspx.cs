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
    public partial class questions_options_ajax : Web.UI.ManagePage
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
    }
}