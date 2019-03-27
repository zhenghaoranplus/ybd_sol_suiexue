<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unselected_chapter.aspx.cs" Inherits="Appoa.Manage.admin.dialog.unselected_chapter" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课程章节管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/common.js"></script>
    <style>
        .single-select {
            float: left;
        }

        .toolbar .l-list .keyword {
            display: block;
            float: left;
            margin: 0;
            padding: 0 5px;
            width: 210px;
            height: 30px;
            line-height: 28px;
            font-size: 12px;
            border: 1px solid #eee;
            color: #444;
        }

        .toolbar .l-list .btn-search {
            display: block;
            float: left;
            margin: 0 0 0 -1px;
            padding: 0;
            width: 30px;
            height: 30px;
            line-height: 30px;
            border: 1px solid #eee;
            background: url(../skin/default/skin_icons.png) -160px -20px no-repeat #fafafa;
            cursor: pointer;
            text-indent: -9999px;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <span>课程章节列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                    <div class="r-list">
                        <%--<asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>--%>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">序号
                            </th>
                            <th align="left">课程
                            </th>
                            <th align="left">名称
                            </th>
                            <th width="8%">操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("ID")%>
                        </td>
                        <td>
                            <%#Eval("course_name")%>
                        </td>
                        <td>
                            <%#Eval("name")%>
                        </td>
                        <td align="center">
                            <a href="unselected_question.aspx?group=<%=RequestHelper.GetQueryInt("group") %>&exaid=<%=RequestHelper.GetQueryInt("exaid") %>&chapter=<%#Eval("Id")%>">试题管理</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : "" %>
                </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
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
