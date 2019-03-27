<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="work_edit.aspx.cs" Inherits="Appoa.Manage.admin.classroom.work_edit" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课堂作业信息添加</title>
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

            $("#selectedQu").click(function () {
                var id = $(this).attr('exaid');
                var winDialog = top.dialog({
                    title: '已选试题',
                    url: '/admin/dialog/selected_question.aspx?group=1&exaid=' + id,
                    width: 1280,
                    height: 760,
                    data: window //传入当前窗口
                }).showModal();
            })

            $("#unselectedQu").click(function () {
                var id = $(this).attr('exaid');
                var winDialog = top.dialog({
                    title: '未选试题',
                    url: '/admin/dialog/unselected_course.aspx?group=1&exaid=' + id,
                    width: 1280,
                    height: 760,
                    data: window //传入当前窗口
                }).showModal();
            })
        });

        function doSelect(title, contents, func) {
            var d = dialog({
                title: title,
                content: contents,
                okValue: '确定',
                ok: function () { func(); }
            }).showModal();
        }

        function openSelectQu() {
            var id = $('#selectedQu').attr('exaid');
            var winDialog = top.dialog({
                title: '已选试题',
                url: '/admin/dialog/selected_question.aspx?group=1&exaid=' + id,
                width: 1280,
                height: 760,
                data: window //传入当前窗口
            }).showModal();
        }

        function openUnSelectQu() {
            var id = $('#unselectedQu').attr('exaid');
            var winDialog = top.dialog({
                title: '未选试题',
                url: '/admin/dialog/unselected_course.aspx?group=1&exaid=' + id,
                width: 1280,
                height: 760,
                data: window //传入当前窗口,
            }).showModal();
        }
    </script>
    <style type="text/css">
        #rbtnType tr td {
            padding: .5em;
            margin: .3em;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="javascript:history.back(-1);">
                    <span>课堂作业信息管理</span></a> <i class="arrow"></i><span>修改课堂作业信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">课堂作业信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>课堂名称</dt>
                <dd>
                    <asp:Label ID="lblClassName" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>章节名称</dt>
                <dd>
                    <asp:Label ID="lblChapterName" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>作业名称</dt>
                <dd>
                    <asp:TextBox ID="txtname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*50字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>题目数量</dt>
                <dd>
                    <asp:TextBox ID="txtnums" runat="server" CssClass="input normal" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>总分</dt>
                <dd>
                    <asp:TextBox ID="txtscore" runat="server" CssClass="input normal" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>题目</dt>
                <dd>
                    <a id="selectedQu" href="javascript:;" exaid="<%=addRow %>">查看已选试题</a>
                    <br />
                    <a id="unselectedQu" href="javascript:;" exaid="<%=addRow %>">查看未选试题</a>
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
