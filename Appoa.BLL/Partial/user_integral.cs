﻿/*功能：生成实体类
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
    /// 积分记录业务逻辑类
    /// </summary>
    public partial class user_integral
    {
        public int GetRecordSum(string field, string whereStr)
        {
            return dal.GetRecordSum(field, whereStr);
        }
    }
}