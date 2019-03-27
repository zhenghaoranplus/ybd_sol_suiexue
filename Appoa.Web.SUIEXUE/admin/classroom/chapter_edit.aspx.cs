using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class chapter_edit : Web.UI.ManagePage
    {
        protected string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int parent_id = 0;
        protected int class_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.parent_id = RequestHelper.GetQueryInt("parent_id");
            this.class_id = RequestHelper.GetQueryInt("class_id");

            if (!string.IsNullOrEmpty(_action) && _action == EnumCollection.ActionEnum.Modify.ToString())
            {
                this.action = EnumCollection.ActionEnum.Modify.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");

                if (this.id <= 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.course_chapter().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_chapter", EnumCollection.ActionEnum.View.ToString()); //检查权限
                Bind();
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (parent_id > 0)
                    {
                        this.ddlChapter.SelectedValue = this.parent_id + "";
                        if (!new BLL.course_chapter().Exists(this.parent_id))
                        {
                            JscriptMsg("信息不存在或已被删除！", "back");
                            return;
                        }
                    }
                }
            }
        }

        #region 赋值操作=================================
        private void Bind()
        {
            DataTable dt = new BLL.course_chapter().GetListNew(" group_id = " + (int)EnumCollection.chapter_group.课堂 + " and course_id = " + this.class_id, "0");
            this.ddlChapter.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["chapter_level"].ToString());
                string Title = dr["name"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlChapter.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlChapter.Items.Add(new ListItem(Title, Id));
                }
            }
            this.ddlChapter.Items.Insert(0, new ListItem("无父级章节", "0"));
        }

        private void ShowInfo(int _id)
        {
            BLL.course_chapter bll = new BLL.course_chapter();
            Model.course_chapter model = bll.GetModel(_id);

            this.ddlChapter.SelectedValue = model.parent_id + "";
            this.txtname.Text = model.name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.course_chapter model = new Model.course_chapter();

            model.group_id = (int)EnumCollection.chapter_group.课堂;
            model.course_id = this.class_id;
            model.name = txtname.Text.Trim();
            model.tag = "";
            model.parent_id = Convert.ToInt32(this.ddlChapter.SelectedValue);
            model.add_time = DateTime.Now;
            model.chapter_level = 1;

            if (model.parent_id > 0)
            {
                Model.course_chapter parent_model = new BLL.course_chapter().GetModel(model.parent_id);
                if (parent_model != null)
                {
                    model.chapter_level = parent_model.chapter_level + 1;
                }
            }

            int id = new BLL.course_chapter().Add(model);
            if (id > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            Model.course_chapter model = new BLL.course_chapter().GetModel(_id);

            model.group_id = (int)EnumCollection.chapter_group.课堂;
            model.parent_id = Convert.ToInt32(this.ddlChapter.SelectedValue);
            model.name = txtname.Text.Trim();

            if (new BLL.course_chapter().Update(model))
            {
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
                ChkAdminLevel("_classroom_chapter", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改章节信息成功！", "chapter_list.aspx?class_id=" + class_id);
            }
            else //添加
            {
                ChkAdminLevel("_classroom_chapter", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加章节信息成功！", "chapter_list.aspx?class_id=" + class_id);
            }
        }
    }
}