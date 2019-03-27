<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionnaire_list.aspx.cs" Inherits="Appoa.Manage.admin.course.questionnaire_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>调查问卷管理</title>
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
    <script type="text/javascript">
        $(function () {
            $('.zoomify').zoomify();

            $('.wjjx').click(function () {
                var id = $(this).attr('eid');
                var winDialog = top.dialog({
                    title: '问卷解析',
                    url: '/admin/dialog/wjjx_info.aspx?id=' + id,
                    width: 1280,
                    height: 760,
                    data: window //传入当前窗口
                }).showModal();
            })

            $(".selectedQu").click(function () {
                var id = $(this).attr('exaid');
                var winDialog = top.dialog({
                    title: '已选试题',
                    url: '/admin/dialog/selected_question.aspx?group=2&exaid=' + id,
                    width: 1280,
                    height: 760,
                    data: window //传入当前窗口
                }).showModal();
            })

            $(".unselectedQu").click(function () {
                var id = $(this).attr('exaid');
                var winDialog = top.dialog({
                    title: '未选试题',
                    url: '/admin/dialog/unselected_course.aspx?group=2&exaid=' + id,
                    width: 1280,
                    height: 760,
                    data: window //传入当前窗口
                }).showModal();
            })
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i><span>调查问卷列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="questionnaire_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>&chapter=<%=RequestHelper.GetQueryInt("chapter") %>"><i></i><span>新增</span></a></li>
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
                        <th align="left">课程名称
                        </th>
                        <th align="left">章节名称
                        </th>
                        <th align="left">问卷名称
                        </th>
                        <th align="left">描述
                        </th>
                        <th align="left">解析
                        </th>
                        <th align="center">二维码
                        </th>
                        <th align="left">创建时间
                        </th>
                        <th width="20%">操作
                        </th>
                    </tr>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                    </td>
                    <td>
                        <%=course_name %>
                    </td>
                    <td>
                        <%=chapter_name %>
                    </td>
                    <td>
                        <%#Eval("name")%>
                    </td>
                    <td>
                        <%#Eval("info") %>
                    </td>
                    <td>
                        <a href="javascript:;" eid="<%#Eval("id") %>" class="wjjx">查看解析</a>
                    </td>
                    <td align="center">
                        <%#Eval("qrcode").ToString()!="" ? "<img class='zoomify' width=\"64\" src=\"" + Eval("qrcode") + "\" />" : "" %>
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td align="center">
                        <a href="questionnaire_edit.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&chapter=<%=RequestHelper.GetQueryInt("chapter") %>&id=<%#Eval("Id")%>">修改</a>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <a class="selectedQu" href="javascript:;" exaid="<%#Eval("Id") %>">查看已选试题</a>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <a class="unselectedQu" href="javascript:;" exaid="<%#Eval("Id") %>">查看未选试题</a>
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
