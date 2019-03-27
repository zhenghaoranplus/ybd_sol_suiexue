/*功能：生成实体类
 *编码日期:2017/10/18 10:18:12
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

namespace Appoa.Manage.admin.common_resource
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_resource", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_resource", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtfrom_id.Text.Trim() == "" || txtfrom_id.Text.Trim().Length>4 ){ strError += "归属 1微课 2课堂为空或超出长度![br]"; }
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txttype.Text.Trim() == "" || txttype.Text.Trim().Length>4 ){ strError += "分类ID为空或超出长度![br]"; }
                if (txtschool_id.Text.Trim() == "" || txtschool_id.Text.Trim().Length>4 ){ strError += "学校ID为空或超出长度![br]"; }
                if (txtschool_name.Text.Trim() == "" || txtschool_name.Text.Trim().Length>50 ){ strError += "学校名称为空或超出长度![br]"; }
                if (txtdata_id.Text.Trim() == "" || txtdata_id.Text.Trim().Length>4 ){ strError += "数据关联ID为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "上传者为空或超出长度![br]"; }
                if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length>50 ){ strError += "标题为空或超出长度![br]"; }
                if (txtcover.Text.Trim() == "" || txtcover.Text.Trim().Length>255 ){ strError += "封面图为空或超出长度![br]"; }
                if (txtpath.Text.Trim() == "" || txtpath.Text.Trim().Length>16 ){ strError += "路径为空或超出长度![br]"; }
                if (txtqrcode.Text.Trim() == "" || txtqrcode.Text.Trim().Length>500 ){ strError += "二维码为空或超出长度![br]"; }
                if (txtfile_name.Text.Trim() == "" || txtfile_name.Text.Trim().Length>50 ){ strError += "文件名为空或超出长度![br]"; }
                if (txtextend.Text.Trim() == "" || txtextend.Text.Trim().Length>50 ){ strError += "扩展名为空或超出长度![br]"; }
                if (txtlikn_url.Text.Trim() == "" || txtlikn_url.Text.Trim().Length>500 ){ strError += "链接为空或超出长度![br]"; }
                if (txtshare_user.Text.Trim() == "" || txtshare_user.Text.Trim().Length>16 ){ strError += "要分享给的用户ID为空或超出长度![br]"; }
                if (txtsort.Text.Trim() == "" || txtsort.Text.Trim().Length>4 ){ strError += "排序为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "上传时间为空或超出长度![br]"; }
                if (txtis_del.Text.Trim() == "" || txtis_del.Text.Trim().Length>4 ){ strError += "是否删除为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_resource model = new Model.common_resource();
            BLL.common_resource bll = new BLL.common_resource();
            
		        model.from_id = Convert.ToInt32(txtfrom_id.Text);
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.school_id = Convert.ToInt32(txtschool_id.Text);
		        model.school_name = Convert.ToString(txtschool_name.Text);
		        model.data_id = Convert.ToInt32(txtdata_id.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.title = Convert.ToString(txttitle.Text);
		        model.cover = Convert.ToString(txtcover.Text);
		        model.path = Convert.ToString(txtpath.Text);
		        model.qrcode = Convert.ToString(txtqrcode.Text);
		        model.file_name = Convert.ToString(txtfile_name.Text);
		        model.extend = Convert.ToString(txtextend.Text);
		        model.likn_url = Convert.ToString(txtlikn_url.Text);
		        model.share_user = Convert.ToString(txtshare_user.Text);
		        model.sort = Convert.ToInt32(txtsort.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
		        model.is_del = Convert.ToInt32(txtis_del.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加资源信息信息，主键:" + id); //记录日志
                JscriptMsg("添加资源信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}