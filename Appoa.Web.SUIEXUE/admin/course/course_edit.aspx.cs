using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class course_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int page = 1;

        protected Model.sys_manager admin_info; //管理员信息

        protected void Page_Load(object sender, EventArgs e)
        {
            admin_info = GetAdminInfo();

            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.page = RequestHelper.GetQueryInt("page", 1);
            if (this.id > 0)
            {
                if (!new BLL.course_info().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void BindSelect()
        {
            DataTable dt = new BLL.common_category().GetListNew(" group_id = " + (int)EnumCollection.category_group.精品微课, "0");
            this.ddlCategory.Items.Clear();
            this.ddlCategory.Items.Add(new ListItem("无父级分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["category_level"].ToString());
                string Title = dr["name"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategory.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategory.Items.Add(new ListItem(Title, Id));
                }
            }
        }

        private void ShowInfo(int _id)
        {
            BLL.course_info bll = new BLL.course_info();
            Model.course_info model = bll.GetModel(this.id);

            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            this.ddlCategory.SelectedValue = model.category_id + "";
            this.txtname.Text = model.name + "";
            this.txtcover.Text = model.cover + "";
            this.txtinfo.Text = model.info + "";
            this.txtqrcode_logo.Text = model.qrcode_logo + "";
            //this.qrcodeview.Value = model.qrcode + "";
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            BLL.course_info bll = new BLL.course_info();
            Model.course_info model = new Model.course_info();

            model.group_id = (int)EnumCollection.course_group.精品微课;
            model.category_id = Convert.ToInt32(this.ddlCategory.SelectedValue);
            model.name = Convert.ToString(txtname.Text);
            model.cover = Convert.ToString(txtcover.Text);
            model.info = Convert.ToString(txtinfo.Text);
            model.qrcode = "";
            model.qrcode_logo = Convert.ToString(txtqrcode_logo.Text);
            model.user_id = admin_info.id;
            model.is_show = (int)EnumCollection.course_is_show.是;
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                model.id = id;
                model.qrcode = "/QrCode.aspx?type=course&id=" + id;
                bll.Update(model);

                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加课程信息，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.course_info bll = new BLL.course_info();
            Model.course_info model = bll.GetModel(id);

            model.group_id = (int)EnumCollection.course_group.精品微课;
            model.category_id = Convert.ToInt32(this.ddlCategory.SelectedValue);
            model.name = Convert.ToString(txtname.Text);
            model.cover = Convert.ToString(txtcover.Text);
            model.info = Convert.ToString(txtinfo.Text);
            model.qrcode = "/QrCode.aspx?type=course&id=" + model.id;
            model.qrcode_logo = Convert.ToString(txtqrcode_logo.Text);

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改课程信息，主键:" + model.id); //记录日志
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
                ChkAdminLevel("_course_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改课程信息成功！", "course_list.aspx?page=" + this.page);
            }
            else //添加
            {
                ChkAdminLevel("_course_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加课程信息成功！", "course_list.aspx");
            }
        }
    }
}