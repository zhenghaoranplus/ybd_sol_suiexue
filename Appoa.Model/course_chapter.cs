/*功能：生成实体类
 *编码日期:2017/7/10 9:25:46
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 课程章节实体类
    /// id:自增ID,group_id:分组,course_id:课程ID,name:名称,tag:标签,chapter_level:章节级别,parent_id:父级ID,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class course_chapter
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public course_chapter()
        {
        }
		/// <summary>
        ///课程章节
        /// </summary>
		public const string TABLE_NAME = "ybd_course_chapter";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,course_id,name,tag,chapter_level,parent_id,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 课程ID
        /// </summary>
        public Int32 course_id { get; set; }
        
		/// <summary>
        /// 名称
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 标签
        /// </summary>
        public String tag { get; set; }
        
		/// <summary>
        /// 章节级别
        /// </summary>
        public Int32 chapter_level { get; set; }
        
		/// <summary>
        /// 父级ID
        /// </summary>
        public Int32 parent_id { get; set; }
        
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
        /// 课程ID
        /// </summary>
		public const string FLD_course_id="course_id";        
		/// <summary>
        /// 课程ID参数字段
        /// </summary>
		public const string FAR_course_id="@course_id";        
		
		/// <summary>
        /// 名称
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 名称参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 标签
        /// </summary>
		public const string FLD_tag="tag";        
		/// <summary>
        /// 标签参数字段
        /// </summary>
		public const string FAR_tag="@tag";        
		
		/// <summary>
        /// 章节级别
        /// </summary>
		public const string FLD_chapter_level="chapter_level";        
		/// <summary>
        /// 章节级别参数字段
        /// </summary>
		public const string FAR_chapter_level="@chapter_level";        
		
		/// <summary>
        /// 父级ID
        /// </summary>
		public const string FLD_parent_id="parent_id";        
		/// <summary>
        /// 父级ID参数字段
        /// </summary>
		public const string FAR_parent_id="@parent_id";        
		
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