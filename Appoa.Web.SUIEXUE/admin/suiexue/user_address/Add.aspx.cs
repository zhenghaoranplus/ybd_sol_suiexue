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

namespace Appoa.Manage.admin.user_address
{
    public partial class Add : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_ybd_user_address", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            }
        }        

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_address", EnumCollection.ActionEnum.Add.ToString()); //检查权限
            
            #region
            string strError = string.Empty;
                if (txttype.Text.Trim() == "" || txttype.Text.Trim().Length>4 ){ strError += "地址类型id为空或超出长度![br]"; }
                if (txttype_name.Text.Trim() == "" || txttype_name.Text.Trim().Length>50 ){ strError += "地址类型名称为空或超出长度![br]"; }
                if (txtuser_id.Text.Trim() == "" || txtuser_id.Text.Trim().Length>4 ){ strError += "用户id为空或超出长度![br]"; }
                if (txtname.Text.Trim() == "" || txtname.Text.Trim().Length>50 ){ strError += "收货人姓名为空或超出长度![br]"; }
                if (txtmobile.Text.Trim() == "" || txtmobile.Text.Trim().Length>50 ){ strError += "手机号为空或超出长度![br]"; }
                if (txttel.Text.Trim() == "" || txttel.Text.Trim().Length>50 ){ strError += "联系电话为空或超出长度![br]"; }
                if (txtsheng.Text.Trim() == "" || txtsheng.Text.Trim().Length>50 ){ strError += "省为空或超出长度![br]"; }
                if (txtshi.Text.Trim() == "" || txtshi.Text.Trim().Length>50 ){ strError += "市为空或超出长度![br]"; }
                if (txtxian.Text.Trim() == "" || txtxian.Text.Trim().Length>50 ){ strError += "区县为空或超出长度![br]"; }
                if (txtarea.Text.Trim() == "" || txtarea.Text.Trim().Length>50 ){ strError += "区域为空或超出长度![br]"; }
                if (txtaddress.Text.Trim() == "" || txtaddress.Text.Trim().Length>100 ){ strError += "详细地址为空或超出长度![br]"; }
                if (txtpostcode.Text.Trim() == "" || txtpostcode.Text.Trim().Length>20 ){ strError += "邮政编码为空或超出长度![br]"; }
                if (txtIDCard.Text.Trim() == "" || txtIDCard.Text.Trim().Length>50 ){ strError += "身份证号为空或超出长度![br]"; }
                if (txtis_default.Text.Trim() == "" || txtis_default.Text.Trim().Length>4 ){ strError += "是否是默认地址为空或超出长度![br]"; }
                if (txtadd_time.Text.Trim() == "" || txtadd_time.Text.Trim().Length>8 ){ strError += "添加时间为空或超出长度![br]"; }
           
            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            Model.user_address model = new Model.user_address();
            BLL.user_address bll = new BLL.user_address();
            
		        model.type = Convert.ToInt32(txttype.Text);
		        model.type_name = Convert.ToString(txttype_name.Text);
		        model.user_id = Convert.ToInt32(txtuser_id.Text);
		        model.name = Convert.ToString(txtname.Text);
		        model.mobile = Convert.ToString(txtmobile.Text);
		        model.tel = Convert.ToString(txttel.Text);
		        model.sheng = Convert.ToString(txtsheng.Text);
		        model.shi = Convert.ToString(txtshi.Text);
		        model.xian = Convert.ToString(txtxian.Text);
		        model.area = Convert.ToString(txtarea.Text);
		        model.address = Convert.ToString(txtaddress.Text);
		        model.postcode = Convert.ToString(txtpostcode.Text);
		        model.IDCard = Convert.ToString(txtIDCard.Text);
		        model.is_default = Convert.ToInt32(txtis_default.Text);
		        model.add_time = Convert.ToDateTime(txtadd_time.Text);
            
            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加收货地址信息，主键:" + id); //记录日志
                JscriptMsg("添加收货地址信息成功！", "Manage.aspx", "");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }            
        }
    }
}