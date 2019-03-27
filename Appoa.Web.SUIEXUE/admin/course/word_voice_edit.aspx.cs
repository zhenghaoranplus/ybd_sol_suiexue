using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class word_voice_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected int chapter = 0;
        protected string course_name = string.Empty;
        protected string chapter_name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.chapter = RequestHelper.GetQueryInt("chapter");

            if (this.id > 0)
            {
                if (!new BLL.common_resource().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (this.chapter > 0)
            {
                Model.course_chapter model = new BLL.course_chapter().GetModel(this.chapter);
                if (model == null)
                {
                    JscriptMsg("没有此章节！", "back");
                    return;
                }
                else
                {
                    this.chapter_name = model.name;
                    Model.course_info course = new BLL.course_info().GetModel(model.course_id);
                    if (course != null)
                    {
                        this.course_name = course.name;
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_resource_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
            }
        }

        #region 赋值操作=================================
        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.resource_group), "key", "val");
            if (dt.Rows.Count > 0)
            {
                this.rbtnGroup.Items.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    this.rbtnGroup.Items.Add(new ListItem(item["key"].ToString(), item["val"].ToString()));
                }
                this.rbtnGroup.SelectedIndex = 0;
            }
            
            dt = new BLL.user_info().GetList(" group_id = " + (int)EnumCollection.user_group.资源分享用户);
            this.ckbUser.DataSource = dt;
            this.ckbUser.DataTextField = "phone";
            this.ckbUser.DataValueField = "id";
            this.ckbUser.DataBind();
            this.ckbUser.SelectedIndex = 0;

            dt = new BLL.common_school().GetList(" 1=1 order by sort ");
            this.ddlSchool.DataSource = dt;
            this.ddlSchool.DataTextField = "name";
            this.ddlSchool.DataValueField = "id";
            this.ddlSchool.DataBind();
            this.ckbUser.SelectedIndex = 0;
        }

        #endregion
    }
}