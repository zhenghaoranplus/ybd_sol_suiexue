using Appoa.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Appoa.Manage.admin.course
{
    public partial class adR_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");

            if (this.action == EnumCollection.ActionEnum.Modify.ToString())
            {
                if (!new BLL.common_adR().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_course_adR", EnumCollection.ActionEnum.View.ToString()); //检查权限

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void ShowInfo(int _id)
        {
            BLL.common_adR bll = new BLL.common_adR();
            Model.common_adR model = bll.GetModel(this.id);

            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            this.txtad_data_title.Text = model.ad_data_title;
            this.txtad_data_url.Text = model.ad_data_subtitle;
            this.txtad_data_id.Text = model.ad_data_id + "";
            this.txtad_data_img.Text = model.ad_data_img;
            this.txtad_sort_id.Text = model.ad_sort_id + "";
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            BLL.common_adR bll = new BLL.common_adR();
            Model.common_adR model = new Model.common_adR();

            model.ad_group_id = (int)EnumCollection.adR_group.精品微课轮播图;
            model.ad_group_name = EnumCollection.adR_group.精品微课轮播图.ToString();
            model.ad_type_id = 0;
            model.ad_type_name = "";
            model.ad_data_id = Convert.ToInt32(this.txtad_data_id.Text);
            model.ad_data_title = this.txtad_data_title.Text;
            model.ad_data_subtitle = "";
            model.ad_data_url = this.txtad_data_url.Text;
            model.ad_data_img = this.txtad_data_img.Text;
            model.ad_sort_id = Convert.ToInt32(this.txtad_sort_id.Text);
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加广告位信息，主键:" + id); //记录日志
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
            BLL.common_adR bll = new BLL.common_adR();
            Model.common_adR model = bll.GetModel(id);

            model.ad_data_id = Convert.ToInt32(this.txtad_data_id.Text);
            model.ad_data_title = this.txtad_data_title.Text;
            model.ad_data_subtitle = "";
            model.ad_data_url = this.txtad_data_url.Text;
            model.ad_data_img = this.txtad_data_img.Text;
            model.ad_sort_id = Convert.ToInt32(this.txtad_sort_id.Text);

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改广告位信息，主键:" + id); //记录日志
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
                ChkAdminLevel("_course_adR", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改广告位成功！", "adR_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("_course_adR", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加广告位成功！", "adR_list.aspx");
            }
        }
    }
}