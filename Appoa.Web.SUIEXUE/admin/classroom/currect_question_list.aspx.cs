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
    public partial class currect_question_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        private int exa_id = 0;
        private int type = 0;
        protected int chapter = 0;
        protected string class_name = string.Empty;
        protected string parent_name = string.Empty;
        protected string chapter_name = string.Empty;
        protected string examination = string.Empty;
        protected Model.sys_manager adminInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            this.exa_id = RequestHelper.GetQueryInt("id");
            this.type = RequestHelper.GetQueryInt("type");
            this.chapter = RequestHelper.GetQueryInt("chapter");

            adminInfo = GetAdminInfo();
            if (!Page.IsPostBack)
            {
                BindSelect();
                BindData();
            }
        }

        #region 数据绑定
        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.questions_type), "key", "val");
            this.ddlType.DataSource = dt;
            this.ddlType.DataTextField = "key";
            this.ddlType.DataValueField = "val";
            this.ddlType.DataBind();
            this.ddlType.Items.Insert(0, new ListItem("=试题类型=", "0"));
        }

        private void BindData()
        {
            BLL.course_chapter ccBll = new BLL.course_chapter();
            Model.course_chapter chapter = ccBll.GetModel(this.chapter);
            if (chapter == null)
            {
                JscriptMsg("没有此节", "back");
                return;
            }

            this.chapter_name = chapter.name;
            Model.course_chapter pModel = ccBll.GetModel(chapter.parent_id);
            if (pModel == null)
            {
                JscriptMsg("没有此章", "back");
                return;
            }

            this.parent_name = pModel.name;
            Model.classroom_info ciModel = new BLL.classroom_info().GetModel(pModel.course_id);
            if (ciModel == null)
            {
                JscriptMsg("没有此课堂", "back");
                return;
            }

            this.class_name = ciModel.name;
            Model.user_info user = new BLL.user_info().GetModel(" phone = '" + adminInfo.user_name + "' ");
            if (user == null)
            {
                JscriptMsg("没有此教师", "back");
                return;
            }

            if (ciModel.user_id != user.id)
            {
                JscriptMsg("此课堂不属于你", "back");
                return;
            }

            Model.common_examination exaModel = new BLL.common_examination().GetModel(this.exa_id);
            if (exaModel == null)
            {
                JscriptMsg("没有此作业", "back");
                return;
            }

            this.examination = exaModel.name;
            #region 组装查询条件
            string whereStr = " 1 = 1 ";

            DataTable dtids = new BLL.examination_question().GetList(" exa_id = " + this.exa_id);
            string ids = string.Empty;
            foreach (DataRow item in dtids.Rows)
            {
                ids += Convert.ToInt32(item["q_id"]) + ",";
            }

            ids = Utils.DelLastComma(ids);

            if (!string.IsNullOrEmpty(ids))
            {
                whereStr += " and id in (" + ids + ") ";
            }


            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("currect_question_list.aspx", "keywords={0}", ""));
                    return;
                }
            }

            if (this.type > 0)
            {
                this.ddlType.SelectedValue = this.type + "";
                whereStr += " and type = " + this.type;
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.common_questions bll = new BLL.common_questions();
            this.rptList.DataSource = bll.GetListByPage(whereStr, "ID", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("currect_question_list.aspx", "keywords={0}&page={1}&type={2}", this.keywords, "__id__", this.type + "");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("currect_question_list_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("currect_question_list.aspx", "keywords={0}&type={1}", txtKeywords.Text, this.type + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("currect_question_list_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("currect_question_list.aspx", "keywords={0}&type={1}", this.keywords, this.type + ""));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("currect_question_list.aspx", "keywords={0}&type={1}", this.keywords, this.ddlType.SelectedValue));
        }
    }
}