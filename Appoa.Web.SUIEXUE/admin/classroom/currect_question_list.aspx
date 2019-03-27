<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="currect_question_list.aspx.cs" Inherits="Appoa.Manage.admin.classroom.currect_question_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>题目信息管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/common.js"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <script>
        function watchAnswer(exa_id, q_id) {
            var winDialog = top.dialog({
                title: '答题记录',
                url: '/admin/classroom/currect_answer_list.aspx?exa_id=' + exa_id + '&q_id=' + q_id,
                width: 1280,
                height: 760,
                data: window //传入当前窗口
            }).showModal();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>试题管理</span><i class="arrow"></i><span>题目信息列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            课堂：<%=class_name %> > 章：<%=parent_name %> > 节：<%=chapter_name %> > 作业：<%=examination %>
                        </ul>

                    </div>
                    <div class="r-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
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
                            <th width="8%">选择
                            </th>
                            <th align="center">题型
                            </th>
                            <th align="left">题目
                            </th>
                            <th align="center">分值
                            </th>
                            <th align="center">添加时间
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
                            <%#Enum.GetName(typeof(EnumCollection.questions_type), Eval("type"))%>
                        </td>
                        <td>
                            <%#Eval("title")%>
                        </td>
                        <td align="center">
                            <%#Eval("score","{0:F0}")%>
                        </td>
                        <td align="center">
                            <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                        </td>
                        <td align="center">
                            <a href="javascript:;" onclick="watchAnswer(<%=RequestHelper.GetQueryInt("id") %>,<%#Eval("id") %>)">查看答题记录</a>
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
