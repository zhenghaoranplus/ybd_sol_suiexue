<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="question_options_edit.aspx.cs" Inherits="Appoa.Manage.admin.common.question_options_edit" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>选项信息添加</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a><i class="arrow"></i><span>试题管理</span><i class="arrow"></i>
            <a href="javascript:history.back(-1);"><span>选项信息管理</span></a> <i class="arrow"></i><span>修改选项信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">选项信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>题目</dt>
                <dd>
                    <asp:Label ID="lbltitle" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>选项</dt>
                <dd>
                    <asp:TextBox ID="txtoptions" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*50字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>选项内容</dt>
                <dd>
                    <asp:TextBox ID="txtcontents" runat="server" CssClass="input normal" datatype="*1-4000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>分值</dt>
                <dd>
                    <asp:TextBox ID="txtscore" runat="server" CssClass="input normal" datatype="n" sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*整数</span>
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
