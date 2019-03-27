/*功能：生成实体类
 *编码日期:2017/6/21 14:47:44
 *编码人：阴华伟
 *QQ:577372287
 */
using System;

namespace Appoa.Model
{
    /// <summary>
    /// 收货地址实体类
    /// id:自增ID,type:地址类型id,type_name:地址类型名称,user_id:用户id,name:收货人姓名,mobile:手机号,tel:联系电话,sheng:省,shi:市,xian:区县,area:区域,address:详细地址,postcode:邮政编码,IDCard:身份证号,is_default:是否是默认地址,add_time:添加时间,
    /// </summary>
	[Serializable]
    public partial class user_address
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public user_address()
        {
        }
		/// <summary>
        ///收货地址
        /// </summary>
		public const string TABLE_NAME = "ybd_user_address";        
        /// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL_FILED = "id,type,type_name,user_id,name,mobile,tel,sheng,shi,xian,area,address,postcode,IDCard,is_default,add_time";
        
		/// <summary>
        /// 自增ID
        /// </summary>
        public Int32 id { get; set; }
        
		/// <summary>
        /// 地址类型id
        /// </summary>
        public Int32 type { get; set; }
        
		/// <summary>
        /// 地址类型名称
        /// </summary>
        public String type_name { get; set; }
        
		/// <summary>
        /// 用户id
        /// </summary>
        public Int32 user_id { get; set; }
        
		/// <summary>
        /// 收货人姓名
        /// </summary>
        public String name { get; set; }
        
		/// <summary>
        /// 手机号
        /// </summary>
        public String mobile { get; set; }
        
		/// <summary>
        /// 联系电话
        /// </summary>
        public String tel { get; set; }
        
		/// <summary>
        /// 省
        /// </summary>
        public String sheng { get; set; }
        
		/// <summary>
        /// 市
        /// </summary>
        public String shi { get; set; }
        
		/// <summary>
        /// 区县
        /// </summary>
        public String xian { get; set; }
        
		/// <summary>
        /// 区域
        /// </summary>
        public String area { get; set; }
        
		/// <summary>
        /// 详细地址
        /// </summary>
        public String address { get; set; }
        
		/// <summary>
        /// 邮政编码
        /// </summary>
        public String postcode { get; set; }
        
		/// <summary>
        /// 身份证号
        /// </summary>
        public String IDCard { get; set; }
        
		/// <summary>
        /// 是否是默认地址
        /// </summary>
        public Int32 is_default { get; set; }
        
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
        /// 地址类型id
        /// </summary>
		public const string FLD_type="type";        
		/// <summary>
        /// 地址类型id参数字段
        /// </summary>
		public const string FAR_type="@type";        
		
		/// <summary>
        /// 地址类型名称
        /// </summary>
		public const string FLD_type_name="type_name";        
		/// <summary>
        /// 地址类型名称参数字段
        /// </summary>
		public const string FAR_type_name="@type_name";        
		
		/// <summary>
        /// 用户id
        /// </summary>
		public const string FLD_user_id="user_id";        
		/// <summary>
        /// 用户id参数字段
        /// </summary>
		public const string FAR_user_id="@user_id";        
		
		/// <summary>
        /// 收货人姓名
        /// </summary>
		public const string FLD_name="name";        
		/// <summary>
        /// 收货人姓名参数字段
        /// </summary>
		public const string FAR_name="@name";        
		
		/// <summary>
        /// 手机号
        /// </summary>
		public const string FLD_mobile="mobile";        
		/// <summary>
        /// 手机号参数字段
        /// </summary>
		public const string FAR_mobile="@mobile";        
		
		/// <summary>
        /// 联系电话
        /// </summary>
		public const string FLD_tel="tel";        
		/// <summary>
        /// 联系电话参数字段
        /// </summary>
		public const string FAR_tel="@tel";        
		
		/// <summary>
        /// 省
        /// </summary>
		public const string FLD_sheng="sheng";        
		/// <summary>
        /// 省参数字段
        /// </summary>
		public const string FAR_sheng="@sheng";        
		
		/// <summary>
        /// 市
        /// </summary>
		public const string FLD_shi="shi";        
		/// <summary>
        /// 市参数字段
        /// </summary>
		public const string FAR_shi="@shi";        
		
		/// <summary>
        /// 区县
        /// </summary>
		public const string FLD_xian="xian";        
		/// <summary>
        /// 区县参数字段
        /// </summary>
		public const string FAR_xian="@xian";        
		
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
        /// 邮政编码
        /// </summary>
		public const string FLD_postcode="postcode";        
		/// <summary>
        /// 邮政编码参数字段
        /// </summary>
		public const string FAR_postcode="@postcode";        
		
		/// <summary>
        /// 身份证号
        /// </summary>
		public const string FLD_IDCard="IDCard";        
		/// <summary>
        /// 身份证号参数字段
        /// </summary>
		public const string FAR_IDCard="@IDCard";        
		
		/// <summary>
        /// 是否是默认地址
        /// </summary>
		public const string FLD_is_default="is_default";        
		/// <summary>
        /// 是否是默认地址参数字段
        /// </summary>
		public const string FAR_is_default="@is_default";        
		
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