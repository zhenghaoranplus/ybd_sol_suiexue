/*功能：生成实体类
 *编码日期:2017/6/21 16:35:48
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
    /// 试卷信息业务逻辑类
    /// </summary>
    public partial class common_examination
    {
        /// <summary>
        /// 查询我的错题试卷
        /// </summary>
        /// <returns></returns>
        public DataTable GetMyQuestionByPage(int userid, string orderby, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return dal.GetMyQuestionByPage(userid, orderby, startIndex, endIndex).Tables[0];
        }
    }
}