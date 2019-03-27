using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.course
{
    public partial class chapter_list : Web.UI.ManagePage
    {
        protected int course_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.course_id = RequestHelper.GetQueryInt("course_id", 0);
            if (!IsPostBack)
            {
                if (!new BLL.course_info().Exists(this.course_id))
                {
                    JscriptMsg("没有此课程", "back");
                    return;
                }
                ChkAdminLevel("_course_chapter", EnumCollection.ActionEnum.View.ToString()); //检查权限
                
                BindData();
            }
        }

        #region 数据绑定
        private void BindData()
        {
            string whereStr = " chapter_level = 1 and group_id = " + (int)EnumCollection.chapter_group.精品微课 + " and course_id = " + course_id;

            BLL.course_chapter bll = new BLL.course_chapter();
            this.rptList.DataSource = bll.GetListNew(whereStr, "0");
            this.rptList.DataBind();
        }
        #endregion

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_course_chapter", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.course_chapter bll = new BLL.course_chapter();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        DBUtility.DbHelperSQL.ExecuteSql(" delete from ybd_common_resource where from_id = 1 and data_id = " + id);
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除课程章节" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("chapter_list.aspx", "", ""));
        }

        //protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {
        //        Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
        //        HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
        //        string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
        //        string LitImg1 = "<span class=\"folder-open\"></span>";
        //        string LitImg2 = "<span class=\"folder-line\"></span>";

        //        string classLayer = hidLayer.Value;
        //        if (classLayer == "0")
        //        {
        //            LitFirst.Text = LitImg1;
        //        }
        //        else
        //        {
        //            int count = Convert.ToInt32(hidLayer.Value);
        //            LitFirst.Text = string.Format(LitStyle, (count - 1) * 40, LitImg2, LitImg1);
        //        }
        //    }
        //}
    }
}