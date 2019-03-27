/*功能：生成实体类
 *编码日期:2017/6/21 14:47:42
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 广告位与数据对应实体类
    /// id:自增ID,ad_group_id:广告分组id,ad_group_name:广告分组名称,ad_type_id:广告类型id,ad_type_name:广告类型name,ad_data_id:广告数据id,ad_data_title:广告数据标题,ad_data_subtitle:广告数据副标题,ad_data_img:广告数据图片,ad_data_url:广告位链接,ad_sort_id:排序,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_adR
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_adR()
        {
        }
		/// <summary>
        ///广告位与数据对应
        /// </summary>
		public const string TABLE_NAME = "ybd_common_adR";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,ad_group_id,ad_group_name,ad_type_id,ad_type_name,ad_data_id,ad_data_title,ad_data_subtitle,ad_data_img,ad_data_url,ad_sort_id,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 广告分组id
        /// </summary>
        public Int32 ad_group_id { get; set; }
        
		/// <summary>
        /// 广告分组名称
        /// </summary>
        public String ad_group_name { get; set; }
        
		/// <summary>
        /// 广告类型id
        /// </summary>
        public Int32 ad_type_id { get; set; }
        
		/// <summary>
        /// 广告类型name
        /// </summary>
        public String ad_type_name { get; set; }
        
		/// <summary>
        /// 广告数据id
        /// </summary>
        public Int32 ad_data_id { get; set; }
        
		/// <summary>
        /// 广告数据标题
        /// </summary>
        public String ad_data_title { get; set; }
        
		/// <summary>
        /// 广告数据副标题
        /// </summary>
        public String ad_data_subtitle { get; set; }
        
		/// <summary>
        /// 广告数据图片
        /// </summary>
        public String ad_data_img { get; set; }
        
		/// <summary>
        /// 广告位链接
        /// </summary>
        public String ad_data_url { get; set; }
        
		/// <summary>
        /// 排序
        /// </summary>
        public Int32 ad_sort_id { get; set; }
        
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
        /// 广告分组id
        /// </summary>
		public const string FLD_ad_group_id="ad_group_id";        
		/// <summary>
        /// 广告分组id参数字段
        /// </summary>
		public const string FAR_ad_group_id="@ad_group_id";        
		
		/// <summary>
        /// 广告分组名称
        /// </summary>
		public const string FLD_ad_group_name="ad_group_name";        
		/// <summary>
        /// 广告分组名称参数字段
        /// </summary>
		public const string FAR_ad_group_name="@ad_group_name";        
		
		/// <summary>
        /// 广告类型id
        /// </summary>
		public const string FLD_ad_type_id="ad_type_id";        
		/// <summary>
        /// 广告类型id参数字段
        /// </summary>
		public const string FAR_ad_type_id="@ad_type_id";        
		
		/// <summary>
        /// 广告类型name
        /// </summary>
		public const string FLD_ad_type_name="ad_type_name";        
		/// <summary>
        /// 广告类型name参数字段
        /// </summary>
		public const string FAR_ad_type_name="@ad_type_name";        
		
		/// <summary>
        /// 广告数据id
        /// </summary>
		public const string FLD_ad_data_id="ad_data_id";        
		/// <summary>
        /// 广告数据id参数字段
        /// </summary>
		public const string FAR_ad_data_id="@ad_data_id";        
		
		/// <summary>
        /// 广告数据标题
        /// </summary>
		public const string FLD_ad_data_title="ad_data_title";        
		/// <summary>
        /// 广告数据标题参数字段
        /// </summary>
		public const string FAR_ad_data_title="@ad_data_title";        
		
		/// <summary>
        /// 广告数据副标题
        /// </summary>
		public const string FLD_ad_data_subtitle="ad_data_subtitle";        
		/// <summary>
        /// 广告数据副标题参数字段
        /// </summary>
		public const string FAR_ad_data_subtitle="@ad_data_subtitle";        
		
		/// <summary>
        /// 广告数据图片
        /// </summary>
		public const string FLD_ad_data_img="ad_data_img";        
		/// <summary>
        /// 广告数据图片参数字段
        /// </summary>
		public const string FAR_ad_data_img="@ad_data_img";        
		
		/// <summary>
        /// 广告位链接
        /// </summary>
		public const string FLD_ad_data_url="ad_data_url";        
		/// <summary>
        /// 广告位链接参数字段
        /// </summary>
		public const string FAR_ad_data_url="@ad_data_url";        
		
		/// <summary>
        /// 排序
        /// </summary>
		public const string FLD_ad_sort_id="ad_sort_id";        
		/// <summary>
        /// 排序参数字段
        /// </summary>
		public const string FAR_ad_sort_id="@ad_sort_id";        
		
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