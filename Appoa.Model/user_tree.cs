/*功能：生成实体类
 *编码日期:2017/7/20 8:50:22
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 用户关系实体类
    /// id:自增ID,user_id:用户ID,code:唯一标识code,parent_code:父级code,grand_code:父级的父级code,
    /// </summary>
	[Serializable]
    public partial class user_tree
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_tree()
        {
        }
		/// <summary>
        ///用户关系
        /// </summary>
		public const string TABLE_NAME = "ybd_user_tree";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,user_id,code,parent_code,grand_code";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 用户ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 唯一标识code
        /// </summary>
        public String code { get; set; }
        
		/// <summary>
        /// 父级code
        /// </summary>
        public String parent_code { get; set; }
        
		/// <summary>
        /// 父级的父级code
        /// </summary>
        public String grand_code { get; set; }
        
        
        
        
        #region extended
		/// <summary>
        /// 自增ID
        /// </summary>
		public const string FLD_id="id";        
		/// <summary>
        /// 自增ID参数字段
        /// </summary>
		public const string FAR_id="@id";        
		
		/// <summary>
        /// 用户ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 用户ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 唯一标识code
        /// </summary>
		public const string FLD_code="code";        
		/// <summary>
        /// 唯一标识code参数字段
        /// </summary>
		public const string FAR_code="@code";        
		
		/// <summary>
        /// 父级code
        /// </summary>
		public const string FLD_parent_code="parent_code";        
		/// <summary>
        /// 父级code参数字段
        /// </summary>
		public const string FAR_parent_code="@parent_code";        
		
		/// <summary>
        /// 父级的父级code
        /// </summary>
		public const string FLD_grand_code="grand_code";        
		/// <summary>
        /// 父级的父级code参数字段
        /// </summary>
		public const string FAR_grand_code="@grand_code";        
		
        
        #endregion
    }
}