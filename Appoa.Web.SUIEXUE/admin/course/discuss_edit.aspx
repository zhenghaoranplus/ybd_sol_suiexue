<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="discuss_edit.aspx.cs" Inherits="Appoa.Manage.admin.course.discuss_edit" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>问题讨论添加</title>
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
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "/tools/upload_ajax.ashx", swf: "/scripts/webuploader/uploader.swf" });
            $(".upload-piclist").InitUploader({ btntext: "批量上传", multiple: true, water: false, thumbnail: false, filesize: "20480", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
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
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="javascript:history.back(-1);">
                    <span>问题讨论管理</span></a> <i class="arrow"></i><span>添加问题讨论</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">问题讨论信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>课程</dt>
                <dd>
                    <%=course_name %>
                </dd>
            </dl>
            <dl>
                <dt>章节</dt>
                <dd>
                    <%=chapter_name %>
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*1-200" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*200字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>内容</dt>
                <dd>
                    <asp:TextBox ID="txtcontents" runat="server" BorderStyle="Solid" TextMode="MultiLine" datatype="*1-4000" sucmsg=" " Rows="10" Columns="40" BorderColor="#EEEEEE" BorderWidth="1px"></asp:TextBox>
                    <span class="Validform_checktip">*4000字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>图片</dt>
                <dd>
                    <div id="hid_photo" class="upload-box upload-piclist">
                    </div>
                    <input type="hidden" id="h_piclist" runat="server" class="focus-photo" />
                    <div class="photo-list">
                        <ul>
                            <asp:Repeater ID="rptAlbumList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input type="hidden" name="hid_photo_name" value="<%#Eval("id")%>|<%#Eval("original_path")%>|<%#Eval("thumb_path")%>" />
                                    <div class="img-box" onclick="setFocusImg(this);">
                                        <img src="<%#Eval("original_path")%>" bigsrc="<%#Eval("thumb_path")%>" />
                                    </div>
                                    <a href="javascript:;" onclick="delImg(this);">删除</a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                    </div>
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

