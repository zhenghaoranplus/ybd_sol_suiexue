<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="Appoa.Manage.pc.news_list" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>随E学-新闻动态</title>
    <meta name="description" content="梧桐花,随意学,新闻动态" />
    <meta name="keywords" content="梧桐花,随意学,新闻动态" />
    <meta content="telephone=no" name="format-detection" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="renderer" content="webkit">
    <!--360默认急速模式打开-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0,user-scalable=no">
    <link rel="stylesheet" href="skin/css/cui.css" />
    <link rel="stylesheet" href="skin/css/style.css" />
    <link rel="stylesheet" href="skin/css/less.css" />
    <style>
        .ul-list li .title h3 {
            height: 62px;
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
            <div id="ban-in" style="background-image: url(skin/images/14415956107965.jpg)">
                <div class="ban-bg"></div>
            </div>
            <div class="wp">
                <div class="tit-i">
                    <h3>新闻动态</h3>
                    <h5>WEBTHINK <span>NEWS</span></h5>
                </div>
                <div class="sub-nav">
                    <ul>
                        <asp:Repeater ID="rptCategory" runat="server">
                            <ItemTemplate>
                                <li><a <%#GetClass(Convert.ToInt32(Eval("id"))) %> href="news_list.aspx?page=1&cate=<%#Eval("id") %>"><%#Eval("name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <ul class="ul-list">
                    <asp:Repeater ID="rptNews" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="pad">
                                    <div class="pic">
                                        <a href="news_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>">
                                            <img src="<%#Eval("img_src") %>" alt="<%#Eval("title") %>"></a>
                                    </div>
                                    <div class="bor">
                                        <div class="txt">
                                            <div class="title">
                                                <span><em><%#Eval("add_time", "{0:MM/dd}") %></em><%#Eval("add_time", "{0:yyyy}") %></span>
                                                <h3><a href="news_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>"><%#Eval("title") %></a></h3>
                                            </div>
                                            <a href="news_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>" style="color: #666;">
                                                <p><%#Eval("subtitle").ToString().Length > 48 ? Eval("subtitle").ToString().Substring(0, 48) + "..." : Eval("subtitle") %></p>
                                            </a>
                                        </div>
                                        <div class="more">
                                            <a href="news_info.aspx?id=<%#Eval("id") %>" class="r">查看更多 ></a>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="c"></div>
                <div class="pagess">
                    <ul id="PageContent" runat="server">
                    </ul>
                </div>
            </div>
        </div>
        <!-- end #bd -->
        <div class="c"></div>
        <!-- begin #fd -->
        <uc3:foot ID="foot1" runat="server" />
        <script type="text/javascript" src="skin/js/jquery.js"></script>
        <script type="text/javascript" src="skin/js/lib.js"></script>
    </form>
</body>
</html>
