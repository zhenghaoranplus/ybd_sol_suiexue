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
    public partial class goods_spec : Web.UI.ManagePage
    {
        protected int goods_id = 0;
        private int page = 1;
        protected string is_show = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            if (!int.TryParse(Request.QueryString["goods_id"] as string, out this.goods_id))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.goods_goods().Exists(this.goods_id))
            {
                JscriptMsg("记录不存在或已被删除！", "back");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            DataTable dt = bll.GetListNew(this.goods_id.ToString());
            this.rptList.DataSource = dt;
            this.rptList.DataBind();

            if (new BLL.goods_spec_item().GetRecordCount(" parent_id=0 and goods_id=" + this.goods_id) >= 1)
            {
                this.is_show = "1";
            }
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                string classLayer = hidLayer.Value;
                if (classLayer == "0")
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (3 - 1) * 24, LitImg2, LitImg1);
                }
            }
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Modify.ToString()); //检查权限
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtsort")).Text.Trim(), out sortId))
                {
                    sortId = 1;
                }
                bll.UpdateField(id, "sort=" + sortId.ToString());
            }
            AddAdminLog(EnumCollection.ActionEnum.Modify.ToString(), "保存商品规格排序"); //记录日志
            JscriptMsg("保存排序成功！", "goods_spec.aspx?page=" + this.page + "&goods_id=" + this.goods_id);
        }

        //删除规格
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("_goods_list", EnumCollection.ActionEnum.Delete.ToString()); //检查权限
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DataTable old_dt = new BLL.goods_spec_item().GetList("goods_id=" + goods_id + " and parent_id !=0 ");
                    int old_sum = old_dt.AsEnumerable().GroupBy(a => a.Field<int>("parent_id")).Count();
                    if (bll.DeleteNew(id))
                    {
                        //更新规格信息
                        DataTable spec_dt = new BLL.goods_spec_item().GetList("goods_id=" + goods_id + " and parent_id !=0 ");

                        if (spec_dt.AsEnumerable().GroupBy(a => a.Field<int>("parent_id")).Count() == 1 && old_sum > 1)
                        {
                            for (int j = 0; j < spec_dt.Rows.Count; j++)
                            {
                                Model.goods_goods goods_model = new BLL.goods_goods().GetModel(Utils.StrToInt(spec_dt.Rows[j]["goods_id"].ToString(), 0));

                                if (goods_model != null)
                                {
                                    Model.goods_spec_type type_model = new Model.goods_spec_type();
                                    type_model.goods_id = goods_model.id;
                                    type_model.spec = Utils.StrToInt(spec_dt.Rows[j]["id"].ToString(), 0);
                                    type_model.price = goods_model.price;
                                    type_model.stock = 100;
                                    new BLL.goods_spec_type().Add(type_model);
                                }
                            }
                        }
                    }
                }
            }
            AddAdminLog(EnumCollection.ActionEnum.Delete.ToString(), "删除规格"); //记录日志
            JscriptMsg("删除数据成功！", "goods_spec.aspx?page=" + this.page + "&goods_id=" + this.goods_id);
        }
    }
}