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
    public partial class unselected_question : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        private int group = 0;
        private int exaid = 0;
        private int chapter = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageSize = GetPageSize(10); //每页数量
            this.group = RequestHelper.GetQueryInt("group", 1);
            this.exaid = RequestHelper.GetQueryInt("exaid");
            this.chapter = RequestHelper.GetQueryInt("chapter", 0);

            if (this.group == 0 || this.exaid == 0 || this.chapter == 0)
            {
                JscriptMsg("传递参数有误", "back");
                return;
            }

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

            DataTable dtids = new BLL.examination_question().GetViewList("View_ExaminationQuestion", " group_id = " + group + " and exa_id = " + exaid);
            string ids = string.Empty;

            foreach (DataRow item in dtids.Rows)
            {
                ids += Convert.ToInt32(item["id"]) + ",";
            }

            ids = Utils.DelLastComma(ids);

            string where = " group_id = " + this.group + " and data_id = " + this.chapter;
            if (!string.IsNullOrEmpty(ids))
            {
                where += " and id not in (" + ids + ") ";
            }

            BLL.common_questions bLL = new BLL.common_questions();
            DataTable dt = bLL.GetListByPage(where, "id", this.page, this.pageSize);
            this.rptList.DataSource = dt;
            this.rptList.DataBind();

            this.totalCount = bLL.GetRecordCount(where);

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("unselected_question.aspx", "exaid={0}&page={1}&group={2}", this.exaid + "", "__id__", this.group + "");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("unselected_question_page_size", "AppoaPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("unselected_question.aspx", "exaid={0}&group=1", this.exaid + "", this.group + ""));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("unselected_question_page_size", "AppoaPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("unselected_question.aspx", "exaid={0}&group=1", this.exaid + "", this.group + ""));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_common_questions", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;

            string allid = hdfAllID.Value;
            string[] ids = allid.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            BLL.examination_question bll = new BLL.examination_question();
            int id = 0;

            for (int i = 0; i < ids.Length; i++)
            {
                id = Convert.ToInt32(ids[i]);
                Model.examination_question model = bll.GetModel(" exa_id = " + this.exaid + " and q_id = " + id);
                if (model == null)
                {
                    //添加
                    model = new Model.examination_question();
                    model.exa_id = this.exaid;
                    model.q_id = id;

                    if (bll.Add(model) > 0)
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
                else
                {
                    errorCount += 1;
                }
            }

            hdfAllID.Value = "";
            //for (int i = 0; i < rptList.Items.Count; i++)
            //{
            //    int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            //    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            //    if (cb.Checked)
            //    {
            //        Model.examination_question model = bll.GetModel(" group_id = " + this.group + " and exa_id = " + this.exaid + " and q_id = " + id);
            //        if (model == null)
            //        {
            //            //添加
            //            model = new Model.examination_question();
            //            model.exa_id = this.exaid;
            //            model.q_id = id;

            //            if (bll.Add(model) > 0)
            //            {
            //                sucCount += 1;
            //            }
            //            else
            //            {
            //                errorCount += 1;
            //            }
            //        }
            //        else
            //        {
            //            errorCount += 1;
            //        }
            //    }
            //}
            AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加未选题目信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("添加成功" + sucCount + "条，失败" + errorCount + "条！", "");
            BindData();
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb != null)
                {
                    cb.ID = "chkId" + id;
                }
            }
        }
    }
}