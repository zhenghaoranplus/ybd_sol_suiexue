using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class video_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected int class_id = 0;
        protected int page = 1;
        protected string classroom_name = string.Empty;

        protected Model.sys_manager admin_info; //管理员信息
        protected void Page_Load(object sender, EventArgs e)
        {
            admin_info = GetAdminInfo();

            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.class_id = RequestHelper.GetQueryInt("class_id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (this.id > 0)
            {
                if (!new BLL.common_resource().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (this.class_id > 0)
            {
                Model.classroom_info model = new BLL.classroom_info().GetModel(this.class_id);
                if (model == null)
                {
                    JscriptMsg("没有此课堂！", "back");
                    return;
                }
                else
                {
                    this.classroom_name = model.name;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_video_materials", EnumCollection.ActionEnum.View.ToString()); //检查权限
                this.txtpath.Attributes.Add("readonly", "true");

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================

        private void ShowInfo(int _id)
        {
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(this.id);

            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            this.txtpath.Text = model.path + "";
            this.hdfVal.Value = model.title + "." + model.extend;
            this.txtcover.Text = model.cover + "";
        }

        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(id);

            model.from_id = (int)EnumCollection.resource_from.课堂;
            model.group_id = (int)EnumCollection.resource_group.公共资源;
            model.type = (int)EnumCollection.resource_type.视频资源;
            model.school_id = 0;
            model.school_name = "";
            model.data_id = class_id;
            model.user_id = admin_info.id;
            model.title = getStr(this.hdfVal.Value, 1);
            model.cover = this.txtcover.Text.Trim();
            model.path = this.txtpath.Text.Trim();
            model.file_name = this.hdfVal.Value;
            model.extend = getStr(this.hdfVal.Value, 2);
            model.likn_url = "";
            model.qrcode = "/QrCode.aspx?type=re&id=" + id;
            model.share_user = "";

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改课堂视频资源信息，主键:" + id); //记录日志
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
                ChkAdminLevel("_classroom_video_materials", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改课堂视频资源成功！", "video_list.aspx?page=" + this.page + "&class_id=" + this.class_id);
            }
        }

        #region 获取文件名和扩展名
        private string getStr(string temp, int num)
        {
            int index = temp.LastIndexOf('.');
            if (index < 0)
            {
                return "";
            }

            string name = temp.Substring(0, index);
            string extend = temp.Substring(index + 1, temp.Length - index - 1);
            if (num == 1)
            {
                return name;
            }
            if (num == 2)
            {
                return extend;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}