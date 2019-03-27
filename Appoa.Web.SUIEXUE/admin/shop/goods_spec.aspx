<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods_spec.aspx.cs" Inherits="Appoa.Manage.admin.shop.goods_spec" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <title>商品规格</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.zoomify').zoomify();

            //获取url中的参数
            function getUrlParam(name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
                var r = window.location.search.substr(1).match(reg);  //匹配目标参数
                if (r != null) return unescape(r[2]); return null; //返回参数值
            }

            var id = getUrlParam('goods_id');

            //配置库存
            $('#save').click(function () {
                var winDialog = top.dialog({
                    title: '配置价格',
                    url: '/admin/dialog/dialog_SaveStock.aspx?id=' + id,
                    width: 800,
                    height: 600,
                    data: window //传入当前窗口
                }).showModal();
            });

        })
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../right.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>商品规格</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li style='display: <%= is_show=="1" ? "none" :"block"%>'><a class="add" href="goods_spec_edit.aspx?action=<%=EnumCollection.ActionEnum.Add %>&goods_id=<%=RequestHelper.GetQueryInt("goods_id") %>&page=<%=RequestHelper.GetQueryInt("page", 1) %>">
                                <i></i><span>新增</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本规格及下属子规格，是否继续？');"
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                            <li><a class="save" href="javascript:;" id="save"><i></i><span>配置价格</span></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="10%">选择
                            </th>
                            <th align="left">规格名称
                            </th>
                            <th align="left" width="12%">排序
                            </th>
                            <th width="20%">操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                            <asp:HiddenField ID="hidLayer" Value='<%#Eval("parent_id") %>' runat="server" />
                        </td>
                        <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                            <%#Eval("name")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsort" runat="server" CssClass="sort" Text='<%#Eval("sort") %>'></asp:TextBox>
                        </td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <a href="goods_spec_edit.aspx?action=<%#EnumCollection.ActionEnum.Add %>&id=<%#Eval("id")%>&page=<%=RequestHelper.GetQueryInt("page", 1) %>"
                                style='display: <%#(Eval("parent_id").ToString() != "0") ? "none" :"block"%>'>添加子规格</a>
                            <a href="goods_spec_edit.aspx?action=<%#EnumCollection.ActionEnum.Modify %>&id=<%#Eval("id")%>&page=<%=RequestHelper.GetQueryInt("page", 1) %>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
                </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->
    </form>
</body>
</html>
