<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resource_list.aspx.cs" Inherits="Appoa.Manage.admin.course.resource_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>资源信息管理</title>
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
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="chapter_list.aspx?course_id=<%=RequestHelper.GetQueryInt("course_id") %>" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a><i class="arrow"></i>
            <a href="javascript:history.back(-1);"><span>章节管理</span></a>
            <i class="arrow"></i><span>资源信息列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="resource_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>&chapter=<%=RequestHelper.GetQueryInt("chapter") %>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>"><i></i><span>新增</span></a></li>
                            <li><a class="add" href="word_voice_edit.aspx?chapter=<%=RequestHelper.GetQueryInt("chapter") %>"><i></i><span>新增英文发音资源</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
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
                        <th align="left">分类
                        </th>
                        <th align="left">章节
                        </th>
                        <th align="left">标题
                        </th>
                        <th align="left">内容/路径
                        </th>
                        <th align="center">二维码
                        </th>
                        <th align="left">文件名
                        </th>
                        <th align="left">扩展名
                        </th>
                        <th align="left">上传者
                        </th>
                        <th align="left">排序
                        </th>
                        <th align="left">上传时间
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
                        <%#Enum.GetName(typeof(EnumCollection.resource_group), Eval("group_id"))%>
                    </td>
                    <td>
                        <%#Enum.GetName(typeof(EnumCollection.resource_type), Eval("type"))%>
                    </td>
                    <td>
                        <%#Eval("chapter_name")%>
                    </td>
                    <td>
                        <%#Eval("title")%>
                    </td>
                    <td>
                        <%#Eval("type").ToString() == "1" ? "<a href='../common/article_view.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" : 
                        Eval("type").ToString() == "2" ? "<a href='" + ReturnHtmlPath(Eval("path").ToString()) + "' target='_blank'>预览</a>" : 
                        Eval("type").ToString() == "3" || Eval("type").ToString() == "4" ? "<a href='../common/video_view.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" : 
                        Eval("type").ToString() == "6" ? "<a href='../common/3d.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" :
                        Eval("type").ToString() == "9" ? "<a href='../common/voice_view.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" : "" %>
                    </td>
                    <td align="center">
                        <%#Eval("qrcode").ToString()!="" ? "<img class='zoomify' width=\"64\" src=\"" + Eval("qrcode") + "\" />" : "" %>
                    </td>
                    <td>
                        <%#Eval("file_name")%>
                    </td>
                    <td>
                        <%#Eval("extend")%>
                    </td>
                    <td>
                        <%#Eval("user_name")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsort" Text='<%#Eval("sort")%>' runat="server" CssClass="sort" onkeydown="return checkNumber(event);"></asp:TextBox>
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td align="center">
                        <a href="<%#Eval("type").ToString() == "9" ? "word_voice_edit" : "resource_edit" %>.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&chapter=<%=RequestHelper.GetQueryInt("chapter") %>&id=<%#Eval("Id")%>&page=<%=RequestHelper.GetQueryInt("page", 1) %>&course_id=<%=RequestHelper.GetQueryInt("course_id") %>">修改</a>
                        <%--<a href="resource_edit.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&chapter=<%=RequestHelper.GetQueryInt("chapter") %>&id=<%#Eval("Id")%>">修改</a>--%>
                        <%#Eval("type").ToString() == "1" ? "<a href='../common/article_view.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" : 
                        Eval("type").ToString() == "2" ? "<a href='" + ReturnHtmlPath(Eval("path").ToString()) + "' target='_blank'>预览</a>" : 
                        Eval("type").ToString() == "3" || Eval("type").ToString() == "4" ? "<a href='../common/video_view.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" : 
                        Eval("type").ToString() == "6" ? "<a href='../common/3d.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" :
                        Eval("type").ToString() == "9" ? "<a href='../common/voice_view.aspx?id=" + Eval("Id") + "' target='_blank'>预览</a>" : "" %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : "" %>
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
