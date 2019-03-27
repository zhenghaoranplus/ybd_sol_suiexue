/*功能：生成实体类
 *编码日期:2017/9/7 15:18:44
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 资源信息实体类
    /// id:自增ID,from_id:归属 1微课 2课堂,group_id:分组ID,type:分类ID,school_id:学校ID,school_name:学校名称,data_id:数据关联ID,user_id:上传者,title:标题,cover:封面图,path:路径,qrcode:二维码,file_name:文件名,extend:扩展名,likn_url:链接,share_user:要分享给的用户ID,sort:排序,add_time:上传时间,is_del:是否删除,
    /// </summary>
	[Serializable]
    public partial class common_resource
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public common_resource()
        {
        }
		/// <summary>
        ///资源信息
        /// </summary>
		public const string TABLE_NAME = "ybd_common_resource";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,from_id,group_id,type,school_id,school_name,data_id,user_id,title,cover,path,qrcode,file_name,extend,likn_url,share_user,sort,add_time,is_del";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 归属 1微课 2课堂
        /// </summary>
        public Int32 from_id { get; set; }
        
		/// <summary>
        /// 分组ID
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 分类ID
        /// </summary>
        public Int32 type { get; set; }
        
		/// <summary>
        /// 学校ID
        /// </summary>
        public Int32 school_id { get; set; }
        
		/// <summary>
        /// 学校名称
        /// </summary>
        public String school_name { get; set; }
        
		/// <summary>
        /// 数据关联ID
        /// </summary>
        public Int32 data_id { get; set; }
        
		/// <summary>
        /// 上传者
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 标题
        /// </summary>
        public String title { get; set; }
        
		/// <summary>
        /// 封面图
        /// </summary>
        public String cover { get; set; }
        
		/// <summary>
        /// 路径
        /// </summary>
        public String path { get; set; }
        
		/// <summary>
        /// 二维码
        /// </summary>
        public String qrcode { get; set; }
        
		/// <summary>
        /// 文件名
        /// </summary>
        public String file_name { get; set; }
        
		/// <summary>
        /// 扩展名
        /// </summary>
        public String extend { get; set; }
        
		/// <summary>
        /// 链接
        /// </summary>
        public String likn_url { get; set; }
        
		/// <summary>
        /// 要分享给的用户ID
        /// </summary>
        public String share_user { get; set; }
        
		/// <summary>
        /// 排序
        /// </summary>
        public Int32 sort { get; set; }
        
		/// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? add_time { get; set; }
        
		/// <summary>
        /// 是否删除
        /// </summary>
        public Int32 is_del { get; set; }
        
        
        
        
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
        /// 归属 1微课 2课堂
        /// </summary>
		public const string FLD_from_id="from_id";        
		/// <summary>
        /// 归属 1微课 2课堂参数字段
        /// </summary>
		public const string FAR_from_id="@from_id";        
		
		/// <summary>
        /// 分组ID
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 分组ID参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 分类ID
        /// </summary>
		public const string FLD_type="type";        
		/// <summary>
        /// 分类ID参数字段
        /// </summary>
		public const string FAR_type="@type";        
		
		/// <summary>
        /// 学校ID
        /// </summary>
		public const string FLD_school_id="school_id";        
		/// <summary>
        /// 学校ID参数字段
        /// </summary>
		public const string FAR_school_id="@school_id";        
		
		/// <summary>
        /// 学校名称
        /// </summary>
		public const string FLD_school_name="school_name";        
		/// <summary>
        /// 学校名称参数字段
        /// </summary>
		public const string FAR_school_name="@school_name";        
		
		/// <summary>
        /// 数据关联ID
        /// </summary>
		public const string FLD_data_id="data_id";        
		/// <summary>
        /// 数据关联ID参数字段
        /// </summary>
		public const string FAR_data_id="@data_id";        
		
		/// <summary>
        /// 上传者
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 上传者参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
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
		public const string FLD_cover="cover";        
		/// <summary>
        /// 封面图参数字段
        /// </summary>
		public const string FAR_cover="@cover";        
		
		/// <summary>
        /// 路径
        /// </summary>
		public const string FLD_path="path";        
		/// <summary>
        /// 路径参数字段
        /// </summary>
		public const string FAR_path="@path";        
		
		/// <summary>
        /// 二维码
        /// </summary>
		public const string FLD_qrcode="qrcode";        
		/// <summary>
        /// 二维码参数字段
        /// </summary>
		public const string FAR_qrcode="@qrcode";        
		
		/// <summary>
        /// 文件名
        /// </summary>
		public const string FLD_file_name="file_name";        
		/// <summary>
        /// 文件名参数字段
        /// </summary>
		public const string FAR_file_name="@file_name";        
		
		/// <summary>
        /// 扩展名
        /// </summary>
		public const string FLD_extend="extend";        
		/// <summary>
        /// 扩展名参数字段
        /// </summary>
		public const string FAR_extend="@extend";        
		
		/// <summary>
        /// 链接
        /// </summary>
		public const string FLD_likn_url="likn_url";        
		/// <summary>
        /// 链接参数字段
        /// </summary>
		public const string FAR_likn_url="@likn_url";        
		
		/// <summary>
        /// 要分享给的用户ID
        /// </summary>
		public const string FLD_share_user="share_user";        
		/// <summary>
        /// 要分享给的用户ID参数字段
        /// </summary>
		public const string FAR_share_user="@share_user";        
		
		/// <summary>
        /// 排序
        /// </summary>
		public const string FLD_sort="sort";        
		/// <summary>
        /// 排序参数字段
        /// </summary>
		public const string FAR_sort="@sort";        
		
		/// <summary>
        /// 上传时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 上传时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
		/// <summary>
        /// 是否删除
        /// </summary>
		public const string FLD_is_del="is_del";        
		/// <summary>
        /// 是否删除参数字段
        /// </summary>
		public const string FAR_is_del="@is_del";        
		
        
        #endregion
    }
}