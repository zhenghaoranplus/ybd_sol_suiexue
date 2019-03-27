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
    public partial class resource_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected int chapter = 0;
        protected int page = 0;
        protected int course_id = 0;

        protected string course_name = string.Empty;
        protected string chapter_name = string.Empty;

        protected Model.sys_manager admin_info; //管理员信息
        protected void Page_Load(object sender, EventArgs e)
        {
            admin_info = GetAdminInfo();

            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.chapter = RequestHelper.GetQueryInt("chapter");
            this.page = RequestHelper.GetQueryInt("page", 1);
            this.course_id = RequestHelper.GetQueryInt("course_id", 0);

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
                this.txtpath.Attributes.Add("readonly", "true");

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
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

            dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.resource_type), "key", "val");
            DataRow[] drs = dt.Select("val not in (5,7,8)", "val");

            if (drs.Length > 0)
            {
                this.rbtnType.Items.Clear();
                foreach (DataRow item in drs)
                {
                    this.rbtnType.Items.Add(new ListItem(item["key"].ToString(), item["val"].ToString()));
                }
                this.rbtnType.SelectedIndex = 0;
            }

            dt = new BLL.user_info().GetList(" group_id = " + (int)EnumCollection.user_group.资源分享用户);
            this.ckbUser.DataSource = dt;
            this.ckbUser.DataTextField = "phone";
            this.ckbUser.DataValueField = "id";
            this.ckbUser.DataBind();

            dt = new BLL.common_school().GetList(" 1=1 order by sort ");
            this.ddlSchool.DataSource = dt;
            this.ddlSchool.DataTextField = "name";
            this.ddlSchool.DataValueField = "id";
            this.ddlSchool.DataBind();
        }

        private void ShowInfo(int _id)
        {
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(this.id);

            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            this.rbtnGroup.SelectedValue = model.group_id + "";
            this.rbtnType.SelectedValue = model.type + "";
            if (model.type == (int)EnumCollection.resource_type.图文资源)
            {
                this.txttitle.Text = model.title + "";
                this.txtcontents.Text = model.path + "";
            }
            else
            {
                this.txtpath.Text = model.path + "";
                this.hdfVal.Value = model.title + "." + model.extend;
            }

            if (model.group_id == (int)EnumCollection.resource_group.共享资源)
            {
                string[] uidArr = model.share_user.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < this.ckbUser.Items.Count; i++)
                {
                    for (int n = 0; n < uidArr.Length; n++)
                    {
                        if (uidArr[n] == this.ckbUser.Items[i].Value)
                        {
                            this.ckbUser.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(id);

            model.from_id = (int)EnumCollection.resource_from.精品微课;
            model.group_id = Convert.ToInt32(this.rbtnGroup.SelectedValue);
            model.type = Convert.ToInt32(this.rbtnType.SelectedValue);
            if (model.group_id != (int)EnumCollection.resource_group.学校资源)
            {
                model.school_id = 0;
                model.school_name = "";
            }
            else
            {
                model.school_id = Convert.ToInt32(this.ddlSchool.SelectedValue);
                model.school_name = this.ddlSchool.SelectedItem.Text;
            }
            model.data_id = chapter;
            model.user_id = admin_info.id;

            if (model.type == (int)EnumCollection.resource_type.图文资源)
            {
                model.title = Convert.ToString(txttitle.Text.Trim());
                model.cover = "";
                model.path = Convert.ToString(txtcontents.Text.Trim());
                model.qrcode = "/QrCode.aspx?type=re&id=" + id;
                model.file_name = "";
                model.extend = "";
                model.likn_url = "";
            }
            else
            {
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
            }

            string userids = string.Empty;
            for (int i = 0; i < ckbUser.Items.Count; i++)
            {
                if (ckbUser.Items[i].Selected)
                {
                    userids += "," + ckbUser.Items[i].Value + ",";
                }
            }
            model.share_user = userids;

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
                ChkAdminLevel("_resource_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改资源成功！", "resource_list.aspx?page=" + this.page + "&chapter=" + this.chapter + "&course_id=" + this.course_id);
            }
            else //添加
            {
                ChkAdminLevel("_resource_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限

                #region 添加操作
                if (Convert.ToInt32(this.rbtnType.SelectedValue) == (int)EnumCollection.resource_type.图文资源)
                {
                    model = new Model.common_resource();

                    model.from_id = (int)EnumCollection.resource_from.精品微课;
                    model.group_id = Convert.ToInt32(this.rbtnGroup.SelectedValue);
                    model.type = Convert.ToInt32(this.rbtnType.SelectedValue);
                    if (model.group_id != (int)EnumCollection.resource_group.学校资源)
                    {
                        model.school_id = 0;
                        model.school_name = "";
                    }
                    else
                    {
                        model.school_id = Convert.ToInt32(this.ddlSchool.SelectedValue);
                        model.school_name = this.ddlSchool.SelectedItem.Text;
                    }
                    model.data_id = chapter;
                    model.user_id = admin_info.id;
                    model.title = Convert.ToString(txttitle.Text.Trim());
                    model.cover = "";
                    model.path = Convert.ToString(txtcontents.Text.Trim());
                    model.qrcode = "";
                    model.file_name = "";
                    model.extend = "";
                    model.likn_url = "";
                    model.add_time = System.DateTime.Now;

                    Model.common_resource maxModel = bll.GetModel(" from_id = " + (int)EnumCollection.resource_from.精品微课 + " and data_id = " + chapter + " order by sort desc ");
                    if (maxModel != null)
                    {
                        model.sort = maxModel.sort + 1;
                    }
                    else
                    {
                        model.sort = 1;
                    }

                    string userids = string.Empty;
                    for (int i = 0; i < ckbUser.Items.Count; i++)
                    {
                        if (ckbUser.Items[i].Selected)
                        {
                            userids += "," + ckbUser.Items[i].Value + ",";
                        }
                    }
                    model.share_user = userids;

                    int id = bll.Add(model);
                    if (id > 0)
                    {
                        model.id = id;
                        model.qrcode = "/QrCode.aspx?type=re&id=" + id;
                        bll.Update(model);

                        AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加图文资源信息，主键:" + id); //记录日志
                        JscriptMsg("添加图文资源成功！", "resource_list.aspx?chapter=" + this.chapter + "&course_id=" + this.course_id);
                    }
                    else
                    {
                        JscriptMsg("保存过程中发生错误！", "");
                        return;
                    }
                }
                else
                {
                    string fileNames = Utils.DelLastChar(this.hdfVal.Value, "|");
                    string path = Utils.DelLastChar(this.txtpath.Text, "|");
                    string[] files = fileNames.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] paths = path.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    int count = 0;
                    Model.common_resource maxModel = null;

                    for (int i = 0; i < files.Length; i++)
                    {
                        model = new Model.common_resource();

                        model.from_id = (int)EnumCollection.resource_from.精品微课;
                        model.group_id = Convert.ToInt32(this.rbtnGroup.SelectedValue);
                        model.type = Convert.ToInt32(this.rbtnType.SelectedValue);
                        if (model.group_id == (int)EnumCollection.resource_group.公共资源)
                        {
                            model.school_id = 0;
                            model.school_name = "";
                        }
                        else
                        {
                            model.school_id = Convert.ToInt32(this.ddlSchool.SelectedValue);
                            model.school_name = this.ddlSchool.SelectedItem.Text;
                        }
                        model.data_id = chapter;
                        model.user_id = admin_info.id;

                        string file = files[i];

                        model.title = getStr(file, 1);
                        model.cover = "";
                        model.path = paths[i];
                        model.qrcode = "";
                        model.file_name = file;
                        model.extend = getStr(file, 2);
                        model.likn_url = "";
                        model.add_time = System.DateTime.Now;

                        maxModel = bll.GetModel(" from_id = " + (int)EnumCollection.resource_from.精品微课 + " and data_id = " + chapter + " order by sort desc ");
                        if (maxModel != null)
                        {
                            model.sort = maxModel.sort + 1;
                        }
                        else
                        {
                            model.sort = 1;
                        }

                        string userids = string.Empty;
                        for (int j = 0; j < ckbUser.Items.Count; j++)
                        {
                            if (ckbUser.Items[j].Selected)
                            {
                                userids += "," + ckbUser.Items[j].Value + ",";
                            }
                        }
                        model.share_user = userids;

                        int id = bll.Add(model);
                        if (id > 0)
                        {
                            model.id = id;
                            model.qrcode = "/QrCode.aspx?type=re&id=" + id;
                            bll.Update(model);

                            AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加" + Enum.GetName(typeof(EnumCollection.resource_type), model.type) + "资源信息，主键:" + id); //记录日志
                            count++;
                        }
                    }

                    JscriptMsg("添加" + Enum.GetName(typeof(EnumCollection.resource_type), model.type) + "资源成功！总文件" + files.Length + "个，成功" + count + "个", "resource_list.aspx?chapter=" + this.chapter + "&course_id=" + this.course_id);
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