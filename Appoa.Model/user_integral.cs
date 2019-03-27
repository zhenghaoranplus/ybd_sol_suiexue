/*功能：生成实体类
 *编码日期:2017/6/21 14:47:45
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 积分记录实体类
    /// id:自增ID,user_id:用户ID,integral:积分值,get_or_use:获得或使用 1获得 2使用,type:积分类型,type_name:积分类型名称,add_time:操作时间,
    /// </summary>
	[Serializable]
    public partial class user_integral
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_integral()
        {
        }
		/// <summary>
        ///积分记录
        /// </summary>
		public const string TABLE_NAME = "ybd_user_integral";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,user_id,integral,get_or_use,type,type_name,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 用户ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 积分值
        /// </summary>
        public Int32 integral { get; set; }
        
		/// <summary>
        /// 获得或使用 1获得 2使用
        /// </summary>
        public Int32 get_or_use { get; set; }
        
		/// <summary>
        /// 积分类型
        /// </summary>
        public Int32 type { get; set; }
        
		/// <summary>
        /// 积分类型名称
        /// </summary>
        public String type_name { get; set; }
        
		/// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
        
        
        
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
        /// 积分值
        /// </summary>
		public const string FLD_integral="integral";        
		/// <summary>
        /// 积分值参数字段
        /// </summary>
		public const string FAR_integral="@integral";        
		
		/// <summary>
        /// 获得或使用 1获得 2使用
        /// </summary>
		public const string FLD_get_or_use="get_or_use";        
		/// <summary>
        /// 获得或使用 1获得 2使用参数字段
        /// </summary>
		public const string FAR_get_or_use="@get_or_use";        
		
		/// <summary>
        /// 积分类型
        /// </summary>
		public const string FLD_type="type";        
		/// <summary>
        /// 积分类型参数字段
        /// </summary>
		public const string FAR_type="@type";        
		
		/// <summary>
        /// 积分类型名称
        /// </summary>
		public const string FLD_type_name="type_name";        
		/// <summary>
        /// 积分类型名称参数字段
        /// </summary>
		public const string FAR_type_name="@type_name";        
		
		/// <summary>
        /// 操作时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 操作时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}