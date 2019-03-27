/*功能：生成实体类
 *编码日期:2017/7/19 9:30:54
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 用户阅读记录实体类
    /// id:自增ID,group_id:分组ID,data_id:数据ID,user_id:用户ID,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class user_readrecord
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_readrecord()
        {
        }
		/// <summary>
        ///用户阅读记录
        /// </summary>
		public const string TABLE_NAME = "ybd_user_readrecord";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,data_id,user_id,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 数据ID
        /// </summary>
        public Int32 data_id { get; set; }
        
		/// <summary>
        /// 用户ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 添加时间
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
        /// 分组ID
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 数据ID
        /// </summary>
		public const string FLD_data_id="data_id";        
		/// <summary>
        /// 数据ID参数字段
        /// </summary>
		public const string FAR_data_id="@data_id";        
		
		/// <summary>
        /// 用户ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 用户ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 添加时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 添加时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}