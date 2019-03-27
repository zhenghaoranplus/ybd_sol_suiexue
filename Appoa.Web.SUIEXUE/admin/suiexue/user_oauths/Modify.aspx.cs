/*功能：生成实体类
 *编码日期:2017/6/21 16:35:50
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

namespace Appoa.Manage.admin.user_oauths
{
    public partial class Modify : Web.UI.ManagePage
    {
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_oauths", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_oauths bll = new BLL.user_oauths();
            Model.user_oauths model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txtuser_id.Text = model.user_id + "";
		        txttype.Text = model.type + "";
		        txtname.Text = model.name + "";
		        txtappid.Text = model.appid + "";
		        txtunionid.Text = model.unionid + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_oauths", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_oauths bll = new BLL.user_oauths();
            Model.user_oauths model = bll.GetModel(this.id);
            
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.type = Convert.ToInt32(txttype.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.appid = Convert.ToString(txtappid.Text);
		        model.unionid = Convert.ToString(txtunionid.Text);
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改用户认证信息，主键:" + id); //记录日志
                JscriptMsg("修改用户认证信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}