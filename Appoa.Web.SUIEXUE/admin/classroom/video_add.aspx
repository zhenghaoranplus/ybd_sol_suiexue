﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="video_add.aspx.cs" Inherits="Appoa.Manage.admin.classroom.video_add" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>添加视频</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Scripts/WebUploader/webuploader.min.js" type="text/javascript"></script>
    <script src="/Editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <link href="../js/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../js/uploadify/jquery.uploadify.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            $("#uploadify").uploadify({
                height: 32,
                swf: '../js/uploadify/uploadify.swf',
                uploader: '/tools/UploadHandler.ashx?thumb=true',
                width: 120,
                fileSizeLimit: 512000,
                removeCompleted: false,
                buttonText: '选择文件',
                queueSizeLimit: 5,
                fileTypeExts: '*.mp3;*.mp4',
                fileTypeDesc: 'mp3 mp4',
                onUploadSuccess: function (files, data, response) {
                    console.log(JSON.stringify(data));
                    getFile(data);
                }
            });

            /**获取url中的参数**/
            function getUrlParam(name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
                var r = window.location.search.substr(1).match(reg); //匹配目标参数
                if (r != null) return decodeURI(r[2]);
                return null; //返回参数值
            }

            function getFile(json) {
                var action = getUrlParam('action');

                json = JSON.parse(json);
                var hdfVal = $.trim($('#hdfVal').val());
                hdfVal += json.fileName + '|';
                $('#hdfVal').val(hdfVal);

                var path = $.trim($('#txtpath').val());
                path += json.path + '|';
                $('#txtpath').val(path);

                var thumb = $.trim($('#hdfThumb').val());
                thumb += json.thumb_path + '|';
                $('#hdfThumb').val(thumb);
            }
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>学习资料管理</span>
            <i class="arrow"></i><a href="javascript:history.back(-1);">
                <span>视频信息管理</span></a> <i class="arrow"></i><span>添加视频信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">视频信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>当前课堂</dt>
                <dd>
                    <span><%=classroom_name %></span>
                </dd>
            </dl>
            <section id="otherResource">
                <dl>
                    <dt>路径</dt>
                    <dd>
                        <asp:HiddenField ID="hdfVal" runat="server" />
                        <asp:HiddenField ID="hdfThumb" runat="server" />
                        <asp:TextBox ID="txtpath" runat="server" Rows="10" Columns="50" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <input type="file" name="uploadify" id="uploadify" />
                    </dd>
                </dl>
            </section>
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

