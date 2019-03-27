<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="service_industry_edit.aspx.cs" Inherits="Appoa.Manage.admin.pc.service_industry_edit" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑分类信息</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script src="../js/laymain.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script src="../js/uploader.js" type="text/javascript"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            $('.zoomify').zoomify();
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a><i class="arrow"></i><span>配置管理</span>
            <i class="arrow"></i><a href="category_list.aspx"><span>客户案例</span></a> <i class="arrow"></i><span>编辑新闻分类信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">编辑新闻分类信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*类型字段，字符个数50以内</span>
                </dd>
            </dl>
            <dl>
                <dt>上传图片</dt>
                <dd>
                    <asp:TextBox ID="txtImg" runat="server" CssClass="input normal upload-path"></asp:TextBox>
                    <div class="upload-box upload-img">
                    </div>
                    <br />
                    <br />
                    <img class="zoomify upload-imgs" src="<%=this.txtImg.Text.Trim() %>" width="10%" />
                </dd>
            </dl>
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtSort" runat="server" CssClass="input" sucmsg=" "></asp:TextBox>
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
            <input type="hidden" id="ct_id" runat="server" />
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>