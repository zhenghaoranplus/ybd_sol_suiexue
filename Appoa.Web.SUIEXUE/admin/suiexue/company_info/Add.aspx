﻿<%@Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Appoa.Manage.admin.company_info.Add" ValidateRequest="false" %> 
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>集团子公司信息添加</title>
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
            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '700px',
                height: '350px',
                resizeType: 1,
                uploadJson: '/tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '/tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });
            var editorMini = KindEditor.create('.editor-mini', {
                width: '700px',
                height: '250px',
                resizeType: 1,
                uploadJson: '/tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
				'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="Manage.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="Manage.aspx">
                <span>集团子公司信息管理</span></a> <i class="arrow"></i><span>添加集团子公司信息</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div id="floatHead" class="content-tab-wrap">
        <div class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a class="selected" href="javascript:;">集团子公司信息信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
            <dl>
                <dt>logo</dt>
                <dd>
                    <asp:TextBox ID="txtlogo" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*50字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>封面图</dt>
                <dd>
                    <asp:TextBox ID="txtimg_url" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>视频缩略图</dt>
                <dd>
                    <asp:TextBox ID="txtvideo_thumb_img" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>视频</dt>
                <dd>
                    <asp:TextBox ID="txtvideo_url" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>关于我们</dt>
                <dd>
                    <asp:TextBox ID="txtabout_us" runat="server" CssClass="input normal" datatype="*0-16" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*16字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>我们是谁左侧图</dt>
                <dd>
                    <asp:TextBox ID="txtwho_are_we_img" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>我们是谁文字</dt>
                <dd>
                    <asp:TextBox ID="txtwho_are_we" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>我们能做什么文字[[中文,英文],[中文,英文],[中文,英文],[中文,英文]]</dt>
                <dd>
                    <asp:TextBox ID="txtwhat_can_we_do" runat="server" CssClass="input normal" datatype="*0-4000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4000字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>我们能做什么右侧图</dt>
                <dd>
                    <asp:TextBox ID="txtwhat_can_we_do_img" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>我们的团队左侧图</dt>
                <dd>
                    <asp:TextBox ID="txtwe_team_img" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>我们的团队文字</dt>
                <dd>
                    <asp:TextBox ID="txtwe_team" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*500字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>联系我们</dt>
                <dd>
                    <asp:TextBox ID="txtcontact_us" runat="server" CssClass="input normal" datatype="*0-16" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*16字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>添加时间</dt>
                <dd>
                    <asp:TextBox ID="txtadd_time" runat="server" CssClass="input normal" datatype="*0-8" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*8字以内</span>
                </dd>
            </dl>
        
        <%--
        <dl>
            <dt>文章类型</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="radioArticalType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">建材知识</asp:ListItem>
                        <asp:ListItem Value="2">要闻</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>商家分类</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlCategary" runat="server" datatype="*" errormsg="请选择商家分类"
                        sucmsg=" " AutoPostBack="True" OnSelectedIndexChanged="ddlCategary_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlCategarySub" runat="server" datatype="*" errormsg="请选择商家分类"
                        sucmsg=" ">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>--%>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-wrap">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
