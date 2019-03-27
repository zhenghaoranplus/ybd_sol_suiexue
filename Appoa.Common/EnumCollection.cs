using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace Appoa.Common
{
    public class EnumCollection
    {
        #region 后台枚举
        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        public enum ActionEnum
        {
            /// <summary>
            /// 所有
            /// </summary>
            All,
            /// <summary>
            /// 管理
            /// </summary>
            Manage,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 修改
            /// </summary>
            Modify,
            /// <summary>
            /// 修改2
            /// </summary>
            //Edit,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 审核
            /// </summary>
            Audit,
            /// <summary>
            /// 回复
            /// </summary>
            Reply,
            /// <summary>
            /// 确认
            /// </summary>
            Confirm,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel,
            /// <summary>
            /// 作废
            /// </summary>
            Invalid,
            /// <summary>
            /// 生成
            /// </summary>
            Build,
            /// <summary>
            /// 安装
            /// </summary>
            Instal,
            /// <summary>
            /// 卸载
            /// </summary>
            UnLoad,
            /// <summary>
            /// 登录
            /// </summary>
            Login,
            /// <summary>
            /// 备份
            /// </summary>
            Back,
            /// <summary>
            /// 还原
            /// </summary>
            Restore,
            /// <summary>
            /// 替换
            /// </summary>
            Replace,
            /// <summary>
            /// 复制
            /// </summary>
            Copy

        }

        /// <summary>
        /// 系统导航菜单类别枚举
        /// </summary>
        public enum NavigationEnum
        {
            /// <summary>
            /// 系统后台菜单
            /// </summary>
            System,
            /// <summary>
            /// 会员中心导航
            /// </summary>
            Users,
            /// <summary>
            /// 网站主导航
            /// </summary>
            WebSite,
            /// <summary>
            /// 商家后台菜单
            /// </summary>
            CT,
        }

        /// <summary>
        /// 用户生成码枚举
        /// </summary>
        public enum CodeEnum
        {
            /// <summary>
            /// 注册验证
            /// </summary>
            RegVerify,
            /// <summary>
            /// 邀请注册
            /// </summary>
            Register,
            /// <summary>
            /// 取回密码
            /// </summary>
            Password
        }

        /// <summary>
        /// 金额类型枚举
        /// </summary>
        public enum AmountTypeEnum
        {
            /// <summary>
            /// 系统赠送
            /// </summary>
            SysGive,
            /// <summary>
            /// 在线充值
            /// </summary>
            Recharge,
            /// <summary>
            /// 用户消费
            /// </summary>
            Consumption,
            /// <summary>
            /// 购买商品
            /// </summary>
            BuyGoods,
            /// <summary>
            /// 积分兑换
            /// </summary>
            Convert
        }
        #endregion

        /// <summary>
        /// 通用是否枚举(肯定为Yes,否定为Not)
        /// </summary>
        public enum YesOrNot
        {
            /// <summary>
            /// 2否定
            /// </summary>
            否 = 2,
            /// <summary>
            /// 1肯定
            /// </summary>
            是 = 1
        }

        /// <summary>
        /// 订单删除状态
        /// </summary>
        #region 订单删除状态

        public enum order_delStatus
        {
            /// <summary>
            /// 0未删除
            /// </summary>
            未删除 = 0,
            /// <summary>
            /// 1用户删除订单
            /// </summary>
            用户删除订单 = 1

        }
        #endregion

        /// <summary>
        /// 商品分类
        /// </summary>
        #region 商品分类

        public enum goods_group
        {
            /// <summary>
            /// 1 教育商城
            /// </summary>
            教育商城 = 1,
            /// <summary>
            /// 2 积分专区
            /// </summary>
            积分专区 = 2

        }
        #endregion

        /// <summary>
        /// 订单状态
        /// </summary>
        #region 订单状态

        public enum order_status
        {
            /// <summary>
            /// -1 已取消
            /// </summary>
            已取消 = -1,
            /// <summary>
            /// 1 待发货
            /// </summary>
            待发货 = 1,
            /// <summary>
            /// 2 待收货
            /// </summary>
            待收货 = 2,
            /// <summary>
            /// 3 待评价
            /// </summary>
            待评价 = 3,
            /// <summary>
            /// 4 已完成
            /// </summary>
            已完成 = 4
        }
        #endregion

        /// <summary>
        /// 分类分组
        /// </summary>
        #region 分类分组

        public enum category_group
        {
            /// <summary>
            /// 1 精品微课
            /// </summary>
            精品微课 = 1,
            /// <summary>
            /// 2 商城
            /// </summary>
            商城 = 2,
            /// <summary>
            /// 3 客户案例
            /// </summary>
            客户案例 = 3,
            /// <summary>
            /// 4 新闻动态
            /// </summary>
            新闻动态 = 4,
            /// <summary>
            /// 5 服务行业
            /// </summary>
            服务行业 = 5
        }

        #endregion

        /// <summary>
        /// 审核状态
        /// </summary>
        #region 审核状态

        public enum examine_status
        {
            /// <summary>
            /// 0 审核中
            /// </summary>
            审核中 = 0,
            /// <summary>
            /// 1 审核通过
            /// </summary>
            审核通过 = 1,
            /// <summary>
            /// 2 审核失败
            /// </summary>
            审核失败 = 2
        }

        #endregion

        /// <summary>
        /// 字典项分类
        /// </summary>
        #region 字典项分类

        public enum dict_type
        {
            /// <summary>
            /// 1 客服热线
            /// </summary>
            客服热线 = 1,
            /// <summary>
            /// 2 平台运费
            /// </summary>
            平台运费 = 2,
            /// <summary>
            /// 3 签到送积分值
            /// </summary>
            签到送积分值 = 3,
            /// <summary>
            /// 4 注册贡献积分值
            /// </summary>
            注册贡献给上级积分值 = 4,
            /// <summary>
            /// 5 注册赠送积分值
            /// </summary>
            注册赠送积分值 = 5,
            /// <summary>
            /// 6 答题送积分值
            /// </summary>
            答题送积分值 = 6,
            /// <summary>
            /// 4 注册贡献积分值
            /// </summary>
            注册贡献给上上级积分值 = 7
        }

        #endregion

        /// <summary>
        /// 图片分组
        /// </summary>
        #region 图片分组

        public enum img_group
        {
            /// <summary>
            /// 1 精品微课问题讨论图片
            /// </summary>
            精品微课问题讨论图片 = 1,
            /// <summary>
            /// 2 课堂公告
            /// </summary>
            课堂公告 = 2,
            /// <summary>
            /// 3 商品轮播图
            /// </summary>
            商品轮播图 = 3,
            /// <summary>
            /// 4 精品微课问题讨论视频
            /// </summary>
            精品微课问题讨论视频 = 4,
            /// <summary>
            /// 5 系统默认二维码logo
            /// </summary>
            系统默认二维码logo = 5,
            /// <summary>
            /// 6 课堂手机端知识点图片
            /// </summary>
            课堂手机端知识点图片 = 6,
            /// <summary>
            /// 7 新闻中心
            /// </summary>
            新闻中心 = 7
        }

        #endregion

        /// <summary>
        /// 图片分类
        /// </summary>
        #region 图片分类
        public enum img_type
        {
            /// <summary>
            /// 1 梧桐花介绍视频
            /// </summary>
            梧桐花介绍视频 = 1,
            /// <summary>
            /// 2 葫芦娃幼教介绍视频
            /// </summary>
            葫芦娃幼教介绍视频 = 2,
            /// <summary>
            /// 3 豫帛图书介绍视频
            /// </summary>
            豫帛图书介绍视频 = 10
        }
        #endregion

        /// <summary>
        /// 消息分组
        /// </summary>
        #region 消息分组
        public enum message_group
        {
            /// <summary>
            /// 1 系统消息
            /// </summary>
            系统消息 = 1,
            /// <summary>
            /// 2 课堂申请
            /// </summary>
            课堂申请 = 2
        }
        #endregion

        /// <summary>
        /// 广告位分组
        /// </summary>
        #region 广告位分组
        public enum adR_group
        {
            /// <summary>
            /// 1 精品微课轮播图
            /// </summary>
            精品微课轮播图 = 1,
            /// <summary>
            /// 2 商城轮播图
            /// </summary>
            商城轮播图 = 2,
            /// <summary>
            /// 3 精品微课推荐课程
            /// </summary>
            精品微课推荐课程 = 3,
            /// <summary>
            /// 4 教育商城推荐商品
            /// </summary>
            教育商城推荐商品 = 4,
            /// <summary>
            /// 5 积分商城推荐商品
            /// </summary>
            积分商城推荐商品 = 5,
            /// <summary>
            /// 6 梧桐花轮播图
            /// </summary>
            梧桐花轮播图 = 6
        }
        #endregion

        /// <summary>
        /// 文章分组
        /// </summary>
        #region 文章分组
        public enum article_group
        {
            /// <summary>
            /// 1 用户协议
            /// </summary>
            用户协议 = 1,
            /// <summary>
            /// 2 关于我们
            /// </summary>
            关于我们 = 2,
            /// <summary>
            /// 3 精品微课问题讨论
            /// </summary>
            精品微课问题讨论 = 3,
            /// <summary>
            /// 4 课堂公告
            /// </summary>
            课堂公告 = 4,
            /// <summary>
            /// 5 积分规则
            /// </summary>
            积分规则 = 5,
            /// <summary>
            /// 6 新闻动态
            /// </summary>
            新闻动态 = 6,
            /// <summary>
            /// 7 我们的服务
            /// </summary>
            我们的服务 = 7,
            /// <summary>
            /// 8 客户案例
            /// </summary>
            客户案例 = 8,
            /// <summary>
            /// 9 PC站关于我们
            /// </summary>
            PC站关于我们 = 9,
            /// <summary>
            /// 10 我们的团队
            /// </summary>
            我们的团队 = 10,
            /// <summary>
            /// 11 服务项目
            /// </summary>
            服务项目 = 11,
            /// <summary>
            /// 12 微课慕课项目简介
            /// </summary>
            微课慕课项目简介 = 12
        }
        #endregion

        /// <summary>
        /// 课程分组
        /// </summary>
        #region 课程分组
        public enum course_group
        {
            /// <summary>
            /// 1 精品微课
            /// </summary>
            精品微课 = 1
        }
        #endregion

        /// <summary>
        /// 资源归属
        /// </summary>
        #region 资源归属
        public enum resource_from
        {
            /// <summary>
            /// 1 精品微课
            /// </summary>
            精品微课 = 1,
            /// <summary>
            /// 2 课堂
            /// </summary>
            课堂 = 2
        }
        #endregion

        /// <summary>
        /// 资源分组
        /// </summary>
        #region 资源分组
        public enum resource_group
        {
            /// <summary>
            /// 1 公共资源
            /// </summary>
            公共资源 = 1,
            /// <summary>
            /// 2 学校资源
            /// </summary>
            学校资源 = 2,
            /// <summary>
            /// 3 共享资源
            /// </summary>
            共享资源 = 3
        }
        #endregion

        /// <summary>
        /// 资源分类
        /// </summary>
        #region 资源分类
        public enum resource_type
        {
            /// <summary>
            /// 1 图文资源
            /// </summary>
            图文资源 = 1,
            /// <summary>
            /// 2 文档资源
            /// </summary>
            文档资源 = 2,
            /// <summary>
            /// 3 音频资源
            /// </summary>
            音频资源 = 3,
            /// <summary>
            /// 4 视频资源
            /// </summary>
            视频资源 = 4,
            /// <summary>
            /// 5 试卷资源
            /// </summary>
            试卷资源 = 5,
            /// <summary>
            /// 6 三维模型
            /// </summary>
            三维模型 = 6,
            /// <summary>
            /// 7 问题讨论
            /// </summary>
            问题讨论 = 7,
            /// <summary>
            /// 8 心理测试
            /// </summary>
            心理测试 = 8,
            /// <summary>
            /// 9 英文发音
            /// </summary>
            英文发音 = 9
        }
        #endregion

        /// <summary>
        /// 评论分组
        /// </summary>
        #region 评论分组
        public enum evaluate_group
        {
            /// <summary>
            /// 1 课程问题评论
            /// </summary>
            课程问题评论 = 1,
            /// <summary>
            /// 2 音视频资源评论
            /// </summary>
            音视频资源评论 = 2,
            /// <summary>
            /// 3 商品评论
            /// </summary>
            订单商品评价 = 3
        }
        #endregion

        /// <summary>
        /// 评论类型
        /// </summary>
        #region 评论类型
        public enum evaluate_type
        {
            /// <summary>
            /// 1 评论
            /// </summary>
            评论 = 1,
            /// <summary>
            /// 2 回复
            /// </summary>
            回复 = 2
        }
        #endregion

        /// <summary>
        /// 试题分组
        /// </summary>
        #region 试题分组
        public enum questions_group
        {
            /// <summary>
            /// 1 习题测验
            /// </summary>
            习题测验 = 1,
            /// <summary>
            /// 2 心理测试
            /// </summary>
            心理测试 = 2
        }
        #endregion

        /// <summary>
        /// 试题类型
        /// </summary>
        #region 试题题型
        public enum questions_type
        {
            /// <summary>
            /// 1 单选题
            /// </summary>
            单选题 = 1,
            /// <summary>
            /// 2 多选题
            /// </summary>
            多选题 = 2,
            /// <summary>
            /// 3 判断题
            /// </summary>
            判断题 = 3,
            /// <summary>
            /// 4 填空题
            /// </summary>
            填空题 = 4,
            /// <summary>
            /// 5 主观题
            /// </summary>
            主观题 = 5
        }
        #endregion

        /// <summary>
        /// 试卷分组
        /// </summary>
        #region 试卷分组
        public enum examination_group
        {
            /// <summary>
            /// 1 精品微课测验
            /// </summary>
            精品微课测验 = 1,
            /// <summary>
            /// 2 课堂作业
            /// </summary>
            课堂作业 = 2,
            /// <summary>
            /// 3 心理测试
            /// </summary>
            心理测试 = 3
        }
        #endregion

        /// <summary>
        /// 用户分组
        /// </summary>
        #region 用户分组
        public enum user_group
        {
            /// <summary>
            /// 1 普通用户
            /// </summary>
            普通用户 = 1,
            /// <summary>
            /// 2 资源分享用户
            /// </summary>
            资源分享用户 = 2
        }
        #endregion

        /// <summary>
        /// 章节分组
        /// </summary>
        #region 章节分组
        public enum chapter_group
        {
            /// <summary>
            /// 1 精品微课
            /// </summary>
            精品微课 = 1,
            /// <summary>
            /// 2 课堂
            /// </summary>
            课堂 = 2
        }
        #endregion

        /// <summary>
        /// 批改状态
        /// </summary>
        #region 批改状态
        public enum correcting_status
        {
            /// <summary>
            /// 0 未批改
            /// </summary>
            未批改 = 0,
            /// <summary>
            /// 1 已批改
            /// </summary>
            已批改 = 1
        }
        #endregion

        /// <summary>
        /// 商品销售状态
        /// </summary>
        #region 商品销售状态
        public enum sales_status
        {
            /// <summary>
            /// 1 上架
            /// </summary>
            上架 = 1,
            /// <summary>
            /// 2 下架
            /// </summary>
            下架 = 2
        }
        #endregion

        /// <summary>
        /// 积分类型
        /// </summary>
        #region 积分类型
        public enum integral_type
        {
            /// <summary>
            /// 1 购买商品
            /// </summary>
            购买商品 = 1,
            /// <summary>
            /// 2 答题赠送
            /// </summary>
            签到赠送 = 2,
            /// <summary>
            /// 3 取消订单返还
            /// </summary>
            取消订单返还 = 3,
            /// <summary>
            /// 4 注册贡献
            /// </summary>
            注册贡献 = 4,
            /// <summary>
            /// 5 注册赠送
            /// </summary>
            注册赠送 = 5,
            /// <summary>
            /// 6 答题赠送
            /// </summary>
            答题赠送 = 6
        }
        #endregion

        /// <summary>
        /// 积分操作类型
        /// </summary>
        #region 积分操作类型

        public enum integral_method_type
        {
            /// <summary>
            /// 1 获得
            /// </summary>
            获得 = 1,
            /// <summary>
            /// 2 使用
            /// </summary>
            使用 = 2
        }

        #endregion

        /// <summary>
        /// 课程是否显示
        /// </summary>
        #region 课程是否显示
        public enum course_is_show
        {
            /// <summary>
            /// 0 否
            /// </summary>
            否 = 0,
            /// <summary>
            /// 1 是
            /// </summary>
            是 = 1
        }
        #endregion

        /// <summary>
        /// 认证登录方式
        /// </summary>
        #region 认证登录方式
        public enum user_oauths
        {
            /// <summary>
            /// 1 公众号微信登录
            /// </summary>
            公众号微信登录 = 1
        }
        #endregion

        /// <summary>
        /// 收藏分组
        /// </summary>
        #region 收藏分组
        public enum collection_group
        {
            /// <summary>
            /// 1 精品微课
            /// </summary>
            精品微课 = 1,
            /// <summary>
            /// 2 视频资源
            /// </summary>
            视频资源 = 2
        }
        #endregion

        /// <summary>
        /// 服务项目分类
        /// </summary>
        #region 服务项目分类
        public enum service_items_category
        {
            /// <summary>
            /// 1 微课MOOC开发
            /// </summary>
            微课MOOC开发 = 1,
            /// <summary>
            /// 2 立体化教材建设
            /// </summary>
            立体化教材建设 = 2,
            /// <summary>
            /// 3 智慧教室
            /// </summary>
            智慧教室 = 3
        }
        #endregion

        /// <summary>
        /// 微课慕课项目
        /// </summary>
        #region 微课慕课项目
        public enum mooc_item
        {
            /// <summary>
            /// 1 参赛微课
            /// </summary>
            参赛微课 = 1,
            /// <summary>
            /// 2 在线开发课程
            /// </summary>
            在线开发课程 = 2,
            /// <summary>
            /// 3 国家级精品课程
            /// </summary>
            国家级精品课程 = 3
        }
        #endregion

        /// <summary>
        /// 把枚举转换为键值对集合
        /// </summary>
        public static Dictionary<int, string> EnumTypesList(Type enumtype)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (var value in Enum.GetValues(enumtype))
            {
                object[] objAttrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objAttrs != null &&
                    objAttrs.Length > 0)
                {
                    DescriptionAttribute descAttr = objAttrs[0] as DescriptionAttribute;
                    dic.Add(Convert.ToInt32(value), descAttr.Description);
                }
            }
            return dic;
        }

        /// <summary>
        ///  将枚举装换为DataTable 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DataTable EnumToDataTable(Type enumType, string key, string val)
        {
            string[] Names = System.Enum.GetNames(enumType);

            Array Values = System.Enum.GetValues(enumType);


            DataTable table = new DataTable();
            table.Columns.Add(key, System.Type.GetType("System.String"));
            table.Columns.Add(val, System.Type.GetType("System.Int32"));
            table.Columns[key].Unique = true;
            for (int i = 0; i < Values.Length; i++)
            {
                DataRow DR = table.NewRow();
                DR[key] = Names[i].ToString();
                DR[val] = (int)Values.GetValue(i);
                table.Rows.Add(DR);
            }
            return table;
        }
    }
}
