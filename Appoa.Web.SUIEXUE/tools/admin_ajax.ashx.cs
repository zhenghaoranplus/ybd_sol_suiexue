using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Appoa.Web.UI;
using Appoa.Common;

namespace Appoa.Manage.tools
{
    /// <summary>
    /// admin_ajax 的摘要说明
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置信息

        public void ProcessRequest(HttpContext context)
        {
            //检查管理员是否登录
            if (!new ManagePage().IsAdminLogin())
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"尚未登录或已超时，请登录后操作！\"}");
                return;
            }
            //取得处事类型
            string action = RequestHelper.GetQueryString("action");
            switch (action)
            {
                case "navigation_validate": //验证导航菜单别名是否重复
                    navigation_validate(context);
                    break;
                case "manager_validate": //验证管理员用户名是否重复
                    manager_validate(context);
                    break;
                case "get_navigation_list": //获取后台导航字符串
                    get_navigation_list(context);
                    break;
                case "get_remote_fileinfo": //获取远程文件的信息
                    get_remote_fileinfo(context);
                    break;
                case "sms_message_post": //发送手机短信
                    sms_message_post(context);
                    break;
                case "edit_order_status": //修改订单信息和状态
                    //edit_order_status(context);
                    break;
            }
        }
        //***************检测功能*******************

        //******************其他********************

        #region 验证导航菜单别名是否重复========================
        private void navigation_validate(HttpContext context)
        {
            string navname = RequestHelper.GetString("param");
            string old_name = RequestHelper.GetString("old_name");
            if (string.IsNullOrEmpty(navname))
            {
                context.Response.Write("{ \"info\":\"该导航别名不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (navname.ToLower() == old_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"该导航别名可使用\", \"status\":\"y\" }");
                return;
            }
            //检查保留的名称开头
            if (navname.ToLower().StartsWith("channel_"))
            {
                context.Response.Write("{ \"info\":\"该导航别名系统保留，请更换！\", \"status\":\"n\" }");
                return;
            }
            BLL.sys_navigation bll = new BLL.sys_navigation();
            if (bll.Exists(navname))
            {
                context.Response.Write("{ \"info\":\"该导航别名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该导航别名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证管理员用户名是否重复========================
        private void manager_validate(HttpContext context)
        {
            string user_name = RequestHelper.GetString("param");
            if (string.IsNullOrEmpty(user_name))
            {
                context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
                return;
            }
            BLL.sys_manager bll = new BLL.sys_manager();
            if (bll.Exists(user_name))
            {
                context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 获取后台导航字符串==============================
        private void get_navigation_list(HttpContext context)
        {
            Model.sys_manager adminModel = new ManagePage().GetAdminInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return;
            }

            Model.manager_role roleModel = new BLL.manager_role().GetModel(adminModel.role_id); //获得管理角色信息
            if (roleModel == null)
            {
                return;
            }
            DataTable dt = new BLL.sys_navigation().GetList(0, EnumCollection.NavigationEnum.System.ToString());
            this.get_navigation_childs(context, dt, 0, roleModel.role_type, roleModel.manager_role_values);

        }
        private void get_navigation_childs(HttpContext context, DataTable oldData, int parent_id, int role_type, List<Model.manager_role_value> ls)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            bool isWrite = false; //是否输出开始标签
            for (int i = 0; i < dr.Length; i++)
            {
                //检查是否显示在界面上====================
                bool isActionPass = true;
                if (int.Parse(dr[i]["is_lock"].ToString()) == 1)
                {
                    isActionPass = false;
                }
                //检查管理员权限==========================
                if (isActionPass && role_type > 1)
                {
                    string[] actionTypeArr = dr[i]["action_type"].ToString().Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在显示权限资源，则检查是否拥有该权限
                        if (action_type_str == "Show")
                        {
                            Model.manager_role_value modelt = ls.Find(p => p.nav_name == dr[i]["name"].ToString() && p.action_type == "Show");
                            if (modelt == null)
                            {
                                isActionPass = false;
                            }
                        }
                    }
                }
                //如果没有该权限则不显示
                if (!isActionPass)
                {
                    if (isWrite && i == (dr.Length - 1) && parent_id > 0)
                    {
                        context.Response.Write("</ul>\n");
                    }
                    continue;
                }
                //如果是顶级导航
                if (parent_id == 0)
                {
                    context.Response.Write("<div class=\"list-group\">\n");
                    context.Response.Write("<h1 title=\"" + dr[i]["sub_title"].ToString() + "\">");
                    if (!string.IsNullOrEmpty(dr[i]["icon_url"].ToString().Trim()))
                    {
                        context.Response.Write("<img src=\"" + dr[i]["icon_url"].ToString() + "\" />");
                    }
                    context.Response.Write("</h1>\n");
                    context.Response.Write("<div class=\"list-wrap\">\n");
                    context.Response.Write("<h2>" + dr[i]["title"].ToString() + "<i></i></h2>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), role_type, ls);
                    context.Response.Write("</div>\n");
                    context.Response.Write("</div>\n");
                }
                else //下级导航
                {
                    if (!isWrite)
                    {
                        isWrite = true;
                        context.Response.Write("<ul>\n");
                    }
                    context.Response.Write("<li>\n");
                    context.Response.Write("<a navid=\"" + dr[i]["name"].ToString() + "\"");
                    if (!string.IsNullOrEmpty(dr[i]["link_url"].ToString()))
                    {
                        if (int.Parse(dr[i]["channel_id"].ToString()) > 0)
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "?channel_id=" + dr[i]["channel_id"].ToString() + "\" target=\"mainframe\"");
                        }
                        else
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "\" target=\"mainframe\"");
                        }
                    }
                    if (!string.IsNullOrEmpty(dr[i]["icon_url"].ToString()))
                    {
                        context.Response.Write(" icon=\"" + dr[i]["icon_url"].ToString() + "\"");
                    }
                    context.Response.Write(" target=\"mainframe\">\n");
                    context.Response.Write("<span>" + dr[i]["title"].ToString() + "</span>\n");
                    context.Response.Write("</a>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), role_type, ls);
                    context.Response.Write("</li>\n");

                    if (i == (dr.Length - 1))
                    {
                        context.Response.Write("</ul>\n");
                    }
                }
            }
        }
        #endregion

        #region 获取远程文件的信息==============================
        private void get_remote_fileinfo(HttpContext context)
        {
            string filePath = RequestHelper.GetFormString("remotepath");
            if (string.IsNullOrEmpty(filePath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"没有找到远程附件地址！\"}");
                return;
            }
            if (!filePath.ToLower().StartsWith("http://"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"不是远程附件地址！\"}");
                return;
            }
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(filePath);
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                int fileSize = (int)_response.ContentLength;
                string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);
                string fileExt = filePath.Substring(filePath.LastIndexOf(".") + 1).ToUpper();
                context.Response.Write("{\"status\": 1, \"msg\": \"获取远程文件成功！\", \"name\": \"" + fileName + "\", \"path\": \"" + filePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}");
            }
            catch
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"远程文件不存在！\"}");
                return;
            }
        }
        #endregion

        #region 发送手机短信====================================
        private void sms_message_post(HttpContext context)
        {
            string mobiles = RequestHelper.GetFormString("mobiles");
            string content = RequestHelper.GetFormString("content");
            if (mobiles == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"手机号码不能为空！\"}");
                return;
            }
            if (content == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"短信内容不能为空！\"}");
                return;
            }
            //开始发送
            string msg = string.Empty;
            bool result = new BLL.sms_message().Send(mobiles, content, 2, out msg);
            if (result)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"" + msg + "\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"" + msg + "\"}");
            return;
        }
        #endregion

        #region 修改订单信息和状态==============================
        //private void edit_order_status(HttpContext context)
        //{
        //    //取得管理员登录信息
        //    Model.sys_manager adminInfo = new Web.UI.ManagePage().GetAdminInfo();
        //    if (adminInfo == null)
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"未登录或已超时，请重新登录！\"}");
        //        return;
        //    }
        //    //取得订单配置信息
        //    Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();

        //    string order_no = RequestHelper.GetString("order_no");
        //    string edit_type = RequestHelper.GetString("edit_type");
        //    if (order_no == "")
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"传输参数有误，无法获取订单号！\"}");
        //        return;
        //    }
        //    if (edit_type == "")
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"无法获取修改订单类型！\"}");
        //        return;
        //    }

        //    BLL.user_order bll = new BLL.user_order();
        //    Model.user_order model = null;
        //    List<Model.user_order> list = bll.GetModelList(string.Format(" order_no_child={0} ", order_no));
        //    if (list.Count > 0)
        //    {
        //        model = list[0];
        //    }
        //    if (model == null)
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"不存在或已被删除！\"}");
        //        return;
        //    }
        //    switch (edit_type.ToLower())
        //    {
        //        case "edit_order_remark": //修改订单备注=================================
        //            string remark = RequestHelper.GetFormString("remark");
        //            if (remark == "")
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"请填写订单备注内容！\"}");
        //                return;
        //            }
        //            model.remark = remark;
        //            if (!bll.Update(model))
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"修改订单备注失败！\"}");
        //                return;
        //            }
        //            new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, Common.EnumCollection.ActionEnum.Modify.ToString(), "修改订单备注，订单号:" + model.order_no_child); //记录日志
        //            context.Response.Write("{\"status\": 1, \"msg\": \"修改订单备注成功！\"}");
        //            break;
        //        case "order_complete": //完成订单=========================================
        //            if (model.status >= (int)Common.EnumCollection.OrderStatus.已完成)
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能重复处理！\"}");
        //                return;
        //            }
        //            model.status = (int)Common.EnumCollection.OrderStatus.已完成;
        //            model.complete_time = DateTime.Now;
        //            if (!bll.Update(model))
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"确认订单完成失败！\"}");
        //                return;
        //            }
        //            //给会员增加积分检查升级
        //            if (model.user_id > 0 && model.point > 0)
        //            {
        //                new BLL.user_pointlist().Add(model.user_id, model.point, ((int)Common.EnumCollection.UserPointType.购物消费).ToString(), "购物消费获得积分，订单号：" + model.order_no_child);
        //            }
        //            new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, Common.EnumCollection.ActionEnum.Confirm.ToString(), "确认交易完成订单号:" + model.order_no); //记录日志
        //            #region 发送短信或邮件=========================
        //            //if (orderConfig.completemsg > 0)
        //            //{
        //            //    switch (orderConfig.completemsg)
        //            //    {
        //            //        case 1: //短信通知
        //            //            if (string.IsNullOrEmpty(model.mobile))
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >对方未填写手机号码！\"}");
        //            //                return;
        //            //            }
        //            //            Model.sms_template smsModel = new BLL.sms_template().GetModel(orderConfig.completecallindex); //取得短信内容
        //            //            if (smsModel == null)
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >短信通知模板不存在！\"}");
        //            //                return;
        //            //            }
        //            //            //替换标签
        //            //            string msgContent = smsModel.content;
        //            //            msgContent = msgContent.Replace("{webname}", siteConfig.webname);
        //            //            msgContent = msgContent.Replace("{username}", model.user_name);
        //            //            msgContent = msgContent.Replace("{orderno}", model.order_no);
        //            //            msgContent = msgContent.Replace("{amount}", model.order_amount.ToString());
        //            //            //发送短信
        //            //            string tipMsg = string.Empty;
        //            //            bool sendStatus = new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
        //            //            if (!sendStatus)
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >" + tipMsg + "\"}");
        //            //                return;
        //            //            }
        //            //            break;
        //            //        case 2: //邮件通知
        //            //            //取得用户的邮箱地址
        //            //            if (string.IsNullOrEmpty(model.email))
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >该用户没有填写邮箱地址。\"}");
        //            //                return;
        //            //            }
        //            //            //取得邮件模板内容
        //            //            Model.mail_template mailModel = new BLL.mail_template().GetModel(orderConfig.completecallindex);
        //            //            if (mailModel == null)
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >邮件通知模板不存在。\"}");
        //            //                return;
        //            //            }
        //            //            //替换标签
        //            //            string mailTitle = mailModel.maill_title;
        //            //            mailTitle = mailTitle.Replace("{username}", model.user_name);
        //            //            string mailContent = mailModel.content;
        //            //            mailContent = mailContent.Replace("{webname}", siteConfig.webname);
        //            //            mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
        //            //            mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
        //            //            mailContent = mailContent.Replace("{username}", model.user_name);
        //            //            mailContent = mailContent.Replace("{orderno}", model.order_no);
        //            //            mailContent = mailContent.Replace("{amount}", model.order_amount.ToString());
        //            //            //发送邮件
        //            //            DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
        //            //                siteConfig.emailfrom, model.email, mailTitle, mailContent);
        //            //            break;
        //            //    }
        //            //}
        //            #endregion
        //            context.Response.Write("{\"status\": 1, \"msg\": \"确认订单完成成功！\"}");
        //            break;
        //        case "order_express": //确认发货
        //            if (model.status > (int)Common.EnumCollection.OrderStatus.已发货 || model.express_status == (int)Common.EnumCollection.OrderStatus.已发货)
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"订单已完成或已发货，不能重复处理！\"}");
        //                return;
        //            }
        //            int express_id = RequestHelper.GetFormInt("express_id");
        //            string express_no = RequestHelper.GetFormString("express_no");
        //            //if (express_id == 0)
        //            //{
        //            //    context.Response.Write("{\"status\": 0, \"msg\": \"请选择配送方式！\"}");
        //            //    return;
        //            //}
        //            model.express_id = express_id;
        //            model.express_no = express_no;
        //            model.express_status = (int)Common.EnumCollection.OrderExpressStatus.已发货;
        //            model.express_time = DateTime.Now;
        //            model.status = (int)Common.EnumCollection.OrderStatus.已发货;
        //            if (!bll.Update(model))
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"订单发货失败！\"}");
        //                return;
        //            }
        //            new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, Common.EnumCollection.ActionEnum.Confirm.ToString(), "确认发货订单号:" + model.order_no_child); //记录日志
        //            #region 发送短信或邮件============================
        //            //if (orderConfig.expressmsg > 0)
        //            //{
        //            //    switch (orderConfig.expressmsg)
        //            //    {
        //            //        case 1: //短信通知
        //            //            if (string.IsNullOrEmpty(model.mobile))
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >对方未填写手机号码！\"}");
        //            //                return;
        //            //            }
        //            //            Model.sms_template smsModel = new BLL.sms_template().GetModel(orderConfig.expresscallindex); //取得短信内容
        //            //            if (smsModel == null)
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >短信通知模板不存在！\"}");
        //            //                return;
        //            //            }
        //            //            //替换标签
        //            //            string msgContent = smsModel.content;
        //            //            msgContent = msgContent.Replace("{webname}", siteConfig.webname);
        //            //            msgContent = msgContent.Replace("{username}", model.user_name);
        //            //            msgContent = msgContent.Replace("{orderno}", model.order_no);
        //            //            msgContent = msgContent.Replace("{amount}", model.order_amount.ToString());
        //            //            //发送短信
        //            //            string tipMsg = string.Empty;
        //            //            bool sendStatus = new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
        //            //            if (!sendStatus)
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >" + tipMsg + "\"}");
        //            //                return;
        //            //            }
        //            //            break;
        //            //        case 2: //邮件通知
        //            //            //取得用户的邮箱地址
        //            //            if (string.IsNullOrEmpty(model.email))
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >该用户没有填写邮箱地址。\"}");
        //            //                return;
        //            //            }
        //            //            //取得邮件模板内容
        //            //            Model.mail_template mailModel = new BLL.mail_template().GetModel(orderConfig.expresscallindex);
        //            //            if (mailModel == null)
        //            //            {
        //            //                context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >邮件通知模板不存在。\"}");
        //            //                return;
        //            //            }
        //            //            //替换标签
        //            //            string mailTitle = mailModel.maill_title;
        //            //            mailTitle = mailTitle.Replace("{username}", model.user_name);
        //            //            string mailContent = mailModel.content;
        //            //            mailContent = mailContent.Replace("{webname}", siteConfig.webname);
        //            //            mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
        //            //            mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
        //            //            mailContent = mailContent.Replace("{username}", model.user_name);
        //            //            mailContent = mailContent.Replace("{orderno}", model.order_no);
        //            //            mailContent = mailContent.Replace("{amount}", model.order_amount.ToString());
        //            //            //发送邮件
        //            //            DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
        //            //                siteConfig.emailfrom, model.email, mailTitle, mailContent);
        //            //            break;
        //            //    }
        //            //}
        //            #endregion
        //            context.Response.Write("{\"status\": 1, \"msg\": \"订单发货成功！\"}");
        //            break;
        //        case "order_cancel": //取消订单==========================================
        //            if (model.status == (int)Common.EnumCollection.OrderStatus.已完成)
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能取消订单！\"}");
        //                return;
        //            }
        //            if (model.status == (int)Common.EnumCollection.OrderStatus.已发货)
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"订单已发货，不能取消订单！\"}");
        //                return;
        //            }
        //            if (model.status == (int)Common.EnumCollection.OrderStatus.待发货)
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"订单已支付，不能取消订单！\"}");
        //                return;
        //            }
        //            model.status = (int)Common.EnumCollection.OrderStatus.已取消;
        //            if (!bll.Update(model))
        //            {
        //                context.Response.Write("{\"status\": 0, \"msg\": \"取消订单失败！\"}");
        //                return;
        //            }
        //            //##??
        //            int check_revert1 = RequestHelper.GetFormInt("check_revert");
        //            if (check_revert1 == 1)
        //            {
        //                //如果存在积分换购则返还会员积分
        //                if (model.user_id > 0 && model.use_point < 0)
        //                {
        //                    new BLL.user_pointlist().Add(model.user_id, model.use_point, ((int)Common.EnumCollection.UserPointType.订单取消返还).ToString(), "取消订单返还积分，订单号：" + model.order_no_child);
        //                }
        //                //如果已支付则退还金额到会员账户
        //                if (model.user_id > 0 && model.payment_status == (int)Common.EnumCollection.OrderPaymentStatus.已支付 && model.order_amount > 0)
        //                {
        //                    //用户暂无余额不考虑
        //                    //new BLL.user_amount_log().Add(model.user_id, model.user_name, model.order_amount, "取消订单退还金额，订单号：" + model.order_no);
        //                }
        //            }
        //            new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, Common.EnumCollection.ActionEnum.Cancel.ToString(), "取消订单号:" + model.order_no); //记录日志
        //            context.Response.Write("{\"status\": 1, \"msg\": \"取消订单成功！\"}");
        //            break;

        //    }

        //}
        #endregion


        #region 判断是否登陆以及是否开启静态====================
        private int get_builder_status()
        {
            //取得管理员登录信息
            Model.sys_manager adminInfo = new Web.UI.ManagePage().GetAdminInfo();
            if (adminInfo == null)
                return -1;
            else if (!new BLL.manager_role().Exists(adminInfo.role_id, "sys_builder_html", EnumCollection.ActionEnum.Build.ToString()))
                return -2;
            else if (siteConfig.staticstatus != 2)
                return -3;
            else
                return 1;
        }
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