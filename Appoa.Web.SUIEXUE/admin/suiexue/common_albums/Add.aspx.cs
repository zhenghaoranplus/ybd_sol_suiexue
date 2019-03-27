/*功能：生成实体类
 *编码日期:2017/10/17 13:49:55
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

namespace Appoa.Manage.admin.common_albums
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_albums", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_albums", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组id为空或超出长度![br]"; }
                if (txtrc_title.Text.Trim() == "" || txtrc_title.Text.Trim().Length>50 ){ strError += "标题为空或超出长度![br]"; }
                if (txtrc_type.Text.Trim() == "" || txtrc_type.Text.Trim().Length>4 ){ strError += "关联内容分类id为空或超出长度![br]"; }
                if (txtrc_data_id.Text.Trim() == "" || txtrc_data_id.Text.Trim().Length>4 ){ strError += "关联内容数据ID为空或超出长度![br]"; }
                if (txtthumb_path.Text.Trim() == "" || txtthumb_path.Text.Trim().Length>255 ){ strError += "缩略图地址为空或超出长度![br]"; }
                if (txtoriginal_path.Text.Trim() == "" || txtoriginal_path.Text.Trim().Length>255 ){ strError += "原图地址为空或超出长度![br]"; }
                if (txtremark.Text.Trim() == "" || txtremark.Text.Trim().Length>500 ){ strError += "图片描述为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "上传时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_albums model = new Model.common_albums();
            BLL.common_albums bll = new BLL.common_albums();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.rc_title = Convert.ToString(txtrc_title.Text);
		        model.rc_type = Convert.ToInt32(txtrc_type.Text);
		        model.rc_data_id = Convert.ToInt32(txtrc_data_id.Text);
		        model.thumb_path = Convert.ToString(txtthumb_path.Text);
		        model.original_path = Convert.ToString(txtoriginal_path.Text);
		        model.remark = Convert.ToString(txtremark.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加全局相册信息，主键:" + id); //记录日志
                JscriptMsg("添加全局相册信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}