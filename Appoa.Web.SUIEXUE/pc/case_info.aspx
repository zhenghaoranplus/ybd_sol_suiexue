<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case_info.aspx.cs" Inherits="Appoa.Manage.pc.case_info" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>客户案例-<%=title %></title>
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
            <div class="cur">
                <div class="wp">
                    您的当前位置：
                    <a href="/pc/index.aspx">主页</a> &gt; 
                    <a href="case_list.aspx">客户案例</a> &gt; 
                    <a href="case_list.aspx?page=1&cate=<%=cate %>"><%=cate_name %></a> &gt;  
                    <a href="javascript:;"><%=title %></a>
                </div>
            </div>
            <div class="case-article">
                <div class="case-article-bg">
                    <div class="wp pr">
                        <div class="case-logo">
                            <!--<img src="/skin/images/14429937758428.png" alt="14429937758428.png">-->
                        </div>
                        <h1 style="color: #000000"><%=title %></h1>
                        <div class="tc" style="text-align: center">
                            <%=contents %>
                        </div>
                    </div>
                </div>
                <div class="case-back"><a href="javascript:history.back(-1);">返回案例列表</a></div>
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
