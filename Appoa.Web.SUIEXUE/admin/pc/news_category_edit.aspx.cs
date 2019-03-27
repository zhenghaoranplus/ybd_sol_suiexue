using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.pc
{
    public partial class news_category_edit : Web.UI.ManagePage
    {
        protected string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumCollection.ActionEnum.Modify.ToString())
            {
                this.action = EnumCollection.ActionEnum.Modify.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                if (this.id <= 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.common_category().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_news_category", EnumCollection.ActionEnum.View.ToString()); //检查权限

                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.common_category bll = new BLL.common_category();
            Model.common_category model = bll.GetModel(_id);

            txtImg.Text = model.img_src;
            txtSort.Text = model.sort.ToString();
            txtName.Text = model.name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.common_category model = new Model.common_category();

            model.name = txtName.Text.Trim();
            model.sort = Utils.StrToInt(txtSort.Text.Trim(), 0);
            model.img_src = txtImg.Text.Trim();
            model.group_id = (int)EnumCollection.category_group.新闻动态;
            model.add_time = DateTime.Now;
            model.parent_id = 0;
            model.category_level = 1;

            int id = new BLL.common_category().Add(model);
            if (id > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            Model.common_category model = new BLL.common_category().GetModel(_id);

            model.name = txtName.Text.Trim();
            model.sort = Utils.StrToInt(txtSort.Text.Trim(), 0);
            model.img_src = txtImg.Text.Trim();

            if (new BLL.common_category().Update(model))
            {
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_news_category", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改新闻分类成功！", "news_category.aspx");
            }
            else //添加
            {
                ChkAdminLevel("_news_category", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加新闻分类成功！", "news_category.aspx");
            }
        }
    }
}