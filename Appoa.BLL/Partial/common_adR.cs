/*功能：生成实体类
 *编码日期:2017/6/21 16:35:47
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
    /// 广告位与数据对应业务逻辑类
    /// </summary>
    public partial class common_adR
    {
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string viewname, string whereStr)
        {
            return dal.GetRecordCount(viewname, whereStr);
        }
    }
}