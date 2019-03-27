﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verify_list.aspx.cs" Inherits="Appoa.Manage.admin.classroom.verify_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课堂用户关系管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/common.js"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $('.zoomify').zoomify();
        })

        function examineVerify(obj, type) {
            var id = $(obj).attr('vid');

            $.ajax({
                type: 'post',
                url: '/tools/ajax_action.ashx',
                dataType: 'json',
                data: { action: 'ExamineVerify', id: id, type: type },
                success: function (result) {
                    window.location.reload();
                }
            })
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>课堂用户关系列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlClassroom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClassroom_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="8%">选择
                        </th>
                        <th align="left">课堂头像
                        </th>
                        <th align="left">课堂名称
                        </th>
                        <th align="left">申请者头像
                        </th>
                        <th align="left">申请者昵称
                        </th>
                        <th align="left">验证信息
                        </th>
                        <th align="left">审核状态
                        </th>
                        <th align="left">申请时间
                        </th>
                        <th width="8%">操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                    </td>
                    <td>
                        <%#Eval("classroom_avatar").ToString()!="" ? "<img src='"+Eval("classroom_avatar")+"' class='zoomify' width='64' />" : "" %>
                    </td>
                    <td>
                        <%#Eval("classroom_name")%>
                    </td>
                    <td>
                        <%#Eval("avatar").ToString()!="" ? "<img src='"+Eval("avatar")+"' class='zoomify' width='64' />" : "" %>
                    </td>
                    <td>
                        <%#string.IsNullOrEmpty(Eval("nick_name").ToString()) ? Eval("phone") : Eval("nick_name") %>
                    </td>
                    <td>
                        <%#Eval("contents")%>
                    </td>
                    <td>
                        <%#Enum.GetName(typeof(EnumCollection.examine_status), Eval("status"))%>
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td align="center">
                        <a href="javascript:;" vid="<%#Eval("Id")%>" onclick="examineVerify(this,1)">审核通过</a>
                        <a href="javascript:;" vid="<%#Eval("Id")%>" onclick="examineVerify(this,2)">审核失败</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : "" %>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->
        <!--内容底部-->
        <div class="line20">
        </div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default">
            </div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
