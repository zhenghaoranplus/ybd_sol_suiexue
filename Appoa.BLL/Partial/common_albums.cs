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
    /// 全局相册业务逻辑类
    /// </summary>
    public partial class common_albums
    {
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere)
        {
            return dal.Delete(strWhere);
        }
    }
}