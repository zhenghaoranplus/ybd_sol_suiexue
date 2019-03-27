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
    public partial class file_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected int class_id = 0;
        protected int page = 1;

        protected string classroom_name = string.Empty;
        private int user_id = 0;

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
                    this.user_id = model.user_id;
                    this.classroom_name = model.name;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_file_materials", EnumCollection.ActionEnum.View.ToString()); //检查权限
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
        }

        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(id);

            model.from_id = (int)EnumCollection.resource_from.课堂;
            model.group_id = (int)EnumCollection.resource_group.公共资源;
            model.type = (int)EnumCollection.resource_type.文档资源;
            model.school_id = 0;
            model.school_name = "";
            model.data_id = class_id;
            model.user_id = user_id;

            string fileNames = Utils.DelLastChar(this.hdfVal.Value, "|");
            string path = Utils.DelLastChar(this.txtpath.Text, "|");
            string[] files = fileNames.Split('|');
            string[] paths = path.Split('|');

            model.title = getStr(files[0], 1);
            model.cover = "";
            model.path = paths[0];
            model.file_name = files[0];
            model.extend = getStr(files[0], 2);
            model.likn_url = "";
            model.qrcode = "/QrCode.aspx?type=re&id=" + id;
            model.share_user = "";

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改资源信息，主键:" + id); //记录日志
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
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = null;

            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_classroom_file_materials", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改资源成功！", "file_list.aspx?page=" + this.page + "&class_id=" + this.class_id);
            }
            else //添加
            {
                ChkAdminLevel("_classroom_file_materials", EnumCollection.ActionEnum.Add.ToString()); //检查权限

                #region 添加操作

                string fileNames = Utils.DelLastChar(this.hdfVal.Value, "|");
                string path = Utils.DelLastChar(this.txtpath.Text, "|");
                string[] files = fileNames.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] paths = path.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                int count = 0;
                Model.common_resource maxModel = null;

                for (int i = 0; i < files.Length; i++)
                {
                    model = new Model.common_resource();

                    model.from_id = (int)EnumCollection.resource_from.课堂;
                    model.group_id = (int)EnumCollection.resource_group.公共资源;
                    model.type = (int)EnumCollection.resource_type.文档资源;
                    model.school_id = 0;
                    model.school_name = "";
                    model.data_id = class_id;
                    model.user_id = user_id;

                    string file = files[i];

                    model.title = getStr(file, 1);
                    model.cover = "";
                    model.path = paths[i];
                    model.qrcode = "";
                    model.file_name = file;
                    model.extend = getStr(file, 2);
                    model.likn_url = "";
                    model.share_user = "";
                    model.add_time = System.DateTime.Now;

                    maxModel = bll.GetModel(" from_id = " + model.from_id + " and group_id = " + model.group_id + " and type = " + model.type + " and data_id = " + class_id + " order by sort desc ");
                    if (maxModel != null)
                    {
                        model.sort = maxModel.sort + 1;
                    }
                    else
                    {
                        model.sort = 1;
                    }

                    int id = bll.Add(model);
                    if (id > 0)
                    {
                        model.id = id;
                        model.qrcode = "/QrCode.aspx?type=re&id=" + id;
                        bll.Update(model);

                        AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加" + Enum.GetName(typeof(EnumCollection.resource_type), model.type) + "资源信息，主键:" + id); //记录日志
                        count++;
                    }

                    JscriptMsg("添加" + Enum.GetName(typeof(EnumCollection.resource_type), model.type) + "资源成功！总文件" + files.Length + "个，成功" + count + "个", "file_list.aspx?class_id=" + this.class_id);
                }
                #endregion
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