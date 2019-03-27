<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="currect_chapter_list.aspx.cs" Inherits="Appoa.Manage.admin.classroom.currect_chapter_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课堂章节管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <style type="text/css">
        .tree-list .col-1 {
            width: 8%;
            text-align: center;
        }

        .tree-list .col-2 {
            width: 16%;
            text-align: center;
        }

        .tree-list .col-3 {
            width: 42%;
            white-space: nowrap;
            word-break: break-all;
            overflow: hidden;
        }

        .tree-list .col-4 {
            width: 32%;
            text-align: center;
            white-space: nowrap;
            word-break: break-all;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            initCategoryHtml('.tree-list', 1); //初始化分类的结构
            $('.tree-list').initCategoryTree(false); //初始化分类的事件
        })
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>课堂管理</span><i class="arrow"></i><span>章节管理</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <h3>课堂名称：
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <div class="table-container">
            <div class="tree-list">
                <div class="thead">
                    <div class="col col-1">选择</div>
                    <div class="col col-2">课堂名称</div>
                    <div class="col col-3">章节名称</div>
                    <div class="col col-4">操作</div>
                </div>
                <ul>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <li class="layer-<%#Eval("chapter_level")%>">
                                <div class="tbody">
                                    <div class="col col-1">
                                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                    </div>
                                    <div class="col col-2">
                                        <%#Eval("classroom_name") %>
                                    </div>
                                    <div class="col index col-3">
                                        <%#Eval("name")%>
                                    </div>
                                    <div class="col col-4">
                                        <%#Eval("chapter_level").ToString() == "2" ? "<a href='correct_work_list.aspx?chapter="+Eval("id")+"'>查看作业</a>" : "" %>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <%--<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">选择
                            </th>
                            <th align="center">课堂名称
                            </th>
                            <th align="left">章节名称
                            </th>
                            <th width="28%">操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                            <asp:HiddenField ID="hidLayer" Value='<%#Eval("chapter_level") %>' runat="server" />
                        </td>
                        <td align="center">
                            <%#Eval("classroom_name") %>
                        </td>
                        <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <asp:Literal ID="LitFirst" runat="server"></asp:Literal><%#Eval("name")%>
                        </td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <%#Eval("chapter_level").ToString() == "2" ? "<a href='correct_work_list.aspx?chapter="+Eval("id")+"'>查看作业</a>" : "" %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : "" %>
                </table>
                </FooterTemplate>
            </asp:Repeater>--%>
        </div>
        <!--/列表-->
        <!--内容底部-->
        <div class="line20">
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
