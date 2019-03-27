<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_info.aspx.cs" Inherits="Appoa.Manage.pc.news_info" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title><%=title %></title>
    <meta name="keywords" content="<%=title %>" />
    <meta name="description" content="<%=subtitle %>" />
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
            <div class="cur">
                <div class="wp">
                    您的当前位置：
					<a href='/pc/index.aspx'>主页</a> &gt;
					<a href='news_list.aspx'>新闻动态</a> &gt;
                    <a href="news_list.aspx?page=1&cate=<%=cate %>"><%=cate_name %></a> &gt;  
                    <a href="javascript:;"><%=title %></a>
                </div>
            </div>
            <div class="wp">
                <div class="article">
                    <h1><%=title %></h1>
                    <p class="time">时间：<%=add_time %></p>
                    <div class="article-con">
                        <%=contents %>
                    </div>
                    <div class="h20"></div>
                    <div class="share">
                        
                    </div>
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
