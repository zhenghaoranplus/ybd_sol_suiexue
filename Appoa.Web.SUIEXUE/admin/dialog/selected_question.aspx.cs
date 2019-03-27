using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.dialog
{
    public partial class selected_question : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        private int exaid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageSize = GetPageSize(10); //每页数量
            this.exaid = RequestHelper.GetQueryInt("exaid");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.View.ToString()); //检查权限

                BindData();
            }
        }

        #region 数据绑定

        private void BindData()
        {
            this.page = RequestHelper.GetQueryInt("page", 1);

            BLL.examination_question bll = new BLL.examination_question();
            this.rptList.DataSource = bll.GetListByPage("*", "View_ExaminationQuestion", " exa_id = " + exaid, "ID DESC", this.page, this.pageSize);
            this.rptList.DataBind();

            this.totalCount = bll.GetRecordCount("View_ExaminationQuestion", " exa_id = " + exaid);
            int score = bll.GetSumCount("score", "View_ExaminationQuestion", " exa_id = " + exaid);
            int singleSelete = bll.GetRecordCount("View_ExaminationQuestion", " exa_id = " + exaid + " and type = " + (int)EnumCollection.questions_type.单选题);
            int muliteSelete = bll.GetRecordCount("View_ExaminationQuestion", " exa_id = " + exaid + " and type = " + (int)EnumCollection.questions_type.多选题);
            int istrueth = bll.GetRecordCount("View_ExaminationQuestion", " exa_id = " + exaid + " and type = " + (int)EnumCollection.questions_type.判断题);
            int input = bll.GetRecordCount("View_ExaminationQuestion", " exa_id = " + exaid + " and type = " + (int)EnumCollection.questions_type.填空题);
            int subjective = bll.GetRecordCount("View_ExaminationQuestion", " exa_id = " + exaid + " and type = " + (int)EnumCollection.questions_type.主观题);

            this.lblCount.Text = string.Format("共 {0} 道题目，总分 {1} 分。其中单选题 {2} 道，多选题 {3} 道，判断题 {4} 道，填空题 {5} 道，主观题 {6} 道。",
                this.totalCount, score, singleSelete, muliteSelete, istrueth, input, subjective);
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("selected_question.aspx", "exaid={0}&page={1}", this.exaid + "", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("selected_question_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("selected_question.aspx", "exaid={0}", this.exaid + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("selected_question_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("selected_question.aspx", "exaid={0}", this.exaid + ""));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.examination_question bll = new BLL.examination_question();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(" exa_id = " + this.exaid + " and q_id = " + id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除已选题目信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", "");
            BindData();
        }
    }
}