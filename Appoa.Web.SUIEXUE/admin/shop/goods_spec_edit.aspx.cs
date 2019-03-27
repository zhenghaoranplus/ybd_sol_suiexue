using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;
using System.Data;

namespace Appoa.Manage.admin.shop
{
    public partial class goods_spec_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString(); //操作类型
        private int goods_id = 0;
        private int id = 0;
        private int page = 1;

        protected string is_stock = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.goods_id = RequestHelper.GetQueryInt("goods_id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (goods_id > 0)
            {
                if (!new BLL.goods_goods().Exists(this.goods_id))
                {
                    JscriptMsg("商品信息不存在或已被删除！", "back");
                    return;
                }
            }
            this.id = RequestHelper.GetQueryInt("id");
            if (this.id > 0)
            {
                if (!new BLL.goods_spec_item().Exists(this.id))
                {
                    JscriptMsg("主规格不存在或已被删除！", "back");
                    return;
                }
                this.is_stock = "1";
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            Model.goods_spec_item model = bll.GetModel(_id);

            txtSort.Text = model.sort.ToString();
            txtTitle.Text = model.name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.goods_spec_item model = new Model.goods_spec_item();
            BLL.goods_spec_item bll = new BLL.goods_spec_item();

            model.goods_id = this.goods_id;
            model.name = txtTitle.Text.Trim();
            model.sort = Utils.StrToInt(txtSort.Text.Trim(), 0);
            model.parent_id = 0;
            if (this.id > 0)
            {
                Model.goods_spec_item main_mdoel = new BLL.goods_spec_item().GetModel(this.id);
                model.goods_id = main_mdoel.goods_id;
                model.parent_id = this.id;
                this.goods_id = model.goods_id;
            }

            int addId = bll.Add(model);
            if (addId > 0)
            {
                Model.goods_spec_type spec_type = new Model.goods_spec_type();
                Model.goods_goods goods = new BLL.goods_goods().GetModel(this.goods_id);
                if (goods != null)
                {
                    spec_type.goods_id = this.goods_id;
                    spec_type.price = goods.price;
                    spec_type.spec = addId;
                    spec_type.stock = 100;
                }
                else
                {
                    spec_type.goods_id = this.goods_id;
                    spec_type.price = 0;
                    spec_type.spec = addId;
                    spec_type.stock = 100;
                }
                new BLL.goods_spec_type().Add(spec_type);

                return true;
            }
            return false;
        }
        #endregion

        //修改
        #region 修改操作=================================
        private bool DoModify(int _id)
        {
            bool result = false;
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            Model.goods_spec_item model = bll.GetModel(_id);

            model.name = txtTitle.Text.Trim();
            model.sort = Utils.StrToInt(txtSort.Text.Trim(), 0);
            this.goods_id = model.goods_id;

            if (bll.Update(model))
            {
                return true;
            }
            return result;
        }
        #endregion

        //保存
        #region 保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Modify.ToString()) //修改
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoModify(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改商品规格信息成功！", "goods_spec.aspx?page=" + this.page + "&goods_id=" + this.goods_id);
            }
            else //添加
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加商品规格信息成功！", "goods_spec.aspx?page=" + this.page + "&goods_id=" + this.goods_id);
            }
        }
        #endregion
    }
}