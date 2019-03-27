using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class examination_edit : Web.UI.ManagePage
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
            txtnums.Text = model.nums + "";
            txtscore.Text = model.score + "";
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

            model.group_id = (int)EnumCollection.examination_group.精品微课测验;
            model.name = Convert.ToString(txtname.Text);
            model.parent_id = this.chapter;
            model.nums = Convert.ToInt32(txtnums.Text);
            model.score = Convert.ToInt32(txtscore.Text);
            model.qrcode = "";
            model.add_time = System.DateTime.Now;

            int row = bll.Add(model);
            if (row > 0)
            {
                addrow = row;
                model.id = row;
                model.qrcode = "/QrCode.aspx?type=test&id=" + row;
                bll.Update(model);

                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加试卷信息，主键:" + row); //记录日志
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

            model.group_id = (int)EnumCollection.examination_group.精品微课测验;
            model.name = Convert.ToString(txtname.Text);
            model.parent_id = this.chapter;
            model.nums = Convert.ToInt32(txtnums.Text);
            model.score = Convert.ToInt32(txtscore.Text);
            model.qrcode = "/QrCode.aspx?type=test&id=" + id;
            model.add_time = System.DateTime.Now;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改试卷信息，主键:" + id); //记录日志
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

                //JscriptMsg("修改试卷成功！", "");
                JscriptDialog("修改试卷成功！", "试卷修改成功，快去选题吧~", "openUnSelectQu");
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
                //JscriptMsg("添加试卷成功！", "");
                JscriptDialog("添加试卷成功！", "试卷添加成功，快去选题吧~", "openUnSelectQu");
            }
        }

        //返回上一页
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("examination_list.aspx?chapter=" + this.chapter + "&page=" + RequestHelper.GetQueryInt("page", 1));
        }
    }
}