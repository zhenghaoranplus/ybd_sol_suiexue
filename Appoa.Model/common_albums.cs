/*功能：生成实体类
 *编码日期:2017/10/17 13:49:55
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 全局相册实体类
    /// id:自增id,group_id:分组id,rc_title:标题,rc_type:关联内容分类id,rc_data_id:关联内容数据ID,thumb_path:缩略图地址,original_path:原图地址,remark:图片描述,add_time:上传时间,
    /// </summary>
	[Serializable]
    public partial class common_albums
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_albums()
        {
        }
		/// <summary>
        ///全局相册
        /// </summary>
		public const string TABLE_NAME = "ybd_common_albums";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,rc_title,rc_type,rc_data_id,thumb_path,original_path,remark,add_time";
        
		/// <summary>
        /// 自增id
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 分组id
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String rc_title { get; set; }
        
		/// <summary>
        /// 关联内容分类id
        /// </summary>
        public Int32 rc_type { get; set; }
        
		/// <summary>
        /// 关联内容数据ID
        /// </summary>
        public Int32 rc_data_id { get; set; }
        
		/// <summary>
        /// 缩略图地址
        /// </summary>
        public String thumb_path { get; set; }
        
		/// <summary>
        /// 原图地址
        /// </summary>
        public String original_path { get; set; }
        
		/// <summary>
        /// 图片描述
        /// </summary>
        public String remark { get; set; }
        
		/// <summary>
        /// 上传时间
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
        /// 分组id
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组id参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 标题
        /// </summary>
		public const string FLD_rc_title="rc_title";        
		/// <summary>
        /// 标题参数字段
        /// </summary>
		public const string FAR_rc_title="@rc_title";        
		
		/// <summary>
        /// 关联内容分类id
        /// </summary>
		public const string FLD_rc_type="rc_type";        
		/// <summary>
        /// 关联内容分类id参数字段
        /// </summary>
		public const string FAR_rc_type="@rc_type";        
		
		/// <summary>
        /// 关联内容数据ID
        /// </summary>
		public const string FLD_rc_data_id="rc_data_id";        
		/// <summary>
        /// 关联内容数据ID参数字段
        /// </summary>
		public const string FAR_rc_data_id="@rc_data_id";        
		
		/// <summary>
        /// 缩略图地址
        /// </summary>
		public const string FLD_thumb_path="thumb_path";        
		/// <summary>
        /// 缩略图地址参数字段
        /// </summary>
		public const string FAR_thumb_path="@thumb_path";        
		
		/// <summary>
        /// 原图地址
        /// </summary>
		public const string FLD_original_path="original_path";        
		/// <summary>
        /// 原图地址参数字段
        /// </summary>
		public const string FAR_original_path="@original_path";        
		
		/// <summary>
        /// 图片描述
        /// </summary>
		public const string FLD_remark="remark";        
		/// <summary>
        /// 图片描述参数字段
        /// </summary>
		public const string FAR_remark="@remark";        
		
		/// <summary>
        /// 上传时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 上传时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}