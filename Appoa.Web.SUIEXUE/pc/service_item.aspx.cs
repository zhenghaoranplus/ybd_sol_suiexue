using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.pc
{
    public partial class service_item : System.Web.UI.Page
    {
        protected string str = string.Empty;
        protected string str1 = string.Empty;
        protected string str2 = string.Empty;
        protected string str3 = string.Empty;
        protected string str4 = string.Empty;
        protected string str5 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.common_article bll = new BLL.common_article();
                Model.common_article model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.服务项目 + " and category_id = " + (int)EnumCollection.service_items_category.微课MOOC开发);

                if (model != null)
                {
                    str = model.contents;
                }

                model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.服务项目 + " and category_id = " + (int)EnumCollection.service_items_category.立体化教材建设);
                if (model != null)
                {
                    str1 = model.contents;
                }

                model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.服务项目 + " and category_id = " + (int)EnumCollection.service_items_category.智慧教室);
                if (model != null)
                {
                    str2 = model.contents;
                }

                model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.微课慕课项目简介 + " and category_id = " + (int)EnumCollection.mooc_item.参赛微课);
                if (model != null)
                {
                    str3 = model.contents;
                }

                model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.微课慕课项目简介 + " and category_id = " + (int)EnumCollection.mooc_item.在线开发课程);
                if (model != null)
                {
                    str4 = model.contents;
                }

                model = bll.GetModel(" group_id = " + (int)EnumCollection.article_group.微课慕课项目简介 + " and category_id = " + (int)EnumCollection.mooc_item.国家级精品课程);
                if (model != null)
                {
                    str5 = model.contents;
                }
            }
        }
    }
}