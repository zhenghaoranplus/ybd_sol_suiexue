/*功能：生成实体类
 *编码日期:2017/8/17 16:19:50
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 课堂信息实体类
    /// id:自增ID,name:课堂名称,avatar:课堂头像/背景图,user_id:创建者ID,user_name:创建者姓名,info:课堂简介,qrcode:课堂二维码,is_show:是否公开,add_time:创建时间,
    /// </summary>
	[Serializable]
    public partial class classroom_info
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public classroom_info()
        {
        }
		/// <summary>
        ///课堂信息
        /// </summary>
		public const string TABLE_NAME = "ybd_classroom_info";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,name,avatar,user_id,user_name,info,qrcode,is_show,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 课堂名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 课堂头像/背景图
        /// </summary>
        public String avatar { get; set; }
        
		/// <summary>
        /// 创建者ID
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 创建者姓名
        /// </summary>
        public String user_name { get; set; }
        
		/// <summary>
        /// 课堂简介
        /// </summary>
        public String info { get; set; }
        
		/// <summary>
        /// 课堂二维码
        /// </summary>
        public String qrcode { get; set; }
        
		/// <summary>
        /// 是否公开
        /// </summary>
        public Int32 is_show { get; set; }
        
		/// <summary>
        /// 创建时间
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
        /// 课堂名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 课堂名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 课堂头像/背景图
        /// </summary>
		public const string FLD_avatar="avatar";        
		/// <summary>
        /// 课堂头像/背景图参数字段
        /// </summary>
		public const string FAR_avatar="@avatar";        
		
		/// <summary>
        /// 创建者ID
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 创建者ID参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 创建者姓名
        /// </summary>
		public const string FLD_user_name="user_name";        
		/// <summary>
        /// 创建者姓名参数字段
        /// </summary>
		public const string FAR_user_name="@user_name";        
		
		/// <summary>
        /// 课堂简介
        /// </summary>
		public const string FLD_info="info";        
		/// <summary>
        /// 课堂简介参数字段
        /// </summary>
		public const string FAR_info="@info";        
		
		/// <summary>
        /// 课堂二维码
        /// </summary>
		public const string FLD_qrcode="qrcode";        
		/// <summary>
        /// 课堂二维码参数字段
        /// </summary>
		public const string FAR_qrcode="@qrcode";        
		
		/// <summary>
        /// 是否公开
        /// </summary>
		public const string FLD_is_show="is_show";        
		/// <summary>
        /// 是否公开参数字段
        /// </summary>
		public const string FAR_is_show="@is_show";        
		
		/// <summary>
        /// 创建时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 创建时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}