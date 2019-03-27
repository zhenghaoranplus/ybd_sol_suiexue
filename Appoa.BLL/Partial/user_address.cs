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
    /// 收货地址业务逻辑类
    /// </summary>
    public partial class user_address
    {
        public bool SetDefault(int user_id, int aid)
        {
            return dal.SetDefault(user_id,aid);
        }
    }
}