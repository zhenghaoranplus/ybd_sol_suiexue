<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course_edit.aspx.cs" Inherits="Appoa.Manage.admin.course.course_edit" ValidateRequest="false" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课程信息添加</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Scripts/WebUploader/webuploader.min.js" type="text/javascript"></script>
    <script src="/editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/uploader.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            $('.zoomify').zoomify();
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "/tools/upload_ajax.ashx", swf: "/scripts/webuploader/uploader.swf" });

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
                    <span>课程信息管理</span></a> <i class="arrow"></i><span>添加课程信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">课程信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>分类</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem Text="=所属分类=" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txtname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*50字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>封面图</dt>
                <dd>
                    <asp:TextBox ID="txtcover" runat="server" CssClass="input normal upload-path" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <div class="upload-box upload-img">
                    </div>
                    <br />
                    <br />
                    <img class="zoomify upload-imgs" src="<%=this.txtcover.Text %>" width="20%" />
                </dd>
            </dl>
            <dl>
                <dt>简介</dt>
                <dd>
                    <asp:TextBox ID="txtinfo" runat="server" CssClass="editor" datatype="*0-2000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4000字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>二维码logo</dt>
                <dd>
                    <asp:TextBox ID="txtqrcode_logo" runat="server" CssClass="input normal upload-path" datatype="*0-500" sucmsg=" "></asp:TextBox>
                    <div class="upload-box upload-img">
                    </div>
                    <br />
                    <br />
                    <img class="zoomify upload-imgs" src="<%=this.txtqrcode_logo.Text %>" width="20%" />
                </dd>
            </dl>
            <%--<dl>
                <dt>二维码图片</dt>
                <dd>
                    <input type="hidden" runat="server" id="qrcodeview" />
                    <img class="zoomify" src="<%=this.qrcodeview.Value %>" width="20%" />
                </dd>
            </dl>--%>
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
