/*功能：生成实体类
 *编码日期:2017/7/10 9:25:47
 *编码人：阴华伟
 *QQ:577372287
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;
using System.Data;

namespace Appoa.Manage.admin.course_chapter
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_course_chapter", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_course_chapter", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组为空或超出长度![br]"; }
                if (txtcourse_id.Text.Trim() == "" || txtcourse_id.Text.Trim().Length>4 ){ strError += "课程ID为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "名称为空或超出长度![br]"; }
                if (txttag.Text.Trim() == "" || txttag.Text.Trim().Length>50 ){ strError += "标签为空或超出长度![br]"; }
                if (txtchapter_level.Text.Trim() == "" || txtchapter_level.Text.Trim().Length>4 ){ strError += "章节级别为空或超出长度![br]"; }
                if (txtparent_id.Text.Trim() == "" || txtparent_id.Text.Trim().Length>4 ){ strError += "父级ID为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.course_chapter model = new Model.course_chapter();
            BLL.course_chapter bll = new BLL.course_chapter();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.course_id = Convert.ToInt32(txtcourse_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.tag = Convert.ToString(txttag.Text);
		        model.chapter_level = Convert.ToInt32(txtchapter_level.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加课程章节信息，主键:" + id); //记录日志
                JscriptMsg("添加课程章节信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}