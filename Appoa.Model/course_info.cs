/*功能：生成实体类
 *编码日期:2017/7/20 14:51:23
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 课程信息实体类
    /// id:自增ID,group_id:分组ID 1公共资源 2学校资源,category_id:分类ID,name:名称,cover:封面图,info:简介,notice:公告,qrcode:二维码图片,qrcode_logo:二维码logo,user_id:发布者id,is_show:是否显示,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class course_info
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public course_info()
        {
        }
		/// <summary>
        ///课程信息
        /// </summary>
		public const string TABLE_NAME = "ybd_course_info";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,category_id,name,cover,info,notice,qrcode,qrcode_logo,user_id,is_show,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组ID 1公共资源 2学校资源
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 分类ID
        /// </summary>
        public Int32 category_id { get; set; }
        
		/// <summary>
        /// 名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String cover { get; set; }
        
		/// <summary>
        /// 简介
        /// </summary>
        public String info { get; set; }
        
		/// <summary>
        /// 公告
        /// </summary>
        public String notice { get; set; }
        
		/// <summary>
        /// 二维码图片
        /// </summary>
        public String qrcode { get; set; }
        
		/// <summary>
        /// 二维码logo
        /// </summary>
        public String qrcode_logo { get; set; }
        
		/// <summary>
        /// 发布者id
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 是否显示
        /// </summary>
        public Int32 is_show { get; set; }
        
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
        /// 分组ID 1公共资源 2学校资源
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID 1公共资源 2学校资源参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 分类ID
        /// </summary>
		public const string FLD_category_id="category_id";        
		/// <summary>
        /// 分类ID参数字段
        /// </summary>
		public const string FAR_category_id="@category_id";        
		
		/// <summary>
        /// 名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 封面图
        /// </summary>
		public const string FLD_cover="cover";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_cover="@cover";        
		
		/// <summary>
        /// 简介
        /// </summary>
		public const string FLD_info="info";        
		/// <summary>
        /// 简介参数字段
        /// </summary>
		public const string FAR_info="@info";        
		
		/// <summary>
        /// 公告
        /// </summary>
		public const string FLD_notice="notice";        
		/// <summary>
        /// 公告参数字段
        /// </summary>
		public const string FAR_notice="@notice";        
		
		/// <summary>
        /// 二维码图片
        /// </summary>
		public const string FLD_qrcode="qrcode";        
		/// <summary>
        /// 二维码图片参数字段
        /// </summary>
		public const string FAR_qrcode="@qrcode";        
		
		/// <summary>
        /// 二维码logo
        /// </summary>
		public const string FLD_qrcode_logo="qrcode_logo";        
		/// <summary>
        /// 二维码logo参数字段
        /// </summary>
		public const string FAR_qrcode_logo="@qrcode_logo";        
		
		/// <summary>
        /// 发布者id
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 发布者id参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 是否显示
        /// </summary>
		public const string FLD_is_show="is_show";        
		/// <summary>
        /// 是否显示参数字段
        /// </summary>
		public const string FAR_is_show="@is_show";        
		
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