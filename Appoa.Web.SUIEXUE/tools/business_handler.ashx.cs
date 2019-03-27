using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using Appoa.Common;
using Appoa.Model.Entity;
using Appoa.API.WeChat;
using Baidu.Aip.Demo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Appoa.Manage.tools
{
    /// <summary>
    /// business_handler 的摘要说明
    /// </summary>
    public class business_handler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = RequestHelper.GetQueryString("action");

            switch (action)
            {
                case "GetSchoolList"://查询学校列表
                    GetSchoolList();
                    break;
                case "GetUserAgreement"://查询用户协议
                    GetUserAgreement();
                    break;
                case "GetVerifyCode"://发送验证码
                    GetVerifyCode();
                    break;
                case "Register"://注册
                    Register();
                    break;
                case "UserLogin"://登录
                    UserLogin();
                    break;
                case "ResetPwd"://重置密码
                    ResetPwd();
                    break;
                case "GetUserInfo"://获取个人资料
                    GetUserInfo();
                    break;
                case "EditUserInfo"://编辑个人资料
                    EditUserInfo();
                    break;
                case "GetIndexAdR"://获取首页轮播图
                    GetIndexAdR();
                    break;
                case "GetIndexCategory"://获取首页分类
                    GetIndexCategory();
                    break;
                case "GetCategoryList"://获取全部分类
                    GetCategoryList();
                    break;
                case "GetIndexRecommend"://获取首页推荐课程
                    GetIndexRecommend();
                    break;
                case "GetRecommendList"://分页获取推荐课程
                    GetRecommendList();
                    break;
                case "SearchCourse"://搜索课程
                    SearchCourse();
                    break;
                case "SearchResource"://搜索资源
                    SearchResource();
                    break;
                case "GetCrouseList"://分类查询课程列表
                    GetCrouseList();
                    break;
                case "GetCourseInfo"://查询课程详情
                    GetCourseInfo();
                    break;
                case "GetCourseChapter"://查询章节
                    GetCourseChapter();
                    break;
                case "DoColletion"://收藏
                    DoColletion();
                    break;
                case "CancelColletion"://取消收藏
                    CancelColletion();
                    break;
                case "AddArticle"://发布讨论
                    AddArticle();
                    break;
                case "GetArticle"://讨论列表
                    GetArticle();
                    break;
                case "DelArticle"://删除讨论
                    DelArticle();
                    break;
                case "GetCourseArticleInfo"://讨论详情
                    GetCourseArticleInfo();
                    break;
                case "GetCourseEvaluate"://讨论评论
                    GetCourseEvaluate();
                    break;
                case "DoEvaluate"://发表评论/回复
                    DoEvaluate();
                    break;
                case "DelEvaluate"://删除评论
                    DelEvaluate();
                    break;
                case "GetResourcePath"://获取资源地址
                    GetResourcePath();
                    break;
                case "GetFinalPath"://获取最终地址(扫码后)
                    GetFinalPath();
                    break;
                case "GetCommonResourcePath"://获取学校资源对应的公共资源
                    GetCommonResourcePath();
                    break;
                case "GetVideoEvaluate"://获取视频评论
                    GetVideoEvaluate();
                    break;
                case "GetTestInfo"://查询试卷信息
                    GetTestInfo();
                    break;
                case "GetTestList"://查询试卷题目
                    GetTestList();
                    break;
                case "GetQuestionnaire"://心理测试详情
                    GetQuestionnaire();
                    break;
                case "GetQuestionnaireList"://心理测试题目
                    GetQuestionnaireList();
                    break;
                case "GetQuestionnaireResult"://心理测试结果
                    GetQuestionnaireResult();
                    break;
                case "GetExaminationAnswer"://保存用户答题记录
                    GetExaminationAnswer();
                    break;
                case "GetTestResult"://查询用户答题结果
                    GetTestResult();
                    break;
                case "GetAnswerResult"://查询答题结果列表
                    GetAnswerResult();
                    break;
                case "GetTestRank"://查询测验排名
                    GetTestRank();
                    break;
                case "GetQuestionAnalysis"://查询试题解析
                    GetQuestionAnalysis();
                    break;
                case "GetClassroomList"://分页查询课堂列表
                    GetClassroomList();
                    break;
                case "SearchClassroom"://搜索课堂
                    SearchClassroom();
                    break;
                case "CreateClassroom"://创建课堂
                    CreateClassroom();
                    break;
                case "GetClassroomInfo"://查询课堂信息
                    GetClassroomInfo();
                    break;
                case "JoinClass"://加入课堂
                    JoinClass();
                    break;
                case "DirectJoinClass"://直接加入课堂
                    DirectJoinClass();
                    break;
                case "GetClassroomNotice"://查看课堂公告
                    GetClassroomNotice();
                    break;
                case "GetNoticeDetails"://查看公告详情
                    GetNoticeDetails();
                    break;
                case "GetClassroomUsers"://查看课堂成员
                    GetClassroomUsers();
                    break;
                case "GetMemberClassroom"://查看成员参与课堂
                    GetMemberClassroom();
                    break;
                case "ReleaseVideo"://发布视频
                    ReleaseVideo();
                    break;
                case "ReleaseArticle"://发布知识点
                    ReleaseArticle();
                    break;
                case "GetMaterials"://查看学习资料
                    GetMaterials();
                    break;
                case "GetFileList"://查看课件列表
                    GetFileList();
                    break;
                case "GetVideoList"://查看视频列表
                    GetVideoList();
                    break;
                case "GetArticleList"://查看知识点列表
                    GetArticleList();
                    break;
                case "GetArticleDetails"://查看知识点详情
                    GetArticleDetails();
                    break;
                case "GetWorkList"://查看作业列表
                    GetWorkList();
                    break;
                case "DelClassroom"://解散课堂
                    DelClassroom();
                    break;
                case "ExitClassroom"://退出课堂
                    ExitClassroom();
                    break;
                case "GetShopIndexData"://查询商城首页数据
                    GetShopIndexData();
                    break;
                case "GetFirstCategory"://查询一级商品分类
                    GetFirstCategory();
                    break;
                case "GetSecondCategory"://查询二级商品分类
                    GetSecondCategory();
                    break;
                case "GetGoodsByCategory"://根据分类查询商品
                    GetGoodsByCategory();
                    break;
                case "GetGoodsDetail"://查看商品详情
                    GetGoodsDetail();
                    break;
                case "GetSpecType"://查询规格种类
                    GetSpecType();
                    break;
                case "GetGoodsEvaluate"://查看商品评论
                    GetGoodsEvaluate();
                    break;
                case "AddToCart"://加入购物车
                    AddToCart();
                    break;
                case "GetCartList"://查看购物车列表
                    GetCartList();
                    break;
                case "UpdateGoodsNum"://更改购物车商品数量
                    UpdateGoodsNum();
                    break;
                case "DelCartGoods"://删除商品
                    DelCartGoods();
                    break;
                case "AddUserAddress"://添加地址
                    AddUserAddress();
                    break;
                case "GetAdderssList"://查询地址列表
                    GetAdderssList();
                    break;
                case "SetDefaultAddress"://设置默认地址
                    SetDefaultAddress();
                    break;
                case "GetAddressInfo"://查询地址信息
                    GetAddressInfo();
                    break;
                case "EditAddress"://编辑地址
                    EditAddress();
                    break;
                case "DelAddress"://删除地址
                    DelAddress();
                    break;
                case "ConfirmOrder"://确认订单
                    ConfirmOrder();
                    break;
                case "AddOrder"://提交订单
                    AddOrder();
                    break;
                case "GetOrderList"://订单列表
                    GetOrderList();
                    break;
                case "GetOrderDetails"://订单详情
                    GetOrderDetails();
                    break;
                case "CancelOrder"://取消订单
                    CancelOrder();
                    break;
                case "ConfirmReceive"://确认收货
                    ConfirmReceive();
                    break;
                case "DoEvaluateGoods"://评价商品
                    DoEvaluateGoods();
                    break;
                case "GetMyCenter"://个人中心
                    GetMyCenter();
                    break;
                case "GetMessageList"://系统消息
                    GetMessageList();
                    break;
                case "GetMessageInfo"://消息详情
                    GetMessageInfo();
                    break;
                case "GetClassroomVerify"://加入课堂申请
                    GetClassroomVerify();
                    break;
                case "DoExamine"://审核加入课堂申请
                    DoExamine();
                    break;
                case "DoSignIn"://签到
                    DoSignIn();
                    break;
                case "GetMyIntegral"://我的积分
                    GetMyIntegral();
                    break;
                case "GetIntegralRule"://积分规则
                    GetIntegralRule();
                    break;
                case "GetMyCollection"://我收藏的课程
                    GetMyCollection();
                    break;
                case "GetMyResourceColl"://我收藏的资源
                    GetMyResourceColl();
                    break;
                case "DelCollection"://删除收藏
                    DelCollection();
                    break;
                case "GetMyDistribution"://我的分销
                    GetMyDistribution();
                    break;
                case "GetSubordinate"://查看他的下级
                    GetSubordinate();
                    break;
                case "GetMyClass"://我的课堂
                    GetMyClass();
                    break;
                case "GetMyExamination"://我的题库试卷列表
                    GetMyExamination();
                    break;
                case "GetMyQuestion"://题库试题列表
                    GetMyQuestion();
                    break;
                case "GetMyReadRecord"://播放历史
                    GetMyReadRecord();
                    break;
                case "DelReadRecord"://删除播放历史
                    DelReadRecord();
                    break;
                case "UpdatePwd"://修改密码
                    UpdatePwd();
                    break;
                case "UpdatePhone"://修改手机号
                    UpdatePhone();
                    break;
                case "GetServiceTelephone"://查询客服电话
                    GetServiceTelephone();
                    break;
                case "FeedBack"://意见反馈
                    FeedBack();
                    break;
                case "GetAboutUs"://关于我们
                    GetAboutUs();
                    break;
                case "GetWeChatInfo"://获取微信配置信息
                    GetWeChatInfo();
                    break;
                case "WeChat_GetCode"://微信授权登录获取code
                    WeChat_GetCode();
                    break;
                case "wxLogin"://微信登录
                    wxLogin();
                    break;
                case "GetEnglishVoice"://获取单词发音
                    GetEnglishVoice();
                    break;
            }
        }

        #region 查询学校列表
        private void GetSchoolList()
        {
            try
            {
                DataTable dt = new BLL.common_school().GetList(" 1 = 1 order by sort ");

                writeMsgSuccess("查询成功", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 用户协议
        private void GetUserAgreement()
        {
            try
            {
                Model.common_article model = new BLL.common_article().GetModel(" group_id = " + (int)EnumCollection.article_group.用户协议);
                string contents = string.Empty;
                if (model != null)
                {
                    contents = model.contents;
                }
                else
                {
                    contents = "";
                }

                DataTable dt = GetTableSingle("contents", contents);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 发送验证码
        private void GetVerifyCode()
        {
            try
            {
                bool ceshi = Utils.StrToBool(System.Configuration.ConfigurationManager.AppSettings["ceshi"], false);
                string phone = RequestHelper.GetString("phone");

                if (!Utils.IsPhone(phone))
                {
                    writeMsgError("手机号码格式有误，请重新输入");
                    return;
                }
                string number = "123456";
                bool b = true;
                if (!ceshi)
                {
                    number = Utils.Number(6);
                    //string msg = "【随E学】尊敬的用户：您的短信验证码是" + number + "。请妥善保管，不要泄露给其他人！";
                    //b = PhoneSMS.SendMsg(phone, msg);
                }
                if (b)
                {
                    HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE] = number;
                    HttpContext.Current.Session["SMS_CODE_TIME"] = System.DateTime.Now;
                    DataTable dt = GetTable("code", number);

                    writeMsgSuccess("验证码发送成功", dt);
                }
                else
                {
                    writeMsgError("验证码发送失败");
                }
            }
            catch (Exception e)
            {
                writeMsgError("手机号码格式有误，请重新输入");
            }
        }
        #endregion

        #region 注册
        private void Register()
        {
            try
            {
                string phone = RequestHelper.GetString("phone");
                string pwd = RequestHelper.GetString("pwd");
                string verifycode = RequestHelper.GetString("verifycode");
                int school_id = RequestHelper.GetInt("school_id", 0);
                string recommend = RequestHelper.GetString("recommend");

                if (!Utils.IsPhone(phone))
                {
                    writeMsgError("手机号格式不正确");
                    return;
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    writeMsgError("请输入密码");
                    return;
                }

                #region 检测验证码
                if (HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE] == null || HttpContext.Current.Session["SMS_CODE_TIME"] == null)
                {
                    writeMsgError("您还没有发送验证码或验证码已过期，请重新发送");
                    return;
                }
                string code = HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE].ToString();
                string codetime = HttpContext.Current.Session["SMS_CODE_TIME"].ToString();

                if (string.IsNullOrEmpty(code))
                {
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }
                if (string.IsNullOrEmpty(codetime))
                {
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }
                DateTime time = Convert.ToDateTime(codetime);
                DateTime now = System.DateTime.Now;

                TimeSpan ts = now - time;

                if (ts.TotalSeconds >= 60)
                {
                    HttpContext.Current.Session.Remove(AppoaKeys.SESSION_SMS_CODE);
                    HttpContext.Current.Session.Remove("SMS_CODE_TIME");
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }

                if (verifycode != code)
                {
                    writeMsgError("验证码不正确");
                    return;
                }
                #endregion

                Model.common_school school = null;
                if (school_id > 0)
                {
                    school = new BLL.common_school().GetModel(school_id);
                    if (school == null)
                    {
                        writeMsgError("没有此学校");
                        return;
                    }
                }

                BLL.user_tree tBll = new BLL.user_tree();
                if (!string.IsNullOrEmpty(recommend) && recommend != "0")
                {
                    Model.user_tree treeModel = tBll.GetModel(" code = '" + recommend + "'");
                    if (treeModel == null && recommend != "ybd188")
                    {
                        writeMsgError("此推荐者不存在");
                        return;
                    }
                }

                BLL.user_info bll = new BLL.user_info();
                Model.user_info model = bll.GetModel(" phone = '" + phone + "' ");

                if (model != null)
                {
                    writeMsgError("此手机号已注册");
                    return;
                }

                model = new Model.user_info();
                model.group_id = (int)EnumCollection.user_group.普通用户;
                model.user_name = phone;
                model.phone = phone;
                model.salt = Utils.GetCheckCode(6);
                model.user_pwd = DESEncrypt.Encrypt(pwd, model.salt.Trim());
                model.nick_name = "";
                model.avatar = "";
                model.integral = 0;
                model.school_id = school != null ? school.id : 0;
                model.school_name = school != null ? school.name : "";
                model.college = "";
                model.job = "";
                model.course = "";
                model.line_way = "";
                model.area = "";
                model.address = "";
                model.reg_ip = RequestHelper.GetIP();
                model.add_time = System.DateTime.Now;

                int row = bll.Add(model);
                if (row > 0)
                {
                    model.id = row;

                    #region 给用户赠送积分
                    int point = 5;
                    Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册赠送积分值);
                    if (dict != null)
                    {
                        point = Convert.ToInt32(dict.contents);
                    }
                    else
                    {
                        point = 5;
                    }
                    model.integral += point;
                    bll.Update(model);
                    AddIntegralRecord(row, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.注册赠送, point);
                    #endregion

                    #region 添加用户关系树并给用户的上级推荐者赠送积分

                    string tree_code = string.Empty; do
                    {
                        tree_code = Utils.Number(6);
                    } while (tBll.GetModel(" code = '" + tree_code + "'") != null);

                    Model.user_tree tree = new Model.user_tree();
                    tree.user_id = row;
                    tree.code = tree_code;

                    Model.user_tree treeModel = tBll.GetModel(" code = '" + recommend + "'");
                    Model.user_tree grandModel = null;
                    if (treeModel != null)
                    {
                        tree.parent_code = treeModel.code;
                        grandModel = tBll.GetModel(" code = '" + treeModel.parent_code + "'");
                        if (grandModel != null)
                        {
                            tree.grand_code = grandModel.code;
                        }
                        else
                        {
                            tree.grand_code = "0";
                        }
                    }
                    else
                    {
                        tree.parent_code = "0";
                        tree.grand_code = "0";
                    }

                    if (tBll.Add(tree) > 0)
                    {
                        if (treeModel != null)
                        {
                            Model.user_info pModel = bll.GetModel(treeModel.user_id);
                            if (pModel != null)
                            {
                                #region 给上级赠送积分
                                point = 10;
                                dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册贡献给上级积分值);
                                if (dict != null)
                                {
                                    point = Convert.ToInt32(dict.contents);
                                }
                                else
                                {
                                    point = 10;
                                }
                                pModel.integral += point;
                                bll.Update(pModel);
                                #endregion

                                AddIntegralRecord(treeModel.user_id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.注册贡献, point);
                                if (grandModel != null)
                                {
                                    #region 给上上级赠送积分
                                    point = 3;
                                    dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册贡献给上上级积分值);
                                    if (dict != null)
                                    {
                                        point = Convert.ToInt32(dict.contents);
                                    }
                                    else
                                    {
                                        point = 3;
                                    }

                                    Model.user_info gModel = bll.GetModel(grandModel.user_id);
                                    if (gModel != null)
                                    {
                                        gModel.integral += point;
                                        bll.Update(gModel);

                                        AddIntegralRecord(grandModel.user_id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.注册贡献, point);
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                    #endregion

                    writeMsgSuccessNull("注册成功");
                }
                else
                {
                    writeMsgError("注册失败");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 登录
        private void UserLogin()
        {
            try
            {
                string phone = RequestHelper.GetString("phone");
                string pwd = RequestHelper.GetString("pwd");

                if (string.IsNullOrEmpty(phone.Trim()) || string.IsNullOrEmpty(pwd.Trim()))
                {
                    writeMsgError("手机号或密码不能为空");
                    return;
                }
                if (!Utils.IsPhone(phone))
                {
                    writeMsgError("手机号格式错误");
                    return;
                }

                BLL.user_info bll = new BLL.user_info();
                Model.user_info user = bll.GetModel(" phone = '" + phone + "' ");
                if (user == null)
                {
                    writeMsgError("此手机号还没有注册");
                    return;
                }

                if (user.user_pwd == DESEncrypt.Encrypt(pwd, user.salt))
                {
                    user.user_pwd = "";
                    user.salt = "";
                    user.reg_ip = "";

                    user_info_entity entity = new user_info_entity();
                    entity.UserInfo = user;
                    entity.UserTree = new BLL.user_tree().GetModel(" user_id = " + user.id);
                    entity.UserOAuths = new BLL.user_oauths().GetModel(" type = " + (int)EnumCollection.user_oauths.公众号微信登录 + " and user_id = " + user.id);

                    writeMsgSuccess("登录成功", entity);
                }
                else
                {
                    writeMsgError("用户名或密码错误");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 重置密码
        private void ResetPwd()
        {
            try
            {
                string phone = RequestHelper.GetString("phone");
                string new_pwd = RequestHelper.GetString("newpwd");
                string verifycode = RequestHelper.GetString("verifycode");

                if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(new_pwd))
                {
                    writeMsgError("手机号或新密码不能为空");
                    return;
                }
                if (!Utils.IsPhone(phone))
                {
                    writeMsgError("手机号格式不正确");
                    return;
                }

                #region 检测验证码
                if (HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE] == null || HttpContext.Current.Session["SMS_CODE_TIME"] == null)
                {
                    writeMsgError("您还没有发送验证码或验证码已过期，请重新发送");
                    return;
                }

                string code = HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE].ToString();
                string codetime = HttpContext.Current.Session["SMS_CODE_TIME"].ToString();

                if (string.IsNullOrEmpty(code))
                {
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }
                if (string.IsNullOrEmpty(codetime))
                {
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }
                DateTime time = Convert.ToDateTime(codetime);
                DateTime now = System.DateTime.Now;

                TimeSpan ts = now - time;

                if (ts.TotalSeconds >= 60)
                {
                    HttpContext.Current.Session.Remove(AppoaKeys.SESSION_SMS_CODE);
                    HttpContext.Current.Session.Remove("SMS_CODE_TIME");
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }

                if (verifycode != code)
                {
                    writeMsgError("验证码不正确");
                    return;
                }
                #endregion

                BLL.user_info bll = new BLL.user_info();
                Model.user_info model = bll.GetModel(" phone = '" + phone + "' ");
                if (model != null)
                {
                    string new_pwd_e = DESEncrypt.Encrypt(new_pwd, model.salt);

                    model.user_pwd = new_pwd_e;

                    bool flag = bll.Update(model);
                    if (flag)
                    {
                        writeMsgSuccess("修改成功", null);
                    }
                    else
                    {
                        writeMsgError("修改失败");
                    }
                }
                else
                {
                    writeMsgError("此手机号还没有注册");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 获取个人资料
        private void GetUserInfo()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                user.user_pwd = "";
                user.salt = "";
                user.reg_ip = "";

                writeMsgSuccess("查询成功", new List<Model.user_info>() { user });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 编辑个人资料
        private void EditUserInfo()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string nick_name = RequestHelper.GetString("nick_name");
                string avatar = RequestHelper.GetString("avatar");
                string true_name = RequestHelper.GetString("true_name");
                int school_id = RequestHelper.GetInt("school_id", 0);
                string college = RequestHelper.GetString("college");
                string job = RequestHelper.GetString("job");
                string course = RequestHelper.GetString("course");
                string linkway = RequestHelper.GetString("linkway");
                string area = RequestHelper.GetString("area");
                string address = RequestHelper.GetString("address");

                BLL.user_info bll = new BLL.user_info();
                Model.user_info user = bll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                string[] arr = avatar.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 0)
                {
                    writeMsgError("请上传头像");
                    return;
                }

                if (arr.Length == 2)
                {
                    user.avatar = Base64LoadImg(arr[1], "avatar", "");
                }
                else if (arr.Length == 1 && arr[0].Contains("upload"))
                {
                    user.avatar = avatar;
                }

                user.nick_name = nick_name;
                user.user_name = true_name;
                Model.common_school school = new BLL.common_school().GetModel(school_id);
                user.school_id = school == null ? 0 : school.id;
                user.school_name = school == null ? "" : school.name;
                user.college = college;
                user.job = job;
                user.course = course;
                user.line_way = linkway;
                user.area = area;
                user.address = address;

                if (bll.Update(user))
                {
                    user_info_entity entity = new user_info_entity();
                    user.user_pwd = "";
                    user.salt = "";
                    user.reg_ip = "";
                    entity.UserInfo = user;
                    entity.UserTree = new BLL.user_tree().GetModel(" user_id = " + uid);
                    entity.UserOAuths = new BLL.user_oauths().GetModel(" type = " + (int)EnumCollection.user_oauths.公众号微信登录 + " and user_id = " + uid);

                    writeMsgSuccess("修改成功", entity);
                }
                else
                {
                    writeMsgError("修改失败");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 获取首页轮播图
        private void GetIndexAdR()
        {
            try
            {
                BLL.common_adR bll = new BLL.common_adR();
                DataTable dt = bll.GetList(" ad_group_id = " + (int)EnumCollection.adR_group.精品微课轮播图);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 获取首页分类
        private void GetIndexCategory()
        {
            try
            {
                int pageSize = RequestHelper.GetInt("page_size", 9);
                BLL.common_category bll = new BLL.common_category();
                DataTable dt = bll.GetListByPage(" group_id = " + (int)EnumCollection.category_group.精品微课 + " and category_level = 1 ", " sort ", 1, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 获取所有分类
        private void GetCategoryList()
        {
            try
            {
                int group_id = RequestHelper.GetInt("group", 0);
                //List<category_entity> list = getCategoryList(group_id, 0);
                DataTable dt = new BLL.common_category().GetList(" group_id = " + group_id + " and parent_id = 0 and category_level = 1 order by sort asc ");

                List<category_entity> list = new List<category_entity>();
                category_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new category_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.category_level = Convert.ToInt32(item["category_level"]);
                    entity.img_src = item["img_src"].ToString();
                    entity.title = item["name"].ToString();
                    entity.childrenList = getCategoryList(group_id, entity.id);

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }

        private List<category_entity> getCategoryList(int group_id, int parentid)
        {
            BLL.common_category bll = new BLL.common_category();
            DataTable dt = bll.GetList(" group_id = " + group_id + " and parent_id = " + parentid);

            List<category_entity> list = new List<category_entity>();
            category_entity entity = null;
            foreach (DataRow item in dt.Rows)
            {
                entity = new category_entity();
                entity.id = Convert.ToInt32(item["id"]);
                entity.category_level = Convert.ToInt32(item["category_level"]);
                entity.img_src = item["img_src"].ToString();
                entity.title = item["name"].ToString();
                entity.childrenList = getCategoryList(group_id, entity.id);

                list.Add(entity);
            }

            return list;
        }
        #endregion

        #region 获取首页推荐课程
        private void GetIndexRecommend()
        {
            try
            {
                DataTable dt = new BLL.course_info().GetListByPage("*", "View_RecommendCourse", "", "ad_sort_id asc", 1, 9);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 分页获取推荐课程
        private void GetRecommendList()
        {
            try
            {
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                DataTable dt = new BLL.course_info().GetListByPage("*", "View_RecommendCourse", "", "ad_sort_id asc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 搜索课程
        private void SearchCourse()
        {
            try
            {
                string keywords = RequestHelper.GetString("keywords");
                if (string.IsNullOrEmpty(keywords))
                {
                    writeMsgError("请传入搜索关键词");
                    return;
                }

                if (Utils.IsSafeSqlString(keywords))
                {
                    try
                    {
                        keywords = Utils.Filter(keywords);
                    }
                    catch
                    {
                        writeMsgError("系统检测到非法字符");
                        return;
                    }
                }
                else
                {
                    writeMsgError("系统检测到非法字符");
                    return;
                }

                string where = " name like '%" + keywords + "%' ";

                DataTable dt = new BLL.course_info().GetList(where + " and is_show = " + (int)EnumCollection.course_is_show.是 + " order by add_time desc");

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 搜索资源
        private void SearchResource()
        {
            try
            {
                string keywords = RequestHelper.GetString("keywords");
                if (string.IsNullOrEmpty(keywords))
                {
                    writeMsgError("请传入搜索关键词");
                    return;
                }

                if (Utils.IsSafeSqlString(keywords))
                {
                    try
                    {
                        keywords = Utils.Filter(keywords);
                    }
                    catch
                    {
                        writeMsgError("系统检测到非法字符");
                        return;
                    }
                }
                else
                {
                    writeMsgError("系统检测到非法字符");
                    return;
                }

                string where = " from_id = 1 and is_del = 0 and group_id = " + (int)EnumCollection.resource_group.公共资源 + " and title like '%" + keywords + "%' ";

                DataTable dt = new BLL.course_info().GetList("View_ChapterResource", where, " add_time desc ");

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
            }
        }
        #endregion

        #region 分类查询课程列表
        private void GetCrouseList()
        {
            try
            {
                int category = RequestHelper.GetInt("category", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                string whereStr = string.Empty;

                Model.common_category cate = new BLL.common_category().GetModel(category);
                if (cate == null)
                {
                    writeMsgError("此分类不存在");
                    return;
                }
                //if (cate.category_level == 1)
                //{
                //    DataTable dtids = new BLL.common_category().GetList(" parent_id = " + cate.id);
                //    string ids = string.Empty;
                //    foreach (DataRow item in dtids.Rows)
                //    {
                //        ids += Convert.ToInt32(item["id"]) + ",";
                //    }

                //    ids = Utils.DelLastComma(ids);
                //    if (!string.IsNullOrEmpty(ids))
                //    {
                //        whereStr = " category_id in (" + ids + ") ";
                //    }
                //    else
                //    {
                //        whereStr = " 1 != 1 ";
                //    }
                //}
                //else
                //{
                //    whereStr = " category_id = " + category;
                //}
                whereStr = " category_id = " + category + " and is_show = " + (int)EnumCollection.course_is_show.是;

                DataTable dt = new BLL.course_info().GetListByPage(whereStr, "add_time desc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 查询课程详情
        private void GetCourseInfo()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.course_info model = new BLL.course_info().GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此课程");
                    return;
                }

                if (model.is_show == (int)EnumCollection.course_is_show.否)
                {
                    writeMsgError("没有此课程");
                    return;
                }

                if (uid > 0)
                {
                    BLL.user_readrecord readBll = new BLL.user_readrecord();
                    Model.user_readrecord read = readBll.GetModel(" group_id = 1 and data_id = " + id + " and user_id = " + uid);
                    if (read != null)
                    {
                        read.add_time = System.DateTime.Now;
                        readBll.Update(read);
                    }
                    else
                    {
                        read = new Model.user_readrecord();
                        read.group_id = 1;
                        read.data_id = id;
                        read.user_id = uid;
                        read.add_time = System.DateTime.Now;

                        readBll.Add(read);
                    }
                }

                course_info_entity entity = new course_info_entity();
                entity.id = model.id;
                entity.user_id = model.user_id;
                entity.cover = model.cover;
                entity.name = model.name;
                entity.info = model.info;
                entity.qrcode = model.qrcode;
                entity.is_collection = new BLL.user_collection().GetRecordCount(" data_id = " + entity.id + " and user_id = " + uid) > 0 ? 1 : 0;

                writeMsgSuccess("", new List<course_info_entity> { entity });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 查询章节
        private void GetCourseChapter()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int group = 0;
                int school_id = 0;

                string recourseWhere = " from_id = " + (int)EnumCollection.resource_from.精品微课 + " and is_del = 0 ";

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    group = (int)EnumCollection.resource_group.公共资源;
                    recourseWhere += " and group_id = " + group + " and school_id = 0";
                }
                else
                {
                    if (user.group_id == (int)EnumCollection.user_group.普通用户)
                    {
                        if (user.school_id == 0)
                        {
                            group = (int)EnumCollection.resource_group.公共资源;
                            recourseWhere += " and group_id = " + group + " and school_id = 0";
                        }
                        else
                        {
                            school_id = user.school_id;
                            recourseWhere += " and (group_id = " + (int)EnumCollection.resource_group.公共资源 + " or (group_id = "
                                + (int)EnumCollection.resource_group.学校资源 + " and school_id = " + school_id + ")) ";
                        }
                    }
                    else if (user.group_id == (int)EnumCollection.user_group.资源分享用户)
                    {
                        recourseWhere += " and group_id in (" + (int)EnumCollection.resource_group.公共资源 + ","
                                + (int)EnumCollection.resource_group.共享资源 + ") and share_user like '%," + uid + ",%' ";
                    }
                }

                List<course_chapter_entity> list = GetChapterList(recourseWhere, id, 0);

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }

        private List<course_chapter_entity> GetChapterList(string recourseWhere, int cid, int parentid)
        {
            BLL.course_chapter bll = new BLL.course_chapter();

            DataTable dt = bll.GetList(" group_id = " + (int)EnumCollection.chapter_group.精品微课 + " and course_id = " + cid + " and chapter_level = 1 ");
            BLL.common_resource crbll = new BLL.common_resource();
            DataTable dtresource = null;

            BLL.common_examination exaBll = new BLL.common_examination();
            Model.common_examination exa = null;

            BLL.common_article disBll = new BLL.common_article();
            DataTable dtDiscuss = null;

            List<course_chapter_entity> list = new List<course_chapter_entity>();
            course_chapter_entity entity = null;
            foreach (DataRow item in dt.Rows)
            {
                entity = new course_chapter_entity();
                entity.id = Convert.ToInt32(item["id"]);
                entity.title = item["name"].ToString();

                //资源列表
                dtresource = crbll.GetList(recourseWhere + " and data_id = " + entity.id + " order by sort asc ");
                List<course_resource_entity> resourceList = new List<course_resource_entity>();
                course_resource_entity resource = null;
                foreach (DataRow row in dtresource.Rows)
                {
                    resource = new course_resource_entity();
                    resource.id = Convert.ToInt32(row["id"]);
                    resource.title = row["title"].ToString();
                    resource.cover = row["cover"].ToString();
                    resource.type = Convert.ToInt32(row["type"]);
                    if (resource.type == (int)EnumCollection.resource_type.文档资源)
                    {
                        resource.path = row["path"].ToString();
                        resource.path = resource.path.Substring(0, resource.path.LastIndexOf('.'));
                        resource.path = resource.path + ".html";
                    }
                    else
                    {
                        resource.path = row["path"].ToString();
                    }
                    resource.add_time = Convert.ToDateTime(row["add_time"]).ToString("yyyy-MM-dd");

                    resourceList.Add(resource);
                }

                //测验
                exa = exaBll.GetModel(" group_id = " + (int)EnumCollection.examination_group.精品微课测验 + " and parent_id = " + entity.id);
                if (exa != null)
                {
                    resource = new course_resource_entity();
                    resource.id = exa.id;
                    resource.title = exa.name;
                    resource.cover = "";
                    resource.type = (int)EnumCollection.resource_type.试卷资源;
                    resource.path = "";
                    resource.add_time = Convert.ToDateTime(exa.add_time).ToString("yyyy-MM-dd");

                    resourceList.Add(resource);
                }

                //心理测试
                exa = exaBll.GetModel(" group_id = " + (int)EnumCollection.examination_group.心理测试 + " and parent_id = " + entity.id);
                if (exa != null)
                {
                    resource = new course_resource_entity();
                    resource.id = exa.id;
                    resource.title = exa.name;
                    resource.cover = "";
                    resource.type = (int)EnumCollection.resource_type.心理测试;
                    resource.path = "";
                    resource.add_time = Convert.ToDateTime(exa.add_time).ToString("yyyy-MM-dd");

                    resourceList.Add(resource);
                }

                //讨论
                dtDiscuss = disBll.GetList(" group_id = " + (int)EnumCollection.article_group.精品微课问题讨论 + " and user_id = 0 and category_id = " + entity.id + " order by add_time ");
                foreach (DataRow row in dtDiscuss.Rows)
                {
                    resource = new course_resource_entity();
                    resource.id = Convert.ToInt32(row["id"]);
                    resource.type = (int)EnumCollection.resource_type.问题讨论;
                    resource.cover = "";
                    resource.title = row["title"].ToString();
                    resource.path = row["contents"].ToString();
                    resource.add_time = Convert.ToDateTime(row["add_time"]).ToString("yyyy-MM-dd");

                    resourceList.Add(resource);
                }

                entity.resourceList = resourceList;

                //entity.childrenList = GetChapterList(recourseWhere, cid, entity.id);

                list.Add(entity);
            }

            return list;
        }
        #endregion

        #region 收藏
        private void DoColletion()
        {
            try
            {
                int group_id = RequestHelper.GetInt("group", 1);
                int uid = RequestHelper.GetInt("user_id", 0);
                int data_id = RequestHelper.GetInt("data_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (group_id == (int)EnumCollection.collection_group.精品微课)
                {
                    if (!new BLL.course_info().Exists(data_id))
                    {
                        writeMsgError("没有此课程");
                        return;
                    }
                }
                if (group_id == (int)EnumCollection.collection_group.视频资源)
                {
                    if (!new BLL.common_resource().Exists(data_id))
                    {
                        writeMsgError("没有此视频");
                        return;
                    }
                }


                object obj = new object();
                lock (obj)
                {
                    BLL.user_collection bll = new BLL.user_collection();
                    Model.user_collection model = bll.GetModel(" user_id = " + uid + " and data_id = " + data_id);
                    if (model == null)//没有收藏过
                    {
                        model = new Model.user_collection();
                        model.group_id = group_id;
                        model.data_id = data_id;
                        model.user_id = uid;
                        model.add_time = System.DateTime.Now;

                        if (bll.Add(model) > 0)
                        {
                            writeMsgSuccessNull("收藏成功");
                            return;
                        }
                        else
                        {
                            writeMsgError("收藏失败");
                            return;
                        }
                    }
                    else
                    {
                        writeMsgSuccessNull("收藏成功");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 取消收藏
        private void CancelColletion()
        {
            try
            {
                int group_id = RequestHelper.GetInt("group", 1);
                int uid = RequestHelper.GetInt("user_id", 0);
                int data_id = RequestHelper.GetInt("data_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (group_id == (int)EnumCollection.collection_group.精品微课)
                {
                    if (!new BLL.course_info().Exists(data_id))
                    {
                        writeMsgError("没有此课程");
                        return;
                    }
                }
                if (group_id == (int)EnumCollection.collection_group.视频资源)
                {
                    if (!new BLL.common_resource().Exists(data_id))
                    {
                        writeMsgError("没有此视频");
                        return;
                    }
                }

                BLL.user_collection bll = new BLL.user_collection();
                Model.user_collection model = bll.GetModel(" user_id = " + uid + " and data_id = " + data_id);
                if (model == null)
                {
                    writeMsgSuccessNull("取消收藏成功");
                    return;
                }

                if (bll.Delete(model.id))
                {
                    writeMsgSuccessNull("取消收藏成功");
                    return;
                }
                else
                {
                    writeMsgError("取消收藏失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 发布讨论
        private void AddArticle()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int cid = RequestHelper.GetInt("course_id", 0);
                string title = RequestHelper.GetString("title");
                string contents = RequestHelper.GetString("contents");
                string type = RequestHelper.GetString("type");
                string src = RequestHelper.GetString("src");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                Model.course_info course = new BLL.course_info().GetModel(cid);
                if (course == null)
                {
                    writeMsgError("没有此课程");
                    return;
                }

                object obj = new object();
                lock (obj)
                {
                    Model.common_article model = new Model.common_article();
                    model.group_id = (int)EnumCollection.article_group.精品微课问题讨论;
                    model.user_id = uid;
                    model.category_id = cid;
                    model.title = title;
                    model.subtitle = "";
                    model.contents = contents;
                    model.img_src = "";
                    model.click = 0;
                    model.upvote = 0;
                    model.status = 1;
                    model.add_time = System.DateTime.Now;

                    int id = new BLL.common_article().Add(model);
                    if (id > 0)
                    {
                        model.id = id;

                        if (type == "image")
                        {
                            if (!string.IsNullOrEmpty(src))
                            {
                                string[] arr = src.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                                BLL.common_albums albll = new BLL.common_albums();
                                Model.common_albums albums = null;
                                foreach (string url in arr)
                                {
                                    albums = new Model.common_albums();
                                    albums.group_id = (int)EnumCollection.img_group.精品微课问题讨论图片;
                                    albums.rc_type = 0;
                                    albums.rc_data_id = id;
                                    albums.original_path = Base64LoadImg(url.Split(',')[1], "course", "");
                                    albums.thumb_path = albums.original_path;
                                    albums.remark = "";
                                    albums.add_time = System.DateTime.Now;

                                    albll.Add(albums);
                                }
                            }
                        }
                        if (type == "video")
                        {
                            if (!string.IsNullOrEmpty(src))
                            {
                                string[] arr = src.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                if (arr.Length == 2)
                                {
                                    BLL.common_albums albll = new BLL.common_albums();
                                    Model.common_albums albums = new Model.common_albums();

                                    albums.group_id = (int)EnumCollection.img_group.精品微课问题讨论视频;
                                    albums.rc_type = 0;
                                    albums.rc_data_id = id;
                                    albums.original_path = Base64LoadVideo(arr[0].Split(',')[1], "course", "");
                                    albums.thumb_path = Base64LoadImg(arr[1].Split(',')[1], "course", "");
                                    albums.remark = "";
                                    albums.add_time = System.DateTime.Now;

                                    albll.Add(albums);
                                }
                            }
                        }

                        writeMsgSuccessNull("发布成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("发布失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 讨论列表
        private void GetArticle()
        {
            try
            {
                int cid = RequestHelper.GetInt("course_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                BLL.common_albums bll = new BLL.common_albums();
                DataTable dt = new BLL.common_article().GetListByPage("*", "View_CourseDiscuss", " category_id = " + cid, " add_time desc ", pageIndex, pageSize);
                List<course_article_entity> list = new List<course_article_entity>();
                course_article_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new course_article_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.course_id = Convert.ToInt32(item["category_id"]);
                    entity.user_id = Convert.ToInt32(item["user_id"]);
                    entity.avatar = item["avatar"].ToString();
                    entity.nick_name = item["nick_name"].ToString();
                    entity.title = item["title"].ToString();
                    entity.contents = item["contents"].ToString();
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");
                    entity.eval_count = Convert.ToInt32(item["eval_count"]);

                    List<img_entity> imgList = new List<img_entity>();
                    img_entity img = null;
                    DataTable dtimg = bll.GetList(" group_id = " + (int)EnumCollection.img_group.精品微课问题讨论图片 + " and rc_data_id = " + entity.id + " order by id ");
                    DataTable dtvideo = bll.GetList(" group_id = " + (int)EnumCollection.img_group.精品微课问题讨论视频 + " and rc_data_id = " + entity.id + " order by id ");
                    if (dtimg.Rows.Count > 0 && dtvideo.Rows.Count == 0)
                    {
                        foreach (DataRow row in dtimg.Rows)
                        {
                            img = new img_entity();
                            img.id = Convert.ToInt32(row["id"]);
                            img.thumb_path = row["thumb_path"].ToString();
                            img.original_path = row["original_path"].ToString();

                            imgList.Add(img);
                        }
                    }

                    List<img_entity> videoList = new List<img_entity>();
                    img_entity video = null;
                    if (dtimg.Rows.Count == 0 && dtvideo.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtvideo.Rows)
                        {
                            video = new img_entity();
                            video.id = Convert.ToInt32(row["id"]);
                            video.thumb_path = row["thumb_path"].ToString();
                            video.original_path = row["original_path"].ToString();

                            videoList.Add(video);
                        }
                    }

                    entity.imgList = imgList;
                    entity.videoList = videoList;

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 删除讨论
        private void DelArticle()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int aid = RequestHelper.GetInt("article_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.common_article bll = new BLL.common_article();
                Model.common_article model = bll.GetModel(aid);
                if (model == null)
                {
                    writeMsgError("没有此讨论");
                    return;
                }

                if (model.user_id != uid)
                {
                    writeMsgError("此讨论不属于你");
                    return;
                }

                if (bll.Delete(model.id))
                {
                    writeMsgSuccessNull("删除成功");
                }
                else
                {
                    writeMsgError("删除失败");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 讨论详情
        private void GetCourseArticleInfo()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                BLL.common_article arbll = new BLL.common_article();
                BLL.common_albums bll = new BLL.common_albums();
                Model.common_article model = arbll.GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此讨论");
                    return;
                }

                DataTable dt = arbll.GetListByPage("*", "View_CourseAllDiscuss", " id = " + id, " add_time desc ", 1, 1);
                if (dt.Rows.Count == 0)
                {
                    writeMsgError("没有此讨论");
                    return;
                }

                List<course_article_entity> list = new List<course_article_entity>();
                course_article_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new course_article_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.course_id = Convert.ToInt32(item["category_id"]);
                    entity.user_id = Convert.ToInt32(item["user_id"]);
                    entity.avatar = item["avatar"].ToString();
                    entity.nick_name = item["nick_name"].ToString();
                    entity.title = item["title"].ToString();
                    entity.contents = item["contents"].ToString();
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");
                    entity.eval_count = Convert.ToInt32(item["eval_count"]);

                    List<img_entity> imgList = new List<img_entity>();
                    img_entity img = null;
                    DataTable dtimg = bll.GetList(" group_id = " + (int)EnumCollection.img_group.精品微课问题讨论图片 + " and rc_data_id = " + entity.id + " order by id ");
                    DataTable dtvideo = bll.GetList(" group_id = " + (int)EnumCollection.img_group.精品微课问题讨论视频 + " and rc_data_id = " + entity.id + " order by id ");
                    if (dtimg.Rows.Count > 0 && dtvideo.Rows.Count == 0)
                    {
                        foreach (DataRow row in dtimg.Rows)
                        {
                            img = new img_entity();
                            img.id = Convert.ToInt32(row["id"]);
                            img.thumb_path = row["thumb_path"].ToString();
                            img.original_path = row["original_path"].ToString();

                            imgList.Add(img);
                        }
                    }

                    List<img_entity> videoList = new List<img_entity>();
                    img_entity video = null;
                    if (dtimg.Rows.Count == 0 && dtvideo.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtvideo.Rows)
                        {
                            video = new img_entity();
                            video.id = Convert.ToInt32(row["id"]);
                            video.thumb_path = row["thumb_path"].ToString();
                            video.original_path = row["original_path"].ToString();

                            videoList.Add(video);
                        }
                    }

                    entity.imgList = imgList;
                    entity.videoList = videoList;

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 讨论评论
        private void GetCourseEvaluate()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                BLL.common_evaluate bll = new BLL.common_evaluate();
                DataTable dt = bll.GetListByPage("*", "View_CourseEvaluate", "group_id = " + (int)EnumCollection.evaluate_group.课程问题评论 +
                    " and eval_type = " + (int)EnumCollection.evaluate_type.评论 + " and parent_id = " + id, " add_time desc ", pageIndex, pageSize);

                int count = bll.GetRecordCount("View_CourseEvaluate", "group_id = " + (int)EnumCollection.evaluate_group.课程问题评论 + " and parent_id = " + id);
                List<resource_evaluate_entity> list = new List<resource_evaluate_entity>();
                resource_evaluate_entity entity = null;

                foreach (DataRow item in dt.Rows)
                {
                    entity = new resource_evaluate_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.count = count;
                    entity.user_id = Convert.ToInt32(item["from_user_id"]);
                    entity.avatar = item["from_avatar"].ToString();
                    entity.nick_name = item["from_nick_name"].ToString();
                    entity.contents = item["contents"].ToString();
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    List<reply_entity> replyList = new List<reply_entity>();
                    reply_entity reply = null;
                    DataTable dtreply = bll.GetList("*", "View_CourseEvaluate", " group_id = " + (int)EnumCollection.evaluate_group.课程问题评论 +
                        " and eval_type = " + (int)EnumCollection.evaluate_type.回复 + " and parent_id = " + id + " and data_id = " + entity.id);
                    foreach (DataRow row in dtreply.Rows)
                    {
                        reply = new reply_entity();
                        reply.id = Convert.ToInt32(row["id"]);
                        reply.from_user_id = Convert.ToInt32(row["from_user_id"]);
                        reply.from_nick_name = row["from_nick_name"].ToString();
                        reply.to_user_id = Convert.ToInt32(row["to_user_id"]);
                        reply.to_nick_name = row["to_nick_name"].ToString();
                        reply.contents = row["contents"].ToString();

                        replyList.Add(reply);
                    }

                    entity.replyList = replyList;

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 发表评论/回复
        private void DoEvaluate()
        {
            try
            {
                int group_id = RequestHelper.GetInt("group", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int pid = RequestHelper.GetInt("parent_id", 0);
                int touid = RequestHelper.GetInt("to_user_id", 0);
                int did = RequestHelper.GetInt("data_id", 0);
                int type = RequestHelper.GetInt("type", 1);
                int reply = RequestHelper.GetInt("reply_id", 0);
                string contents = RequestHelper.GetString("contents");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (type == (int)EnumCollection.evaluate_type.回复)
                {
                    if (uid == touid)
                    {
                        writeMsgError("不能回复自己");
                        return;
                    }
                }

                object obj = new object();
                lock (obj)
                {
                    BLL.common_evaluate bll = new BLL.common_evaluate();
                    Model.common_evaluate model = new Model.common_evaluate();
                    model.group_id = group_id;
                    model.eval_type = type;
                    model.parent_id = pid;
                    model.from_user_id = uid;
                    model.to_user_id = touid;
                    model.start = 0;
                    model.contents = contents;
                    model.data_id = did;
                    model.reply_id = reply;
                    model.add_time = System.DateTime.Now;

                    if (bll.Add(model) > 0)
                    {
                        writeMsgSuccessNull("评论成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("评论失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 删除评论
        private void DelEvaluate()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int id = RequestHelper.GetInt("id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.common_evaluate bll = new BLL.common_evaluate();
                Model.common_evaluate model = bll.GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此评论");
                    return;
                }

                if (model.from_user_id != uid)
                {
                    writeMsgError("此评论不是您发的");
                    return;
                }

                if (bll.Delete(id))
                {
                    writeMsgSuccessNull("删除成功");
                }
                else
                {
                    writeMsgError("删除失败");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 获取资源地址
        private void GetResourcePath()
        {
            int id = RequestHelper.GetFormInt("id");
            int uid = RequestHelper.GetFormInt("user_id");

            Model.common_resource model = new BLL.common_resource().GetModel(id);
            if (model != null)
            {
                if (model.is_del == 0)
                {
                    resource_model_entity entity = new resource_model_entity();
                    entity.resource = model;
                    entity.is_collection = new BLL.user_collection().GetRecordCount(string.Format(" group_id = {0} and user_id = {1} and data_id = {2} ",
                        (int)EnumCollection.collection_group.视频资源, uid, model.id)) > 0 ? 1 : 0;

                    writeMsgSuccess("", new List<resource_model_entity>() { entity });
                    return;
                }
                else
                {
                    writeMsgError("没有此资源");
                    return;
                }
            }
            else
            {
                writeMsgError("没有此资源");
                return;
            }
        }
        #endregion

        #region 获取最终资源地址
        private void GetFinalPath()
        {
            try
            {
                string openid = RequestHelper.GetString("openid");
                string decodeurl = RequestHelper.GetString("source_url");

                Utils.StringToTxt("GetFinalPath————openid=" + openid + ",decodeurl=" + decodeurl);
                if (string.IsNullOrEmpty(openid))
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (string.IsNullOrEmpty(decodeurl))
                {
                    writeMsgError("请传入回调地址");
                    return;
                }

                Model.user_oauths oauth = new BLL.user_oauths().GetModel(" appid = '" + openid + "' ");
                if (oauth != null)
                {
                    Model.user_info model = new BLL.user_info().GetModel(oauth.user_id);

                    if (model.school_id == 0)//没有学校，公共资源
                    {
                        writeMsgError(-1, "没有学校，查看公共资源");
                        return;
                    }
                    else//有学校，学校资源
                    {
                        int idindex = decodeurl.IndexOf('=');
                        int mtindex = decodeurl.IndexOf('&');
                        string id = decodeurl.Substring(idindex + 1, mtindex - idindex - 1);

                        BLL.common_resource resBll = new BLL.common_resource();
                        Model.common_resource res = resBll.GetModel(Convert.ToInt32(id));
                        if (res != null)
                        {
                            resource_model_entity entity = new resource_model_entity();
                            if (res.is_del == 1)
                            {
                                writeMsgError(-1, "");
                                return;
                            }
                            if (res.from_id == (int)EnumCollection.resource_from.精品微课)//如果是精品微课的资源
                            {
                                if (res.group_id == (int)EnumCollection.resource_group.公共资源)//若此资源是公共资源，查询此章节下的学校资源
                                {
                                    Model.common_resource newRes = resBll.GetModel(string.Format(" is_del = 0 and from_id = {0} and group_id = {1} and type = {2} and data_id = {3}",
                                         res.from_id, (int)EnumCollection.resource_group.学校资源, res.type, res.data_id));
                                    if (newRes != null)
                                    {
                                        decodeurl = decodeurl.Replace("id=" + id, "id=" + newRes.id);
                                        Utils.StringToTxt("GetFinalPath————学校资源=" + decodeurl);

                                        entity.resource = newRes;
                                        entity.is_collection = new BLL.user_collection().GetRecordCount(string.Format(" group_id = {0} and user_id = {1} and data_id = {2} ",
                                            (int)EnumCollection.collection_group.视频资源, model.id, newRes.id)) > 0 ? 1 : 0;

                                        writeMsgSuccess("", new List<resource_model_entity>() { entity });
                                        return;
                                    }

                                    entity.resource = res;
                                    entity.is_collection = new BLL.user_collection().GetRecordCount(string.Format(" group_id = {0} and user_id = {1} and data_id = {2} ",
                                        (int)EnumCollection.collection_group.视频资源, model.id, res.id)) > 0 ? 1 : 0;

                                    writeMsgSuccess("", new List<resource_model_entity>() { entity });
                                    return;
                                }
                                else if (res.group_id == (int)EnumCollection.resource_group.学校资源)//若此资源是学校资源，判断是否是本学校的
                                {
                                    if (model.school_id != res.school_id)
                                    {
                                        writeMsgError("您没有权限查看此资源");
                                        return;
                                    }
                                    else
                                    {
                                        entity.resource = res;
                                        entity.is_collection = new BLL.user_collection().GetRecordCount(string.Format(" group_id = {0} and user_id = {1} and data_id = {2} ",
                                            (int)EnumCollection.collection_group.视频资源, model.id, res.id)) > 0 ? 1 : 0;

                                        writeMsgSuccess("", new List<resource_model_entity>() { entity });
                                        return;
                                    }
                                }
                            }
                            else if (res.from_id == (int)EnumCollection.resource_from.课堂)//如果是课堂的资源
                            {
                                writeMsgSuccess("", new List<Model.common_resource>() { res });
                                return;
                            }
                        }
                        else
                        {
                            writeMsgError(-1, "");
                            return;
                        }
                    }

                    DataTable dt = GetTableSingle("url", decodeurl);
                    writeMsgSuccess("", dt);
                }
                else
                {
                    writeMsgError("没有此用户");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 获取公共资源地址
        private void GetCommonResourcePath()
        {
            int id = RequestHelper.GetFormInt("id");
            int uid = RequestHelper.GetFormInt("user_id");

            BLL.common_resource bll = new BLL.common_resource();
            Model.common_resource model = bll.GetModel(id);
            if (model != null)
            {
                if (model.is_del == 1)
                {
                    writeMsgError("没有此资源");
                    return;
                }
                if (model.group_id == (int)EnumCollection.resource_group.学校资源)
                {
                    model = bll.GetModel(string.Format(" is_del = 0 and from_id = {0} and group_id = {1} and type = {2} and data_id = {3} ",
                        model.from_id, (int)EnumCollection.resource_group.公共资源, model.type, model.data_id));

                    if (model == null)
                    {
                        writeMsgError("您没有权限查看此资源");
                        return;
                    }
                }

                resource_model_entity entity = new resource_model_entity();
                entity.resource = model;
                entity.is_collection = new BLL.user_collection().GetRecordCount(string.Format(" group_id = {0} and user_id = {1} and data_id = {2} ",
                    (int)EnumCollection.collection_group.视频资源, uid, model.id)) > 0 ? 1 : 0;

                writeMsgSuccess("", new List<resource_model_entity>() { entity });
                return;
            }
            else
            {
                writeMsgError("没有此资源");
                return;
            }
        }
        #endregion

        #region 获取音视频资源评论
        private void GetVideoEvaluate()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                BLL.common_evaluate bll = new BLL.common_evaluate();
                DataTable dt = bll.GetListByPage("*", "View_CourseEvaluate", " group_id = " + (int)EnumCollection.evaluate_group.音视频资源评论 +
                    " and eval_type = " + (int)EnumCollection.evaluate_type.评论 + " and parent_id = " + id, " add_time desc ", pageIndex, pageSize);
                int count = bll.GetRecordCount(" group_id = " + (int)EnumCollection.evaluate_group.音视频资源评论 + " and parent_id = " + id);

                List<resource_evaluate_entity> list = new List<resource_evaluate_entity>();
                resource_evaluate_entity entity = null;

                foreach (DataRow item in dt.Rows)
                {
                    entity = new resource_evaluate_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.count = count;
                    entity.user_id = Convert.ToInt32(item["from_user_id"]);
                    entity.avatar = item["from_avatar"].ToString();
                    entity.nick_name = item["from_nick_name"].ToString();
                    entity.contents = item["contents"].ToString();
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    List<reply_entity> replyList = new List<reply_entity>();
                    reply_entity reply = null;
                    DataTable dtreply = bll.GetList("*", "View_CourseEvaluate", " group_id = " + (int)EnumCollection.evaluate_group.音视频资源评论 +
                        " and eval_type = " + (int)EnumCollection.evaluate_type.回复 + " and parent_id = " + id + " and data_id = " + entity.id);
                    foreach (DataRow row in dtreply.Rows)
                    {
                        reply = new reply_entity();
                        reply.id = Convert.ToInt32(row["id"]);
                        reply.from_user_id = Convert.ToInt32(row["from_user_id"]);
                        reply.from_nick_name = row["from_nick_name"].ToString();
                        reply.to_user_id = Convert.ToInt32(row["to_user_id"]);
                        reply.to_nick_name = row["to_nick_name"].ToString();
                        reply.contents = row["contents"].ToString();

                        replyList.Add(reply);
                    }

                    entity.replyList = replyList;

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 测验详情
        private void GetTestInfo()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                BLL.common_examination bll = new BLL.common_examination();
                Model.common_examination model = bll.GetModel(id);

                if (model == null)
                {
                    writeMsgError("没有此试卷");
                    return;
                }

                DataTable dt = Appoa.DBUtility.DbHelperSQL.Query(" select type from View_TestList where exa_id = " + id + " group by type ").Tables[0];
                string desc = "";
                foreach (DataRow item in dt.Rows)
                {
                    desc += Enum.GetName(typeof(EnumCollection.questions_type), Convert.ToInt32(item["type"])) + "、";
                }

                desc = Utils.DelLastChar(desc, "、");

                test_info_entity entity = new test_info_entity();
                entity.id = model.id;
                entity.name = model.name;
                entity.desc = desc;
                entity.nums = model.nums;
                entity.score = model.score;

                writeMsgSuccess("", new List<test_info_entity>() { entity });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 测验习题
        private void GetTestList()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                BLL.common_answers opBll = new BLL.common_answers();
                BLL.examination_question bll = new BLL.examination_question();
                DataTable dt = bll.GetQuestionByExa(" exa_id = " + id + " order by id ");

                List<test_entity> list = new List<test_entity>();
                test_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new test_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.q_id = Convert.ToInt32(item["q_id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.type_name = Enum.GetName(typeof(EnumCollection.questions_type), entity.type);
                    entity.title = item["title"].ToString();
                    entity.score = Convert.ToInt32(item["score"]);

                    if (entity.type == (int)EnumCollection.questions_type.单选题 ||
                        entity.type == (int)EnumCollection.questions_type.多选题 ||
                        entity.type == (int)EnumCollection.questions_type.判断题)
                    {
                        DataTable dtoptions = opBll.GetList(" question_id = " + entity.q_id);
                        List<options_entity> optionsList = new List<options_entity>();
                        options_entity option = null;
                        foreach (DataRow row in dtoptions.Rows)
                        {
                            option = new options_entity();
                            option.id = Convert.ToInt32(row["id"]);
                            option.no = row["options"].ToString();
                            option.title = row["contents"].ToString();

                            optionsList.Add(option);
                        }

                        entity.optionsList = optionsList;
                    }

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 心理测试详情
        private void GetQuestionnaire()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                Model.common_examination model = new BLL.common_examination().GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此测验");
                    return;
                }

                writeMsgSuccess("", model);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 心理测试题目
        private void GetQuestionnaireList()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                BLL.common_answers opBll = new BLL.common_answers();
                BLL.examination_question bll = new BLL.examination_question();
                DataTable dt = bll.GetQuestionByExa(" exa_id = " + id + " order by id ");

                List<test_entity> list = new List<test_entity>();
                test_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new test_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.q_id = Convert.ToInt32(item["q_id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.type_name = Enum.GetName(typeof(EnumCollection.questions_type), entity.type);
                    entity.title = item["title"].ToString();
                    entity.score = Convert.ToInt32(item["score"]);

                    if (entity.type == (int)EnumCollection.questions_type.单选题 ||
                        entity.type == (int)EnumCollection.questions_type.多选题 ||
                        entity.type == (int)EnumCollection.questions_type.判断题)
                    {
                        DataTable dtoptions = opBll.GetList(" question_id = " + entity.q_id);
                        List<options_entity> optionsList = new List<options_entity>();
                        options_entity option = null;
                        foreach (DataRow row in dtoptions.Rows)
                        {
                            option = new options_entity();
                            option.id = Convert.ToInt32(row["id"]);
                            option.no = row["options"].ToString();
                            option.title = row["contents"].ToString();

                            optionsList.Add(option);
                        }

                        entity.optionsList = optionsList;
                    }

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 心理测试结果
        private void GetQuestionnaireResult()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.common_examination model = new BLL.common_examination().GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此测验");
                    return;
                }

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                Model.answer_result result = new BLL.answer_result().GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} ",
                                            (int)EnumCollection.examination_group.心理测试, uid, id));

                if (result == null)
                {
                    writeMsgError("您还没有答过题");
                    return;
                }

                object data = new
                {
                    title = model.name,
                    descript = model.descript,
                    score = result.score
                };

                writeMsgSuccess("", new List<object>() { data });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 保存用户答题记录
        private void GetExaminationAnswer()
        {
            try
            {
                int group = RequestHelper.GetInt("group", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int exa_id = RequestHelper.GetInt("exa_id", 0);
                int min = RequestHelper.GetInt("min", 0);
                int sec = RequestHelper.GetInt("sec", 0);
                string result = RequestHelper.GetString("result");

                object obj = new object();
                lock (obj)
                {
                    Model.user_info user = new BLL.user_info().GetModel(uid);
                    if (user == null)
                    {
                        writeMsgError("没有此用户");
                        return;
                    }
                    Model.common_examination exa = new BLL.common_examination().GetModel(exa_id);
                    if (exa == null)
                    {
                        writeMsgError("没有此试卷");
                        return;
                    }
                    if (string.IsNullOrEmpty(result))
                    {
                        writeMsgError("没有答案");
                        return;
                    }

                    int point = 2;
                    Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.答题送积分值);
                    if (dict != null)
                    {
                        point = Convert.ToInt32(dict.contents);
                    }
                    else
                    {
                        point = 2;
                    }

                    BLL.answer_result resultbll = new BLL.answer_result();
                    //检查是否完成过本测验
                    Model.answer_result model = null;

                    if (group == (int)EnumCollection.examination_group.精品微课测验)
                    {
                        #region 精品微课、覆盖答题记录
                        int truth_count = 0;
                        int score = 0;
                        int integral = 0;

                        BLL.common_questions qBll = new BLL.common_questions();
                        BLL.common_answers aBll = new BLL.common_answers();

                        List<answer_result_request> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<answer_result_request>>(result);
                        BLL.answer_record bll = new BLL.answer_record();

                        model = resultbll.GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} and status = {3} ",
                            group, uid, exa_id, (int)EnumCollection.correcting_status.已批改));
                        if (model != null)
                        {
                            #region 答过题，则覆盖上一次的答题记录、答题结果
                            foreach (answer_result_request item in list)
                            {
                                Model.answer_record record = bll.GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} and q_id = {3} ",
                                    group, uid, exa_id, item.id));
                                if (record != null)
                                {
                                    record.group_id = group;
                                    record.user_id = uid;
                                    record.exa_id = exa_id;
                                    record.q_id = item.id;
                                    record.answer = item.answer;

                                    Model.common_questions question = qBll.GetModel(record.q_id);

                                    #region 判断对错
                                    if (string.IsNullOrEmpty(item.answer))//没有答题
                                    {
                                        record.is_truth = (int)EnumCollection.YesOrNot.否;
                                        record.score = 0;
                                    }
                                    else
                                    {
                                        if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                                        {
                                            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));
                                            if (anModel.options == question.answer)
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += record.score;
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.多选题)
                                        {
                                            string[] ids = item.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                            string anids = string.Empty;
                                            foreach (string id in ids)
                                            {
                                                Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                                                anids += anModel.options + ",";
                                            }
                                            if (question.answer == Utils.DelLastComma(anids))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                                        {
                                            if (item.answer.Contains(question.answer))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                    }
                                    #endregion

                                    bll.Update(record);
                                }
                                else
                                {
                                    record = new Model.answer_record();
                                    record.group_id = group;
                                    record.user_id = uid;
                                    record.exa_id = exa_id;
                                    record.q_id = item.id;
                                    record.answer = item.answer;

                                    Model.common_questions question = qBll.GetModel(record.q_id);

                                    #region 判断对错
                                    if (string.IsNullOrEmpty(item.answer))//没有答题
                                    {
                                        record.is_truth = (int)EnumCollection.YesOrNot.否;
                                        record.score = 0;
                                    }
                                    else
                                    {
                                        if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                                        {
                                            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));
                                            if (anModel.options == question.answer)
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += record.score;
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.多选题)
                                        {
                                            string[] ids = item.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                            string anids = string.Empty;
                                            foreach (string id in ids)
                                            {
                                                Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                                                anids += anModel.options + ",";
                                            }
                                            if (question.answer == Utils.DelLastComma(anids))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                                        {
                                            if (item.answer.Contains(question.answer))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                    }
                                    #endregion

                                    record.add_time = System.DateTime.Now;

                                    bll.Add(record);
                                }
                            }

                            model.group_id = group;
                            model.exa_id = exa_id;
                            model.exa_title = exa.name;
                            model.user_id = uid;
                            model.avatar = user.avatar;
                            model.nick_name = user.nick_name;
                            model.use_min = min;
                            model.use_sec = sec;
                            model.truth_num = truth_count;
                            model.count = exa.nums;
                            model.truth_ratio = Convert.ToDecimal((decimal)model.truth_num / (decimal)model.count) * 100;
                            model.score = score;
                            model.status = (int)EnumCollection.correcting_status.已批改;
                            model.add_time = System.DateTime.Now;

                            if (resultbll.Update(model))
                            {
                                user.integral += integral;
                                new BLL.user_info().Update(user);
                                AddIntegralRecord(user.id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.答题赠送, integral);

                                writeMsgSuccessNull("提交成功");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            #region 没答过题，新增答题结果

                            foreach (answer_result_request item in list)
                            {
                                Model.answer_record record = new Model.answer_record();
                                record.group_id = group;
                                record.user_id = uid;
                                record.exa_id = exa_id;
                                record.q_id = item.id;
                                record.answer = item.answer;

                                Model.common_questions question = qBll.GetModel(record.q_id);

                                #region 判断对错
                                if (string.IsNullOrEmpty(item.answer))//没有答题
                                {
                                    record.is_truth = (int)EnumCollection.YesOrNot.否;
                                    record.score = 0;
                                }
                                else
                                {
                                    if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                                    {
                                        Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));
                                        if (anModel.options == question.answer)
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.是;
                                            record.score = Convert.ToInt32(question.score);
                                            truth_count++;
                                            score += record.score;
                                            integral += point;
                                        }
                                        else
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.否;
                                            record.score = 0;
                                        }
                                    }
                                    if (question.type == (int)EnumCollection.questions_type.多选题)
                                    {
                                        string[] ids = item.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        string anids = string.Empty;
                                        foreach (string id in ids)
                                        {
                                            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                                            anids += anModel.options + ",";
                                        }
                                        if (question.answer == Utils.DelLastComma(anids))
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.是;
                                            record.score = Convert.ToInt32(question.score);
                                            truth_count++;
                                            score += Convert.ToInt32(question.score);
                                            integral += point;
                                        }
                                        else
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.否;
                                            record.score = 0;
                                        }
                                    }
                                    if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                                    {
                                        if (item.answer.Contains(question.answer))
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.是;
                                            record.score = Convert.ToInt32(question.score);
                                            truth_count++;
                                            score += Convert.ToInt32(question.score);
                                            integral += point;
                                        }
                                        else
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.否;
                                            record.score = 0;
                                        }
                                    }
                                }
                                #endregion

                                record.add_time = System.DateTime.Now;

                                bll.Add(record);
                            }

                            model = new Model.answer_result();
                            model.group_id = group;
                            model.exa_id = exa_id;
                            model.exa_title = exa.name;
                            model.user_id = uid;
                            model.avatar = user.avatar;
                            model.nick_name = user.nick_name;
                            model.use_min = min;
                            model.use_sec = sec;
                            model.truth_num = truth_count;
                            model.count = exa.nums;
                            model.truth_ratio = Convert.ToDecimal((decimal)model.truth_num / (decimal)model.count) * 100;
                            model.score = score;
                            model.status = (int)EnumCollection.correcting_status.已批改;
                            model.add_time = System.DateTime.Now;

                            if (resultbll.Add(model) > 0)
                            {
                                user.integral += integral;
                                new BLL.user_info().Update(user);
                                AddIntegralRecord(user.id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.答题赠送, integral);

                                writeMsgSuccessNull("提交成功");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else if (group == (int)EnumCollection.examination_group.课堂作业)//课堂作业
                    {

                        #region 课堂作业、覆盖答题记录
                        int truth_count = 0;
                        int score = 0;
                        int integral = 0;

                        BLL.common_questions qBll = new BLL.common_questions();
                        BLL.common_answers aBll = new BLL.common_answers();

                        model = resultbll.GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} ",
                                            group, uid, exa_id));
                        List<answer_result_request> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<answer_result_request>>(result);
                        BLL.answer_record bll = new BLL.answer_record();

                        if (model != null)
                        {
                            #region 答过题，则覆盖上一次的答题记录、答题结果
                            foreach (answer_result_request item in list)
                            {
                                Model.answer_record record = bll.GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} and q_id = {3} ",
                                    group, uid, exa_id, item.id));
                                if (record != null)
                                {
                                    record.group_id = group;
                                    record.user_id = uid;
                                    record.exa_id = exa_id;
                                    record.q_id = item.id;
                                    record.answer = item.answer;

                                    #region 判断对错
                                    Model.common_questions question = qBll.GetModel(record.q_id);
                                    if (string.IsNullOrEmpty(item.answer))//没有答题
                                    {
                                        record.is_truth = (int)EnumCollection.YesOrNot.否;
                                        record.score = 0;
                                    }
                                    else
                                    {
                                        if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                                        {
                                            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));
                                            if (anModel.options == question.answer)
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += record.score;
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.多选题)
                                        {
                                            string[] ids = item.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                            string anids = string.Empty;
                                            foreach (string id in ids)
                                            {
                                                Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                                                anids += anModel.options + ",";
                                            }
                                            if (question.answer == Utils.DelLastComma(anids))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                                        {
                                            if (item.answer.Contains(question.answer))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                    }
                                    #endregion

                                    record.add_time = System.DateTime.Now;

                                    bll.Update(record);
                                }
                                else
                                {
                                    record = new Model.answer_record();
                                    record.group_id = group;
                                    record.user_id = uid;
                                    record.exa_id = exa_id;
                                    record.q_id = item.id;
                                    record.answer = item.answer;

                                    #region 判断对错
                                    Model.common_questions question = qBll.GetModel(record.q_id);
                                    if (string.IsNullOrEmpty(item.answer))//没有答题
                                    {
                                        record.is_truth = (int)EnumCollection.YesOrNot.否;
                                        record.score = 0;
                                    }
                                    else
                                    {
                                        if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                                        {
                                            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));
                                            if (anModel.options == question.answer)
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += record.score;
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.多选题)
                                        {
                                            string[] ids = item.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                            string anids = string.Empty;
                                            foreach (string id in ids)
                                            {
                                                Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                                                anids += anModel.options + ",";
                                            }
                                            if (question.answer == Utils.DelLastComma(anids))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                        if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                                        {
                                            if (item.answer.Contains(question.answer))
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                                record.score = Convert.ToInt32(question.score);
                                                truth_count++;
                                                score += Convert.ToInt32(question.score);
                                                integral += point;
                                            }
                                            else
                                            {
                                                record.is_truth = (int)EnumCollection.YesOrNot.否;
                                                record.score = 0;
                                            }
                                        }
                                    }
                                    #endregion

                                    record.add_time = System.DateTime.Now;

                                    bll.Add(record);
                                }
                            }

                            model.group_id = group;
                            model.exa_id = exa_id;
                            model.exa_title = exa.name;
                            model.user_id = uid;
                            model.avatar = user.avatar;
                            model.nick_name = user.nick_name;
                            model.use_min = min;
                            model.use_sec = sec;
                            model.truth_num = truth_count;
                            model.count = exa.nums;
                            model.truth_ratio = Convert.ToDecimal((decimal)model.truth_num / (decimal)model.count) * 100;
                            model.score = score;
                            model.status = (int)EnumCollection.correcting_status.未批改;
                            model.add_time = System.DateTime.Now;

                            if (resultbll.Update(model))
                            {
                                user.integral += integral;
                                new BLL.user_info().Update(user);
                                AddIntegralRecord(user.id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.答题赠送, integral);

                                writeMsgSuccessNull("提交成功，请等待老师批改作业");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            #region 没答过题，新增答题记录、答题结果
                            foreach (answer_result_request item in list)
                            {
                                Model.answer_record record = new Model.answer_record();
                                record.group_id = group;
                                record.user_id = uid;
                                record.exa_id = exa_id;
                                record.q_id = item.id;
                                record.answer = item.answer;

                                #region 判断对错
                                Model.common_questions question = qBll.GetModel(record.q_id);
                                if (string.IsNullOrEmpty(item.answer))//没有答题
                                {
                                    record.is_truth = (int)EnumCollection.YesOrNot.否;
                                    record.score = 0;
                                }
                                else
                                {
                                    if (question.type == (int)EnumCollection.questions_type.单选题 || question.type == (int)EnumCollection.questions_type.判断题)
                                    {
                                        Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));
                                        if (anModel.options == question.answer)
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.是;
                                            record.score = Convert.ToInt32(question.score);
                                            truth_count++;
                                            score += record.score;
                                            integral += point;
                                        }
                                        else
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.否;
                                            record.score = 0;
                                        }
                                    }
                                    if (question.type == (int)EnumCollection.questions_type.多选题)
                                    {
                                        string[] ids = item.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        string anids = string.Empty;
                                        foreach (string id in ids)
                                        {
                                            Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(id));
                                            anids += anModel.options + ",";
                                        }
                                        if (question.answer == Utils.DelLastComma(anids))
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.是;
                                            record.score = Convert.ToInt32(question.score);
                                            truth_count++;
                                            score += Convert.ToInt32(question.score);
                                            integral += point;
                                        }
                                        else
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.否;
                                            record.score = 0;
                                        }
                                    }
                                    if (question.type == (int)EnumCollection.questions_type.填空题 || question.type == (int)EnumCollection.questions_type.主观题)
                                    {
                                        if (item.answer.Contains(question.answer))
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.是;
                                            record.score = Convert.ToInt32(question.score);
                                            truth_count++;
                                            score += Convert.ToInt32(question.score);
                                            integral += point;
                                        }
                                        else
                                        {
                                            record.is_truth = (int)EnumCollection.YesOrNot.否;
                                            record.score = 0;
                                        }
                                    }
                                }
                                #endregion

                                record.add_time = System.DateTime.Now;

                                bll.Add(record);
                            }

                            model = new Model.answer_result();
                            model.group_id = group;
                            model.exa_id = exa_id;
                            model.exa_title = exa.name;
                            model.user_id = uid;
                            model.avatar = user.avatar;
                            model.nick_name = user.nick_name;
                            model.use_min = min;
                            model.use_sec = sec;
                            model.truth_num = truth_count;
                            model.count = exa.nums;
                            model.truth_ratio = Convert.ToDecimal((decimal)model.truth_num / (decimal)model.count) * 100;
                            model.score = score;
                            model.status = (int)EnumCollection.correcting_status.未批改;
                            model.add_time = System.DateTime.Now;

                            if (resultbll.Add(model) > 0)
                            {
                                user.integral += integral;
                                new BLL.user_info().Update(user);
                                AddIntegralRecord(user.id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.答题赠送, integral);

                                writeMsgSuccessNull("提交成功，请等待老师批改作业");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                            #endregion
                        }

                        #endregion
                    }
                    else if (group == (int)EnumCollection.examination_group.心理测试)
                    {
                        #region 心理测试、只有单选题计算分
                        int truth_count = 0;
                        int score = 0;
                        BLL.common_questions qBll = new BLL.common_questions();
                        BLL.common_answers aBll = new BLL.common_answers();

                        model = resultbll.GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} ",
                                            group, uid, exa_id));
                        List<answer_result_request> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<answer_result_request>>(result);
                        BLL.answer_record bll = new BLL.answer_record();

                        if (model != null)
                        {
                            #region 答过题，则覆盖上一次的答题记录、答题结果
                            foreach (answer_result_request item in list)
                            {
                                Model.answer_record record = bll.GetModel(string.Format(" group_id = {0} and user_id = {1} and exa_id = {2} and q_id = {3} ",
                                    group, uid, exa_id, item.id));
                                if (record != null)
                                {
                                    record.group_id = group;
                                    record.user_id = uid;
                                    record.exa_id = exa_id;
                                    record.q_id = item.id;
                                    record.answer = item.answer;
                                    record.is_truth = (int)EnumCollection.YesOrNot.否;
                                    truth_count++;

                                    #region 记录分值
                                    Model.common_questions question = qBll.GetModel(record.q_id);
                                    if (string.IsNullOrEmpty(item.answer))//没有答题
                                    {
                                        record.score = 0;
                                    }
                                    else
                                    {
                                        Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));

                                        record.score = Convert.ToInt32(anModel.score);
                                        score += record.score;
                                    }
                                    #endregion

                                    record.add_time = System.DateTime.Now;

                                    bll.Update(record);
                                }
                                else
                                {
                                    record = new Model.answer_record();
                                    record.group_id = group;
                                    record.user_id = uid;
                                    record.exa_id = exa_id;
                                    record.q_id = item.id;
                                    record.answer = item.answer;
                                    record.is_truth = (int)EnumCollection.YesOrNot.是;
                                    truth_count++;

                                    #region 记录分值
                                    Model.common_questions question = qBll.GetModel(record.q_id);
                                    if (string.IsNullOrEmpty(item.answer))//没有答题
                                    {
                                        record.score = 0;
                                    }
                                    else
                                    {
                                        Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));

                                        record.score = Convert.ToInt32(anModel.score);
                                        score += record.score;
                                    }
                                    #endregion

                                    record.add_time = System.DateTime.Now;

                                    bll.Add(record);
                                }
                            }

                            model.group_id = group;
                            model.exa_id = exa_id;
                            model.exa_title = exa.name;
                            model.user_id = uid;
                            model.avatar = user.avatar;
                            model.nick_name = user.nick_name;
                            model.use_min = 0;
                            model.use_sec = 0;
                            model.truth_num = truth_count;
                            model.count = exa.nums;
                            model.truth_ratio = 100;
                            model.score = score;
                            model.status = (int)EnumCollection.correcting_status.已批改;
                            model.add_time = System.DateTime.Now;

                            if (resultbll.Update(model))
                            {
                                writeMsgSuccessNull("提交成功，请等待老师批改作业");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            #region 没答过题，新增答题记录、答题结果
                            foreach (answer_result_request item in list)
                            {
                                Model.answer_record record = new Model.answer_record();
                                record.group_id = group;
                                record.user_id = uid;
                                record.exa_id = exa_id;
                                record.q_id = item.id;
                                record.answer = item.answer;
                                record.is_truth = (int)EnumCollection.YesOrNot.是;
                                truth_count++;

                                #region 记录分值
                                Model.common_questions question = qBll.GetModel(record.q_id);
                                if (string.IsNullOrEmpty(item.answer))//没有答题
                                {
                                    record.score = 0;
                                }
                                else
                                {
                                    Model.common_answers anModel = aBll.GetModel(Convert.ToInt32(item.answer));

                                    record.score = Convert.ToInt32(anModel.score);
                                    score += record.score;
                                }
                                #endregion

                                record.add_time = System.DateTime.Now;

                                bll.Add(record);
                            }

                            model = new Model.answer_result();
                            model.group_id = group;
                            model.exa_id = exa_id;
                            model.exa_title = exa.name;
                            model.user_id = uid;
                            model.avatar = user.avatar;
                            model.nick_name = user.nick_name;
                            model.use_min = min;
                            model.use_sec = sec;
                            model.truth_num = truth_count;
                            model.count = exa.nums;
                            model.truth_ratio = 100;
                            model.score = score;
                            model.status = (int)EnumCollection.correcting_status.已批改;
                            model.add_time = System.DateTime.Now;

                            if (resultbll.Add(model) > 0)
                            {
                                writeMsgSuccessNull("提交成功，请等待老师批改作业");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询用户答题结果
        private void GetTestResult()
        {
            try
            {
                int exa_id = RequestHelper.GetInt("exa_id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.answer_result model = new BLL.answer_result().GetModel(" exa_id = " + exa_id + " and user_id = " + uid);

                writeMsgSuccess("", new List<Model.answer_result>() { model });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询用户答题结果列表
        private void GetAnswerResult()
        {
            try
            {
                int group = RequestHelper.GetInt("group", 1);
                int exa_id = RequestHelper.GetInt("exa_id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                DataTable dt = new BLL.answer_record().GetList(" group_id = " + group + " and exa_id = " + exa_id + " and user_id = " + uid + " order by id asc ");

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询试题解析
        private void GetQuestionAnalysis()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int group = RequestHelper.GetInt("group", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int count = 0;

                BLL.common_answers opBll = new BLL.common_answers();
                BLL.answer_record reBll = new BLL.answer_record();
                BLL.common_questions qBll = new BLL.common_questions();
                BLL.examination_question bll = new BLL.examination_question();
                Model.common_answers anModel = null;

                DataTable dt = bll.GetQuestionByExa(" exa_id = " + id + " order by id ");

                List<question_analysis_entity> list = new List<question_analysis_entity>();
                question_analysis_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new question_analysis_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.q_id = Convert.ToInt32(item["q_id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.type_name = Enum.GetName(typeof(EnumCollection.questions_type), entity.type);
                    entity.title = item["title"].ToString();
                    entity.score = Convert.ToInt32(item["score"]);

                    Model.answer_record record = reBll.GetModel(" group_id = " + group + " and exa_id = " + id + " and q_id = " + entity.q_id + " and user_id = " + uid + " order by add_time desc");
                    entity.is_truth = record.is_truth;
                    Model.common_questions question = qBll.GetModel(entity.q_id);
                    entity.truth_answer = question.answer;
                    if (entity.type == (int)EnumCollection.questions_type.单选题 || entity.type == (int)EnumCollection.questions_type.判断题)
                    {
                        anModel = opBll.GetModel(" id = " + (string.IsNullOrEmpty(record.answer) ? 0 : Convert.ToInt32(record.answer)));
                        entity.user_answer = anModel == null ? "" : anModel.options;
                    }
                    if (entity.type == (int)EnumCollection.questions_type.多选题)
                    {
                        string[] ids = record.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string anids = string.Empty;
                        foreach (string optionsid in ids)
                        {
                            anModel = opBll.GetModel(" id = " + (string.IsNullOrEmpty(optionsid) ? 0 : Convert.ToInt32(optionsid)));
                            anids += anModel.options + ",";
                        }
                        entity.user_answer = Utils.DelLastComma(anids);
                    }
                    if (entity.type == (int)EnumCollection.questions_type.填空题 || entity.type == (int)EnumCollection.questions_type.主观题)
                    {
                        entity.user_answer = record.answer;
                    }

                    entity.join_count = reBll.GetRecordCount(" q_id = " + entity.q_id);
                    count = reBll.GetRecordCount(" q_id = " + entity.q_id + " and is_truth = " + (int)EnumCollection.YesOrNot.是);
                    entity.truth_ratio = Convert.ToDecimal((decimal)count / (decimal)entity.join_count) * 100;
                    entity.analysis = question.analysis;

                    if (entity.type == (int)EnumCollection.questions_type.单选题 ||
                        entity.type == (int)EnumCollection.questions_type.多选题 ||
                        entity.type == (int)EnumCollection.questions_type.判断题)
                    {
                        DataTable dtoptions = opBll.GetList(" question_id = " + entity.q_id);
                        List<options_entity> optionsList = new List<options_entity>();
                        options_entity option = null;
                        foreach (DataRow row in dtoptions.Rows)
                        {
                            option = new options_entity();
                            option.id = Convert.ToInt32(row["id"]);
                            option.no = row["options"].ToString();
                            option.title = row["contents"].ToString();

                            optionsList.Add(option);
                        }

                        entity.optionsList = optionsList;
                    }

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询测验排名
        private void GetTestRank()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 20);

                DataTable dt = new BLL.answer_result().GetListByPage("*", " exa_id = " + id, " score desc,add_time ", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 分页查询课堂列表
        private void GetClassroomList()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                string whereStr = " is_show = " + (int)EnumCollection.YesOrNot.是;
                whereStr += " or user_id = " + uid;

                DataTable dtids = new BLL.classroom_user().GetList(" user_id = " + uid);
                string ids = string.Empty;
                if (dtids.Rows.Count > 0)
                {
                    foreach (DataRow item in dtids.Rows)
                    {
                        ids += Convert.ToInt32(item["classroom_id"]) + ",";
                    }

                    ids = Utils.DelLastComma(ids);
                    if (!string.IsNullOrEmpty(ids))
                    {
                        whereStr += " or id in (" + ids + ") ";
                    }
                }

                DataTable dt = new BLL.classroom_info().GetListByPage(whereStr, "add_time desc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 搜索课堂
        private void SearchClassroom()
        {
            try
            {
                string keywords = RequestHelper.GetString("keywords");
                if (string.IsNullOrEmpty(keywords))
                {
                    writeMsgError("请传入搜索关键词");
                    return;
                }

                if (Utils.IsSafeSqlString(keywords))
                {
                    try
                    {
                        keywords = Utils.Filter(keywords);
                    }
                    catch
                    {
                        writeMsgError("系统检测到非法字符");
                        return;
                    }
                }
                else
                {
                    writeMsgError("系统检测到非法字符");
                    return;
                }

                string where = " name like '%" + keywords + "%' ";

                DataTable dt = new BLL.classroom_info().GetList(where + " order by add_time desc");

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 创建课堂/编辑课堂
        private void CreateClassroom()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int isshow = RequestHelper.GetInt("isshow", (int)EnumCollection.YesOrNot.是);
                string name = RequestHelper.GetString("name");
                string avatar = RequestHelper.GetString("avatar");
                string info = RequestHelper.GetString("info");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                object obj = new object();
                lock (obj)
                {
                    BLL.classroom_info bll = new BLL.classroom_info();
                    Model.classroom_info model = bll.GetModel(id);
                    if (model == null)
                    {
                        model = new Model.classroom_info();

                        string[] arr = avatar.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 0)
                        {
                            writeMsgError("请上传头像");
                            return;
                        }

                        if (arr.Length == 2)
                        {
                            model.avatar = Base64LoadImg(arr[1], "classroom", "");
                        }
                        else if (arr.Length == 1 && arr[0].Contains("upload"))
                        {
                            model.avatar = avatar;
                        }

                        model.name = name;
                        model.user_id = uid;
                        model.user_name = user.nick_name;
                        model.info = info;
                        model.qrcode = "";
                        model.is_show = isshow;
                        model.add_time = System.DateTime.Now;

                        id = bll.Add(model);
                        if (id > 0)
                        {
                            model.id = id;
                            model.qrcode = "/QrCode.aspx?type=classroom&id=" + id;
                            bll.Update(model);

                            BLL.sys_manager mngBll = new BLL.sys_manager();
                            Model.sys_manager manager = mngBll.GetModel(user.phone, user.user_pwd);
                            if (manager == null)
                            {
                                manager = new Model.sys_manager();
                                manager.role_id = 2;
                                manager.role_type = 2;
                                manager.user_name = user.phone;
                                manager.password = user.user_pwd;
                                manager.salt = user.salt;
                                manager.real_name = user.user_name;
                                manager.telephone = "";
                                manager.email = "";
                                manager.is_lock = 0;
                                manager.add_time = System.DateTime.Now;

                                int mngid = mngBll.Add(manager);
                                Utils.StringToTxt("CreateClassroom————课堂教师后台账号ID------" + mngid);
                            }

                            DataTable dt = GetTable("classroom_id", id + "");

                            writeMsgSuccess("创建成功", dt);
                            return;
                        }
                        else
                        {
                            writeMsgError("创建失败");
                            return;
                        }
                    }
                    else
                    {
                        string[] arr = avatar.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 0)
                        {
                            writeMsgError("请上传头像");
                            return;
                        }

                        if (arr.Length == 2)
                        {
                            model.avatar = Base64LoadImg(arr[1], "classroom", "");
                        }
                        else if (arr.Length == 1 && arr[0].Contains("upload"))
                        {
                            model.avatar = avatar;
                        }

                        model.name = name;
                        model.user_id = uid;
                        model.user_name = user.nick_name;
                        model.info = info;
                        model.is_show = isshow;

                        if (bll.Update(model))
                        {
                            DataTable dt = GetTable("classroom_id", model.id + "");

                            writeMsgSuccessNull("修改成功");
                            return;
                        }
                        else
                        {
                            writeMsgError("修改失败");
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询课堂信息
        private void GetClassroomInfo()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                Model.classroom_info model = new BLL.classroom_info().GetModel(id);
                List<classroom_info_entity> list = new List<classroom_info_entity>();
                if (model != null)
                {
                    classroom_info_entity entity = new classroom_info_entity();
                    entity.id = model.id;
                    entity.user_id = model.user_id;
                    entity.user_name = model.user_name;
                    entity.avatar = model.avatar;
                    entity.name = model.name;
                    entity.info = model.info;
                    entity.qrcode = model.qrcode;
                    entity.is_show = model.is_show;
                    entity.add_time = Convert.ToDateTime(model.add_time).ToString("yyyy-MM-dd");

                    if (entity.user_id == uid)
                    {
                        entity.is_join = 1;//创建者
                    }
                    else
                    {
                        Model.classroom_user cu = new BLL.classroom_user().GetModel(" classroom_id = " + entity.id + " and user_id = " + uid);
                        if (cu != null)
                        {
                            if (cu.status == (int)EnumCollection.examine_status.审核通过)
                            {
                                entity.is_join = 2;//已加入
                            }
                            if (cu.status == (int)EnumCollection.examine_status.审核中)
                            {
                                entity.is_join = 4;//审核中
                            }
                            if (cu.status == (int)EnumCollection.examine_status.审核失败)
                            {
                                entity.is_join = 3;//未加入
                            }
                        }
                        else
                        {
                            entity.is_join = 3;//未加入
                        }
                    }

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 加入课堂
        private void JoinClass()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int cid = RequestHelper.GetInt("classroom_id", 0);
                string contents = RequestHelper.GetString("contents");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                Model.classroom_info classroom = new BLL.classroom_info().GetModel(cid);
                if (classroom == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }

                object obj = new object();
                lock (obj)
                {
                    BLL.classroom_user bll = new BLL.classroom_user();
                    Model.classroom_user model = bll.GetModel(" classroom_id = " + cid + " and user_id = " + uid);
                    if (model != null)
                    {
                        if (model.status == (int)EnumCollection.examine_status.审核中)
                        {
                            writeMsgError("您已提交了加入课堂的申请，请耐心等待老师审核");
                            return;
                        }
                        if (model.status == (int)EnumCollection.examine_status.审核通过)
                        {
                            writeMsgError("您已加入了该课堂");
                            return;
                        }
                        if (model.status == (int)EnumCollection.examine_status.审核失败)
                        {
                            model.contents = contents;
                            model.status = (int)EnumCollection.examine_status.审核中;
                            model.add_time = System.DateTime.Now;

                            if (bll.Update(model))
                            {
                                writeMsgSuccessNull("提交成功");
                                return;
                            }
                            else
                            {
                                writeMsgError("提交失败");
                                return;
                            }
                        }
                    }
                    else
                    {
                        model = new Model.classroom_user();
                        model.classroom_id = cid;
                        model.user_id = uid;
                        model.contents = contents;
                        model.status = (int)EnumCollection.examine_status.审核中;
                        model.add_time = System.DateTime.Now;

                        if (bll.Add(model) > 0)
                        {
                            writeMsgSuccessNull("提交成功");
                            return;
                        }
                        else
                        {
                            writeMsgError("提交失败");
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 直接加入公开课
        private void DirectJoinClass()
        {
            try
            {
                int cid = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                Model.classroom_info classroom = new BLL.classroom_info().GetModel(cid);
                if (classroom == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }

                object obj = new object();
                lock (obj)
                {
                    BLL.classroom_user bll = new BLL.classroom_user();
                    Model.classroom_user model = bll.GetModel(" classroom_id = " + cid + " and user_id = " + uid);
                    if (model != null)
                    {
                        model.contents = "直接加入";
                        model.status = (int)EnumCollection.examine_status.审核通过;

                        if (bll.Update(model))
                        {
                            writeMsgSuccessNull("加入成功");
                            return;
                        }
                        else
                        {
                            writeMsgError("加入失败");
                            return;
                        }
                    }
                    else
                    {
                        model = new Model.classroom_user();
                        model.classroom_id = cid;
                        model.user_id = uid;
                        model.contents = "直接加入";
                        model.status = (int)EnumCollection.examine_status.审核通过;
                        model.add_time = System.DateTime.Now;

                        if (bll.Add(model) > 0)
                        {
                            writeMsgSuccessNull("加入成功");
                            return;
                        }
                        else
                        {
                            writeMsgError("加入失败");
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看课堂公告
        private void GetClassroomNotice()
        {
            try
            {
                int cid = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.classroom_info model = new BLL.classroom_info().GetModel(cid);
                if (model == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }

                DataTable dt = new BLL.common_article().GetListByPage(" group_id = " + (int)EnumCollection.article_group.课堂公告 + " and category_id = " + cid, " add_time desc ", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看课堂公告详情
        private void GetNoticeDetails()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                List<Model.common_article> list = new BLL.common_article().GetModelList(" id = " + id);

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看课堂成员
        private void GetClassroomUsers()
        {
            try
            {
                int cid = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.classroom_info model = new BLL.classroom_info().GetModel(cid);
                if (model == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }

                BLL.classroom_user bll = new BLL.classroom_user();
                DataTable dt = bll.GetListByPage("*", "View_ClassroomVerify", " classroom_id = " + cid + " and status = " + (int)EnumCollection.examine_status.审核通过, " add_time ", pageIndex, pageSize);
                classroom_user_entity entity = new classroom_user_entity();
                int count = bll.GetRecordCount("View_ClassroomVerify", " classroom_id = " + cid + " and status = " + (int)EnumCollection.examine_status.审核通过);
                entity.count = count + 1;
                entity.member = count;

                Model.user_info user = new BLL.user_info().GetModel(model.user_id);
                if (user != null)
                {
                    member_info teacher = new member_info();
                    teacher.user_id = user.id;
                    teacher.avatar = user.avatar;
                    teacher.nick_name = user.nick_name;
                    entity.teacher = teacher;
                }

                List<member_info> list = new List<member_info>();
                member_info member = null;
                foreach (DataRow item in dt.Rows)
                {
                    member = new member_info();
                    member.user_id = Convert.ToInt32(item["user_id"]);
                    member.avatar = item["avatar"].ToString();
                    member.nick_name = item["nick_name"].ToString();

                    list.Add(member);
                }
                entity.memberList = list;

                writeMsgSuccess("", new List<classroom_user_entity>() { entity });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看成员参与课堂
        private void GetMemberClassroom()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                List<member_info_entity> list = new List<member_info_entity>();
                member_info_entity entity = new member_info_entity();
                entity.user_id = uid;
                entity.avatar = user.avatar;
                entity.nick_name = user.nick_name;
                entity.school_name = user.school_name;

                List<classroom_info_entity> classroomList = new List<classroom_info_entity>();
                classroom_info_entity room = null;

                DataTable dtids = new BLL.classroom_user().GetList(" user_id = " + uid);
                string ids = string.Empty;
                foreach (DataRow item in dtids.Rows)
                {
                    ids += Convert.ToInt32(item["classroom_id"]) + ",";
                }

                ids = Utils.DelLastComma(ids);

                string whereStr = " (user_id = " + uid + ") ";
                if (!string.IsNullOrEmpty(ids))
                {
                    whereStr += " or id in (" + ids + ") ";
                }

                DataTable dt = new BLL.classroom_info().GetListByPage(whereStr, "add_time desc", pageIndex, pageSize);
                foreach (DataRow item in dt.Rows)
                {
                    room = new classroom_info_entity();
                    room.id = Convert.ToInt32(item["id"]);
                    room.id = Convert.ToInt32(item["user_id"]);
                    room.user_name = item["user_name"].ToString();
                    room.avatar = item["avatar"].ToString();
                    room.name = item["name"].ToString();
                    room.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");
                    room.info = item["info"].ToString();
                    room.qrcode = item["qrcode"].ToString();
                    room.is_show = Convert.ToInt32(item["is_show"]);
                    room.is_join = 1;

                    classroomList.Add(room);
                }

                entity.classroomList = classroomList;

                list.Add(entity);

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 发布视频
        private void ReleaseVideo()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                string title = RequestHelper.GetString("title");
                string filename = RequestHelper.GetString("filename");
                string path = RequestHelper.GetString("path");

                object obj = new object();
                lock (obj)
                {
                    Model.user_info user = new BLL.user_info().GetModel(uid);
                    if (user == null)
                    {
                        writeMsgError("没有此用户");
                        return;
                    }

                    Model.classroom_info classroom = new BLL.classroom_info().GetModel(id);
                    if (classroom == null)
                    {
                        writeMsgError("没有此课堂");
                        return;
                    }
                    if (classroom.user_id != uid)
                    {
                        writeMsgError("此课堂不属于你");
                        return;
                    }

                    if (string.IsNullOrEmpty(path))
                    {
                        writeMsgError("请选择要发布的视频");
                        return;
                    }
                    if (filename.IndexOf('.') < 0)
                    {
                        writeMsgError("文件名格式错误");
                        return;
                    }

                    BLL.common_resource bll = new BLL.common_resource();
                    Model.common_resource model = new Model.common_resource();

                    model.from_id = (int)EnumCollection.resource_from.课堂;
                    model.group_id = (int)EnumCollection.resource_group.公共资源;
                    model.type = (int)EnumCollection.resource_type.视频资源;
                    model.school_id = 0;
                    model.school_name = "";
                    model.data_id = classroom.id;
                    model.user_id = uid;
                    model.title = title;
                    model.path = Base64LoadVideo(path.Split(',')[1], "video", "");

                    bool flag = VideoThumbHelper.cutVideoThumb(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["FFmpegPath"]), HttpContext.Current.Server.MapPath(model.path), 1);
                    if (flag)
                    {
                        model.cover = model.path.Replace(".mp4", "_thumb.jpg");
                    }
                    else
                    {
                        model.cover = "";
                    }

                    model.file_name = filename.Substring(0, filename.LastIndexOf('.'));
                    model.extend = Utils.GetFileExt(filename);
                    model.likn_url = "";
                    model.share_user = "";
                    model.add_time = System.DateTime.Now;

                    int row = bll.Add(model);
                    if (row > 0)
                    {
                        model.id = row;
                        model.qrcode = "/QrCode.aspx?type=re&id=" + row;

                        bll.Update(model);
                    }

                    writeMsgSuccessNull("发布成功");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 发布知识点
        private void ReleaseArticle()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                string title = RequestHelper.GetString("title");
                string contents = RequestHelper.GetString("contents");
                string path = RequestHelper.GetString("path");

                object obj = new object();
                lock (obj)
                {
                    Model.user_info user = new BLL.user_info().GetModel(uid);
                    if (user == null)
                    {
                        writeMsgError("没有此用户");
                        return;
                    }

                    Model.classroom_info classroom = new BLL.classroom_info().GetModel(id);
                    if (classroom == null)
                    {
                        writeMsgError("没有此课堂");
                        return;
                    }

                    if (classroom.user_id != uid)
                    {
                        writeMsgError("此课堂不属于你");
                        return;
                    }

                    BLL.common_resource bll = new BLL.common_resource();
                    Model.common_resource model = new Model.common_resource();

                    model.from_id = (int)EnumCollection.resource_from.课堂;
                    model.group_id = (int)EnumCollection.resource_group.公共资源;
                    model.type = (int)EnumCollection.resource_type.图文资源;
                    model.school_id = 0;
                    model.school_name = "";
                    model.data_id = classroom.id;
                    model.user_id = uid;
                    model.title = title;
                    model.path = contents;
                    model.cover = "";
                    model.file_name = "";
                    model.extend = "";
                    model.likn_url = "";
                    model.share_user = "";
                    model.add_time = System.DateTime.Now;

                    int row = bll.Add(model);
                    if (row > 0)
                    {
                        model.id = row;
                        model.qrcode = "/QrCode.aspx?type=re&id=" + row;

                        bll.Update(model);

                        if (!string.IsNullOrEmpty(path))
                        {
                            string[] arr = path.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arr.Length <= 3)
                            {
                                BLL.common_albums albll = new BLL.common_albums();
                                Model.common_albums alModel = null;
                                foreach (string item in arr)
                                {
                                    alModel = new Model.common_albums();
                                    alModel.group_id = (int)EnumCollection.img_group.课堂手机端知识点图片;
                                    alModel.rc_type = 0;
                                    alModel.rc_data_id = row;
                                    alModel.original_path = Base64LoadImg(item.Split(',')[1], "", "");
                                    alModel.thumb_path = alModel.original_path;
                                    alModel.remark = "";
                                    alModel.add_time = System.DateTime.Now;

                                    albll.Add(alModel);
                                }
                            }
                        }
                    }

                    writeMsgSuccessNull("发布成功");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看学习资料
        private void GetMaterials()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                Model.classroom_info model = new BLL.classroom_info().GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }

                BLL.common_resource bll = new BLL.common_resource();

                #region 课件资源
                DataTable dtfile = bll.GetListByPage(" from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.文档资源 + " and data_id = " + id, " sort asc ", 1, 2);
                List<course_resource_entity> fileList = new List<course_resource_entity>();
                course_resource_entity file = null;
                foreach (DataRow item in dtfile.Rows)
                {
                    file = new course_resource_entity();
                    file.id = Convert.ToInt32(item["id"]);
                    file.type = Convert.ToInt32(item["type"]);
                    file.cover = item["cover"].ToString();
                    file.title = item["title"].ToString();
                    file.path = item["path"].ToString();
                    if (file.path.LastIndexOf('.') >= 0)
                    {
                        file.path = file.path.Substring(0, file.path.LastIndexOf('.'));
                        file.path = file.path + ".html";
                    }
                    file.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    fileList.Add(file);
                }
                #endregion

                #region 视频资源
                DataTable dtvideo = bll.GetListByPage(" from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.视频资源 + " and data_id = " + id, " sort asc ", 1, 4);
                List<course_resource_entity> videoList = new List<course_resource_entity>();
                course_resource_entity video = null;
                foreach (DataRow item in dtvideo.Rows)
                {
                    video = new course_resource_entity();
                    video.id = Convert.ToInt32(item["id"]);
                    video.type = Convert.ToInt32(item["type"]);
                    video.cover = item["cover"].ToString();
                    video.title = item["title"].ToString();
                    video.path = item["path"].ToString();
                    video.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    videoList.Add(video);
                }
                #endregion

                #region 知识点资源
                DataTable dtarticle = bll.GetListByPage(" from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.图文资源 + " and data_id = " + id, " sort asc ", 1, 2);
                List<course_resource_entity> articleList = new List<course_resource_entity>();
                course_resource_entity article = null;
                foreach (DataRow item in dtarticle.Rows)
                {
                    article = new course_resource_entity();
                    article.id = Convert.ToInt32(item["id"]);
                    article.type = Convert.ToInt32(item["type"]);
                    article.cover = item["cover"].ToString();
                    article.title = item["title"].ToString();
                    article.path = item["path"].ToString();
                    article.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    articleList.Add(article);
                }
                #endregion

                List<course_chapter_entity> workList = new List<course_chapter_entity>();

                string recourseWhere = " from_id = " + (int)EnumCollection.resource_from.课堂 + " and group_id = " + (int)EnumCollection.resource_group.公共资源;

                workList = GetClassWorkList(recourseWhere, id, 0, 2);

                materials_entity entity = new materials_entity();
                entity.user_id = model.user_id;
                entity.fileList = fileList;
                entity.videoList = videoList;
                entity.articleList = articleList;
                entity.workList = workList;

                writeMsgSuccess("", new List<materials_entity>() { entity });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }

        private List<course_chapter_entity> GetClassWorkList(string recourseWhere, int cid, int parentid, int top)
        {
            BLL.course_chapter bll = new BLL.course_chapter();
            DataTable dt = new DataTable();
            if (top > 0)
            {
                dt = bll.GetList(top, " group_id = " + (int)EnumCollection.chapter_group.课堂 + " and course_id = " + cid + " and parent_id = " + parentid, " name ");
            }
            else if (top == 0)
            {
                dt = bll.GetList(" group_id = " + (int)EnumCollection.chapter_group.课堂 + " and course_id = " + cid + " and parent_id = " + parentid + " order by name ");
            }

            List<course_chapter_entity> list = new List<course_chapter_entity>();
            course_chapter_entity entity = null;

            BLL.common_examination exaBll = new BLL.common_examination();
            Model.common_examination exa = null;

            foreach (DataRow item in dt.Rows)
            {
                entity = new course_chapter_entity();
                entity.id = Convert.ToInt32(item["id"]);
                entity.title = item["name"].ToString();

                List<course_resource_entity> resourceList = new List<course_resource_entity>();
                course_resource_entity resource = null;

                exa = exaBll.GetModel(" group_id = " + (int)EnumCollection.examination_group.课堂作业 + " and parent_id = " + entity.id);
                if (exa != null)
                {
                    resource = new course_resource_entity();
                    resource.id = exa.id;
                    resource.title = exa.name;
                    resource.cover = "";
                    resource.type = (int)EnumCollection.resource_type.试卷资源;
                    resource.path = "";
                    resource.add_time = Convert.ToDateTime(exa.add_time).ToString("yyyy-MM-dd");

                    resourceList.Add(resource);
                }

                entity.resourceList = resourceList;
                //entity.childrenList = GetClassWorkList(recourseWhere, cid, entity.id, 0);

                list.Add(entity);
            }

            return list;
        }
        #endregion

        #region 查看课件列表
        private void GetFileList()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                DataTable dt = new BLL.common_resource().GetListByPage(" from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.文档资源 + " and data_id = " + id, " sort asc ", pageIndex, pageSize);
                List<course_resource_entity> list = new List<course_resource_entity>();
                course_resource_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new course_resource_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.cover = item["cover"].ToString();
                    entity.title = item["title"].ToString();
                    entity.path = item["path"].ToString();
                    if (entity.path.LastIndexOf('.') >= 0)
                    {
                        entity.path = entity.path.Substring(0, entity.path.LastIndexOf('.'));
                        entity.path = entity.path + ".html";
                    }
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看视频列表
        private void GetVideoList()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                DataTable dt = new BLL.common_resource().GetListByPage(" from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.视频资源 + " and data_id = " + id, " sort asc ", pageIndex, pageSize);
                List<course_resource_entity> list = new List<course_resource_entity>();
                course_resource_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new course_resource_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.cover = item["cover"].ToString();
                    entity.title = item["title"].ToString();
                    entity.path = item["path"].ToString();
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看知识点列表
        private void GetArticleList()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                BLL.common_albums albll = new BLL.common_albums();
                DataTable dt = new BLL.common_resource().GetListByPage(" from_id = " + (int)EnumCollection.resource_from.课堂 + " and is_del = 0 and type = " + (int)EnumCollection.resource_type.图文资源 + " and data_id = " + id, " sort asc ", pageIndex, pageSize);
                List<course_resource_entity> list = new List<course_resource_entity>();
                course_resource_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new course_resource_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.cover = item["cover"].ToString();
                    entity.title = item["title"].ToString();
                    entity.path = item["path"].ToString();
                    entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd");

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看知识点详情
        private void GetArticleDetails()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                classroom_article_detail detail = new classroom_article_detail();

                Model.common_resource model = new BLL.common_resource().GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此知识点");
                    return;
                }
                if (model.is_del == 1)
                {
                    writeMsgError("没有此知识点");
                    return;
                }

                DataTable dtimg = new BLL.common_albums().GetList(" group_id = " + (int)EnumCollection.img_group.课堂手机端知识点图片 + " and rc_data_id = " + id);
                List<img_entity> imgList = new List<img_entity>();
                img_entity img = null;
                foreach (DataRow row in dtimg.Rows)
                {
                    img = new img_entity();
                    img.id = Convert.ToInt32(row["id"]);
                    img.thumb_path = row["thumb_path"].ToString();
                    img.original_path = row["original_path"].ToString();

                    imgList.Add(img);
                }

                detail.model = model;
                detail.imgList = imgList;

                writeMsgSuccess("", new List<classroom_article_detail>() { detail });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看作业列表
        private void GetWorkList()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                List<course_chapter_entity> list = new List<course_chapter_entity>();

                string recourseWhere = " from_id = " + (int)EnumCollection.resource_from.课堂 + " and group_id = " + (int)EnumCollection.resource_group.公共资源;

                list = GetClassWorkList(recourseWhere, id, 0, 0);

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 解散(删除)课堂
        private void DelClassroom()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int cid = RequestHelper.GetInt("classroom_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.classroom_info bll = new BLL.classroom_info();
                Model.classroom_info model = bll.GetModel(cid);
                if (model == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }
                if (model.user_id != uid)
                {
                    writeMsgError("此课堂不是你创建的");
                    return;
                }

                if (bll.Delete(model.id))
                {
                    //删除关系表
                    new BLL.classroom_user().DeleteByWhere(" classroom_id = " + cid);

                    writeMsgSuccessNull("解散成功");
                    return;
                }
                else
                {
                    writeMsgError("解散失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 退出课堂
        private void ExitClassroom()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int cid = RequestHelper.GetInt("classroom_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                Model.classroom_info model = new BLL.classroom_info().GetModel(cid);
                if (model == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }

                if (new BLL.classroom_user().DeleteByWhere(" classroom_id = " + cid + " and user_id = " + uid))
                {
                    writeMsgSuccessNull("解散成功");
                    return;
                }
                else
                {
                    writeMsgError("解散失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询商城首页数据
        private void GetShopIndexData()
        {
            try
            {
                shop_index_goods entity = new shop_index_goods();

                DataTable dt = new BLL.common_adR().GetList(" ad_group_id = " + (int)EnumCollection.adR_group.商城轮播图 + " order by ad_sort_id asc ");
                List<banner_entity> bannerList = new List<banner_entity>();
                banner_entity banner = null;
                foreach (DataRow item in dt.Rows)
                {
                    banner = new banner_entity();
                    banner.img_url = item["ad_data_img"].ToString();
                    banner.data_id = Convert.ToInt32(item["ad_data_id"]);
                    banner.data_url = item["ad_data_url"].ToString();

                    bannerList.Add(banner);
                }

                entity.bannerList = bannerList;

                dt = new BLL.goods_goods().GetListByPage("*", "View_IndexGoods", " ad_group_id = " + (int)EnumCollection.adR_group.教育商城推荐商品 + " and status = " + (int)EnumCollection.sales_status.上架, " add_time desc ", 1, 6);
                List<index_goods_info> eduGoodsList = new List<index_goods_info>();
                index_goods_info goods = null;
                foreach (DataRow item in dt.Rows)
                {
                    goods = new index_goods_info();
                    goods.id = Convert.ToInt32(item["id"]);
                    goods.img_src = item["img_src"].ToString();
                    goods.title = item["title"].ToString();
                    goods.subtitle = item["subtitle"].ToString();
                    goods.price = Convert.ToDecimal(item["price"]);

                    eduGoodsList.Add(goods);
                }

                entity.eduGoodsList = eduGoodsList;

                dt = new BLL.goods_goods().GetListByPage("*", "View_IndexGoods", " ad_group_id = " + (int)EnumCollection.adR_group.积分商城推荐商品 + " and status = " + (int)EnumCollection.sales_status.上架, " add_time desc ", 1, 6);
                List<index_goods_info> pointGoodsList = new List<index_goods_info>();
                foreach (DataRow item in dt.Rows)
                {
                    goods = new index_goods_info();
                    goods.id = Convert.ToInt32(item["id"]);
                    goods.img_src = item["img_src"].ToString();
                    goods.title = item["title"].ToString();
                    goods.subtitle = item["subtitle"].ToString();
                    goods.price = Convert.ToDecimal(item["price"]);

                    pointGoodsList.Add(goods);
                }

                entity.pointGoodsList = pointGoodsList;

                writeMsgSuccess("", new List<shop_index_goods>() { entity });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询一级商品分类
        private void GetFirstCategory()
        {
            try
            {
                DataTable dt = new BLL.common_category().GetList(" group_id = " + (int)EnumCollection.category_group.商城 + " and category_level = 1 and parent_id = 0");

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询二级商品分类
        private void GetSecondCategory()
        {
            try
            {
                int pid = RequestHelper.GetInt("parent_id", 0);

                string whereStr = " group_id = " + (int)EnumCollection.category_group.商城 + " and category_level = 2 ";
                if (pid > 0)
                {
                    whereStr += " and parent_id = " + pid;
                }

                DataTable dt = new BLL.common_category().GetList(whereStr);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 根据分类查询商品
        private void GetGoodsByCategory()
        {
            try
            {
                int cid = RequestHelper.GetInt("category", 0);
                int group = RequestHelper.GetInt("group_id", 1);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                string whereStr = " group_id = " + group + " and status = " + (int)EnumCollection.sales_status.上架;

                if (cid > 0)
                {
                    Model.common_category cate = new BLL.common_category().GetModel(cid);
                    if (cate == null)
                    {
                        writeMsgError("请传入正确的分类");
                        return;
                    }
                    if (cate.category_level == 1)
                    {
                        DataTable dtids = new BLL.common_category().GetList(" parent_id = " + cate.id);
                        string ids = string.Empty;
                        foreach (DataRow item in dtids.Rows)
                        {
                            ids += Convert.ToInt32(item["id"]) + ",";
                        }

                        ids = Utils.DelLastComma(ids);

                        if (!string.IsNullOrEmpty(ids))
                        {
                            whereStr += " and category_id in (" + ids + ") ";
                        }
                    }
                    else
                    {
                        whereStr += " and category_id = " + cid;
                    }
                }

                DataTable dt = new BLL.goods_goods().GetListByPage(whereStr, " add_time desc ", pageIndex, pageSize);
                List<index_goods_info> goodsList = new List<index_goods_info>();
                index_goods_info goods = null;
                foreach (DataRow item in dt.Rows)
                {
                    goods = new index_goods_info();
                    goods.id = Convert.ToInt32(item["id"]);
                    goods.img_src = item["img_src"].ToString();
                    goods.title = item["title"].ToString();
                    goods.subtitle = item["subtitle"].ToString();
                    goods.price = Convert.ToDecimal(item["price"]);

                    goodsList.Add(goods);
                }

                writeMsgSuccess("", goodsList);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询商品详情
        private void GetGoodsDetail()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.goods_goods model = new BLL.goods_goods().GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此商品");
                    return;
                }
                Model.user_info user = new BLL.user_info().GetModel(uid);

                goods_detail_entity entity = new goods_detail_entity();
                entity.id = model.id;
                entity.group_id = model.group_id;
                entity.title = model.title;
                entity.price = model.price;
                entity.details = model.details;
                entity.parameters = model.parameters;

                Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.平台运费);
                if (dict == null)
                {
                    entity.express_money = 10;
                }
                else
                {
                    entity.express_money = Convert.ToInt32(dict.contents);
                }

                entity.integral = user == null ? 0 : user.integral;
                entity.cart_num = new BLL.user_cart().GetRecordSum("num", " user_id = " + uid);

                DataTable dt = new BLL.common_albums().GetList(" group_id = " + (int)EnumCollection.img_group.商品轮播图 + " and rc_data_id = " + entity.id);
                List<img_entity> imgList = new List<img_entity>();
                img_entity img = null;
                foreach (DataRow item in dt.Rows)
                {
                    img = new img_entity();
                    img.id = Convert.ToInt32(item["id"]);
                    img.thumb_path = item["thumb_path"].ToString();
                    img.original_path = item["original_path"].ToString();

                    imgList.Add(img);
                }
                entity.imgList = imgList;

                entity.specItemList = getItemList(entity.id, 0);

                writeMsgSuccess("", new List<goods_detail_entity>() { entity });
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
            }
        }

        /// <summary>
        /// 递归查询商品规格列表
        /// </summary>
        /// <param name="goodsid"></param>
        /// <param name="parentid"></param>
        /// <returns></returns>
        private List<goods_spec> getItemList(int goodsid, int parentid)
        {
            BLL.goods_spec_item bll = new BLL.goods_spec_item();
            List<goods_spec> lists = new List<goods_spec>();
            goods_spec entity = null;

            DataTable dt = bll.GetListByParentId(goodsid, parentid);

            foreach (DataRow row in dt.Rows)
            {
                entity = new goods_spec();
                entity.spec_id = Convert.ToInt32(row["id"]);
                entity.spec_name = row["name"].ToString();
                entity.sort = Convert.ToInt32(row["sort"]);
                entity.itemList = getItemList(goodsid, Convert.ToInt32(row["id"]));

                lists.Add(entity);
            }

            return lists;
        }
        #endregion

        #region 查询规格种类
        private void GetSpecType()
        {
            try
            {
                int itemid = RequestHelper.GetInt("itemid", 0);

                Model.goods_spec_item item = new BLL.goods_spec_item().GetModel(itemid);
                if (item != null)//规格项
                {
                    List<Model.goods_spec_type> list = new BLL.goods_spec_type().GetModelList(" spec = " + itemid);
                    if (list.Count > 0)//规格种类
                    {
                        writeMsgSuccess("", list);
                        return;
                    }
                    else
                    {
                        writeMsgError("没有此规格");
                        return;
                    }
                }
                else
                {
                    writeMsgError("没有此规格");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看商品评论
        private void GetGoodsEvaluate()
        {
            try
            {
                int gid = RequestHelper.GetInt("goods_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                DataTable dtids = new BLL.user_ordergoods().GetList(" goods_id = " + gid);
                string ids = string.Empty;
                foreach (DataRow item in dtids.Rows)
                {
                    ids += Convert.ToInt32(item["id"]) + ",";
                }

                ids = Utils.DelLastComma(ids);

                if (string.IsNullOrEmpty(ids))
                {
                    writeMsgError(300, "没有评论");
                    return;
                }

                BLL.common_evaluate bll = new BLL.common_evaluate();
                string whereStr = " group_id = " + (int)EnumCollection.evaluate_group.订单商品评价 + " and parent_id in (" + ids + ") ";

                int count = bll.GetRecordCount("View_GoodsEvaluate", whereStr);
                int avg = bll.GetRecordAvg("View_GoodsEvaluate", whereStr);

                goods_evaluate_entity entity = new goods_evaluate_entity();
                entity.count = count;
                entity.avg_star = avg;

                List<goods_evaluate> list = new List<goods_evaluate>();
                goods_evaluate goods = null;
                DataTable dt = bll.GetListByPage("*", "View_GoodsEvaluate", whereStr, "add_time desc", pageIndex, pageSize);
                foreach (DataRow item in dt.Rows)
                {
                    goods = new goods_evaluate();
                    goods.avatar = item["from_avatar"].ToString();
                    goods.nick_name = item["from_nick_name"].ToString();
                    goods.contents = item["contents"].ToString();
                    goods.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    goods.star = Convert.ToInt32(item["start"]);

                    list.Add(goods);
                }

                entity.evalList = list;

                writeMsgSuccess("", entity);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 加入购物车
        private void AddToCart()
        {
            try
            {
                int gid = RequestHelper.GetInt("gid", 0);
                int specid = RequestHelper.GetInt("specid", 0);
                int nums = RequestHelper.GetInt("nums", 1);
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.goods_goods goods = new BLL.goods_goods().GetModel(gid);
                if (goods == null)
                {
                    writeMsgError("没有此商品");
                    return;
                }
                Model.goods_spec_type spectype = new BLL.goods_spec_type().GetModel(specid);
                if (spectype == null)
                {
                    writeMsgError("没有此规格");
                    return;
                }

                #region 查询规格字符串
                string temp = string.Empty;
                BLL.goods_spec_item itemBll = new BLL.goods_spec_item();
                Model.goods_spec_item itemModel = itemBll.GetModel(spectype.spec);
                if (itemModel != null)
                {
                    Model.goods_spec_item parentModel = itemBll.GetModel(itemModel.parent_id);
                    if (parentModel != null)
                    {
                        temp = parentModel.name + ":" + itemModel.name;
                    }
                    else
                    {
                        writeMsgError("没有此父级规格");
                        return;
                    }
                }
                else
                {
                    writeMsgError("没有此规格项");
                    return;
                }
                #endregion

                BLL.user_cart bll = new BLL.user_cart();
                Model.user_cart model = bll.GetModel(string.Format(" user_id = {0} and goods_id = {1} and goods_spec_id = {2} ", uid, gid, specid));
                if (model != null)
                {
                    model.group_id = goods.group_id;
                    model.user_id = uid;
                    model.goods_id = gid;
                    model.goods_name = goods.title;
                    model.goods_subtitle = goods.subtitle;
                    model.goods_img = goods.img_src;
                    model.goods_oprice = goods.oprice;
                    model.goods_price = spectype.price;
                    model.goods_spec_id = specid + "";
                    model.goods_spec = temp;
                    model.num += nums;

                    if (bll.Update(model))
                    {
                        int count = bll.GetRecordSum("num", " user_id = " + uid);
                        DataTable dt = GetTable("cart_num", count + "");
                        writeMsgSuccess("加入购物车成功", dt);
                        return;
                    }
                    else
                    {
                        writeMsgError("加入购物车失败");
                        return;
                    }
                }
                else
                {
                    model = new Model.user_cart();
                    model.ct_id = 0;
                    model.group_id = goods.group_id;
                    model.user_id = uid;
                    model.goods_sale_type = 0;
                    model.goods_id = gid;
                    model.goods_name = goods.title;
                    model.goods_subtitle = goods.subtitle;
                    model.goods_img = goods.img_src;
                    model.goods_oprice = goods.oprice;
                    model.goods_price = spectype.price;
                    model.goods_spec_id = specid + "";
                    model.goods_spec = temp;
                    model.num = nums;
                    model.add_time = System.DateTime.Now;

                    int id = bll.Add(model);
                    if (id > 0)
                    {
                        int count = bll.GetRecordSum("num", " user_id = " + uid);
                        DataTable dt = GetTable("cart_num", count + "");
                        writeMsgSuccess("加入购物车成功", dt);
                        return;
                    }
                    else
                    {
                        writeMsgError("加入购物车失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
            }
        }
        #endregion

        #region 查看购物车
        private void GetCartList()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);

                DataTable dt = new BLL.user_cart().GetList(" user_id = " + uid + " order by add_time ");

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 更改购物车商品数量
        private void UpdateGoodsNum()
        {
            try
            {
                int cid = RequestHelper.GetInt("cartid", 0);
                string method = RequestHelper.GetString("method");
                int num = RequestHelper.GetInt("num", 1);

                BLL.user_cart bll = new BLL.user_cart();
                Model.user_cart cart = bll.GetModel(cid);
                if (cart == null)
                {
                    writeMsgError("此购物车记录不存在");
                    return;
                }
                if (num < 1)
                {
                    num = 1;
                }

                if (method == "add")
                {
                    cart.num++;
                }
                if (method == "sub")
                {
                    cart.num--;
                }
                if (method == "upd")
                {
                    cart.num = num;
                }

                if (bll.Update(cart))
                {
                    DataTable dt = GetTable("nums", cart.num + "");
                    writeMsgSuccess("修改成功", dt);
                }
                else
                {
                    writeMsgError("修改失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 删除购物车商品
        private void DelCartGoods()
        {
            try
            {
                string ids = RequestHelper.GetString("ids");
                int uid = RequestHelper.GetInt("user_id", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 0)
                {
                    writeMsgError("请选择要删除的商品");
                    return;
                }

                bool flag = new BLL.user_cart().DeleteListByWhere(" user_id = " + uid + " and id in (" + ids + ") ");
                if (flag)
                {
                    writeMsgSuccessNull("删除成功");
                    return;
                }
                else
                {
                    writeMsgError("删除失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 添加地址
        private void AddUserAddress()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string name = RequestHelper.GetString("name");
                string phone = RequestHelper.GetString("phone");
                string area = RequestHelper.GetString("area");
                string address = RequestHelper.GetString("address");
                int is_default = RequestHelper.GetInt("is_default", 2);

                object obj = new object();
                lock (obj)
                {
                    var user_address_time = CacheHelper.Get("user_" + uid + "_address");
                    if (user_address_time != null)
                    {
                        if (Convert.ToInt32(user_address_time) == uid)
                        {
                            writeMsgError("10s内不可重复操作");
                            return;
                        }
                    }

                    CacheHelper.InsertDateTime("user_" + uid + "_address", uid, 10);

                    string[] areaArr = area.Split(',');
                    Model.user_address model = new Model.user_address();
                    model.type = 0;
                    model.type_name = "";
                    model.user_id = uid;
                    model.name = name;
                    model.mobile = phone;
                    model.tel = "";
                    model.sheng = areaArr.Length > 0 ? areaArr[0] : "";
                    model.shi = areaArr.Length > 1 ? areaArr[1] : "";
                    model.xian = areaArr.Length > 2 ? areaArr[2] : "";
                    model.area = area.Replace(",", "");
                    model.address = address;
                    model.postcode = "";
                    model.IDCard = "";
                    model.is_default = is_default;
                    model.add_time = System.DateTime.Now;

                    BLL.user_address bll = new BLL.user_address();
                    int id = bll.Add(model);
                    if (id > 0)
                    {
                        if (is_default == (int)EnumCollection.YesOrNot.是)
                        {
                            bll.SetDefault(uid, id);
                        }

                        user_address_entity entity = new user_address_entity();
                        entity.id = id;
                        entity.name = model.name;
                        entity.phone = model.mobile;
                        entity.address = model.area + model.address;
                        entity.is_default = model.is_default;

                        writeMsgSuccess("添加成功", entity);
                    }
                    else
                    {
                        writeMsgError("添加失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看地址列表
        private void GetAdderssList()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                DataTable dt = new BLL.user_address().GetListByPage(" user_id = " + uid, " is_default asc,add_time desc ", pageIndex, pageSize);
                List<user_address_entity> list = new List<user_address_entity>();
                user_address_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new user_address_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.name = item["name"].ToString();
                    entity.phone = item["mobile"].ToString();
                    entity.address = item["area"].ToString() + item["address"].ToString();
                    entity.is_default = Convert.ToInt32(item["is_default"]);

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 设置默认地址
        private void SetDefaultAddress()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int aid = RequestHelper.GetInt("aid", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.user_address bll = new BLL.user_address();
                Model.user_address model = bll.GetModel(aid);
                if (model == null)
                {
                    writeMsgError("没有此地址");
                    return;
                }
                if (model.user_id != uid)
                {
                    writeMsgError("此地址不属于此用户");
                    return;
                }

                if (bll.SetDefault(uid, aid))
                {
                    writeMsgSuccessNull("设置成功");
                    return;
                }
                else
                {
                    writeMsgError("设置失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查询地址信息
        private void GetAddressInfo()
        {
            try
            {
                int aid = RequestHelper.GetInt("aid", 0);

                Model.user_address model = new BLL.user_address().GetModel(aid);
                if (model == null)
                {
                    writeMsgError("没有此地址");
                    return;
                }

                writeMsgSuccess("", model);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 编辑地址
        private void EditAddress()
        {
            try
            {
                int aid = RequestHelper.GetInt("aid", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                string name = RequestHelper.GetString("name");
                string phone = RequestHelper.GetString("phone");
                string area = RequestHelper.GetString("area");
                string address = RequestHelper.GetString("address");

                BLL.user_address bll = new BLL.user_address();
                Model.user_address model = null;
                string[] areaArr = area.Split(',');

                if (aid == 0)
                {
                    model = new Model.user_address();
                    model.type = 0;
                    model.type_name = "";
                    model.user_id = uid;
                    model.name = name;
                    model.mobile = phone;
                    model.tel = "";
                    model.sheng = areaArr.Length > 0 ? areaArr[0] : "";
                    model.shi = areaArr.Length > 1 ? areaArr[1] : "";
                    model.xian = areaArr.Length > 2 ? areaArr[2] : "";
                    model.area = area.Replace(",", "");
                    model.address = address;
                    model.postcode = "";
                    model.IDCard = "";
                    model.is_default = (int)EnumCollection.YesOrNot.否;
                    model.add_time = System.DateTime.Now;

                    if (bll.Add(model) > 0)
                    {
                        writeMsgSuccessNull("添加成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("添加失败");
                        return;
                    }
                }
                else if (aid > 0)
                {
                    model = bll.GetModel(aid);
                    if (model == null)
                    {
                        writeMsgError("没有此地址");
                        return;
                    }

                    model.name = name;
                    model.mobile = phone;
                    model.sheng = areaArr.Length > 0 ? areaArr[0] : "";
                    model.shi = areaArr.Length > 1 ? areaArr[1] : "";
                    model.xian = areaArr.Length > 2 ? areaArr[2] : "";
                    model.area = area.Replace(",", "");
                    model.address = address;

                    if (bll.Update(model))
                    {
                        writeMsgSuccessNull("修改成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("修改失败");
                        return;
                    }
                }

                writeMsgSuccess("", model);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 删除地址
        private void DelAddress()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int aid = RequestHelper.GetInt("aid", 0);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.user_address bll = new BLL.user_address();
                Model.user_address model = bll.GetModel(aid);
                if (model == null)
                {
                    writeMsgError("没有此地址");
                    return;
                }
                if (model.user_id != uid)
                {
                    writeMsgError("此地址不属于此用户");
                    return;
                }

                if (bll.Delete(aid))
                {
                    writeMsgSuccessNull("删除成功");
                    return;
                }
                else
                {
                    writeMsgError("删除失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 确认订单
        private void ConfirmOrder()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string ids = RequestHelper.GetString("ids");
                string from = RequestHelper.GetString("from");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.user_address uaBll = new BLL.user_address();
                BLL.goods_goods ggBll = new BLL.goods_goods();
                Model.goods_goods ggModel = null;

                confirm_order_entity entity = new confirm_order_entity();

                Model.user_address address = uaBll.GetModel(" user_id = " + uid + " and is_default = " + (int)EnumCollection.YesOrNot.是);
                if (address == null)
                {
                    List<Model.user_address> addressList = uaBll.GetModelList(" user_id = " + uid + " order by add_time desc ");
                    if (addressList.Count > 0)
                    {
                        address = addressList[0];
                    }
                }

                if (address != null)
                {
                    user_address_entity defaultAddress = new user_address_entity();
                    defaultAddress.id = address.id;
                    defaultAddress.name = address.name;
                    defaultAddress.phone = address.mobile;
                    defaultAddress.address = address.area + address.address;
                    defaultAddress.is_default = address.is_default;

                    entity.defaultAddress = defaultAddress;
                }

                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                decimal total = 0M;
                decimal integral = 0;
                int count = 0;
                List<order_goods_entity> goodsList = new List<order_goods_entity>();
                order_goods_entity goods = null;
                if (from == "cart")
                {
                    if (arr.Length == 0)
                    {
                        writeMsgError("请选择要结算的商品");
                        return;
                    }

                    BLL.user_cart bll = new BLL.user_cart();
                    DataTable dt = bll.GetList(" user_id = " + uid + " and id in (" + ids + ") ");

                    foreach (DataRow item in dt.Rows)
                    {
                        goods = new order_goods_entity();
                        goods.id = Convert.ToInt32(item["goods_id"]);
                        goods.group = Convert.ToInt32(item["group_id"]);
                        goods.img_src = item["goods_img"].ToString();
                        goods.title = item["goods_name"].ToString();
                        goods.price = Convert.ToDecimal(item["goods_price"]);
                        goods.spec = item["goods_spec"].ToString();
                        goods.num = Convert.ToInt32(item["num"]);

                        ggModel = ggBll.GetModel(goods.id);
                        if (ggModel == null)
                        {
                            writeMsgError("商品 " + goods.title + " 不存在");
                            return;
                        }

                        if (goods.group == (int)EnumCollection.goods_group.教育商城)
                        {
                            total += goods.price * goods.num;
                        }
                        else
                        {
                            integral += goods.price;
                        }

                        count += goods.num;

                        goodsList.Add(goods);
                    }
                }
                if (from == "buy")
                {
                    if (arr.Length != 3)
                    {
                        writeMsgError("请选择要购买的商品");
                        return;
                    }

                    int gid = Convert.ToInt32(arr[0]);//商品ID
                    int specid = Convert.ToInt32(arr[1]);//规格种类ID
                    int num = Convert.ToInt32(arr[2]);//购买数量

                    ggModel = ggBll.GetModel(gid);
                    if (ggModel == null)
                    {
                        writeMsgError("没有此商品");
                        return;
                    }
                    Model.goods_spec_type spectype = new BLL.goods_spec_type().GetModel(specid);
                    if (spectype == null)
                    {
                        writeMsgError("没有此规格");
                        return;
                    }

                    #region 查询规格字符串
                    string temp = string.Empty;
                    BLL.goods_spec_item itemBll = new BLL.goods_spec_item();
                    Model.goods_spec_item itemModel = itemBll.GetModel(spectype.spec);
                    if (itemModel != null)
                    {
                        Model.goods_spec_item parentModel = itemBll.GetModel(itemModel.parent_id);
                        if (parentModel != null)
                        {
                            temp = parentModel.name + ":" + itemModel.name;
                        }
                        else
                        {
                            writeMsgError("没有此父级规格");
                            return;
                        }
                    }
                    else
                    {
                        writeMsgError("没有此规格项");
                        return;
                    }
                    #endregion

                    goods = new order_goods_entity();
                    goods.id = ggModel.id;
                    goods.group = ggModel.group_id;
                    goods.img_src = ggModel.img_src;
                    goods.title = ggModel.title;
                    goods.price = spectype.price;
                    goods.spec = temp;
                    goods.num = num;

                    goodsList.Add(goods);
                    if (goods.group == (int)EnumCollection.goods_group.教育商城)
                    {
                        total = goods.price * goods.num;
                    }
                    else
                    {
                        integral = goods.price * goods.num;
                    }

                    count = num;
                }

                entity.goodsList = goodsList;
                entity.total_price = total;
                entity.total_integral = integral;
                entity.has_integral = user.integral;
                entity.count = count;

                Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.平台运费);
                if (dict == null)
                {
                    entity.express_money = 10;
                }
                else
                {
                    entity.express_money = Convert.ToInt32(dict.contents);
                }

                writeMsgSuccess("", new List<confirm_order_entity>() { entity });
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 提交订单
        private void AddOrder()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int aid = RequestHelper.GetInt("aid", 0);
                string cids = RequestHelper.GetString("cids");
                decimal price = RequestHelper.GetDecimal("price", 0M);
                int integral = RequestHelper.GetInt("integral", 0);
                string remark = RequestHelper.GetString("remark");
                string from = RequestHelper.GetString("from");

                BLL.user_info ubll = new BLL.user_info();
                Model.user_info user = ubll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                Model.user_address address = new BLL.user_address().GetModel(aid);
                if (address == null)
                {
                    writeMsgError("没有此地址");
                    return;
                }
                if (integral > user.integral)
                {
                    writeMsgError("您拥有的积分不足，无法购买");
                    return;
                }

                string[] arr = cids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                BLL.user_cart cbll = new BLL.user_cart();

                string orderNo = string.Empty;
            cr: orderNo = Utils.GetOrderNumber();

                BLL.user_order bll = new BLL.user_order();
                Model.user_order model = bll.GetModel(" order_no = '" + orderNo + "' ");
                if (model != null)
                {
                    goto cr;
                }

                decimal express_money = 0M;
                Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.平台运费);
                if (dict == null)
                {
                    express_money = 10;
                }
                else
                {
                    express_money = Convert.ToDecimal(dict.contents);
                }

                BLL.goods_goods ggBll = new BLL.goods_goods();
                BLL.user_ordergoods ogBll = new BLL.user_ordergoods();
                Model.goods_goods goods = null;
                Model.user_ordergoods ogModel = null;

                if (from == "buy")
                {
                    if (arr.Length != 3)
                    {
                        writeMsgError("请选择要购买的商品");
                        return;
                    }

                    int gid = Convert.ToInt32(arr[0]);//商品ID
                    int specid = Convert.ToInt32(arr[1]);//规格种类ID
                    int num = Convert.ToInt32(arr[2]);//购买数量

                    goods = ggBll.GetModel(gid);
                    if (goods == null)
                    {
                        writeMsgError("没有此商品");
                        return;
                    }
                    Model.goods_spec_type spectype = new BLL.goods_spec_type().GetModel(specid);
                    if (spectype == null)
                    {
                        writeMsgError("没有此规格");
                        return;
                    }

                    #region 查询规格字符串
                    string temp = string.Empty;
                    BLL.goods_spec_item itemBll = new BLL.goods_spec_item();
                    Model.goods_spec_item itemModel = itemBll.GetModel(spectype.spec);
                    if (itemModel != null)
                    {
                        Model.goods_spec_item parentModel = itemBll.GetModel(itemModel.parent_id);
                        if (parentModel != null)
                        {
                            temp = parentModel.name + ":" + itemModel.name;
                        }
                        else
                        {
                            writeMsgError("没有此父级规格");
                            return;
                        }
                    }
                    else
                    {
                        writeMsgError("没有此规格项");
                        return;
                    }
                    #endregion

                    #region 订单基础信息
                    model = new Model.user_order();
                    model.order_no = orderNo;
                    model.order_type = 0;
                    model.trade_no = "";
                    model.user_id = uid;
                    model.user_name = user.nick_name;
                    model.payment_way = 1;
                    model.payment_name = "货到付款";
                    model.payment_fee = 0M;
                    model.payment_time = null;
                    model.express_type = 1;
                    model.express_man_name = "";
                    model.express_mobile = "";
                    model.express_name = "";
                    model.express_no = "";
                    model.express_money = express_money;
                    model.accept_name = address.name;
                    model.post_code = "";
                    model.mobile = address.mobile;
                    model.area = address.area;
                    model.address = address.address;
                    model.address_id = aid;
                    model.message = remark;
                    model.remark = "";
                    model.use_point = integral;
                    model.order_amount = price + model.express_money;
                    model.order_coupon_money = 0M;
                    model.payable_amount = model.order_amount - model.order_coupon_money;
                    model.status = (int)EnumCollection.order_status.待发货;
                    model.add_time = System.DateTime.Now;
                    model.confirm_time = Convert.ToDateTime(model.add_time).AddDays(10);
                    model.complete_time = null;
                    model.del_status = (int)EnumCollection.order_delStatus.未删除;
                    #endregion

                    int orderid = bll.Add(model);
                    if (orderid > 0)
                    {
                        #region 订单商品信息
                        ogModel = new Model.user_ordergoods();
                        ogModel.order_id = orderid;
                        ogModel.goods_group = goods.group_id;
                        ogModel.goods_id = gid;
                        ogModel.goods_title = goods.title;
                        ogModel.goods_subtitle = goods.subtitle;
                        ogModel.goods_spec = temp;
                        ogModel.goods_stock = 0;
                        ogModel.img_url = goods.img_src;
                        ogModel.goods_oprice = goods.oprice;
                        ogModel.goods_price = spectype.price;
                        ogModel.quantity = num;

                        ogBll.Add(ogModel);
                        #endregion

                        //更新已售数量
                        goods.sales_num += ogModel.quantity;
                        ggBll.Update(goods);

                        //更新积分
                        if (integral > 0)
                        {
                            user.integral -= integral;
                            if (user.integral < 0)
                            {
                                user.integral = 0;
                            }
                            ubll.Update(user);

                            AddIntegralRecord(uid, (int)EnumCollection.integral_method_type.使用, (int)EnumCollection.integral_type.购买商品, integral);
                        }

                        DataTable responsedt = GetTable("orderid,order_no", orderid + "," + orderNo);

                        writeMsgSuccess("订单提交成功", responsedt);
                    }
                    else
                    {
                        writeMsgError("提交失败");
                        return;
                    }
                }
                if (from == "cart")
                {
                    if (arr.Length == 0)
                    {
                        writeMsgError("请选择要购买的商品");
                        return;
                    }

                    #region 订单基础信息
                    model = new Model.user_order();
                    model.order_no = orderNo;
                    model.order_type = 0;
                    model.trade_no = "";
                    model.user_id = uid;
                    model.user_name = user.nick_name;
                    model.payment_way = 1;
                    model.payment_name = "货到付款";
                    model.payment_fee = 0M;
                    model.payment_time = null;
                    model.express_type = 1;
                    model.express_man_name = "";
                    model.express_mobile = "";
                    model.express_name = "";
                    model.express_no = "";
                    model.express_money = express_money;
                    model.accept_name = address.name;
                    model.post_code = "";
                    model.mobile = address.mobile;
                    model.area = address.area;
                    model.address = address.address;
                    model.address_id = aid;
                    model.message = remark;
                    model.remark = "";
                    model.use_point = integral;
                    model.order_amount = price + model.express_money;
                    model.order_coupon_money = 0M;
                    model.payable_amount = model.order_amount - model.order_coupon_money;
                    model.status = (int)EnumCollection.order_status.待发货;
                    model.add_time = System.DateTime.Now;
                    model.confirm_time = Convert.ToDateTime(model.add_time).AddDays(10);
                    model.complete_time = null;
                    model.del_status = (int)EnumCollection.order_delStatus.未删除;
                    #endregion

                    int orderid = bll.Add(model);
                    if (orderid > 0)
                    {
                        //购物车商品记录
                        DataTable dt = cbll.GetList(" user_id = " + uid + " and id in (" + cids + ") ");

                        #region 订单商品信息
                        int gid = 0;
                        foreach (DataRow item in dt.Rows)
                        {
                            gid = Convert.ToInt32(item["goods_id"]);
                            goods = ggBll.GetModel(gid);

                            ogModel = new Model.user_ordergoods();
                            ogModel.order_id = orderid;
                            ogModel.goods_group = goods.group_id;
                            ogModel.goods_id = gid;
                            ogModel.goods_title = goods.title;
                            ogModel.goods_subtitle = goods.subtitle;
                            ogModel.goods_spec = item["goods_spec"].ToString();
                            ogModel.goods_stock = 0;
                            ogModel.img_url = goods.img_src;
                            ogModel.goods_oprice = Convert.ToDecimal(item["goods_oprice"]);
                            ogModel.goods_price = Convert.ToDecimal(item["goods_price"]);
                            ogModel.quantity = Convert.ToInt32(item["num"]);

                            ogBll.Add(ogModel);

                            //更新已售数量
                            goods.sales_num += ogModel.quantity;
                            ggBll.Update(goods);
                        }
                        #endregion

                        //更新积分
                        if (integral > 0)
                        {
                            user.integral -= integral;
                            if (user.integral < 0)
                            {
                                user.integral = 0;
                            }
                            ubll.Update(user);

                            AddIntegralRecord(uid, (int)EnumCollection.integral_method_type.使用, (int)EnumCollection.integral_type.购买商品, integral);
                        }

                        //删除购物车记录
                        cbll.DeleteList(cids);

                        DataTable responsedt = GetTable("orderid,order_no", orderid + "," + orderNo);

                        writeMsgSuccess("订单提交成功", responsedt);
                    }
                    else
                    {
                        writeMsgError("提交失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 插入积分记录
        /// <summary>
        /// 插入积分记录
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="method">操作类型 1获得 2使用</param>
        /// <param name="type">积分类型</param>
        /// <param name="integral">积分值</param>
        private void AddIntegralRecord(int uid, int method, int type, int integral)
        {
            Model.user_integral model = new Model.user_integral();
            model.user_id = uid;
            model.integral = integral;
            model.get_or_use = method;
            model.type = type;
            model.type_name = Enum.GetName(typeof(EnumCollection.integral_type), type);
            model.add_time = System.DateTime.Now;

            new BLL.user_integral().Add(model);
        }
        #endregion

        #region 订单列表
        private void GetOrderList()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);
                string tag = RequestHelper.GetString("tag");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.user_order bll = new BLL.user_order();
                BLL.user_ordergoods ogbll = new BLL.user_ordergoods();
                DataTable dt = null;
                DataTable dtgoods = null;

                dt = bll.GetList(" del_status = 0 and user_id = " + uid + " and status = 2 and confirm_time < getdate() ");
                string ids = string.Empty;
                foreach (DataRow item in dt.Rows)
                {
                    ids += Convert.ToInt32(item["id"]) + ",";
                }
                if (!string.IsNullOrEmpty(ids))
                {
                    bll.UpdateStatus((int)EnumCollection.order_status.待评价, " id in (" + ids + ") ");
                }

                switch (tag)
                {
                    case "all"://全部
                        dt = bll.GetListByPage(" del_status = 0 and user_id = " + uid, " add_time desc ", pageIndex, pageSize);
                        break;
                    case "send"://待发货
                        dt = bll.GetListByPage(" del_status = 0 and user_id = " + uid + " and status = 1", " add_time desc ", pageIndex, pageSize);
                        break;
                    case "receive"://待收货
                        dt = bll.GetListByPage(" del_status = 0 and user_id = " + uid + " and status = 2", " add_time desc ", pageIndex, pageSize);
                        break;
                    case "evaluate"://待评价
                        dt = bll.GetListByPage(" del_status = 0 and user_id = " + uid + " and status = 3 ", " add_time desc ", pageIndex, pageSize);
                        break;
                    case "finish"://已完成
                        dt = bll.GetListByPage(" del_status = 0 and user_id = " + uid + " and status = 4 ", " add_time desc ", pageIndex, pageSize);
                        break;
                }


                List<my_order_entity> list = new List<my_order_entity>();
                my_order_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new my_order_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.order_no = item["order_no"].ToString();
                    entity.status = Convert.ToInt32(item["status"]);
                    entity.status_name = Enum.GetName(typeof(EnumCollection.order_status), entity.status);
                    entity.total_integral = Convert.ToInt32(item["use_point"]);
                    entity.total_price = Convert.ToDecimal(item["payable_amount"]);
                    entity.remark = item["remark"].ToString();
                    entity.express_no = item["express_no"].ToString();

                    List<order_goods_entity> goodsList = new List<order_goods_entity>();
                    order_goods_entity goods = null;
                    dtgoods = ogbll.GetList(" order_id = " + entity.id);
                    int count = 0;
                    foreach (DataRow row in dtgoods.Rows)
                    {
                        goods = new order_goods_entity();
                        goods.id = Convert.ToInt32(row["id"]);
                        goods.goods_id = Convert.ToInt32(row["goods_id"]);
                        goods.group = Convert.ToInt32(row["goods_group"]);
                        goods.img_src = row["img_url"].ToString();
                        goods.title = row["goods_title"].ToString();
                        goods.price = Convert.ToDecimal(row["goods_price"]);
                        goods.spec = row["goods_spec"].ToString();
                        goods.num = Convert.ToInt32(row["quantity"]);

                        goodsList.Add(goods);

                        count += goods.num;
                    }

                    entity.goodsList = goodsList;
                    entity.count = count;

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 订单详情
        private void GetOrderDetails()
        {
            try
            {
                int oid = RequestHelper.GetInt("order_id", 0);

                BLL.user_order bll = new BLL.user_order();
                BLL.user_ordergoods ogbll = new BLL.user_ordergoods();
                DataTable dt = bll.GetListByPage(" id = " + oid, " add_time desc ", 1, 1);
                DataTable dtgoods = null;

                int count = 0;
                List<order_details_entity> list = new List<order_details_entity>();
                order_details_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new order_details_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.order_no = item["order_no"].ToString();
                    entity.status = Convert.ToInt32(item["status"]);
                    entity.status_name = Enum.GetName(typeof(EnumCollection.order_status), entity.status);
                    entity.total_integral = Convert.ToInt32(item["use_point"]);
                    entity.total_price = Convert.ToDecimal(item["payable_amount"]);
                    entity.remark = item["remark"].ToString();
                    entity.express_no = item["express_no"].ToString();
                    entity.accept_name = item["accept_name"].ToString();
                    entity.mobile = item["mobile"].ToString();
                    entity.address = item["area"].ToString() + item["address"].ToString();

                    Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.平台运费);
                    if (dict == null)
                    {
                        entity.express_money = 10;
                    }
                    else
                    {
                        entity.express_money = Convert.ToInt32(dict.contents);
                    }

                    BLL.common_evaluate evbll = new BLL.common_evaluate();
                    List<order_goods_entity> goodsList = new List<order_goods_entity>();
                    order_goods_entity goods = null;
                    dtgoods = ogbll.GetList(" order_id = " + entity.id);
                    foreach (DataRow row in dtgoods.Rows)
                    {
                        goods = new order_goods_entity();
                        goods.id = Convert.ToInt32(row["id"]);
                        goods.goods_id = Convert.ToInt32(row["goods_id"]);
                        goods.group = Convert.ToInt32(row["goods_group"]);
                        goods.img_src = row["img_url"].ToString();
                        goods.title = row["goods_title"].ToString();
                        goods.price = Convert.ToDecimal(row["goods_price"]);
                        goods.spec = row["goods_spec"].ToString();
                        goods.num = Convert.ToInt32(row["quantity"]);
                        goods.is_eval = evbll.GetRecordCount(" group_id = " + (int)EnumCollection.evaluate_group.订单商品评价
                            + " and parent_id = " + goods.id + " and from_user_id = " + Convert.ToInt32(item["user_id"]));
                        goodsList.Add(goods);

                        count += goods.num;
                    }

                    entity.goodsList = goodsList;
                    entity.count = count;

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 取消订单
        private void CancelOrder()
        {
            try
            {
                int oid = RequestHelper.GetInt("order_id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                BLL.user_order bll = new BLL.user_order();
                Model.user_order order = bll.GetModel(oid);
                if (order == null)
                {
                    writeMsgError("没有此订单");
                    return;
                }
                BLL.user_info ubll = new BLL.user_info();
                Model.user_info user = ubll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                if (order.status == (int)EnumCollection.order_status.待发货)
                {
                    order.status = (int)EnumCollection.order_status.已取消;
                    if (bll.Update(order))
                    {
                        if (order.use_point > 0)
                        {
                            user.integral += order.use_point;
                            ubll.Update(user);

                            AddIntegralRecord(uid, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.取消订单返还, order.use_point);
                        }

                        writeMsgSuccessNull("取消订单成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("取消订单失败");
                        return;
                    }
                }
                else if (order.status > (int)EnumCollection.order_status.待发货)
                {
                    writeMsgError("此订单已发货，无法取消订单");
                    return;
                }
                else
                {
                    writeMsgError("此订单状态已取消");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 确认收货
        private void ConfirmReceive()
        {
            try
            {
                int oid = RequestHelper.GetInt("order_id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);

                BLL.user_order bll = new BLL.user_order();
                Model.user_order order = bll.GetModel(oid);
                if (order == null)
                {
                    writeMsgError("没有此订单");
                    return;
                }
                BLL.user_info ubll = new BLL.user_info();
                Model.user_info user = ubll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                if (order.status == (int)EnumCollection.order_status.待收货)
                {
                    order.status = (int)EnumCollection.order_status.待评价;
                    order.confirm_time = System.DateTime.Now;
                    if (bll.Update(order))
                    {
                        writeMsgSuccessNull("确认收货成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("确认收货失败");
                        return;
                    }
                }
                else if (order.status > (int)EnumCollection.order_status.待收货)
                {
                    writeMsgError("此订单已确认收货，无法重复确认收货");
                    return;
                }
                else
                {
                    writeMsgError("订单状态不正确");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
                return;
            }
        }
        #endregion

        #region 评价商品
        private void DoEvaluateGoods()
        {
            try
            {
                int ogid = RequestHelper.GetInt("order_goods_id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int star = RequestHelper.GetInt("star", 1);
                string contents = RequestHelper.GetString("contents");

                object obj = new object();
                lock (obj)
                {
                    BLL.user_ordergoods ogbll = new BLL.user_ordergoods();
                    Model.user_ordergoods goods = ogbll.GetModel(ogid);
                    if (goods == null)
                    {
                        writeMsgError("没有此购买记录");
                        return;
                    }
                    Model.user_info user = new BLL.user_info().GetModel(uid);
                    if (user == null)
                    {
                        writeMsgError("没有此用户");
                        return;
                    }
                    if (string.IsNullOrEmpty(contents))
                    {
                        writeMsgError("请输入评价内容");
                        return;
                    }

                    BLL.common_evaluate bll = new BLL.common_evaluate();
                    Model.common_evaluate model = bll.GetModel(" group_id = " + (int)EnumCollection.evaluate_group.订单商品评价 + " and parent_id = " + ogid + " and from_user_id = " + uid);

                    if (model != null)
                    {
                        writeMsgError("您已评价过此商品，不能再次评价");
                        return;
                    }

                    model = new Model.common_evaluate();
                    model.group_id = (int)EnumCollection.evaluate_group.订单商品评价;
                    model.eval_type = (int)EnumCollection.evaluate_type.评论;
                    model.parent_id = ogid;
                    model.from_user_id = uid;
                    model.to_user_id = 0;
                    model.start = star;
                    model.contents = contents;
                    model.data_id = 0;
                    model.reply_id = 0;
                    model.add_time = System.DateTime.Now;

                    if (bll.Add(model) > 0)
                    {
                        DataTable dt = bll.GetList(" group_id = " + (int)EnumCollection.evaluate_group.订单商品评价 + " and from_user_id = " + uid);
                        string ids = string.Empty;
                        foreach (DataRow item in dt.Rows)
                        {
                            ids += Convert.ToInt32(item["parent_id"]) + ",";
                        }
                        ids = Utils.DelLastComma(ids);

                        if (!string.IsNullOrEmpty(ids))
                        {
                            int no_eval = ogbll.GetRecordCount(" id in (" + ids + ") ");//没有评价过的购买记录

                            if (no_eval == dt.Rows.Count)//没有未评价的购买记录
                            {
                                //更改订单状态为已完成
                                BLL.user_order obll = new BLL.user_order();
                                Model.user_order order = obll.GetModel(goods.order_id);
                                order.status = (int)EnumCollection.order_status.已完成;
                                order.complete_time = System.DateTime.Now;

                                obll.Update(order);
                            }
                        }

                        writeMsgSuccessNull("评价成功");
                        return;
                    }
                    else
                    {
                        writeMsgError("评价失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 个人中心
        private void GetMyCenter()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);

                BLL.user_info ubll = new BLL.user_info();
                Model.user_info model = ubll.GetModel(uid);
                if (model == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                user_info_entity user = new user_info_entity();
                model.user_pwd = "";
                model.salt = "";
                model.reg_ip = "";
                user.UserInfo = model;
                user.UserTree = new BLL.user_tree().GetModel(" user_id = " + uid);
                user.UserOAuths = new BLL.user_oauths().GetModel(" type = " + (int)EnumCollection.user_oauths.公众号微信登录 + " and user_id = " + uid);

                my_center_entity entity = new my_center_entity();
                //用户实体
                entity.user = user;

                //是否签到
                entity.is_signin = new BLL.user_signin().GetRecordCount(" user_id = " + uid + " and convert(varchar(10), add_time, 23) = convert(varchar(10),getdate(),23)") > 0 ? 1 : 0;

                //我的积分
                entity.integral = model.integral;

                //我的收藏
                entity.collection = new BLL.user_collection().GetRecordCount(" user_id = " + uid);

                //购物车
                entity.cart_num = new BLL.user_cart().GetRecordSum("num", " user_id = " + uid);

                BLL.user_order bll = new BLL.user_order();
                //待发货订单
                entity.send = bll.GetRecordCount(" del_status = 0 and user_id = " + uid + " and status = " + (int)EnumCollection.order_status.待发货);

                //待收货订单
                entity.receive = bll.GetRecordCount(" del_status = 0 and user_id = " + uid + " and status = " + (int)EnumCollection.order_status.待收货);

                //待评价订单
                entity.eval = bll.GetRecordCount(" del_status = 0 and user_id = " + uid + " and status = " + (int)EnumCollection.order_status.待评价);

                writeMsgSuccess("", entity);
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
            }
        }
        #endregion

        #region 系统消息
        private void GetMessageList()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                DataTable dt = new BLL.common_message().GetListByPage(" receiver_id = 0 and add_time > '" + user.add_time + "' ", "add_time desc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 消息详情
        private void GetMessageInfo()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);

                Model.common_message model = new BLL.common_message().GetModel(id);

                writeMsgSuccess("", model);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 加入课堂申请
        private void GetClassroomVerify()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                string whereStr = " 1 = 1 ";

                DataTable dtids = new BLL.classroom_info().GetList(" is_show = " + (int)EnumCollection.YesOrNot.否 + " and user_id = " + uid);
                string ids = string.Empty;
                foreach (DataRow item in dtids.Rows)
                {
                    ids += Convert.ToInt32(item["id"]) + ",";
                }
                ids = Utils.DelLastComma(ids);

                if (!string.IsNullOrEmpty(ids))
                {
                    whereStr += " and classroom_id in (" + ids + ") ";

                    BLL.classroom_user bll = new BLL.classroom_user();
                    DataTable dt = bll.GetListByPage("*", "View_ClassroomVerify", whereStr, "add_time desc", pageIndex, pageSize);

                    writeMsgSuccess("", dt);
                }
                else
                {
                    writeMsgSuccessNull("");
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 审核加入课堂申请
        private void DoExamine()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int id = RequestHelper.GetInt("id", 0);
                int status = RequestHelper.GetInt("status", 1);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.classroom_user bll = new BLL.classroom_user();
                Model.classroom_user model = bll.GetModel(id);
                if (model == null)
                {
                    writeMsgError("没有此申请");
                    return;
                }

                Model.classroom_info ciModel = new BLL.classroom_info().GetModel(model.classroom_id);
                if (ciModel == null)
                {
                    writeMsgError("没有此课堂");
                    return;
                }
                if (ciModel.user_id != uid)
                {
                    writeMsgError("此课堂不属于你");
                    return;
                }

                model.status = status;

                if (bll.Update(model))
                {
                    writeMsgSuccessNull("审核成功");
                    return;
                }
                else
                {
                    writeMsgError("审核失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 签到
        private void DoSignIn()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                BLL.user_info ubll = new BLL.user_info();
                Model.user_info user = ubll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                object obj = new object();
                lock (obj)
                {
                    BLL.user_signin bll = new BLL.user_signin();
                    Model.user_signin model = bll.GetModel(" user_id = " + uid + " and convert(varchar(10), add_time, 23) = convert(varchar(10),getdate(),23)");
                    if (model != null)
                    {
                        writeMsgError("您今天已签到");
                        return;
                    }

                    model = new Model.user_signin();
                    model.user_id = uid;
                    model.add_time = System.DateTime.Now;

                    if (bll.Add(model) > 0)
                    {
                        int point = 0;
                        Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.签到送积分值);
                        if (dict == null)
                        {
                            point = 2;
                        }
                        else
                        {
                            point = Convert.ToInt32(dict.contents);
                        }

                        user.integral += point;
                        ubll.Update(user);

                        AddIntegralRecord(uid, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.签到赠送, point);

                        DataTable dt = GetTable("signin_point,count", point + "," + user.integral);
                        writeMsgSuccess("", dt);
                        return;
                    }
                    else
                    {
                        writeMsgError("签到失败");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
            }
        }
        #endregion

        #region 我的积分
        private void GetMyIntegral()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                DataTable dt = new BLL.user_integral().GetListByPage(" user_id = " + uid, "add_time desc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 积分规则
        private void GetIntegralRule()
        {
            try
            {
                Model.common_article model = new BLL.common_article().GetModel(" group_id = " + (int)EnumCollection.article_group.积分规则);
                string contents = string.Empty;
                if (model != null)
                {
                    contents = model.contents;
                }
                else
                {
                    contents = "";
                }

                DataTable dt = GetTableSingle("contents", contents);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 我收藏的课程
        private void GetMyCollection()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                DataTable dt = new BLL.user_collection().GetListByPage("*", "View_UserCollection", " user_id = " + uid, "add_time desc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 我收藏的资源
        private void GetMyResourceColl()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                DataTable dt = new BLL.user_collection().GetListByPage("*", "View_UserResourceColl", " user_id = " + uid, "add_time desc", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 删除收藏
        private void DelCollection()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string ids = RequestHelper.GetString("ids");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 0)
                {
                    writeMsgError("请选择要删除的收藏");
                    return;
                }

                bool flag = new BLL.user_collection().DeleteListByWhere(" user_id = " + uid + " and id in (" + ids + ") ");
                if (flag)
                {
                    writeMsgSuccessNull("删除成功");
                    return;
                }
                else
                {
                    writeMsgError("删除失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
                return;
            }
        }
        #endregion

        #region 我的分销
        private void GetMyDistribution()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 20);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.user_tree bll = new BLL.user_tree();
                BLL.user_integral ibll = new BLL.user_integral();

                Model.user_tree tree = bll.GetModel(" user_id = " + uid);
                int count = bll.GetRecordCount(" parent_code = '" + tree.code + "' ");
                int sum = ibll.GetRecordSum("integral", " type = " + (int)EnumCollection.integral_type.注册贡献 + " and user_id = " + uid);

                my_distribution_entity entity = new my_distribution_entity();
                List<next_level> nextList = new List<next_level>();
                List<next_level> recordList = new List<next_level>();
                next_level next = null;

                int point = 20;
                Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册贡献给上级积分值);
                if (dict != null)
                {
                    point = Convert.ToInt32(dict.contents);
                }
                else
                {
                    point = 20;
                }

                DataTable dt = bll.GetListByPage("*", "View_MyTree", " parent_code = '" + tree.code + "' ", " id desc ", pageIndex, pageSize);
                foreach (DataRow item in dt.Rows)
                {
                    next = new next_level();
                    next.user_id = Convert.ToInt32(item["user_id"]);
                    next.avatar = item["avatar"].ToString();
                    next.nick_name = item["nick_name"].ToString();
                    next.integral = point;
                    next.add_time = "";

                    nextList.Add(next);
                }

                dt = ibll.GetListByPage("*", "View_MyContribution", " type = " + (int)EnumCollection.integral_type.注册贡献 + " and user_id = " + uid, " add_time desc ", pageIndex, pageSize);
                foreach (DataRow item in dt.Rows)
                {
                    next = new next_level();
                    next.user_id = Convert.ToInt32(item["user_id"]);
                    next.avatar = item["avatar"].ToString();
                    next.nick_name = item["nick_name"].ToString();
                    next.integral = Convert.ToInt32(item["integral"]);
                    next.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd HH:mm:ss");

                    recordList.Add(next);
                }

                entity.count = count;
                entity.sum = sum;
                entity.nextList = nextList;
                entity.recordList = recordList;

                writeMsgSuccess("", entity);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 查看他的下级
        private void GetSubordinate()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 20);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                BLL.user_tree bll = new BLL.user_tree();
                Model.user_tree tree = bll.GetModel(" user_id = " + uid);

                if (tree == null)
                {
                    writeMsgError("没有此关系");
                    return;
                }

                List<next_level> list = new List<next_level>();
                next_level entity = null;

                int point = 20;
                Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册贡献给上级积分值);
                if (dict != null)
                {
                    point = Convert.ToInt32(dict.contents);
                }
                else
                {
                    point = 20;
                }

                DataTable dt = bll.GetListByPage("*", "View_MyTree", " parent_code = '" + tree.code + "' ", " id desc ", pageIndex, pageSize);
                foreach (DataRow item in dt.Rows)
                {
                    entity = new next_level();
                    entity.user_id = Convert.ToInt32(item["user_id"]);
                    entity.avatar = item["avatar"].ToString();
                    entity.nick_name = item["nick_name"].ToString();
                    entity.integral = point;
                    entity.add_time = "";

                    list.Add(entity);
                }


                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 我的课堂
        private void GetMyClass()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);
                int tag = RequestHelper.GetInt("tag", 1);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                List<classroom_info_entity> list = new List<classroom_info_entity>();
                classroom_info_entity entity = null;

                DataTable dt = null;
                if (tag == 1)
                {
                    dt = new BLL.classroom_user().GetListByPage("*", "View_MyJoinClass", " join_user_id = " + uid + " and join_status = " + (int)EnumCollection.examine_status.审核通过, " join_add_time desc ", pageIndex, pageSize);
                    foreach (DataRow item in dt.Rows)
                    {
                        entity = new classroom_info_entity();
                        entity.id = Convert.ToInt32(item["id"]);
                        entity.avatar = item["avatar"].ToString();
                        entity.name = item["name"].ToString();
                        entity.user_name = item["user_name"].ToString();
                        entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd HH:mm:ss");

                        list.Add(entity);
                    }

                    writeMsgSuccess("", list);
                    return;
                }
                if (tag == 2)
                {
                    dt = new BLL.classroom_info().GetListByPage(" user_id = " + uid, "add_time desc", pageIndex, pageSize);
                    foreach (DataRow item in dt.Rows)
                    {
                        entity = new classroom_info_entity();
                        entity.id = Convert.ToInt32(item["id"]);
                        entity.avatar = item["avatar"].ToString();
                        entity.name = item["name"].ToString();
                        entity.user_name = item["user_name"].ToString();
                        entity.add_time = Convert.ToDateTime(item["add_time"]).ToString("yyyy-MM-dd HH:mm:ss");

                        list.Add(entity);
                    }

                    writeMsgSuccess("", list);
                    return;
                }
                else
                {
                    writeMsgError("分组错误");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 我的题库
        private void GetMyExamination()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                DataTable dt = new BLL.common_examination().GetMyQuestionByPage(uid, " add_time desc ", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 试题列表
        private void GetMyQuestion()
        {
            try
            {
                int id = RequestHelper.GetInt("id", 0);
                int uid = RequestHelper.GetInt("user_id", 0);
                int count = 0;

                BLL.common_answers opBll = new BLL.common_answers();
                BLL.answer_record reBll = new BLL.answer_record();
                BLL.common_questions qBll = new BLL.common_questions();
                BLL.examination_question bll = new BLL.examination_question();
                Model.common_answers anModel = null;

                DataTable dt = bll.GetQuestionByExa(" exa_id = " + id + " and q_id in (select distinct q_id from ybd_answer_record where user_id = " + uid + " and is_truth = 2 ) order by id ");

                List<question_analysis_entity> list = new List<question_analysis_entity>();
                question_analysis_entity entity = null;
                foreach (DataRow item in dt.Rows)
                {
                    entity = new question_analysis_entity();
                    entity.id = Convert.ToInt32(item["id"]);
                    entity.q_id = Convert.ToInt32(item["q_id"]);
                    entity.type = Convert.ToInt32(item["type"]);
                    entity.type_name = Enum.GetName(typeof(EnumCollection.questions_type), entity.type);
                    entity.title = item["title"].ToString();
                    entity.score = Convert.ToInt32(item["score"]);

                    Model.answer_record record = reBll.GetModel(" is_truth = 2 and exa_id = " + id + " and q_id = " + entity.q_id + " and user_id = " + uid + " order by add_time desc");
                    entity.is_truth = record.is_truth;
                    Model.common_questions question = qBll.GetModel(entity.q_id);
                    entity.truth_answer = question.answer;
                    if (entity.type == (int)EnumCollection.questions_type.单选题 || entity.type == (int)EnumCollection.questions_type.判断题)
                    {
                        anModel = opBll.GetModel(Convert.ToInt32(record.answer));
                        entity.user_answer = anModel.options;
                    }
                    if (entity.type == (int)EnumCollection.questions_type.多选题)
                    {
                        string[] ids = record.answer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string anids = string.Empty;
                        foreach (string optionsid in ids)
                        {
                            anModel = opBll.GetModel(Convert.ToInt32(optionsid));
                            anids += anModel.options + ",";
                        }
                        entity.user_answer = Utils.DelLastComma(anids);
                    }
                    if (entity.type == (int)EnumCollection.questions_type.填空题 || entity.type == (int)EnumCollection.questions_type.主观题)
                    {
                        entity.user_answer = record.answer;
                    }

                    entity.join_count = reBll.GetRecordCount(" q_id = " + entity.q_id);
                    count = reBll.GetRecordCount(" q_id = " + entity.q_id + " and is_truth = " + (int)EnumCollection.YesOrNot.是);
                    entity.truth_ratio = Convert.ToDecimal((decimal)count / (decimal)entity.join_count) * 100;
                    entity.analysis = question.analysis;

                    if (entity.type == (int)EnumCollection.questions_type.单选题 ||
                        entity.type == (int)EnumCollection.questions_type.多选题 ||
                        entity.type == (int)EnumCollection.questions_type.判断题)
                    {
                        DataTable dtoptions = opBll.GetList(" question_id = " + entity.q_id);
                        List<options_entity> optionsList = new List<options_entity>();
                        options_entity option = null;
                        foreach (DataRow row in dtoptions.Rows)
                        {
                            option = new options_entity();
                            option.id = Convert.ToInt32(row["id"]);
                            option.no = row["options"].ToString();
                            option.title = row["contents"].ToString();

                            optionsList.Add(option);
                        }

                        entity.optionsList = optionsList;
                    }

                    list.Add(entity);
                }

                writeMsgSuccess("", list);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 播放历史
        private void GetMyReadRecord()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                int pageIndex = RequestHelper.GetInt("page_index", 1);
                int pageSize = RequestHelper.GetInt("page_size", 10);

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                DataTable dt = new BLL.user_readrecord().GetListByPage("*", "View_User_ReadRecord", " user_id = " + uid, " add_time desc ", pageIndex, pageSize);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 删除播放历史
        private void DelReadRecord()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string ids = RequestHelper.GetString("ids");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }

                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 0)
                {
                    writeMsgError("请选择要删除的历史记录");
                    return;
                }

                bool flag = new BLL.user_readrecord().DeleteListByWhere(" user_id = " + uid + " and id in (" + ids + ") ");
                if (flag)
                {
                    writeMsgSuccessNull("删除成功");
                    return;
                }
                else
                {
                    writeMsgError("删除失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
                return;
            }
        }
        #endregion

        #region 修改密码
        private void UpdatePwd()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string pwd = RequestHelper.GetString("pwd");
                string newpwd = RequestHelper.GetString("newpwd");

                BLL.user_info bll = new BLL.user_info();
                Model.user_info user = bll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    writeMsgError("请输入原密码");
                    return;
                }
                if (string.IsNullOrEmpty(newpwd))
                {
                    writeMsgError("请输入新密码");
                    return;
                }

                if (user.user_pwd != DESEncrypt.Encrypt(pwd, user.salt))
                {
                    writeMsgError("原密码错误");
                    return;
                }

                user.user_pwd = DESEncrypt.Encrypt(newpwd, user.salt);
                if (bll.Update(user))
                {
                    writeMsgSuccessNull("修改成功");
                    return;
                }
                else
                {
                    writeMsgError("修改失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 修改手机号
        private void UpdatePhone()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string phone = RequestHelper.GetString("phone");
                string verifycode = RequestHelper.GetString("code");

                BLL.user_info bll = new BLL.user_info();
                Model.user_info user = bll.GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (string.IsNullOrEmpty(phone))
                {
                    writeMsgError("请输入新手机号");
                    return;
                }
                if (!Utils.IsPhone(phone))
                {
                    writeMsgError("手机号格式不正确");
                    return;
                }
                Model.user_info model = bll.GetModel(" phone = '" + phone + "' ");
                if (model != null)
                {
                    writeMsgError("此手机号已被注册");
                    return;
                }
                if (string.IsNullOrEmpty(verifycode))
                {
                    writeMsgError("请输入验证码");
                    return;
                }

                #region 检测验证码
                if (HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE] == null || HttpContext.Current.Session["SMS_CODE_TIME"] == null)
                {
                    writeMsgError("您还没有发送验证码或验证码已过期，请重新发送");
                    return;
                }

                string code = HttpContext.Current.Session[AppoaKeys.SESSION_SMS_CODE].ToString();
                string codetime = HttpContext.Current.Session["SMS_CODE_TIME"].ToString();

                if (string.IsNullOrEmpty(code))
                {
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }
                if (string.IsNullOrEmpty(codetime))
                {
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }
                DateTime time = Convert.ToDateTime(codetime);
                DateTime now = System.DateTime.Now;

                TimeSpan ts = now - time;

                if (ts.TotalSeconds >= 60)
                {
                    HttpContext.Current.Session.Remove(AppoaKeys.SESSION_SMS_CODE);
                    HttpContext.Current.Session.Remove("SMS_CODE_TIME");
                    writeMsgError("验证码已过期，请重新发送");
                    return;
                }

                if (verifycode != code)
                {
                    writeMsgError("验证码不正确");
                    return;
                }
                #endregion

                user.phone = phone;

                if (bll.Update(user))
                {
                    writeMsgSuccessNull("修改成功");
                    return;
                }
                else
                {
                    writeMsgError("修改失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 查看客服电话
        private void GetServiceTelephone()
        {
            try
            {
                Model.common_dict model = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.客服热线);
                string content = string.Empty;
                if (model != null)
                {
                    content = model.contents;
                }
                else
                {
                    content = "";
                }

                DataTable dt = GetTable("contents", content);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 意见反馈
        private void FeedBack()
        {
            try
            {
                int uid = RequestHelper.GetInt("user_id", 0);
                string contents = RequestHelper.GetString("contents");

                Model.user_info user = new BLL.user_info().GetModel(uid);
                if (user == null)
                {
                    writeMsgError("没有此用户");
                    return;
                }
                if (string.IsNullOrEmpty(contents))
                {
                    writeMsgError("请输入内容");
                    return;
                }

                BLL.common_feedback bll = new BLL.common_feedback();
                Model.common_feedback model = new Model.common_feedback();

                model.group_id = 0;
                model.user_id = uid;
                model.contents = contents;
                model.add_time = System.DateTime.Now;
                model.is_read = (int)EnumCollection.YesOrNot.是;
                model.read_time = System.DateTime.Now;

                int id = bll.Add(model);
                if (id > 0)
                {
                    writeMsgSuccessNull("提交成功");
                    return;
                }
                else
                {
                    writeMsgError("提交失败");
                    return;
                }
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 关于我们
        private void GetAboutUs()
        {
            try
            {
                Model.common_article model = new BLL.common_article().GetModel(" group_id = " + (int)EnumCollection.article_group.关于我们);

                string contents = string.Empty;
                if (model != null)
                {
                    contents = model.contents;
                }
                else
                {
                    contents = "";
                }

                DataTable dt = GetTableSingle("contents", contents);

                writeMsgSuccess("", dt);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
                return;
            }
        }
        #endregion

        #region 获取微信配置信息
        private void GetWeChatInfo()
        {
            try
            {
                string appid = ConfigHelper.GetConfigString("WechatAppID");
                string jsapi_ticket = GetJsapiTicket();
                string noncestr = Utils.GetCheckCode(32);
                long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
                string url = RequestHelper.GetString("location");

                string str = "";//拼接后的字符串
                string signature = API.WeChat.WeChatContext.GetSignature(jsapi_ticket, noncestr, timestamp, url, out str);

                var obj = new
                {
                    appid = appid,
                    timestamp = timestamp,
                    noncestr = noncestr,
                    signature = signature
                };

                writeMsgSuccess("", obj);
            }
            catch (Exception e)
            {
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 获取微信jsapi_ticket
        /// <summary>
        /// 获取微信jsapi_ticket
        /// </summary>
        /// <returns></returns>
        private string GetJsapiTicket()
        {
            object jsapi_ticket = CacheHelper.Get("JsapiTicket");
            if (jsapi_ticket != null)
            {
                return jsapi_ticket.ToString();
            }
            else
            {
                string access_token = GetAccessToken();
                string result = HttpHelper.HttpGet("https://api.weixin.qq.com/cgi-bin/ticket/getticket", "access_token=" + access_token + "&type=jsapi");

                JavaScriptSerializer Jss = new JavaScriptSerializer();
                Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(result);
                if (respDic["errcode"].ToString() == "0")
                {
                    jsapi_ticket = respDic["ticket"];
                    CacheHelper.Insert("JsapiTicket", jsapi_ticket, Convert.ToInt32(respDic["expires_in"]) / 60 - 3);
                    return jsapi_ticket.ToString();
                }
                else
                {
                    return "errcode-" + respDic["errcode"] + "errmsg-" + respDic["errmsg"];
                }
            }
        }
        #endregion

        #region 获取微信Access_Token
        /// <summary>
        /// 获取微信Access_Token
        /// </summary>
        /// <returns></returns>
        private string GetAccessToken()
        {
            object access_token = CacheHelper.Get("AccessToken");
            if (access_token != null)
            {
                return access_token.ToString();
            }
            else
            {
                string appid = ConfigHelper.GetConfigString("WechatAppID");
                string appsecret = ConfigHelper.GetConfigString("WechatAppSecret");
                string result = HttpHelper.HttpGet("https://api.weixin.qq.com/cgi-bin/token", "grant_type=client_credential&appid=" + appid + "&secret=" + appsecret);

                JavaScriptSerializer Jss = new JavaScriptSerializer();
                Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(result);
                if (respDic.Keys.Contains("access_token"))
                {
                    access_token = respDic["access_token"];
                    CacheHelper.Insert("AccessToken", access_token, Convert.ToInt32(respDic["expires_in"]) / 60 - 3);
                    return access_token.ToString();
                }
                else if (respDic.Keys.Contains("errcode"))
                {
                    return "errcode-" + respDic["errcode"] + "errmsg-" + respDic["errmsg"];
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region 微信授权登录获取code
        private void WeChat_GetCode()
        {
            try
            {
                string source_url = RequestHelper.GetString("source_url");
                Utils.StringToTxt("WeChat_GetCode————source_url==" + source_url);
                Utils.WriteCookie("WeChatGrant", "True");
                string url = WeChatContext.GetRedirectCode("/html/wxlogin.html", source_url, true);
                writeMsgSuccess("", url);
            }
            catch (Exception e)
            {
                writeMsgError("" + e.Message);
            }
        }
        #endregion

        #region 微信登录回调
        private void wxLogin()
        {
            try
            {
                string code = RequestHelper.GetString("code");
                string state = RequestHelper.GetString("state");

                string decodeurl = Utils.UrlDecode(state).Replace('*', '&');
                Utils.StringToTxt("wxLogin————code==" + code + ";state==" + decodeurl);

                WeiXin_Access_token access_token = WeChatContext.GetAccessModel(code);

                if (access_token != null)
                {
                    SnsapiUserInfo userInfo = WeChatContext.GetSnsapiUserInfo(access_token.Access_token, access_token.Openid);//获取用户信息
                    if (userInfo != null)
                    {
                        user_info_entity entity = new user_info_entity();

                        //公众号openid存在
                        Model.user_oauths oaModel = new BLL.user_oauths().GetModel(" appid = '" + access_token.Openid + "'");
                        if (oaModel != null)
                        {
                            try
                            {
                                Utils.StringToTxt("wxLogin————公众号openid存在，则更新openID和unionID");
                                Model.user_info model = new BLL.user_info().GetModel(oaModel.user_id);

                                if (model.avatar.Contains("wx.qlogo.cn"))
                                {
                                    model.avatar = userInfo.headimgurl;
                                    new BLL.user_info().Update(model);
                                }

                                Utils.StringToTxt("wxLogin————用户信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(model));
                                Utils.StringToTxt("wxLogin————认证信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(oaModel));

                                //更新unionid(多应用唯一识别码)
                                oaModel.appid = userInfo.openid;
                                oaModel.unionid = userInfo.unionid;
                                new BLL.user_oauths().Update(oaModel);

                                entity.UserInfo = model;
                                entity.UserTree = new BLL.user_tree().GetModel(" user_id = " + oaModel.user_id);
                                entity.UserOAuths = oaModel;
                                entity.UserInfo.user_pwd = "";
                                entity.UserInfo.salt = "";
                                entity.UserInfo.reg_ip = "";

                                writeMsgSuccess("", entity);
                            }
                            catch (Exception e)
                            {
                                Utils.StringToTxt("wxLogin————获取数据库用户信息出现异常：" + e.Message);
                                return;
                            }
                        }
                        else//不存在
                        {
                            if (Utils.GetCookie("WeChatGrant") == "True")
                            {
                                Utils.WriteCookie("WeChatGrant", "False");

                                Utils.StringToTxt("wxLogin————公众号openid不存在，是全新用户");

                                #region 创建用户
                                Model.user_info model = new Model.user_info();
                                model.group_id = (int)EnumCollection.user_group.普通用户;
                                model.user_name = "";
                                model.phone = "";
                                model.salt = Utils.GetCheckCode(6);
                                model.user_pwd = "";
                                model.nick_name = userInfo.nickname;
                                model.avatar = userInfo.headimgurl;
                                model.integral = 0;
                                model.school_id = 0;
                                model.school_name = "";
                                model.college = "";
                                model.job = "";
                                model.course = "";
                                model.line_way = "";
                                model.area = userInfo.country + userInfo.province + userInfo.city;
                                model.address = "";
                                model.reg_ip = RequestHelper.GetIP();
                                model.add_time = System.DateTime.Now;

                                BLL.user_info bll = new BLL.user_info();
                                int row = bll.Add(model);
                                if (row > 0)
                                {
                                    model.id = row;

                                    #region 给用户赠送积分
                                    int point = 10;
                                    Model.common_dict dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册赠送积分值);
                                    if (dict != null)
                                    {
                                        point = Convert.ToInt32(dict.contents);
                                    }
                                    else
                                    {
                                        point = 10;
                                    }
                                    model.integral += point;
                                    bll.Update(model);

                                    AddIntegralRecord(row, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.注册赠送, point);
                                    #endregion

                                    entity.UserInfo = model;
                                    entity.UserInfo.user_pwd = "";
                                    entity.UserInfo.salt = "";
                                    entity.UserInfo.reg_ip = "";

                                    #region 若有推荐者，创建用户关系树并给推荐者赠送积分

                                    BLL.user_tree tBll = new BLL.user_tree();
                                    string temp = HttpUtility.UrlDecode(state);
                                    int index = temp.LastIndexOf("recommend=");
                                    string recommend = index >= 0 ? temp.Substring(index + 10, temp.Length - index - 10) : "0";//推荐者code
                                    //1 创建code
                                    string tree_code = string.Empty;
                                    do
                                    {
                                        tree_code = Utils.Number(6);
                                    } while (tBll.GetModel(" code = '" + tree_code + "'") != null);

                                    //添加关系
                                    #region 添加关系
                                    Model.user_tree tree = new Model.user_tree();
                                    tree.user_id = row;
                                    tree.code = tree_code;

                                    Model.user_tree treeModel = tBll.GetModel(" code = '" + recommend + "'");
                                    Model.user_tree grandModel = null;
                                    if (treeModel != null)
                                    {
                                        tree.parent_code = treeModel.code;
                                        grandModel = tBll.GetModel(" code = '" + treeModel.parent_code + "'");
                                        if (grandModel != null)
                                        {
                                            tree.grand_code = grandModel.code;
                                        }
                                        else
                                        {
                                            tree.grand_code = "0";
                                        }
                                    }
                                    else
                                    {
                                        tree.parent_code = "0";
                                        tree.grand_code = "0";
                                    }
                                    #endregion

                                    int treeid = tBll.Add(tree);
                                    if (treeid > 0)
                                    {
                                        tree.id = treeid;
                                        entity.UserTree = tree;

                                        if (treeModel != null)
                                        {
                                            #region 注册后向上级贡献积分
                                            Model.user_info pModel = bll.GetModel(treeModel.user_id);
                                            if (pModel != null)
                                            {
                                                #region 给上级赠送积分
                                                point = 5;
                                                dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册贡献给上级积分值);
                                                if (dict != null)
                                                {
                                                    point = Convert.ToInt32(dict.contents);
                                                }
                                                else
                                                {
                                                    point = 5;
                                                }

                                                pModel.integral += point;
                                                bll.Update(pModel);

                                                AddIntegralRecord(pModel.id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.注册贡献, point);
                                                #endregion

                                                if (grandModel != null)
                                                {
                                                    Model.user_info gModel = bll.GetModel(grandModel.user_id);
                                                    if (gModel != null)
                                                    {
                                                        #region 给上上级推荐者赠送积分
                                                        point = 3;
                                                        dict = new BLL.common_dict().GetModel(" type = " + (int)EnumCollection.dict_type.注册贡献给上上级积分值);
                                                        if (dict != null)
                                                        {
                                                            point = Convert.ToInt32(dict.contents);
                                                        }
                                                        else
                                                        {
                                                            point = 3;
                                                        }
                                                        gModel.integral += point;
                                                        bll.Update(gModel);

                                                        AddIntegralRecord(gModel.id, (int)EnumCollection.integral_method_type.获得, (int)EnumCollection.integral_type.注册贡献, point);
                                                        #endregion
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                    }

                                    #endregion

                                    #region 添加认证信息
                                    Utils.StringToTxt("wxLogin————用户信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(model));

                                    Model.user_oauths model1 = new Model.user_oauths();
                                    model1.user_id = row;
                                    model1.type = (int)EnumCollection.user_oauths.公众号微信登录;
                                    model1.name = EnumCollection.user_oauths.公众号微信登录.ToString();
                                    model1.appid = userInfo.openid;
                                    model1.unionid = userInfo.unionid;

                                    int oaid = new BLL.user_oauths().Add(model1);
                                    if (row > 0)
                                    {
                                        model1.id = row;
                                        entity.UserOAuths = model1;

                                        Utils.StringToTxt("wxLogin————新增的认证信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(model1));
                                    }
                                    #endregion

                                    writeMsgSuccess("注册成功", entity);
                                    return;
                                }
                                else
                                {
                                    writeMsgError("注册失败");
                                    return;
                                }
                                #endregion
                            }
                            else
                            {
                                Utils.WriteCookie("WeChatGrant", "True");
                                string url = WeChatContext.GetRedirectCode("/html/wxlogin.html", state, true);
                                writeMsgError(300, url);
                                return;
                            }
                        }
                    }
                    else
                    {
                        writeMsgError("微信用户信息获取失败，请重试");
                        return;
                    }
                }
                else
                {
                    writeMsgError("token获取失败");
                    return;
                }
            }
            catch (Exception e)
            {
                Utils.StringToTxt("wxLogin————授权登录出现异常：" + e.Message);
                writeMsgError("系统错误：" + e.Message);
            }
        }
        #endregion

        #region 获取单词发音
        private void GetEnglishVoice()
        {
            int id = RequestHelper.GetInt("id", 0);

            Model.common_resource model = new BLL.common_resource().GetModel(id);
            if (model == null)
            {
                writeMsgError("没有此资源");
                return;
            }
            if (model.is_del == 1)
            {
                writeMsgError("没有此资源");
                return;
            }

            List<word_voice_entity> list = JsonConvert.DeserializeObject<List<word_voice_entity>>(model.path);

            string pat_url_name = "/upload/voice/";

            SpeechDemo demo = new SpeechDemo();

            foreach (word_voice_entity word in list)
            {
                string text = word.word_name;
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                if (bytes.Length >= 1024)
                {
                    writeMsgError("此单词或词组超出长度");
                    return;
                }


                string pathName = RootDir() + pat_url_name;
                if (!System.IO.Directory.Exists(pathName))
                    System.IO.Directory.CreateDirectory(pathName); // 不存在创建文件夹

                string picPath = text + ".mp3";

                pathName += picPath;

                if (!System.IO.File.Exists(pathName))
                {
                    demo.Tts(text, pathName);
                }

                word.video_path = pat_url_name + picPath;
            }

            list = list.OrderBy(w => w.word_sort).ToList();

            writeMsgSuccess("", list);
        }
        #endregion

        #region 公共方法

        #region 输出json

        #region 失败输出
        /// <summary>
        /// 失败输出
        /// </summary>
        /// <param name="msg">消息</param>
        private void writeMsgError(string msg)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.error(msg));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region 失败输出
        /// <summary>
        /// 失败输出
        /// </summary>
        /// <param name="msg">消息</param>
        private void writeMsgError(int code, string msg)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.error(code, msg));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region 成功输出
        /// <summary>
        /// 成功输出
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="o">不返回数据为null,其他位数组对象</param>
        private void writeMsgSuccess(string msg, object o)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.success(msg, o));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region 成功输出(不含返回数据)
        /// <summary>
        /// 成功输出(不含返回数据)
        /// </summary>
        /// <param name="msg">消息</param>
        private void writeMsgSuccessNull(string msg)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(YBDConvertToJson.success(msg, null));
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #endregion

        #region Base64转图片并保存，返回保存地址
        //获取程序根目录 
        protected string RootDir()
        {
            string RootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()).Replace("\\", "/");
            return RootDir;
        }

        //base64编码的字符串转为图片
        private string Base64LoadImg(string strbase64, string folder, string oldimg)
        {
            if (string.IsNullOrEmpty(strbase64))
            {
                return "";
            }
            //string tempPath = @"/upload/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string pat_url_name = "/upload/" + folder + "/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
            string pathName = RootDir() + pat_url_name;
            if (!System.IO.Directory.Exists(pathName))
                System.IO.Directory.CreateDirectory(pathName); // 不存在创建文件夹
            string picPath = DateTime.Now.ToString("MMddhhmmssfff") + Utils.GetCheckCode(4) + ".jpg";
            if (System.IO.File.Exists(oldimg))
                File.Delete(oldimg);//删除之前的文件
            pathName += picPath;
            if (System.IO.File.Exists(pathName))
                File.Delete(pathName);//删除之前的文件
            strbase64 = Utils.FitlerSpecial(strbase64);
            string img_src = string.Empty;
            try
            {
                //ImageUtil.UploadImg(strbase64, pat_url_name + picPath);
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bitmap = new Bitmap(ms);
                ms.Close();

                Bitmap bmp = new Bitmap(bitmap);
                bmp.Save(pathName, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp.Dispose();
                bitmap.Dispose();
                img_src = pat_url_name + picPath;
            }
            catch (Exception e)
            {
                throw e;
            }
            return img_src;
        }
        #endregion

        #region Base64转视频并保存，返回保存地址

        //base64编码的字符串转为视频
        private string Base64LoadVideo(string strbase64, string folder, string oldVideo)
        {
            if (string.IsNullOrEmpty(strbase64))
            {
                return "";
            }
            //string tempPath = @"/upload/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string pat_url_name = "/upload/" + folder + "/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
            string pathName = RootDir() + pat_url_name;
            if (!System.IO.Directory.Exists(pathName))
                System.IO.Directory.CreateDirectory(pathName); // 不存在创建文件夹

            string fileName = DateTime.Now.ToString("MMddhhmmssfff") + Utils.GetCheckCode(4);
            string fileType = ".mp4";

            //if (System.IO.File.Exists(oldVideo))
            //    File.Delete(oldVideo);//删除之前的文件
            //pathName += picPath;
            //if (System.IO.File.Exists(pathName))
            //    File.Delete(pathName);//删除之前的文件

            strbase64 = Utils.FitlerSpecial(strbase64);
            string video_src = string.Empty;
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);

                Common.FileUp.SaveFile(arr, fileName, pathName, fileType);

                video_src = pat_url_name + fileName + fileType;
            }
            catch (Exception e)
            {
                throw e;
            }
            return video_src;
        }
        #endregion

        #region 生成包含一行一列数据的datatable
        private DataTable GetTableSingle(string columns, string values)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columns);
            DataRow dr = dt.NewRow();
            dr[columns] = values;
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        #region 生成包含一行数据的datatable
        /// <summary>
        /// 生成包含一行数据的datatable
        /// </summary>
        /// <param name="column">键(多个之间逗号分隔)</param>
        /// <param name="value">值(多个之间逗号分隔)</param>
        /// <returns></returns>
        private DataTable GetTable(string columns, string values)
        {
            string[] column_arr = columns.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] value_arr = values.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            DataTable dt = new DataTable();
            if (column_arr.Length != value_arr.Length) return dt;
            foreach (string item in column_arr)
            {
                dt.Columns.Add(item);
            }
            DataRow dr = dt.NewRow();
            for (int i = 0; i < column_arr.Length; i++)
            {
                dr[column_arr[i].ToString()] = value_arr[i].ToString();
            }
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}