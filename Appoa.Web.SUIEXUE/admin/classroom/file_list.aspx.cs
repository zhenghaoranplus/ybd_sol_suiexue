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
    public partial class file_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        protected int class_id = 0;
        protected Model.sys_manager adminInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.page = RequestHelper.GetQueryInt("page", 1);
            this.pageSize = GetPageSize(10); //每页数量
            this.class_id = RequestHelper.GetQueryInt("class_id");
            this.adminInfo = GetAdminInfo();

            if (this.adminInfo == null)
            {
                JscriptMsg("登录超时，请重新登录", "/admin/login.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_file_materials", EnumCollection.ActionEnum.View.ToString()); //检查权限
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定

        private void BindSelect()
        {
            string where = "";
            if (adminInfo.role_type == 2)
            {
                Model.user_info user = new BLL.user_info().GetModel(" phone = '" + adminInfo.user_name + "' ");
                where += " user_id = " + user.id;
            }

            DataTable dt = new BLL.classroom_info().GetList(where);
            this.ddlClass.DataSource = new BLL.classroom_info().GetList(where);
            this.ddlClass.DataTextField = "name";
            this.ddlClass.DataValueField = "id";
            this.ddlClass.DataBind();
        }

        private void BindData()
        {
            #region 组装查询条件

            if (this.class_id > 0)
            {
                this.ddlClass.SelectedValue = this.class_id + "";
            }
            else
            {
                this.class_id = Convert.ToInt32(this.ddlClass.SelectedValue);
            }

            string whereStr = " from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.文档资源 + " and data_id = " + this.class_id;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}", "", this.class_id + ""));
                    return;
                }
            }

            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_resource bll = new BLL.common_resource();
            this.rptList.DataSource = bll.GetListByPage(whereStr, " sort asc ", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}&page={2}", this.keywords, this.class_id + "", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("file_list_page_size", "AppoaPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}", txtKeywords.Text, this.class_id + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("file_list_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id + ""));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_classroom_file_materials", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.common_resource bll = new BLL.common_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtsort")).Text.Trim(), out sortId))
                {
                    sortId = 1;
                }
                bll.UpdateField(id, "sort=" + sortId.ToString());
            }
            AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "保存课堂文档排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}&page={2}", this.keywords, this.class_id + "", this.page + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_classroom_file_materials", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.common_resource bll = new BLL.common_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.UpdateField(id, "is_del = 1"))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除资源信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id + ""));
        }

        protected void ddlddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("file_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.ddlClass.SelectedValue));
        }

        protected string GetClassRoomName(int id)
        {
            Model.classroom_info model = new BLL.classroom_info().GetModel(id);
            if (model != null)
            {
                return model.name;
            }
            return "";
        }
    }
}