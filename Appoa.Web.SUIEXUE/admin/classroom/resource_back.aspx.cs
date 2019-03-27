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
    public partial class resource_back : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.page = RequestHelper.GetQueryInt("page", 1);
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_classroom_resource_back", EnumCollection.ActionEnum.View.ToString()); //检查权限

                BindData();
            }
        }

        #region 数据绑定
        private void BindData()
        {
            #region 组装查询条件
            string whereStr = " from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 1 ";
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("resource_back.aspx", "keywords={0}", ""));
                    return;
                }
            }

            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_resource bll = new BLL.common_resource();
            this.rptList.DataSource = bll.GetListByPage("*", "View_ChapterResource", whereStr, " sort asc ", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("resource_back.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("classroom_resource_back_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("resource_back.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("classroom_resource_back_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("resource_back.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_classroom_resource_back", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.common_resource bll = new BLL.common_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
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
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("resource_back.aspx", "keywords={0}", this.keywords));
        }

        //还原
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_classroom_resource_back", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.common_resource bll = new BLL.common_resource();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.UpdateField(id, "is_del = 0"))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "还原资源信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("还原成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("resource_back.aspx", "keywords={0}", this.keywords));
        }

        protected string ReturnClassroomName(int id)
        {
            Model.course_chapter chapter = new BLL.course_chapter().GetModel(id);
            if (chapter != null)
            {
                Model.classroom_info classroom = new BLL.classroom_info().GetModel(chapter.course_id);
                if (classroom != null)
                {
                    return classroom.name;
                }
            }
            return "";
        }

        protected string ReturnHtmlPath(string path)
        {
            int index = path.LastIndexOf('.');
            string extend = path.Substring(0, index);
            return extend + ".html";
        }
    }
}