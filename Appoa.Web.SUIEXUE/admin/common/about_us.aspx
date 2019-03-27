<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about_us.aspx.cs" Inherits="Appoa.Manage.admin.common.about_us" ValidateRequest="false" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>关于我们编辑</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Scripts/WebUploader/webuploader.min.js" type="text/javascript"></script>
    <script src="/Editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/uploader.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '700px',
                height: '350px',
                resizeType: 1,
                uploadJson: '/tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '/tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">关于我们</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*0-200" sucmsg=" " Text="关于我们"></asp:TextBox>
                    <span class="Validform_checktip">*200字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>内容</dt>
                <dd>
                    <asp:TextBox ID="txtcontents" runat="server" CssClass="input normal editor" datatype="*0-4000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*内容</span>
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>

