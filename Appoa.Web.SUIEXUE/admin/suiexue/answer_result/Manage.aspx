<%@Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Appoa.Manage.admin.answer_result.Manage" ValidateRequest="false" %> 

<%@ Import Namespace="Appoa.Common" %> 
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>答题结果管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../right.aspx" class="home"><i></i><span>首页</span></a> 
        <i class="arrow"></i><span>答题结果列表</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div id="floatHead" class="toolbar-wrap">
        <div class="toolbar">
            <div class="box-wrap">
                <a class="menu-btn"></a>
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="Add.aspx"><i></i><span>新增</span></a></li>
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
    <div class="table-container">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="8%">
                            选择
                        </th>
                            <th align="left">
                                分组ID
                            </th>
                            <th align="left">
                                试卷ID
                            </th>
                            <th align="left">
                                试卷标题
                            </th>
                            <th align="left">
                                答题者ID
                            </th>
                            <th align="left">
                                头像
                            </th>
                            <th align="left">
                                昵称
                            </th>
                            <th align="left">
                                用时-分钟
                            </th>
                            <th align="left">
                                用时-秒钟
                            </th>
                            <th align="left">
                                答对题数
                            </th>
                            <th align="left">
                                总题数
                            </th>
                            <th align="left">
                                正确率
                            </th>
                            <th align="left">
                                总分
                            </th>
                            <th align="left">
                                批改状态 1已批改 0未批改
                            </th>
                            <th align="left">
                                完成时间
                            </th>
                        <th width="8%">
                            操作
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
                                <%#Eval("group_id")%>
                            </td>
                            <td>
                                <%#Eval("exa_id")%>
                            </td>
                            <td>
                                <%#Eval("exa_title")%>
                            </td>
                            <td>
                                <%#Eval("user_id")%>
                            </td>
                            <td>
                                <%#Eval("avatar")%>
                            </td>
                            <td>
                                <%#Eval("nick_name")%>
                            </td>
                            <td>
                                <%#Eval("use_min")%>
                            </td>
                            <td>
                                <%#Eval("use_sec")%>
                            </td>
                            <td>
                                <%#Eval("truth_num")%>
                            </td>
                            <td>
                                <%#Eval("count")%>
                            </td>
                            <td>
                                <%#Eval("truth_ratio","{0:F2}")%>
                            </td>
                            <td>
                                <%#Eval("score")%>
                            </td>
                            <td>
                                <%#Eval("status")%>
                            </td>
                            <td>
                                <%#Eval("add_time","{0:yyyy-MM-dd}")%>
                            </td>
                    <td align="center">
                        <a href="Modify.aspx?id=<%#Eval("Id")%>">修改</a>
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