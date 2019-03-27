<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category_list.aspx.cs" Inherits="Appoa.Manage.admin.course.category_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课程分类</title>
    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <!--<link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />-->
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <style type="text/css">
        /*.tree-list .col-1 {
            width: 6%;
            text-align: center;
        }

        .tree-list .col-2 {
            width: 10%;
        }

        .tree-list .col-3 {
            width: 32%;
        }

        .tree-list .col-4 {
            width: 22%;
        }

        .tree-list .col-5 {
            width: 6%;
            text-align: center;
        }

        .tree-list .col-6 {
            width: 12%;
            text-align: center;
        }

        .tree-list .col-7 {
            width: 12%;
            text-align: center;
        }*/
    </style>
    <script type="text/javascript">
        $(function () {
            initCategoryHtml('.tree-list', 1); //初始化分类的结构
            $('.tree-list').initCategoryTree(false); //初始化分类的事件

            $('.zoomify').zoomify();
        })
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
<div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>课程分类</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="category_edit.aspx?action=<%#EnumCollection.ActionEnum.Add %>">
                                <i></i><span>新增</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本导航及下属子导航，是否继续？');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <%--<div class="tree-list">
            <div class="thead">
                <div class="col col-1">选择</div>
                <div class="col col-2">图标</div>
                <div class="col col-3">类别名称</div>
                <div class="col col-4">标题</div>
                <div class="col col-5">分类等级</div>
                <div class="col col-6">排序</div>
                <div class="col col-7">操作</div>
            </div>
            <ul>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <li class="layer-<%#Eval("category_level")%>">
                            <div class="tbody">
                                <div class="col col-1">
                                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                </div>
                                <div class="col col-2">
                                    <img src="<%# string.IsNullOrEmpty(Eval("img_src").ToString())?"":Eval("img_src")%>"
                                        width="25" alt="" class="zoomify" />
                                </div>
                                <div class="col index col-3">
                                    <a href="category_edit.aspx?action=<%#EnumCollection.ActionEnum.Modify %>&id=<%#Eval("id")%>"><%#Eval("name")%></a>
                                </div>
                                <div class="col col-4">
                                    <%#Eval("name")%>
                                </div>
                                <div class="col col-5">
                                    <%#Eval("category_level").ToString() == "1" ? "一级" : "二级" %>
                                </div>
                                <div class="col col-6">
                                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort")%>' CssClass="sort" onkeydown="return checkNumber(event);" />
                                </div>
                                <div class="col col-7">
                                    <a href="category_edit.aspx?action=<%# EnumCollection.ActionEnum.Add %>&parent_id=<%#Eval("id")%>" style="display: <%# Utils.StrToInt(Eval("category_level").ToString(),0) <=2 ? "" : "none"%>">添加子级</a>
                                    <a href="category_edit.aspx?action=<%# EnumCollection.ActionEnum.Modify %>&id=<%#Eval("id")%>">修改</a>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>--%>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="6%">选择
                        </th>
                        <th width="10%">图标
                        </th>
                        <th align="left" width="60%">标题
                        </th>
                        <th align="left" width="10%">排序
                        </th>
                        <th width="10%">操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td align="center">
                        <div>
                            <img src="<%# string.IsNullOrEmpty(Eval("img_src").ToString())?"":Eval("img_src")%>"
                                width="25" alt="" class="zoomify" />
                        </div>
                    </td>
                    <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                        <a href="category_edit.aspx?action=<%# EnumCollection.ActionEnum.Modify %>&id=<%#Eval("id")%>">
                            <%#Eval("name")%></a>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort")%>' CssClass="sort"
                            onkeydown="return checkNumber(event);" />
                    </td>
                    <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                        <a href="category_edit.aspx?action=<%# EnumCollection.ActionEnum.Modify %>&id=<%#Eval("id")%>">修改</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
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
