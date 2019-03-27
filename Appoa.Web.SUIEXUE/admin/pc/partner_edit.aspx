<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partner_edit.aspx.cs" Inherits="Appoa.Manage.admin.pc.partner_edit" ValidateRequest="false" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>合作伙伴添加</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Scripts/WebUploader/webuploader.min.js" type="text/javascript"></script>
    <script src="/Editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/uploader.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/common.js" type="text/javascript"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <link href="../js/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../js/uploadify/jquery.uploadify.min.js"></script>
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

            $("#uploadify").uploadify({
                height: 32,
                swf: '../js/uploadify/uploadify.swf',
                uploader: '/tools/UploadHandler.ashx?thumb=true',
                width: 120,
                fileSizeLimit: 512000,
                removeCompleted: false,
                buttonText: '选择文件',
                queueSizeLimit: 1,
                fileTypeExts: '*.mp4',
                fileTypeDesc: 'mp4',
                successTimeout: 1800,
                onUploadStart: function () {
                    console.group();
                    console.time();
                },
                onUploadSuccess: function (files, data, response) {
                    console.timeEnd();
                    console.groupEnd();
                    if (data == '') {
                        //data就是服务器输出的内容。     
                        $('#uploadify').uploadify('cancel', '*');   //取消所有上传的文件  
                    } else {
                        data = JSON.parse(data);
                        $('#txtvideo_url').val(data.path);
                    }
                }
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
                    <span>合作伙伴管理</span></a> <i class="arrow"></i><span>修改合作伙伴</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">合作伙伴信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*50字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>logo</dt>
                <dd>
                    <asp:TextBox ID="txtlogo" runat="server" CssClass="input normal upload-path"
                        datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <div class="upload-box upload-img">
                    </div>
                    <br />
                    <br />
                    <img src="<%=this.txtlogo.Text %>" class="zoomify upload-imgs" width="20%" />
                </dd>
            </dl>
            <dl>
                <dt>官网链接</dt>
                <dd>
                    <asp:TextBox ID="txtvideo_url" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <%--<input type="file" name="uploadify" id="uploadify" />--%>
                </dd>
            </dl>
            <dl>
                <dt>是否显示</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rbtnIsShow" runat="server"></asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtsort" runat="server" CssClass="input normal" Text="0" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*数字越小越靠前</span>
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
