using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Appoa.Common;

namespace Appoa.Manage.admin.shop
{
    public partial class goods_edit : Web.UI.ManagePage
    {
        private string action = EnumCollection.ActionEnum.Add.ToString();
        private int id = 0;
        private int page = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");
            this.page = RequestHelper.GetQueryInt("page", 1);

            if (action == EnumCollection.ActionEnum.Modify.ToString())
            {
                if (this.id <= 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.goods_goods().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                this.txtimg_src.Attributes.Add("readonly", "true");
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                BindSelect();

                if (action == EnumCollection.ActionEnum.Modify.ToString())
                {
                    BindInfo();
                }
            }
        }

        #region 赋值操作
        private void BindSelect()
        {
            DataTable dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.goods_group), "key", "val");
            this.rbtnGroup.DataSource = dt;
            this.rbtnGroup.DataTextField = "key";
            this.rbtnGroup.DataValueField = "val";
            this.rbtnGroup.DataBind();
            this.rbtnGroup.SelectedIndex = 0;

            dt = EnumCollection.EnumToDataTable(typeof(EnumCollection.sales_status), "key", "val");
            this.rbtnStatus.DataSource = dt;
            this.rbtnStatus.DataTextField = "key";
            this.rbtnStatus.DataValueField = "val";
            this.rbtnStatus.DataBind();
            this.rbtnStatus.SelectedIndex = 0;

            dt = new BLL.common_category().GetListNew(" group_id = " + (int)EnumCollection.category_group.商城, "0");
            this.ddlCategory.Items.Add(new ListItem("所属分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["category_level"].ToString());
                string Title = dr["name"].ToString().Trim();
                string parent_name = dr["parent_name"].ToString().Trim();

                if (ClassLayer == 2)
                {
                    if (!string.IsNullOrEmpty(parent_name))
                    {
                        Title = parent_name + " ├ " + Title;
                        this.ddlCategory.Items.Add(new ListItem(Title, Id));
                    }
                }
            }
        }

        private void BindInfo()
        {
            BLL.goods_goods bll = new BLL.goods_goods();
            Model.goods_goods model = bll.GetModel(this.id);
            if (model == null)
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            rbtnGroup.SelectedValue = model.group_id + "";
            ddlCategory.SelectedValue = model.category_id + "";
            txttitle.Text = model.title + "";
            txtsubtitle.Text = model.subtitle + "";
            txtimg_src.Text = model.img_src + "";
            txtoprice.Text = model.oprice + "";
            txtprice.Text = model.price + "";
            txtparameters.Text = model.parameters + "";
            txtdetails.Text = model.details + "";
            txtsales_num.Text = model.sales_num + "";
            rbtnStatus.SelectedValue = model.status + "";

            this.rptLYPics.DataSource = new BLL.common_albums().GetList(" group_id = " + (int)EnumCollection.img_group.商品轮播图 + " and rc_data_id = " + this.id);
            this.rptLYPics.DataBind();
        }
        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            BLL.goods_goods bll = new BLL.goods_goods();
            Model.goods_goods model = new Model.goods_goods();

            model.ct_id = 0;
            model.group_id = Convert.ToInt32(rbtnGroup.SelectedValue);
            model.category_id = Convert.ToInt32(ddlCategory.SelectedValue);
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = Convert.ToString(txtsubtitle.Text);
            model.img_src = Convert.ToString(txtimg_src.Text);
            model.oprice = Convert.ToDecimal(txtoprice.Text);
            model.price = Convert.ToDecimal(txtprice.Text);
            model.parameters = Convert.ToString(txtparameters.Text);
            model.details = Convert.ToString(txtdetails.Text);
            model.sales_num = Convert.ToInt32(txtsales_num.Text);
            model.status = Convert.ToInt32(rbtnStatus.SelectedValue);
            model.sj_time = System.DateTime.Now;
            model.xj_time = System.DateTime.Now;
            model.add_time = System.DateTime.Now;

