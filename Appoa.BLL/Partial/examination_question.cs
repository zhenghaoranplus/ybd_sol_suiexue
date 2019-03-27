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
    /// 试卷题目关联业务逻辑类
    /// </summary>
    public partial class examination_question
    {
        public DataTable GetQuestionByExa(string whereStr)
        {
            return dal.GetQuestionByExa(whereStr).Tables[0];
        }

        public bool Delete(string whereStr)
        {
            return dal.Delete(whereStr);
        }

        public int GetSumCount(string field, string viewname, string where)
        {
            return dal.GetSumCount(field, viewname, where);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string viewname, string whereStr)
        {
            return dal.GetRecordCount(viewname, whereStr);
        }

        public DataTable GetViewList(string viewname, string whereStr)
        {
            return dal.GetViewList(viewname, whereStr).Tables[0];
        }
    }
}