/*功能：生成实体类
 *编码日期:2017/6/21 16:35:50
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
    /// 用户收藏业务逻辑类
    /// </summary>
    public partial class user_collection
    {
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteListByWhere(string whereStr)
        {
            return dal.DeleteListByWhere(whereStr);
        }
    }
}