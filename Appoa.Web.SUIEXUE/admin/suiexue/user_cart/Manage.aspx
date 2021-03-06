﻿<%@Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Appoa.Manage.admin.user_cart.Manage" ValidateRequest="false" %> 

<%@ Import Namespace="Appoa.Common" %> 
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>购物车表管理</title>
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
        <i class="arrow"></i><span>购物车表列表</span>
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
                                商家id
                            </th>
                            <th align="left">
                                分组id
                            </th>
                            <th align="left">
                                购买者id
                            </th>
                            <th align="left">
                                商品销售类型
                            </th>
                            <th align="left">
                                商品id
                            </th>
                            <th align="left">
                                标题
                            </th>
                            <th align="left">
                                副标题
                            </th>
                            <th align="left">
                                封面图
                            </th>
                            <th align="left">
                                原价
                            </th>
                            <th align="left">
                                现价
                            </th>
                            <th align="left">
                                规格值
                            </th>
                            <th align="left">
                                规格id
                            </th>
                            <th align="left">
                                数量
                            </th>
                            <th align="left">
                                添加时间
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
                                <%#Eval("ct_id")%>
                            </td>
                            <td>
                                <%#Eval("group_id")%>
                            </td>
                            <td>
                                <%#Eval("user_id")%>
                            </td>
                            <td>
                                <%#Eval("goods_sale_type")%>
                            </td>
                            <td>
                                <%#Eval("goods_id")%>
                            </td>
                            <td>
                                <%#Eval("goods_name")%>
                            </td>
                            <td>
                                <%#Eval("goods_subtitle")%>
                            </td>
                            <td>
                                <%#Eval("goods_img")%>
                            </td>
                            <td>
                                <%#Eval("goods_oprice")%>
                            </td>
                            <td>
                                <%#Eval("goods_price")%>
                            </td>
                            <td>
                                <%#Eval("goods_spec")%>
                            </td>
                            <td>
                                <%#Eval("goods_spec_id")%>
                            </td>
                            <td>
                                <%#Eval("num")%>
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