<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chapter_list.aspx.cs" Inherits="Appoa.Manage.admin.course.chapter_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课程章节管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/common.js"></script>
    <style type="text/css">
        .tree-list .col-1 {
            width: 8%;
            text-align: center;
        }

        .tree-list .col-2 {
            width: 16%;
        }

        .tree-list .col-3 {
            width: 42%;
        }

        .tree-list .col-4 {
            width: 32%;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            initCategoryHtml('.tree-list', 1); //初始化分类的结构
            $('.tree-list').initCategoryTree(false); //初始化分类的事件
        })

        function openicon(obj) {
            $(obj).parent().find('i:eq(0)').click();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="chapter_course_list.aspx" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>精品微课</span><i class="arrow"></i><span>章节管理</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="chapter_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
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
                    <div class="col col-2">微课名称</div>
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
                                        <%#Eval("course_name") %>
                                    </div>
                                    <div class="col col-3">
                                        <%--<a href="javascript:;" onclick="openicon(this)"><%#Eval("name")%></a>--%>
                                        <a href="chapter_edit.aspx?action=<%#EnumCollection.ActionEnum.Modify %>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>&id=<%#Eval("id")%>"><%#Eval("name")%></a>
                                    </div>
                                    <div class="col col-4">
                                        <%--<a href="chapter_edit.aspx?action=<%#EnumCollection.ActionEnum.Add %>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>&parent_id=<%#Eval("id")%>">添加子级</a>--%>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="chapter_edit.aspx?action=<%#EnumCollection.ActionEnum.Modify %>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>&id=<%#Eval("id")%>">修改</a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="resource_list.aspx?chapter=<%#Eval("id")%>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>">资源管理</a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="examination_list.aspx?chapter=<%#Eval("id")%>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>">试卷管理</a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="questionnaire_list.aspx?chapter=<%#Eval("id")%>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>">调查问卷</a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="discuss_list.aspx?chapter=<%#Eval("id")%>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>">讨论列表</a>
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
                            <th align="center">微课名称
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
                            <%#Eval("course_name") %>
                        </td>
                        <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                            <a href="chapter_edit.aspx?action=<%# EnumCollection.ActionEnum.Modify %>&course_id=<%=this.ddlCourse.SelectedValue %>&id=<%#Eval("id")%>">
                                <%#Eval("name")%></a>
                        </td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <a href="chapter_edit.aspx?action=<%#EnumCollection.ActionEnum.Add %>&course_id=<%=this.ddlCourse.SelectedValue %>&parent_id=<%#Eval("id")%>">添加子级</a>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="chapter_edit.aspx?action=<%#EnumCollection.ActionEnum.Modify %>&course_id=<%=this.ddlCourse.SelectedValue %>&id=<%#Eval("id")%>">修改</a>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="resource_list.aspx?chapter=<%#Eval("id")%>">资源管理</a>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="examination_list.aspx?chapter=<%#Eval("id")%>">试卷管理</a>
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
