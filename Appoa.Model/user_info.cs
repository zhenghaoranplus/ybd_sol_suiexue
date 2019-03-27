/*功能：生成实体类
 *编码日期:2017/7/12 11:42:38
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 用户信息实体类
    /// id:自增ID,group_id:用户分组,user_name:用户名,phone:手机号,salt:随机加密字符串,user_pwd:密码,nick_name:昵称,avatar:头像,integral:积分,school_id:学校ID,school_name:学校姓名,college:院系,job:职位,course:所授课程,line_way:联系方式,area:区域,address:详细地址,reg_ip:注册IP,add_time:注册时间,
    /// </summary>
	[Serializable]
    public partial class user_info
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_info()
        {
        }
		/// <summary>
        ///用户信息
        /// </summary>
		public const string TABLE_NAME = "ybd_user_info";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,group_id,user_name,phone,salt,user_pwd,nick_name,avatar,integral,school_id,school_name,college,job,course,line_way,area,address,reg_ip,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 用户分组
        /// </summary>
        public Int32 group_id { get; set; }
        
		/// <summary>
        /// 用户名
        /// </summary>
        public String user_name { get; set; }
        
		/// <summary>
        /// 手机号
        /// </summary>
        public String phone { get; set; }
        
		/// <summary>
        /// 随机加密字符串
        /// </summary>
        public String salt { get; set; }
        
		/// <summary>
        /// 密码
        /// </summary>
        public String user_pwd { get; set; }
        
		/// <summary>
        /// 昵称
        /// </summary>
        public String nick_name { get; set; }
        
		/// <summary>
        /// 头像
        /// </summary>
        public String avatar { get; set; }
        
		/// <summary>
        /// 积分
        /// </summary>
        public Int32 integral { get; set; }
        
		/// <summary>
        /// 学校ID
        /// </summary>
        public Int32 school_id { get; set; }
        
		/// <summary>
        /// 学校姓名
        /// </summary>
        public String school_name { get; set; }
        
		/// <summary>
        /// 院系
        /// </summary>
        public String college { get; set; }
        
		/// <summary>
        /// 职位
        /// </summary>
        public String job { get; set; }
        
		/// <summary>
        /// 所授课程
        /// </summary>
        public String course { get; set; }
        
		/// <summary>
        /// 联系方式
        /// </summary>
        public String line_way { get; set; }
        
		/// <summary>
        /// 区域
        /// </summary>
        public String area { get; set; }
        
		/// <summary>
        /// 详细地址
        /// </summary>
        public String address { get; set; }
        
		/// <summary>
        /// 注册IP
        /// </summary>
        public String reg_ip { get; set; }
        
		/// <summary>
        /// 注册时间
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
        /// 用户分组
        /// </summary>
		public const string FLD_group_id="group_id";        
		/// <summary>
        /// 用户分组参数字段
        /// </summary>
		public const string FAR_group_id="@group_id";        
		
		/// <summary>
        /// 用户名
        /// </summary>
		public const string FLD_user_name="user_name";        
		/// <summary>
        /// 用户名参数字段
        /// </summary>
		public const string FAR_user_name="@user_name";        
		
		/// <summary>
        /// 手机号
        /// </summary>
		public const string FLD_phone="phone";        
		/// <summary>
        /// 手机号参数字段
        /// </summary>
		public const string FAR_phone="@phone";        
		
		/// <summary>
        /// 随机加密字符串
        /// </summary>
		public const string FLD_salt="salt";        
		/// <summary>
        /// 随机加密字符串参数字段
        /// </summary>
		public const string FAR_salt="@salt";        
		
		/// <summary>
        /// 密码
        /// </summary>
		public const string FLD_user_pwd="user_pwd";        
		/// <summary>
        /// 密码参数字段
        /// </summary>
		public const string FAR_user_pwd="@user_pwd";        
		
		/// <summary>
        /// 昵称
        /// </summary>
		public const string FLD_nick_name="nick_name";        
		/// <summary>
        /// 昵称参数字段
        /// </summary>
		public const string FAR_nick_name="@nick_name";        
		
		/// <summary>
        /// 头像
        /// </summary>
		public const string FLD_avatar="avatar";        
		/// <summary>
        /// 头像参数字段
        /// </summary>
		public const string FAR_avatar="@avatar";        
		
		/// <summary>
        /// 积分
        /// </summary>
		public const string FLD_integral="integral";        
		/// <summary>
        /// 积分参数字段
        /// </summary>
		public const string FAR_integral="@integral";        
		
		/// <summary>
        /// 学校ID
        /// </summary>
		public const string FLD_school_id="school_id";        
		/// <summary>
        /// 学校ID参数字段
        /// </summary>
		public const string FAR_school_id="@school_id";        
		
		/// <summary>
        /// 学校姓名
        /// </summary>
		public const string FLD_school_name="school_name";        
		/// <summary>
        /// 学校姓名参数字段
        /// </summary>
		public const string FAR_school_name="@school_name";        
		
		/// <summary>
        /// 院系
        /// </summary>
		public const string FLD_college="college";        
		/// <summary>
        /// 院系参数字段
        /// </summary>
		public const string FAR_college="@college";        
		
		/// <summary>
        /// 职位
        /// </summary>
		public const string FLD_job="job";        
		/// <summary>
        /// 职位参数字段
        /// </summary>
		public const string FAR_job="@job";        
		
		/// <summary>
        /// 所授课程
        /// </summary>
		public const string FLD_course="course";        
		/// <summary>
        /// 所授课程参数字段
        /// </summary>
		public const string FAR_course="@course";        
		
		/// <summary>
        /// 联系方式
        /// </summary>
		public const string FLD_line_way="line_way";        
		/// <summary>
        /// 联系方式参数字段
        /// </summary>
		public const string FAR_line_way="@line_way";        
		
		/// <summary>
        /// 区域
        /// </summary>
		public const string FLD_area="area";        
		/// <summary>
        /// 区域参数字段
        /// </summary>
		public const string FAR_area="@area";        
		
		/// <summary>
        /// 详细地址
        /// </summary>
		public const string FLD_address="address";        
		/// <summary>
        /// 详细地址参数字段
        /// </summary>
		public const string FAR_address="@address";        
		
		/// <summary>
        /// 注册IP
        /// </summary>
		public const string FLD_reg_ip="reg_ip";        
		/// <summary>
        /// 注册IP参数字段
        /// </summary>
		public const string FAR_reg_ip="@reg_ip";        
		
		/// <summary>
        /// 注册时间
        /// </summary>
		public const string FLD_add_time="add_time";        
		/// <summary>
        /// 注册时间参数字段
        /// </summary>
		public const string FAR_add_time="@add_time";        
		
        
        #endregion
    }
}