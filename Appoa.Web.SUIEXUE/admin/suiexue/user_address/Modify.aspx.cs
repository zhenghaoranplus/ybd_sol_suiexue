﻿/*功能：生成实体类
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
                ChkAdminLevel("_ybd_user_address", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindInfo();
            }
        }

        #region 赋值操作
        private void BindInfo()
        {
            BLL.user_address bll = new BLL.user_address();
            Model.user_address model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }
		        txttype.Text = model.type + "";
		        txttype_name.Text = model.type_name + "";
		        txtuser_id.Text = model.user_id + "";
		        txtname.Text = model.name + "";
		        txtmobile.Text = model.mobile + "";
		        txttel.Text = model.tel + "";
		        txtsheng.Text = model.sheng + "";
		        txtshi.Text = model.shi + "";
		        txtxian.Text = model.xian + "";
		        txtarea.Text = model.area + "";
		        txtaddress.Text = model.address + "";
		        txtpostcode.Text = model.postcode + "";
		        txtIDCard.Text = model.IDCard + "";
		        txtis_default.Text = model.is_default + "";
		        txtadd_time.Text = model.add_time + "";
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_ybd_user_address", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.user_address bll = new BLL.user_address();
            Model.user_address model = bll.GetModel(this.id);
            
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
            
            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改收货地址信息，主键:" + id); //记录日志
                JscriptMsg("修改收货地址信息成功！", "Manage.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }
        }
    }
}