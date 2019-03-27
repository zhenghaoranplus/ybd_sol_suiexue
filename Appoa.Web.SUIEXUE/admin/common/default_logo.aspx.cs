using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class default_logo : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_default_logo", EnumCollection.ActionEnum.View.ToString()); //检查权限

                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.common_albums bll = new BLL.common_albums();
            Model.common_albums model = bll.GetModel(" group_id = " + (int)EnumCollection.img_group.系统默认二维码logo);

            if (model != null)
            {
                this.txtad_data_img.Text = model.original_path;
            }
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            Model.common_albums model = new Model.common_albums();
            BLL.common_albums bll = new BLL.common_albums();

            model.group_id = (int)EnumCollection.img_group.系统默认二维码logo;
            model.rc_type = 0;
            model.rc_data_id = 0;
            model.thumb_path = "";
            model.original_path = this.txtad_data_img.Text.Trim();
            model.remark = "";
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加系统默认二维码logo，主键:" + id); //记录日志
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
            BLL.common_albums bll = new BLL.common_albums();
            Model.common_albums model = bll.GetModel(id);

            model.original_path = this.txtad_data_img.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改系统默认二维码logo，主键:" + id); //记录日志
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
            BLL.common_albums bll = new BLL.common_albums();
            Model.common_albums model = bll.GetModel(" group_id = " + (int)EnumCollection.img_group.系统默认二维码logo);
            if (model != null)
            {
                ChkAdminLevel("_default_logo", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(model.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改系统默认二维码logo成功！", "");
            }
            else
            {
                ChkAdminLevel("_default_logo", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("添加系统默认二维码logo成功！", "");
            }
        }
    }
}