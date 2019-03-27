<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Appoa.Manage.pc.index" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/contact_us.ascx" TagName="contact_us" TagPrefix="uc3" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc4" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>随E学-首页</title>
    <meta name="description" content="梧桐花,随意学" />
    <meta name="keywords" content="梧桐花,随意学" />
    <meta content="telephone=no" name="format-detection" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="renderer" content="webkit">
    <!--360默认急速模式打开-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0,user-scalable=no">
    <meta name="full-screen" content="yes">
    <link rel="stylesheet" href="skin/css/cui.css" />
    <link rel="stylesheet" href="skin/css/style.css" />
    <link rel="stylesheet" href="skin/css/less.css" />
    <style>
        .ul-news-i li .hover .pad {
            bottom: -163px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="head1" runat="server" />
        <!-- end #hd -->
        <div class="c"></div>
        <uc2:m ID="m1" runat="server" />
        <div class="c"></div>
        <div id="bd">
            <div id="banner">
                <div class="banner-bg"></div>
                <div class="flexslider">
                    <ul class="slides">
                        <asp:Repeater ID="rptBanner" runat="server">
                            <ItemTemplate>
                                <li class="s<%# Container.ItemIndex + 1 %>">
                                    <img src="<%#Eval("ad_data_img") %>" alt="<%#Eval("ad_data_title") %>">
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!-- end #banner -->
            <div class="row1 fix">
                <div class="wp">
                    <div class="tit-i">
                        <h3>我们的服务</h3>
                        <h5>WEBTHINK <span>SERVICE</span></h5>
                    </div>
                    <ul class="ul-icon-i">
                        <asp:Repeater ID="rptService" runat="server">
                            <ItemTemplate>
                                <li class="li<%# Container.ItemIndex + 1 %>">
                                    <div class="pad">
                                        <a href="javascript:;">
                                            <span style='background: url(<%#Eval("img_src") %>) no-repeat; background-size: 100% 100%; border-radius: 50%;'></span>
                                            <h3><%#Eval("title") %></h3>
                                            <em></em>
                                            <p><%#Eval("contents") %></p>
                                            <div class="pic" style="width: 134px; height: 134px;">
                                                <img src="<%#Eval("subtitle") %>" alt="" class="pic-icon" style="width: 100%; height: 100%; border-radius: 50%;">
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="row2 fix">
                <div class="wp">
                    <div class="tit-i">
                        <h3>我们的案例</h3>
                        <h5><span>case</span> of us</h5>
                    </div>
                    <div class="case-i">
                        <div class="case-i-r" style="width: 100%;">
                            <ul class="ul-case-i">
                                <asp:Repeater ID="rptCase" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="case_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>">
                                                <div class="pic">
                                                    <img src="<%#Eval("img_src") %>" alt="<%#Eval("title") %>">
                                                </div>
                                                <div class="hover">
                                                    <b></b>
                                                    <div class="txt">
                                                        <img src="skin/images/logo_small.png" alt="">
                                                        <h3><%#Eval("title") %></h3>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="c" style="height: 70px"></div>
                        <div runat="server" id="more_i" class="more-i">
                            <a href="case_list.aspx"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row3 news-bg">
                <div class="wp">
                    <div class="tit-i tit-i-1">
                        <h3>最新动态</h3>
                        <h5>our <span>news</span></h5>
                    </div>
                    <ul class="ul-news-i">
                        <asp:Repeater ID="rptNews" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="pad">
                                        <div class="txt">
                                            <span><em><%#Eval("add_time", "{0:MM/dd}") %></em><%#Eval("add_time", "{0:yyyy}") %></span>
                                            <h3><a href="news_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>"><%#Eval("title") %></a></h3>
                                            <p><%#Eval("subtitle").ToString().Length > 48 ? Eval("subtitle").ToString().Substring(0, 48) + "..." : Eval("subtitle") %></p>
                                            <a href="news_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>" class="more"></a>
                                        </div>
                                        <div class="hover">
                                            <div class="img" style='background: url(<%#Eval("img_src") %>) 0 0 /100% 100% no-repeat; background: url(<%#Eval("img_src") %>) 0 0 no-repeat\9;'></div>
                                            <div class="pad">
                                                <h3><a href="news_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>"><%#Eval("title") %></a></h3>
                                                <p><%#Eval("subtitle").ToString().Length > 48 ? Eval("subtitle").ToString().Substring(0, 48) + "..." : Eval("subtitle") %></p>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="c" style="height: 70px"></div>
                    <div runat="server" id="news_more" class="news-more">
                        <a href="news_list.aspx">load more</a>
                    </div>
                </div>
            </div>
            <uc3:contact_us ID="contact_us1" runat="server" />
        </div>
        <!-- end #bd -->
        <div class="c"></div>
        <!-- begin #fd -->
        <uc4:foot ID="foot1" runat="server" />
        <script type="text/javascript" src="skin/js/jquery.js"></script>
        <script type="text/javascript" src="skin/js/lib.js"></script>
        <link rel="stylesheet" href="skin/css/animate.css" />
        <link rel="stylesheet" href="skin/css/flexslider.css" />
        <script type="text/javascript" src="skin/js/flexslider.js"></script>
        <script type="text/javascript" src="skin/js/banner.js"></script>
        <script>
            $('.ul-news-i li').hover(function () {
                $(this).toggleClass('on');
            })
            $('.ul-icon-i li').hover(function () {
                $(this).find('img:first').fadeIn(100);
                $(this).find('.pic-icon').animate({
                    top: 0
                });
            }, function () {
                $(this).find('.pic-icon').animate({
                    top: -134
                });
                $(this).find('img:first').fadeOut(100);
            })

            $('.case-img').hover(function () {
                $(this).toggleClass('on');
            })
        </script>
    </form>
</body>
</html>
