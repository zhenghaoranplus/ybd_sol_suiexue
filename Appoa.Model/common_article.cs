/*功能：生成实体类
 *编码日期:2017/6/21 14:47:42
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 全局文章实体类
    /// id:自增ID,group_id:分组,user_id:发布者id,category_id:分类id,title:标题,subtitle:副标题,contents:内容,img_src:封面图,click:点击量,upvote:点赞数,status:审核状态,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class common_article
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_article()
        {
        }
		/// <summary>
        ///全局文章
        /// </summary>
		public const string TABLE_NAME = "ybd_common_article";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,user_id,category_id,title,subtitle,contents,img_src,click,upvote,status,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 发布者id
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 分类id
        /// </summary>
        public Int32 category_id { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
        public String subtitle { get; set; }
        
		/// <summary>
        /// 内容
        /// </summary>
        public String contents { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String img_src { get; set; }
        
		/// <summary>
        /// 点击量
        /// </summary>
        public Int32 click { get; set; }
        
		/// <summary>
        /// 点赞数
        /// </summary>
        public Int32 upvote { get; set; }
        
		/// <summary>
        /// 审核状态
        /// </summary>
        public Int32 status { get; set; }
        
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
        /// 分组
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 发布者id
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 发布者id参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 分类id
        /// </summary>
		public const string FLD_category_id="category_id";        
		/// <summary>
        /// 分类id参数字段
        /// </summary>
		public const string FAR_category_id="@category_id";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_title="title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_title="@title";        
		
		/// <summary>
        /// 副标题
        /// </summary>
		public const string FLD_subtitle="subtitle";        
		/// <summary>
        /// 副标题参数字段
        /// </summary>
		public const string FAR_subtitle="@subtitle";        
		
		/// <summary>
        /// 内容
        /// </summary>
		public const string FLD_contents="contents";        
		/// <summary>
        /// 内容参数字段
        /// </summary>
		public const string FAR_contents="@contents";        
		
		/// <summary>
        /// 封面图
        /// </summary>
		public const string FLD_img_src="img_src";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_img_src="@img_src";        
		
		/// <summary>
        /// 点击量
        /// </summary>
		public const string FLD_click="click";        
		/// <summary>
        /// 点击量参数字段
        /// </summary>
		public const string FAR_click="@click";        
		
		/// <summary>
        /// 点赞数
        /// </summary>
		public const string FLD_upvote="upvote";        
		/// <summary>
        /// 点赞数参数字段
        /// </summary>
		public const string FAR_upvote="@upvote";        
		
		/// <summary>
        /// 审核状态
        /// </summary>
		public const string FLD_status="status";        
		/// <summary>
        /// 审核状态参数字段
        /// </summary>
		public const string FAR_status="@status";        
		
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