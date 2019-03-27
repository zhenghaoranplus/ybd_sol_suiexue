<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adR_edit.aspx.cs" Inherits="Appoa.Manage.admin.shop.adR_edit" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>广告位与数据对应表添加</title>
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
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            
            $('.zoomify').zoomify();
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "/tools/upload_ajax.ashx", swf: "/scripts/webuploader/uploader.swf" });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="javascript:history.back(-1);"><span>广告位与数据对应表管理</span></a> <i class="arrow"></i><span>添加广告位与数据对应表</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">广告位与数据对应表信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>广告数据图片</dt>
                <dd>
                    <asp:TextBox ID="txtad_data_img" runat="server" CssClass="input normal upload-path"
                        datatype="*0-4000" sucmsg=" "></asp:TextBox>
                    <div class="upload-box upload-img">
                    </div>
                    <br />
                    <br />
                    <img src="<%=this.txtad_data_img.Text %>" class="zoomify upload-imgs" width="30%" />
                </dd>
            </dl>
            <dl>
                <dt>广告数据标题</dt>
                <dd>
                    <asp:TextBox ID="txtad_data_title" runat="server" CssClass="input normal" datatype="*0-50"
                        sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>外链链接</dt>
                <dd>
                    <asp:TextBox ID="txtad_data_url" runat="server" CssClass="input normal" datatype="*0-500"
                        sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>广告数据id</dt>
                <dd>
                    <asp:TextBox ID="txtad_data_id" runat="server" CssClass="input normal" datatype="n"
                        sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*当类型选择为外链时，此处填0</span>
                </dd>
            </dl>
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtad_sort_id" runat="server" CssClass="input normal" datatype="n"
                        sucmsg=" "></asp:TextBox>
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
