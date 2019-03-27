using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appoa.Common;
using Appoa.API.WeChat;
using Appoa.Model.Entity;

namespace Appoa.Manage.html
{
    public partial class wxOAuth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string source_url = Request.QueryString["source_url"];
            string code = Request.QueryString["code"];
            string state = Request.QueryString["state"];

            if (!string.IsNullOrEmpty(source_url))
            {
                string location = Request.RawUrl;
                int index = location.IndexOf('=');
                source_url = location.Substring(index + 1, location.Length - index - 1);
                source_url = source_url.Replace('&', '*');


                Utils.StringToTxt("wxOAuth_WeChat_GetCode————source_url==" + source_url);
                Utils.WriteCookie("wxOAuth_WeChatGrant", "True");
                string url = WeChatContext.GetRedirectCode("/html/wxOAuth.aspx", source_url, true);

                Response.Redirect(url);
            }
            else if (!string.IsNullOrEmpty(code))
            {
                string temp = Utils.UrlDecode(state);
                string decodeurl = temp.Replace('*', '&');

                Utils.StringToTxt("wxOAuth_wxLogin————code==" + code + ";wxOAuth_state==" + decodeurl);

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
                                Utils.StringToTxt("wxOAuth_wxLogin————公众号openid存在，则更新openID=" + access_token.Openid + "和unionID=" + userInfo.unionid);
                                Model.user_info model = new BLL.user_info().GetModel(oaModel.user_id);

                                Utils.StringToTxt("wxOAuth_wxLogin————用户信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(model));
                                Utils.StringToTxt("wxOAuth_wxLogin————认证信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(oaModel));

                                //更新unionid(多应用唯一识别码)
                                oaModel.appid = userInfo.openid;
                                oaModel.unionid = userInfo.unionid;
                                new BLL.user_oauths().Update(oaModel);

                                if (model.school_id == 0)//没有学校，公共资源
                                {
                                    decodeurl += "&method=scan";
                                    Response.Redirect(decodeurl);
                                }
                                else//有学校，学校资源
                                {
                                    int idindex = decodeurl.IndexOf('=');
                                    string id = decodeurl.Substring(idindex + 1, decodeurl.Length - idindex - 1);

                                    BLL.common_resource resBll = new BLL.common_resource();
                                    Model.common_resource res = resBll.GetModel(Convert.ToInt32(id));
                                    if (res != null)
                                    {
                                        if (res.from_id == (int)EnumCollection.resource_from.精品微课)//如果是精品微课的资源
                                        {
                                            if (res.group_id == (int)EnumCollection.resource_group.公共资源)//若此资源是公共资源，查询此章节下的学校资源
                                            {
                                                Model.common_resource newRes = resBll.GetModel(string.Format(" from_id = {0} and group_id = {1} and type = {2} and data_id = {3}",
                                                     res.from_id, (int)EnumCollection.resource_group.学校资源, res.type, res.data_id));
                                                if (newRes != null)
                                                {
                                                    decodeurl = decodeurl.Replace("id=" + id, "id=" + newRes.id);
                                                    Utils.StringToTxt("wxOAuth_wxLogin————学校资源=" + decodeurl);
                                                }

                                                decodeurl += "&method=scan";
                                                Response.Redirect(decodeurl);
                                            }
                                            else if (res.group_id == (int)EnumCollection.resource_group.学校资源)//若此资源是学校资源，判断是否是本学校的
                                            {
                                                if (model.school_id != res.school_id)
                                                {
                                                    Response.Write("您没有权限查看此资源");
                                                }
                                                else
                                                {
                                                    decodeurl += "&method=scan";
                                                    Response.Redirect(decodeurl);
                                                }
                                            }
                                        }
                                        else if (res.from_id == (int)EnumCollection.resource_from.课堂)//如果是课堂的资源
                                        {
                                            decodeurl += "&method=scan";
                                            Response.Redirect(decodeurl);
                                        }
                                    }
                                    else
                                    {
                                        decodeurl += "&method=scan";
                                        Response.Redirect(decodeurl);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Utils.StringToTxt("wxOAuth_wxLogin————获取数据库用户信息出现异常：" + ex.Message);
                                Response.Write("获取数据库用户信息出现异常：" + ex.Message);
                                return;
                            }
                        }
                        else//不存在
                        {
                            if (Utils.GetCookie("wxOAuth_WeChatGrant") == "True")
                            {
                                Utils.WriteCookie("wxOAuth_WeChatGrant", "False");

                                Utils.StringToTxt("wxOAuth_wxLogin————公众号openid不存在，是全新用户");

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
                                    entity.UserInfo = model;
                                    entity.UserInfo.user_pwd = "";
                                    entity.UserInfo.salt = "";
                                    entity.UserInfo.reg_ip = "";

                                    BLL.user_tree tBll = new BLL.user_tree();
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
                                    tree.parent_code = "0";
                                    tree.grand_code = "0";

                                    int treeid = tBll.Add(tree);
                                    if (treeid > 0)
                                    {
                                        tree.id = treeid;
                                        entity.UserTree = tree;

                                    }
                                    #endregion

                                    #region 添加认证信息
                                    Utils.StringToTxt("wxOAuth_wxLogin————用户信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(model));

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

                                        Utils.StringToTxt("wxOAuth_wxLogin————新增的认证信息：" + Newtonsoft.Json.JsonConvert.SerializeObject(model1));
                                    }
                                    #endregion

                                    Response.Redirect(decodeurl);
                                    return;
                                }
                                else
                                {
                                    Utils.WriteCookie("wxOAuth_WeChatGrant", "True");
                                    string url = WeChatContext.GetRedirectCode("/html/wxOAuth.aspx", state, true);
                                    Response.Redirect(url);
                                    return;
                                }
                                #endregion
                            }
                            else
                            {
                                Utils.WriteCookie("wxOAuth_WeChatGrant", "True");
                                string url = WeChatContext.GetRedirectCode("/html/wxOAuth.aspx", state, true);
                                Response.Redirect(url);
                                return;
                            }
                        }
                    }
                    else
                    {
                        Response.Write("微信认证失败，请重试");
                        return;
                    }
                }
                else
                {
                    Response.Write("token获取失败");
                    return;
                }
            }
        }
    }
}