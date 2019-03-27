<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact_us.aspx.cs" Inherits="Appoa.Manage.pc.contact_us" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/contact_us.ascx" TagName="contact_us" TagPrefix="uc3" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>随E学-联系我们</title>
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
            <div id="ban-in" style="background-image: url(skin/images/14415953225349.jpg)">
                <div class="ban-bg"></div>
            </div>
            <uc3:contact_us ID="contact_us1" runat="server" />
        </div>
        <!-- end #bd -->
        <div class="c"></div>
        <!-- begin #fd -->
        <uc4:foot ID="foot1" runat="server" />
        <script type="text/javascript" src="skin/js/jquery.js"></script>
        <script type="text/javascript" src="skin/js/lib.js"></script>
    </form>
</body>
</html>
