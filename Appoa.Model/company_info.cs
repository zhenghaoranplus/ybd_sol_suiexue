/*功能：生成实体类
 *编码日期:2017/11/29 11:05:03
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 集团子公司信息实体类
    /// id:自增id,logo:logo,title:标题,img_url:封面图,video_thumb_img:视频缩略图,video_url:视频,about_us:关于我们,who_are_we_img:我们是谁左侧图,who_are_we:我们是谁文字,what_can_we_do:我们能做什么文字,what_can_we_do_img:我们能做什么右侧图,we_team_img:我们的团队左侧图,we_team:我们的团队文字,contact_us:联系我们,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class company_info
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public company_info()
        {
        }
		/// <summary>
        ///集团子公司信息
        /// </summary>
		public const string TABLE_NAME = "ybd_company_info";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,logo,title,img_url,video_thumb_img,video_url,about_us,who_are_we_img,who_are_we,what_can_we_do,what_can_we_do_img,we_team_img,we_team,contact_us,add_time";
        
		/// <summary>
        /// 自增id
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// logo
        /// </summary>
        public String logo { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String img_url { get; set; }
        
		/// <summary>
        /// 视频缩略图
        /// </summary>
        public String video_thumb_img { get; set; }
        
		/// <summary>
        /// 视频
        /// </summary>
        public String video_url { get; set; }
        
		/// <summary>
        /// 关于我们
        /// </summary>
        public String about_us { get; set; }
        
		/// <summary>
        /// 我们是谁左侧图
        /// </summary>
        public String who_are_we_img { get; set; }
        
		/// <summary>
        /// 我们是谁文字
        /// </summary>
        public String who_are_we { get; set; }
        
		/// <summary>
        /// 我们能做什么文字
        /// </summary>
        public String what_can_we_do { get; set; }
        
		/// <summary>
        /// 我们能做什么右侧图
        /// </summary>
        public String what_can_we_do_img { get; set; }
        
		/// <summary>
        /// 我们的团队左侧图
        /// </summary>
        public String we_team_img { get; set; }
        
		/// <summary>
        /// 我们的团队文字
        /// </summary>
        public String we_team { get; set; }
        
		/// <summary>
        /// 联系我们
        /// </summary>
        public String contact_us { get; set; }
        
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
        /// 封面图
        /// </summary>
		public const string FLD_img_url="img_url";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_img_url="@img_url";        
		
		/// <summary>
        /// 视频缩略图
        /// </summary>
		public const string FLD_video_thumb_img="video_thumb_img";        
		/// <summary>
        /// 视频缩略图参数字段
        /// </summary>
		public const string FAR_video_thumb_img="@video_thumb_img";        
		
		/// <summary>
        /// 视频
        /// </summary>
		public const string FLD_video_url="video_url";        
		/// <summary>
        /// 视频参数字段
        /// </summary>
		public const string FAR_video_url="@video_url";        
		
		/// <summary>
        /// 关于我们
        /// </summary>
		public const string FLD_about_us="about_us";        
		/// <summary>
        /// 关于我们参数字段
        /// </summary>
		public const string FAR_about_us="@about_us";        
		
		/// <summary>
        /// 我们是谁左侧图
        /// </summary>
		public const string FLD_who_are_we_img="who_are_we_img";        
		/// <summary>
        /// 我们是谁左侧图参数字段
        /// </summary>
		public const string FAR_who_are_we_img="@who_are_we_img";        
		
		/// <summary>
        /// 我们是谁文字
        /// </summary>
		public const string FLD_who_are_we="who_are_we";        
		/// <summary>
        /// 我们是谁文字参数字段
        /// </summary>
		public const string FAR_who_are_we="@who_are_we";        
		
		/// <summary>
        /// 我们能做什么文字
        /// </summary>
		public const string FLD_what_can_we_do="what_can_we_do";        
		/// <summary>
        /// 我们能做什么文字参数字段
        /// </summary>
		public const string FAR_what_can_we_do="@what_can_we_do";        
		
		/// <summary>
        /// 我们能做什么右侧图
        /// </summary>
		public const string FLD_what_can_we_do_img="what_can_we_do_img";        
		/// <summary>
        /// 我们能做什么右侧图参数字段
        /// </summary>
		public const string FAR_what_can_we_do_img="@what_can_we_do_img";        
		
		/// <summary>
        /// 我们的团队左侧图
        /// </summary>
		public const string FLD_we_team_img="we_team_img";        
		/// <summary>
        /// 我们的团队左侧图参数字段
        /// </summary>
		public const string FAR_we_team_img="@we_team_img";        
		
		/// <summary>
        /// 我们的团队文字
        /// </summary>
		public const string FLD_we_team="we_team";        
		/// <summary>
        /// 我们的团队文字参数字段
        /// </summary>
		public const string FAR_we_team="@we_team";        
		
		/// <summary>
        /// 联系我们
        /// </summary>
		public const string FLD_contact_us="contact_us";        
		/// <summary>
        /// 联系我们参数字段
        /// </summary>
		public const string FAR_contact_us="@contact_us";        
		
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