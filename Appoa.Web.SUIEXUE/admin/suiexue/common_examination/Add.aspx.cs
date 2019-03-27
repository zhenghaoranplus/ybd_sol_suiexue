/*功能：生成实体类
 *编码日期:2017/8/15 10:38:58
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

namespace Appoa.Manage.admin.common_examination
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_common_examination", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_common_examination", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txtgroup_id.Text.Trim() == "" || txtgroup_id.Text.Trim().Length>4 ){ strError += "分组ID为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "试卷名称为空或超出长度![br]"; }
                if (txtparent_id.Text.Trim() == "" || txtparent_id.Text.Trim().Length>4 ){ strError += "主体ID为空或超出长度![br]"; }
                if (txtnums.Text.Trim() == "" || txtnums.Text.Trim().Length>4 ){ strError += "试题数量为空或超出长度![br]"; }
                if (txtscore.Text.Trim() == "" || txtscore.Text.Trim().Length>4 ){ strError += "总分为空或超出长度![br]"; }
                if (txtinfo.Text.Trim() == "" || txtinfo.Text.Trim().Length>500 ){ strError += "描述为空或超出长度![br]"; }
                if (txtdescript.Text.Trim() == "" || txtdescript.Text.Trim().Length>4000 ){ strError += "结果解析为空或超出长度![br]"; }
                if (txtqrcode.Text.Trim() == "" || txtqrcode.Text.Trim().Length>255 ){ strError += "二维码为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "创建时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.common_examination model = new Model.common_examination();
            BLL.common_examination bll = new BLL.common_examination();
            
		        model.group_id = Convert.ToInt32(txtgroup_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.parent_id = Convert.ToInt32(txtparent_id.Text);
		        model.nums = Convert.ToInt32(txtnums.Text);
		        model.score = Convert.ToInt32(txtscore.Text);
		        model.info = Convert.ToString(txtinfo.Text);
		        model.descript = Convert.ToString(txtdescript.Text);
		        model.qrcode = Convert.ToString(txtqrcode.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加试卷信息信息，主键:" + id); //记录日志
                JscriptMsg("添加试卷信息信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}