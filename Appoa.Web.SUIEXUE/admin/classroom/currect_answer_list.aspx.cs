using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.classroom
{
    public partial class currect_answer_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected string question = string.Empty;
        protected int id = 0;
        protected int exa_id = 0;
        protected Model.sys_manager adminInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量

            this.id = RequestHelper.GetQueryInt("q_id");
            this.exa_id = RequestHelper.GetQueryInt("exa_id");

            adminInfo = GetAdminInfo();
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        #region 数据绑定
        private void BindData()
        {
            Model.common_questions quModel = new BLL.common_questions().GetModel(this.id);
            if (quModel == null)
            {
                JscriptMsg("没有此题目", "back");
                return;
            }
            this.question = quModel.title;

            #region 组装查询条件
            string whereStr = " group_id = " + (int)EnumCollection.examination_group.课堂作业 + " and exa_id = " + this.exa_id + " and q_id = " + this.id;
            string _keywords = keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                if (Utils.IsSafeSqlString(_keywords))
                {
                    whereStr += " and (Title like  '%" + _keywords + "%')";
                }
                else
                {
                    JscriptMsg("搜索关键词中包含危险字符，检索终止！", Utils.CombUrlTxt("currect_answer_list.aspx", "keywords={0}", ""));
                    return;
                }
            }
            #endregion

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.answer_record bll = new BLL.answer_record();
            this.rptList.DataSource = bll.GetListByPage("*", "View_Currect_Question", whereStr, "id", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount(whereStr);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("currect_answer_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("currect_answer_list_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("currect_answer_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("currect_answer_list_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("currect_answer_list.aspx", "keywords={0}", this.keywords));
        }

        protected string GetOptions(string ids)
        {
            BLL.common_answers bll = new BLL.common_answers();
            Model.common_answers model = null;
            string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            string options = string.Empty;
            foreach (string id in arr)
            {
                model = bll.GetModel(Convert.ToInt32(id));
                if (model != null)
                {
                    options += model.options + ",";
                }
            }

            options = Utils.DelLastComma(options);

            return options;
        }
    }
}