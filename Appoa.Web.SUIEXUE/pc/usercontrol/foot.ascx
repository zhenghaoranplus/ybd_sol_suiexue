<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="foot.ascx.cs" Inherits="Appoa.Manage.pc.usercontrol.foot" %>
<div id="fd" class="index-fd pr">
    <div class="map-bg3"></div>
    <div class="wp">
        <div class="fd-top">
            <dl>
                <dt>关于我们</dt>
                <dd>
                    <ul class="ul-fd">
                        <li><a href="about_us.aspx#whous">我们是谁</a></li>
                        <li><a href="about_us.aspx#ourcus">我们服务的客户</a></li>
                        <li><a href="about_us.aspx#ourteam">我们的团队</a></li>
                    </ul>
                </dd>
            </dl>
            <dl>
                <dt>我们的服务</dt>
                <dd>
                    <ul class="ul-fd">
                        <li><a href="service_item.aspx#webbuit">微课&MOOC开发</a></li>
                        <li><a href="service_item.aspx#weiweb">立体化教材建设</a></li>
                        <li><a href="service_item.aspx#webmobel">智慧教室</a></li>
                        <li><a href="service_item.aspx#servweb">服务流程</a></li>
                        <li><a href="service_item.aspx#solution">课程类别</a></li>
                    </ul>
                </dd>
            </dl>
            <dl>
                <dt>我们的案例</dt>
                <dd>
                    <ul class="ul-fd">
                        <asp:Repeater ID="rptCaseCategory" runat="server">
                            <ItemTemplate>
                                <li><a href="case_list.aspx?page=1&cate=<%#Eval("id") %>"><%#Eval("name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
            </dl>
            <dl>
                <dt>新闻动态</dt>
                <dd>
                    <ul class="ul-fd">
                        <asp:Repeater ID="rptNewsCategory" runat="server">
                            <ItemTemplate>
                                <li><a href="news_list.aspx?page=1&cate=<%#Eval("id") %>"><%#Eval("name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
            </dl>
            <dl>
                <dt>联系我们</dt>
                <dd class="pr">
                    <p>
                        <a href="javascript:;" class="weixin"></a>
                        <a href="javascript:;" class="sina"></a>
                        <span class="weixin-pic">
                            <img src="skin/images/ewm.jpg" alt="">
                        </span>
                    </p>
                    <p><b class="tel">0371-88813995</b></p>
                    <h5>公司服务热线</h5>
                </dd>
            </dl>
        </div>
    </div>
    <div class="fd-copy">
        <div class="wp">
            <p>
                <span style="float: right">技术支持：<a href="http://www.appoa.cn" target="_blank">梧桐花教育信息技术有限公司</a></span> 
                <span style="color: #CCCCCC;">Copyright &copy;<e></e> wth.51suiyixue.com 梧桐花教育集团 版权所有</span>
                <a href="http://www.miibeian.gov.cn/" target="_blank"><span style="color: #CCCCCC;">豫ICP备16014068号-1</span></a>
                <script>
                    $('.fd-copy .wp span:eq(1) e').html(new Date().getFullYear());
                </script>
            </p>
        </div>
    </div>
</div>
<div class="side">
    <ul>
        <li>
            <a href="http://wpa.qq.com/msgrd?v=3&uin=1072200735&site=qq&menu=yes" target="_blank">
                <div class="sidebox">
                    <img src="skin/images/side_icon01.png">在线咨询
                </div>
            </a>
        </li>
        <li>
            <a href="javascript:void(0);">
                <div class="sidebox">
                    <img src="skin/images/side_icon03.png">0371-88813995
                </div>
            </a>
        </li>
    </ul>
</div>
<div class="side2">
    <ul>
        <li>
            <a href="">
                <img src="skin/images/r_icon1.png" alt=""></a>
            <div class="weixin">
                <em></em>
                <img src="skin/images/ewm.jpg" alt="">
            </div>
        </li>
        <li>
            <a href="javascript:goTop();" class="sidetop">
                <img src="skin/images/r_icon2.png"></a>
        </li>
    </ul>
</div>
