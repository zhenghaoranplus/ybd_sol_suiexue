<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="video_list.aspx.cs" Inherits="Appoa.Manage.admin.classroom.video_list" %>

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
    <script src="../js/layer/layer.js"></script>
    <script type="text/javascript">
        var flag = false;
        $(function () {
            $('.zoomify').zoomify();

            $('#chooseResource').click(function () {
                layer.open({
                    type: 2,
                    title: '视频资源',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['1280px', '760px'], //宽高
                    content: ['/admin/dialog/video_resource.html?class_id=' + $('#ddlClass').val(), 'yes'],
                    end: function () {
                        if (flag) {
                            location.reload();
                        }
                    }
                })
            })
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a><i class="arrow"></i>
            <a href="javascript:history.back(-1);"><span>学习资料管理</span></a>
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
                            <li><a class="add" href="video_add.aspx?action=<%=EnumCollection.ActionEnum.Add %>&class_id=<%=this.ddlClass.SelectedValue %>"><i></i><span>新增</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                            <li><a href="javascript:;" id="chooseResource" class="move"><i></i><span>从已有资源中选择</span></a></li>
                        </ul>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlddlClass_SelectedIndexChanged"></asp:DropDownList>
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
                        <th align="left">课堂
                        </th>
                        <th align="left">标题
                        </th>
                        <th align="center">封面图
                        </th>
                        <th align="center">二维码
                        </th>
                        <th align="left">文件名
                        </th>
                        <th align="left">扩展名
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
                        <%#GetClassRoomName(Convert.ToInt32(Eval("data_id")))%>
                    </td>
                    <td>
                        <%#Eval("title")%>
                    </td>
                    <td align="center">
                        <%#Eval("cover").ToString()!="" ? "<img class='zoomify' width=\"64\" src=\"" + Eval("cover") + "\" />" : "" %>
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
                        <asp:TextBox ID="txtsort" runat="server" Text='<%#Eval("sort")%>' CssClass="sort" onkeydown="return checkNumber(event);"></asp:TextBox>
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td align="center">
                        <a href="video_edit.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&class_id=<%=this.ddlClass.SelectedValue %>&id=<%#Eval("Id")%>&page=<%=RequestHelper.GetQueryInt("page", 1) %>">修改</a>
                        <a href="../common/video_view.aspx?id=<%#Eval("Id")%>" target="_blank">预览</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : "" %>
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
