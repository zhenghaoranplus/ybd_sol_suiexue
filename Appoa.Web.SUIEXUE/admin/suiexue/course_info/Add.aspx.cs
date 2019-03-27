/*功能：生成实体类
 *编码日期:2017/8/23 14:42:26
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

namespace Appoa.Manage.admin.course_info
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_course_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_course_info", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID 1公共资源 2学校资源为空或超出长度![br]"; }
                if (txtcategory_id.Text.Trim() == "" || txtcategory_id.Text.Trim().Length>4 ){ strError += "分类ID为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "名称为空或超出长度![br]"; }
                if (txtcover.Text.Trim() == "" || txtcover.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtinfo.Text.Trim() == "" || txtinfo.Text.Trim().Length>4000 ){ strError += "简介为空或超出长度![br]"; }
                if (txtnotice.Text.Trim() == "" || txtnotice.Text.Trim().Length>4000 ){ strError += "公告为空或超出长度![br]"; }
                if (txtqrcode.Text.Trim() == "" || txtqrcode.Text.Trim().Length>500 ){ strError += "二维码图片为空或超出长度![br]"; }
                if (txtqrcode_logo.Text.Trim() == "" || txtqrcode_logo.Text.Trim().Length>500 ){ strError += "二维码logo为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "发布者id为空或超出长度![br]"; }
                if (txtis_show.Text.Trim() == "" || txtis_show.Text.Trim().Length>4 ){ strError += "是否显示为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.course_info model = new Model.course_info();
            BLL.course_info bll = new BLL.course_info();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.category_id = Convert.ToInt32(txtcategory_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.cover = Convert.ToString(txtcover.Text);
		        model.info = Convert.ToString(txtinfo.Text);
		        model.notice = Convert.ToString(txtnotice.Text);
		        model.qrcode = Convert.ToString(txtqrcode.Text);
		        model.qrcode_logo = Convert.ToString(txtqrcode_logo.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.is_show = Convert.ToInt32(txtis_show.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加课程信息信息，主键:" + id); //记录日志
                JscriptMsg("添加课程信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}