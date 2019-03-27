<%@Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Appoa.Manage.admin.company_partner.Add" ValidateRequest="false" %> 
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
                <span>合作伙伴管理</span></a> <i class="arrow"></i><span>添加合作伙伴</span>
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
                <dt>公司id</dt>
                <dd>
                    <asp:TextBox ID="txtcompany_id" runat="server" CssClass="input normal" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4字以内</span>
                </dd>
            </dl>
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
                <dt>视频地址</dt>
                <dd>
                    <asp:TextBox ID="txtvideo_url" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>视频缩略图地址</dt>
                <dd>
                    <asp:TextBox ID="txtvideo_thumb_img" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*255字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>案例详情</dt>
                <dd>
                    <asp:TextBox ID="txtdetails" runat="server" CssClass="input normal" datatype="*0-16" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*16字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>是否显示</dt>
                <dd>
                    <asp:TextBox ID="txtis_show" runat="server" CssClass="input normal" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtsort" runat="server" CssClass="input normal" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*4字以内</span>
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
