/*功能：生成实体类
 *编码日期:2017/6/21 16:35:49
 *编码人：阴华伟
 *QQ:508955560
 */
using System;
using System.Data;
using System.Collections.Generic;
using Appoa.Common;

namespace Appoa.BLL
{
    /// <summary>
    /// 商品规格项业务逻辑类
    /// </summary>
    public partial class goods_spec_item
    {
        /// <summary>
        /// 根据父级分类id查询分类
        /// </summary>
        public DataTable GetListByParentId(int goodsid, int parentid)
        {
            return dal.GetListByParentId(goodsid, parentid).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListNew(string goodsId)
        {
            return dal.GetListNew(goodsId);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteNew(int id)
        {
            Model.goods_spec_item item_model = new BLL.goods_spec_item().GetModel(id);
            if (item_model != null)
            {
                if (item_model.parent_id == 0)
                {
                    DataTable dt = new BLL.goods_spec_item().GetList("parent_id=" + item_model.id.ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dal.DeleteNew(Utils.StrToInt(dt.Rows[i]["id"].ToString(), 0));
                    }
                }
            }
            return dal.DeleteNew(id);
        }

        public bool UpdateField(int id, string field)
        {
            return dal.UpdateField(id, field);
        }
    }
}