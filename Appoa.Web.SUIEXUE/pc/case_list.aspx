<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case_list.aspx.cs" Inherits="Appoa.Manage.pc.case_list" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>随E学-客户案例</title>
    <meta name="description" content="梧桐花,随意学" />
    <meta name="keywords" content="梧桐花,随意学" />
    <meta content="telephone=no" name="format-detection" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="renderer" content="webkit">
    <!--360默认急速模式打开-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0,user-scalable=no">
    <link rel="stylesheet" href="skin/css/cui.css" />
    <link rel="stylesheet" href="skin/css/style.css" />
    <link rel="stylesheet" href="skin/css/less.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="head1" runat="server" />
        <!-- end #hd -->
        <div class="c"></div>
        <uc2:m ID="m1" runat="server" />
        <div class="c"></div>
        <div id="bd">
            <div id="ban-in" style="background-image: url(skin/images/14415956337556.jpg)">
                <div class="ban-bg"></div>
            </div>
            <div class="wp">
                <div class="tit-i">
                    <h3>客户案例</h3>
                    <h5><span>case</span> OF US</h5>
                </div>
                <div class="sub-nav">
                    <ul>
                        <asp:Repeater ID="rptCategory" runat="server">
                            <ItemTemplate>
                                <li><a <%#GetClass(Convert.ToInt32(Eval("id"))) %> href="case_list.aspx?page=1&cate=<%#Eval("id") %>"><%#Eval("name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="c"></div>
                <ul class="ul-case" id="ul-pc">
                    <asp:Repeater ID="rptCase" runat="server">
                        <ItemTemplate>
                            <li class="">
                                <div class="block">
                                    <div class="pic">
                                        <img src="<%#Eval("img_src") %>" alt="<%#Eval("title") %>">
                                    </div>
                                    <div class="txt">
                                        <a href="case_info.aspx?id=<%#Eval("id") %>&cate=<%#Eval("category_id") %>" style="width: 100%; height: 100%; display: block;"><b></b>
                                            <div class="pad">
                                                <h5><%#Eval("category_name") %></h5>
                                                <em></em>
                                                <h3><%#Eval("title") %></h3>
                                                <span class="more">案例详情</span>
                                            </div>
                                        </a>
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
        <script>
            var isMobile;
            function mobileCheck() {
                isMobile = $('#m-hd').is(':visible');
            }

            $(window).resize(function (event) {
                mobileCheck();
                $('.ul-case li').removeClass('on');
                if (isMobile) {
                    $('.ul-case').attr('id', 'ul-mobile');
                } else {
                    $('.ul-case').attr('id', 'ul-pc');
                }
            });

            $('body').on('mouseenter mouseleave', '#ul-pc li', function () {
                $(this).toggleClass('on');
            })

            $('body').on('click', '#ul-mobile li', function () {
                $(this).toggleClass('on');
            })

            $(window).load(function () {
                $(window).trigger('resize');
            })
        </script>
    </form>
</body>
</html>
