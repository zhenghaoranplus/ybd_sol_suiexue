using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class questionnaire_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected int chapter = 0;
        protected int addrow = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.chapter = RequestHelper.GetQueryInt("chapter");

            if (this.id > 0)
            {
                if (!new BLL.common_examination().Exists(this.id))
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
                    this.lblChapterName.Text = model.name;
                    Model.course_info course = new BLL.course_info().GetModel(model.course_id);
                    if (course != null)
                    {
                        this.lblCourseName.Text = course.name;
                    }
                    else
                    {
                        JscriptMsg("没有此课程！", "back");
                        return;
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_examination_list", EnumCollection.ActionEnum.View.ToString()); //检查权限

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    addrow = this.id;
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void ShowInfo(int _id)
        {
            BLL.common_examination bll = new BLL.common_examination();
            Model.common_examination model = bll.GetModel(this.id);

            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }


            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            txtname.Text = model.name + "";
            txtinfo.Text = model.info + "";
            txtdescript.Text = model.descript + "";
        }

        #endregion

        private void BindDataGrid(string type)
        {
            string where = " exa_id = " + this.id;
            if (Convert.ToInt32(type) > 0)
            {
                where += " and type = " + type;
            }
        }

        private bool DoAdd()
        {
            BLL.common_examination bll = new BLL.common_examination();
            Model.common_examination model = new Model.common_examination();

            model.group_id = (int)EnumCollection.examination_group.心理测试;
            model.name = Convert.ToString(txtname.Text);
            model.parent_id = this.chapter;
            model.nums = 0;
            model.score = 0;
            model.info = Convert.ToString(txtinfo.Text);
            model.descript = Convert.ToString(txtdescript.Text);
            model.qrcode = "";
            model.add_time = System.DateTime.Now;

            int row = bll.Add(model);
            if (row > 0)
            {
                addrow = row;
                model.id = row;
                model.qrcode = "/QrCode.aspx?type=quest&id=" + row;
                bll.Update(model);

                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加问卷信息，主键:" + row); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_examination bll = new BLL.common_examination();
            Model.common_examination model = bll.GetModel(this.id);

            model.group_id = (int)EnumCollection.examination_group.心理测试;
            model.name = Convert.ToString(txtname.Text);
            model.parent_id = this.chapter;
            model.nums = 0;
            model.score = 0;
            model.info = this.txtinfo.Text.Trim();
            model.descript = this.txtdescript.Text.Trim();
            model.qrcode = "/QrCode.aspx?type=quest&id=" + id;
            model.add_time = System.DateTime.Now;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改问卷信息，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_examination_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                //JscriptMsg("修改问卷成功！", "questionnaire_list.aspx?chapter=" + this.chapter, "openUnSelectQu");
                JscriptDialog("修改问卷成功！", "问卷修改成功，快去选题吧~", "openUnSelectQu");
            }
            else //添加
            {
                ChkAdminLevel("_examination_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限

                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                this.btnSubmit.Enabled = false;
                //JscriptMsg("添加问卷成功！", "questionnaire_list.aspx?chapter=" + this.chapter, "openUnSelectQu");
                JscriptDialog("添加问卷成功！", "问卷创建成功，快去选题吧~", "openUnSelectQu");
            }
        }
    }
}