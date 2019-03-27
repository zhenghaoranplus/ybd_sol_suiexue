/*功能：生成实体类
 *编码日期:2017/10/18 16:06:34
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 合作伙伴实体类
    /// id:自增id,company_id:公司id,logo:logo,title:标题,video_url:视频地址,video_thumb_img:视频缩略图地址,details:案例详情,is_show:是否显示,sort:排序,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class company_partner
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public company_partner()
        {
        }
		/// <summary>
        ///合作伙伴
        /// </summary>
		public const string TABLE_NAME = "ybd_company_partner";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,company_id,logo,title,video_url,video_thumb_img,details,is_show,sort,add_time";
        
		/// <summary>
        /// 自增id
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 公司id
        /// </summary>
        public Int32 company_id { get; set; }
        
		/// <summary>
        /// logo
        /// </summary>
        public String logo { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 视频地址
        /// </summary>
        public String video_url { get; set; }
        
		/// <summary>
        /// 视频缩略图地址
        /// </summary>
        public String video_thumb_img { get; set; }
        
		/// <summary>
        /// 案例详情
        /// </summary>
        public String details { get; set; }
        
		/// <summary>
        /// 是否显示
        /// </summary>
        public Int32 is_show { get; set; }
        
		/// <summary>
        /// 排序
        /// </summary>
        public Int32 sort { get; set; }
        
		/// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
        
        
        
        #region extended
		/// <summary>
        /// 自增id
        /// </summary>
		public const string FLD_id="id";        
		/// <summary>
        /// 自增id参数字段
        /// </summary>
		public const string FAR_id="@id";        
		
		/// <summary>
        /// 公司id
        /// </summary>
		public const string FLD_company_id="company_id";        
		/// <summary>
        /// 公司id参数字段
        /// </summary>
		public const string FAR_company_id="@company_id";        
		
		/// <summary>
        /// logo
        /// </summary>
		public const string FLD_logo="logo";        
		/// <summary>
        /// logo参数字段
        /// </summary>
		public const string FAR_logo="@logo";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_title="title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_title="@title";        
		
		/// <summary>
        /// 视频地址
        /// </summary>
		public const string FLD_video_url="video_url";        
		/// <summary>
        /// 视频地址参数字段
        /// </summary>
		public const string FAR_video_url="@video_url";        
		
		/// <summary>
        /// 视频缩略图地址
        /// </summary>
		public const string FLD_video_thumb_img="video_thumb_img";        
		/// <summary>
        /// 视频缩略图地址参数字段
        /// </summary>
		public const string FAR_video_thumb_img="@video_thumb_img";        
		
		/// <summary>
        /// 案例详情
        /// </summary>
		public const string FLD_details="details";        
		/// <summary>
        /// 案例详情参数字段
        /// </summary>
		public const string FAR_details="@details";        
		
		/// <summary>
        /// 是否显示
        /// </summary>
		public const string FLD_is_show="is_show";        
		/// <summary>
        /// 是否显示参数字段
        /// </summary>
		public const string FAR_is_show="@is_show";        
		
		/// <summary>
        /// 排序
        /// </summary>
		public const string FLD_sort="sort";        
		/// <summary>
        /// 排序参数字段
        /// </summary>
		public const string FAR_sort="@sort";        
		
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