﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="services_list.aspx.cs" Inherits="Appoa.Manage.admin.pc.services_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>我们的服务</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="../js/common.js"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <link href="../js/ios6switch.css" rel="stylesheet" type="text/css" />
    <script src="../js/ios6switch.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $('.zoomify').zoomify();

            $('.is_show').ios6switch({//是否显示
                switchoffText: "否",
                switchonText: "显示",
                switchonColor: "Blue",
                animateSpeed: 200,
                size: 18
            });

            $('.is_show').change(function () {
                var id = $(this).attr('data_id');

                $.ajax({
                    type: 'Post',
                    url: '/tools/ajax_action.ashx',
                    data: { action: 'SetBusinessIsShow', id: id },
                    success: function (data) {

                    }
                })
            });
        })
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>我们的服务</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="services_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
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
                        <th align="center">默认图
                        </th>
                        <th align="center">鼠标划过图
                        </th>
                        <th align="left">标题
                        </th>
                        <th align="left">详情
                        </th>
                        <th align="center">显示
                        </th>
                        <th align="left">添加时间
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
                    <td align="center">
                        <%#Eval("img_src").ToString() != "" ? "<img src='" + Eval("img_src") + "' class='zoomify' width='64'>" : "" %>
                    </td>
                    <td align="center">
                        <%#Eval("subtitle").ToString() != "" ? "<img src='" + Eval("subtitle") + "' class='zoomify' width='64'>" : "" %>
                    </td>
                    <td>
                        <%#Eval("title")%>
                    </td>
                    <td>
                        <div title='<%#Eval("contents") %>'>
                            <%#Eval("contents").ToString().Length > 40 ? Eval("contents").ToString().Substring(0,40) + "..." : Eval("contents")%>
                        </div>
                    </td>
                    <td align="center">
                        <input type="checkbox" data_id='<%#Eval("Id") %>' data_check='<%#Eval("upvote") %>'
                            class="is_show" <%#Eval("upvote").ToString() == "1" ? "checked" : "" %> />
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td align="center">
                        <a href="services_edit.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&id=<%#Eval("Id") %>&page=<%=RequestHelper.GetQueryInt("page", 1)%>&cp=<%=RequestHelper.GetQueryInt("cp") %>">修改</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : "" %>
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