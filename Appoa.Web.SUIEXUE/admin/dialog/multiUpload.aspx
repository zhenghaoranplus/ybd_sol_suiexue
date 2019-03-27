<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="multiUpload.aspx.cs" Inherits="Appoa.Manage.admin.dialog.multiUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>上传习题</title>
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="tab-content" style="min-height: 0">
            <dl>
                <dt>习题分组</dt>
                <dd>
                    <div class="rule-multi-radio" style="margin-bottom: 1rem;">
                        <asp:RadioButtonList ID="rbtnGroup" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="习题测验" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="心理测试" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
                <dt>操作</dt>
                <dd>
                    <asp:FileUpload ID="fupload" runat="server" />
                    <asp:Button ID="btnImport" runat="server" Text="导入" CssClass="btn" OnClick="btnImport_Click" /></dd>
                <dt>结果</dt>
                <dd>
                    <div id="divResult" style="margin-top: 1rem;" runat="server"></div>
                </dd>
            </dl>
        </div>
    </form>
</body>
</html>
