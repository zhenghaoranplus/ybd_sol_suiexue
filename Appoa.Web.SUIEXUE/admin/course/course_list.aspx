<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course_list.aspx.cs" Inherits="Appoa.Manage.admin.course.course_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>课程信息管理</title>
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

            $('.is_recommend').ios6switch({//是否推荐
                switchoffText: "否",
                switchonText: "推荐",
                switchonColor: "Green",
                animateSpeed: 200,
                size: 18
            });

            $('.is_show').ios6switch({//是否显示
                switchoffText: "否",
                switchonText: "显示",
                switchonColor: "Blue",
                animateSpeed: 200,
                size: 18
            });

            $('.is_recommend').change(function () {
                var id = $(this).attr('data_id');
                var check = $(this).attr('data_check');
                $.ajax({
                    type: 'Post',
                    url: '/tools/ajax_action.ashx',
                    data: { action: 'SetRecommend', id: id },
                    success: function (data) {

                    }
                })
            });

            $('.is_show').change(function () {
                var id = $(this).attr('data_id');
                var check = $(this).attr('data_check');
                $.ajax({
                    type: 'Post',
                    url: '/tools/ajax_action.ashx',
                    data: { action: 'SetIsShow', id: id },
                    success: function (data) {

                    }
                })
            });

            $('.watchCourseInfo').click(function () {
                var id = $(this).attr('cid');
                var winDialog = top.dialog({
                    title: '课程简介',
                    url: '/admin/dialog/course_info.aspx?id=' + id,
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
            <i class="arrow"></i><span>课程信息列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="course_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem Text="=所属分类=" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
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
                        <th width="5%">选择
                        </th>
                        <th align="left" width="15%">分类
                        </th>
                        <th align="left" width="15%">名称
                        </th>
                        <th align="center">封面图
                        </th>
                        <th align="center" width="10%">简介
                        </th>
                        <th align="left">二维码图片
                        </th>
                        <th align="left">二维码logo
                        </th>
                        <th align="center">推荐
                        </th>
                        <th align="center">显示
                        </th>
                        <th align="left" width="5%">课程开设者
                        </th>
                        <th align="left" width="10%">添加时间
                        </th>
                        <th width="5%">操作
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
                        <%#Eval("category_name")%>
                    </td>
                    <td>
                        <%#Eval("name")%>
                    </td>
                    <td align="center">
                        <%#Eval("cover").ToString()!=""? "<img class='zoomify' width=\"128\" src=\"" + Eval("cover") + "\" />" : "" %>
                    </td>
                    <td align="center">
                        <a href="javascript:;" cid="<%#Eval("id") %>" class="watchCourseInfo">查看简介</a>
                        <%--<div title="<%#Eval("info")%>">
                            <%#Eval("info").ToString().Length > 20 ? Eval("info").ToString().Substring(0, 20) + "..." : Eval("info").ToString() %>
                        </div>--%>
                    </td>
                    <td>
                        <%#Eval("qrcode").ToString()!=""? "<img class='zoomify' width=\"64\" src=\"" + Eval("qrcode") + "\" />" : "" %>
                    </td>
                    <td>
                        <%#Eval("qrcode_logo").ToString()!=""? "<img class='zoomify' width=\"64\" src=\"" + Eval("qrcode_logo") + "\" />" : "" %>
                    </td>
                    <td align="center">
                        <input type="checkbox" data_id='<%#Eval("Id") %>' data_check='<%#Eval("is_recommend") %>'
                            class="is_recommend" <%#Eval("is_recommend").ToString() == "0" ? "" : "checked" %> />
                    </td>
                    <td align="center">
                        <input type="checkbox" data_id='<%#Eval("Id") %>' data_check='<%#Eval("is_show") %>'
                            class="is_show" <%#Eval("is_show").ToString() == "0" ? "" : "checked" %> />
                    </td>
                    <td>
                        <%#Eval("user_name")%>
                    </td>
                    <td>
                        <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td align="center">
                        <a href="course_edit.aspx?action=<%=EnumCollection.ActionEnum.Modify %>&id=<%#Eval("Id")%>&page=<%=RequestHelper.GetQueryInt("page", 1) %>">修改</a>
                        <a href="javascript:;" onclick="downloadzip(<%#Eval("id") %>)">打包下载</a>
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
    <script>
        function downloadzip(id) {
            //创建iframe
            var action = "/tools/download_qrcode.ashx?action=DownCourseQrCode";
            var downloadHelper = $('<iframe style="display:none;" id="downloadHelper"></iframe>').appendTo('body')[0];
            var doc = downloadHelper.contentWindow.document;
            if (doc) {
                doc.open();
                doc.write('')//微软为doc.clear();
                doc.writeln("<html><body><form id='downloadForm' name='downloadForm' method='post' action='" + action + "'>");
                doc.writeln("<input type='hidden' name='course_id' value='" + id + "'>");
                doc.writeln('<\/form><\/body><\/html>');
                doc.close();
                var form = doc.forms[0];
                if (form) {
                    form.submit();
                }
            }
        }
    </script>
</body>
</html>
