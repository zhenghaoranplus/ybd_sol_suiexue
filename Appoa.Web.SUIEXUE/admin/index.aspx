<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Appoa.Manage.admin.index" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>随E学-管理平台</title>
    <link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery.nicescroll.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/common.js"></script>
    <script type="text/javascript">
        //页面加载完成时
        $(function () {
            //检测IE
            if ('undefined' == typeof (document.body.style.maxHeight)) {
                window.location.href = 'ie6update.html';
            }


        });
        function showdiv() {
            document.getElementById("bg").style.display = "block";
            document.getElementById("show").style.display = "block";
        }
        function hidediv() {
            document.getElementById("bg").style.display = 'none';
            document.getElementById("show").style.display = 'none';
        }
    </script>
    <style type="text/css">
        #bg
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 130%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.7;
            opacity: .70;
            filter: alpha(opacity=70);
        }
        #show
        {
            display: none;
            position: absolute;
            top: 40%;
            left: 40%;
            width: 30%;
            height: 5%;
            padding: 8px;
            border: 8px solid #E8E9F7;
            background-color: white;
            z-index: 1002;
            overflow: auto;
            font-size:15px; 
            font-family:微软雅黑;
            color:Blue;
            font-weight:bolder
        }
    </style>
</head>
<body class="indexbody">
    <form id="form1" runat="server">
    <!--全局菜单-->
    <a class="btn-paograms" onclick="togglePopMenu();"></a>
    <div id="pop-menu" class="pop-menu">
        <div class="pop-box">
            <h1 class="title">
                <i></i>导航菜单</h1>
            <i class="close" onclick="togglePopMenu();">关闭</i>
            <div class="list-box">
            </div>
        </div>
        <i class="arrow">箭头</i>
    </div>
    <!--/全局菜单-->
    <div class="main-top">
        <a class="icon-menu"></a>
        <div id="main-nav" class="main-nav">
        </div>
        <div class="nav-right">
            <div class="info">
                <i></i><span>您好，<%=admin_info.user_name %><br><input type="hidden" id="type" runat="server" />
                    <%=new Appoa.BLL.manager_role().GetTitle(admin_info.role_id) %>
                </span>
            </div>
            <div class="option">
                <i></i>
                <div class="drop-wrap">
                    <div class="arrow">
                    </div>
                    <ul class="item">
                        <li><a href="right.aspx" target="mainframe">管理中心</a> </li>
                        <li><a href="manager/manager_pwd.aspx" onclick="linkMenuTree(false, '');" target="mainframe">
                            修改密码</a> </li>
                        <li>
                            <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click">注销登录</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="main-left">
        <h1 class="logo">
        </h1>
        <div id="sidebar-nav" class="sidebar-nav">
        </div>
    </div>
    <div class="main-container">
        <iframe id="mainframe" name="mainframe" frameborder="0" src="right.aspx"></iframe>
    </div>
    <div id="bg">
    </div>
    <div id="show">
        <input id="btnclose" type="button" value="确定" style="float: right" onclick="hidediv();" />
        <div id="test" style=''>
        </div>
    </div>
    </form>
</body>
</html>
