﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionnaire_edit.aspx.cs" Inherits="Appoa.Manage.admin.course.questionnaire_edit" ValidateRequest="false" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>调查问卷添加</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化编辑器
            var editorMini = KindEditor.create('.editor-mini', {
                width: '700px',
                height: '250px',
                resizeType: 1,
                uploadJson: '/tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
				'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist']
            });

            $("#selectedQu").click(function () {
                openSelectQu();
            })

            $("#unselectedQu").click(function () {
                openUnSelectQu();
            })
        });

        /**获取url中的参数**/
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg); //匹配目标参数
            if (r != null) return decodeURI(r[2]);
            return null; //返回参数值
        }

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
                url: '/admin/dialog/selected_question.aspx?group=2&exaid=' + id,
                width: 1280,
                height: 760,
                data: window //传入当前窗口
            }).showModal();
        }

        function openUnSelectQu() {
            var id = $('#unselectedQu').attr('exaid');
            var winDialog = top.dialog({
                title: '未选试题',
                url: '/admin/dialog/unselected_course.aspx?group=2&exaid=' + id,
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
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="javascript:history.back(-1);">
                    <span>调查问卷管理</span></a> <i class="arrow"></i><span>编辑调查问卷</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">调查问卷</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>课程名称</dt>
                <dd>
                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>章节名称</dt>
                <dd>
                    <asp:Label ID="lblChapterName" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>问卷名称</dt>
                <dd>
                    <asp:TextBox ID="txtname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*50字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>问卷简介</dt>
                <dd>
                    <asp:TextBox ID="txtinfo" runat="server" CssClass="input normal editor-mini" datatype="*0-500" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>问卷解析</dt>
                <dd>
                    <asp:TextBox ID="txtdescript" runat="server" CssClass="input normal editor-mini" datatype="*0-4000" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>题目</dt>
                <dd>
                    <a id="selectedQu" href="javascript:;" exaid="<%=addrow %>">查看已选试题</a>
                    <br />
                    <a id="unselectedQu" href="javascript:;" exaid="<%=addrow %>">查看未选试题</a>
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-2);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
