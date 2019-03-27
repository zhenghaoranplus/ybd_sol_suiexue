using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;

namespace Appoa.Manage.admin.common
{
    public partial class about_us : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_about_us", EnumCollection.ActionEnum.View.ToString()); //检查权限

                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.关于我们);

            if (model != null)
            {
                this.txttitle.Text = model.title;
                this.txtcontents.Text = model.contents;
            }
        }

        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            Model.common_article model = new Model.common_article();
            BLL.common_article bll = new BLL.common_article();

            model.group_id = (int)EnumCollection.article_group.关于我们;
            model.user_id = 0;
            model.category_id = 0;
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = "";
            model.contents = Convert.ToString(txtcontents.Text);
            model.img_src = "";
            model.click = 0;
            model.upvote = 0;
            model.status = (int)EnumCollection.YesOrNot.是;
            model.add_time = System.DateTime.Now;

            int id = bll.Add(model);
            if (id > 0)
            {
                AddAdminLog(EnumCollection.ActionEnum.Add.ToString(), "添加关于我们，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 编辑操作
        private bool DoEdit(int id)
        {
            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(id);

            model.group_id = (int)EnumCollection.article_group.关于我们;
            model.user_id = 0;
            model.category_id = 0;
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = "";
            model.contents = Convert.ToString(txtcontents.Text);
            model.img_src = "";
            model.click = 0;
            model.upvote = 0;
            model.status = (int)EnumCollection.YesOrNot.是;
            model.add_time = System.DateTime.Now;

            if (bll.Update(model))
            {
                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改关于我们，主键:" + id); //记录日志
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region
            string strError = string.Empty;

            if (txttitle.Text.Trim() == "" || txttitle.Text.Trim().Length > 200) { strError += "标题为空或超出长度![br]"; }
            if (txtcontents.Text.Trim() == "" || txtcontents.Text.Trim().Length > 4000) { strError += "内容为空或超出长度![br]"; }

            if (strError != string.Empty)
            {
                JscriptMsg(strError, "", "Error");
                return;
            }
            #endregion

            BLL.common_article bll = new BLL.common_article();
            Model.common_article model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.关于我们);
            if (model != null)
            {
                ChkAdminLevel("_about_us", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit(model.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("修改关于我们成功！", "");
            }
            else
            {
                ChkAdminLevel("_about_us", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                JscriptMsg("添加关于我们成功！", "");
            }
        }
    }
}