<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods_list.aspx.cs" Inherits="Appoa.Manage.admin.shop.goods_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>商品信息管理</title>
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
    <link href="../js/ios6switch.css" rel="stylesheet" type="text/css" />
    <script src="../js/ios6switch.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.zoomify').zoomify();

            $('.status').ios6switch({//是否上架
                switchoffText: "下架",
                switchonText: "上架",
                switchonColor: "Green",
                animateSpeed: 200,
                size: 18
            });

            $('.is_index').ios6switch({//是否首页显示
                switchoffText: "否",
                switchonText: "是",
                switchonColor: "Blue",
                animateSpeed: 200,
                size: 18
            });

            $('.status').change(function () {
                var id = $(this).attr('data_id');
                var check = $(this).attr('data_check');
                $.ajax({
                    type: 'Post',
                    url: '/tools/ajax_action.ashx',
                    data: { action: 'SetSalesStatus', id: id },
                    success: function (data) {

                    }
                })
            });

            $('.is_index').change(function () {
                var id = $(this).attr('data_id');
                var check = $(this).attr('data_check');
                $.ajax({
                    type: 'Post',
                    url: '/tools/ajax_action.ashx',
                    data: { action: 'SetGoodsIndex', id: id },
                    success: function (data) {

                    }
                })
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>商品信息列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="goods_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
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
                        <th align="left">分组
                        </th>
                        <th align="left">商品分类
                        </th>
                        <th align="left">标题
                        </th>
                        <th align="left">外链
                        </th>
                        <th align="left">封面图
                        </th>
                        <th align="left">原价
                        </th>
                        <th align="left">现价
                        </th>
                        <th align="left">销量
                        </th>
                        <th align="center">状态
                        </th>
                        <th align="center">上首页
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
                    <td>
                        <%#Enum.GetName(typeof(EnumCollection.goods_group), Eval("group_id"))%>
                    </td>
                    <td>
                        <%#Eval("category_name")%>
                    </td>
                    <td>
                        <%#Eval("title")%>
                    </td>
                    <td>
                        <%#Eval("subtitle")%>
                    </td>
                    <td>
                        <%#Eval("img_src").ToString() != "" ? "<img src='" + Eval("img_src") + "' class='zoomify' width='100' />" : "" %>
                    </td>
                    <td>
                        <%#Eval("oprice", "{0:F2}")%>
                    </td>
                    <td>
                        <%#Eval("price", "{0:F2}")%>
                    </td>
                    <td>
                        <%#Eval("sales_num")%>
                    </td>
                    <td align="center">
                        <input type="checkbox" data_id='<%#Eval("Id") %>' data_check='<%#Eval("status") %>'
                            class="status" <%#Eval("status").ToString() == "2" ? "" : "checked" %> />
                    </td>
                    <td align="center">
                        <input type="checkbox" data_id='<%#Eval("Id") %>' data_check='<%#Eval("is_index") %>'
                            class="is_index" <%#Eval("is_index").ToString() == "0" ? "" : "checked" %> />
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd}")%>
                    </td>
                    <td align="center">
                        <a href="goods_edit.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&id=<%#Eval("Id")%>&page=<%=RequestHelper.GetQueryInt("page", 1) %>">修改</a>
                        <a href="goods_spec.aspx?goods_id=<%#Eval("id") %>&page=<%=RequestHelper.GetQueryInt("page", 1) %>">规格</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">暂无记录</td></tr>" : "" %>
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