            int row = bll.Add(model);
            if (row > 0)
            {
                #region 添加轮播图
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                if (albumArr != null && albumArr.Length > 0)
                {
                    for (int i = 0; i < albumArr.Length; i++)
                    {
                        string[] imgArr = albumArr[i].Split('|');
                        if (imgArr.Length == 3)
                        {
                            Model.common_albums pic_model = new Model.common_albums();
                            pic_model = new Model.common_albums() { group_id = (int)EnumCollection.img_group.商品轮播图, rc_data_id = row, rc_type = 0, original_path = imgArr[1], thumb_path = imgArr[2], remark = "", add_time = DateTime.Now };
                            new BLL.common_albums().Add(pic_model);
                        }
                    }
                }
                #endregion

                #region 添加默认规格
                BLL.goods_spec_item specBll = new BLL.goods_spec_item();
                Model.goods_spec_item item = new Model.goods_spec_item();
                item.name = "规格";
                item.parent_id = 0;
                item.goods_id = row;
                item.sort = 1;

                int spec = specBll.Add(item);
                if (spec > 0)
                {
                    item = new Model.goods_spec_item();
                    item.name = "平装";
                    item.parent_id = spec;
                    item.goods_id = row;
                    item.sort = 1;

                    int subspec = specBll.Add(item);
                    if (subspec > 0)
                    {
                        Model.goods_spec_type type = new Model.goods_spec_type();
                        type.goods_id = row;
                        type.price = model.price;
                        type.stock = 100;
                        type.spec = subspec;

                        if (new BLL.goods_spec_type().Add(type) <= 0)
                        {
                            specBll.DeleteList(spec + "," + subspec);
                        }
                    }
                    else
                    {
                        specBll.Delete(spec);
                    }
                }
                #endregion

                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "添加商品信息，主键:" + row); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作
        private bool DoEdit()
        {
            BLL.goods_goods bll = new BLL.goods_goods();
            Model.goods_goods model = bll.GetModel(this.id);

            model.ct_id = 0;
            model.group_id = Convert.ToInt32(rbtnGroup.SelectedValue);
            model.category_id = Convert.ToInt32(ddlCategory.SelectedValue);
            model.title = Convert.ToString(txttitle.Text);
            model.subtitle = Convert.ToString(txtsubtitle.Text);
            model.img_src = Convert.ToString(txtimg_src.Text);
            model.oprice = Convert.ToDecimal(txtoprice.Text);
            model.price = Convert.ToDecimal(txtprice.Text);
            model.parameters = Convert.ToString(txtparameters.Text);
            model.details = Convert.ToString(txtdetails.Text);
            model.sales_num = Convert.ToInt32(txtsales_num.Text);
            model.status = Convert.ToInt32(rbtnStatus.SelectedValue);
            model.sj_time = model.status == 1 ? System.DateTime.Now : model.sj_time;
            model.xj_time = model.status == 2 ? System.DateTime.Now : model.sj_time;

            if (bll.Update(model))
            {
                #region 添加轮播图
                new BLL.common_albums().Delete(" group_id = " + (int)EnumCollection.img_group.商品轮播图 + " and rc_data_id = " + model.id);
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                if (albumArr != null && albumArr.Length > 0)
                {
                    for (int i = 0; i < albumArr.Length; i++)
                    {
                        string[] imgArr = albumArr[i].Split('|');
                        if (imgArr.Length == 3)
                        {
                            Model.common_albums pic_model = new Model.common_albums();
                            pic_model = new Model.common_albums() { group_id = (int)EnumCollection.img_group.商品轮播图, rc_data_id = this.id, rc_type = 0, original_path = imgArr[1], thumb_path = imgArr[2], remark = "", add_time = DateTime.Now };
                            new BLL.common_albums().Add(pic_model);
                        }
                    }
                }
                #endregion

                AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "修改商品信息，主键:" + this.id); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumCollection.ActionEnum.Add.ToString())
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加商品信息成功！", "goods_list.aspx?page=" + this.page);
            }
            if (action == EnumCollection.ActionEnum.Modify.ToString())
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改商品信息成功！", "goods_list.aspx");
            }
        }
    }
}