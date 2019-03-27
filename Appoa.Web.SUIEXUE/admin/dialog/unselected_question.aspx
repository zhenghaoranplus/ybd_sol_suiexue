<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unselected_question.aspx.cs" Inherits="Appoa.Manage.admin.dialog.unselected_question" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title></title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/common.js"></script>
    <script>
        $(function () {
            var allid = localStorage.getItem('quest_all_id');
            if (!allid) {
                allid = '';
            } else {
                var arr = allid.split(',,');

                $.each(arr, function (k, v) {
                    var did = v.toString().replace(',', '');
                    $('input[type=checkbox]').each(function (j, r) {
                        var cid = $(r).parent().attr('did');
                        if (cid == did) {
                            $(r).prop('checked', true);
                        }
                    })
                })
            }

            $('#hdfAllID').val(allid);

            $('input[type=checkbox]').click(function () {

                var serverid = $(this).attr('id');
                var findex = serverid.indexOf('_');
                var lindex = serverid.lastIndexOf('_');
                var id = serverid.substr(findex + 1, lindex - findex - 1);
                id = id.toString().replace('chkId', '');

                if ($(this).prop('checked')) {
                    allid += ',' + id + ',';
                    $('#hdfAllID').val(allid);
                } else {
                    allid = allid.replace(',' + id + ',', '');
                    $('#hdfAllID').val(allid);
                }

                localStorage.setItem('quest_all_id', $('#hdfAllID').val());
            })
        })

        function AddBack() {
            var allid = $('#hdfAllID').val();
            if (!allid) {
                parent.dialog({
                    title: '提示',
                    content: '对不起，请选中您要操作的记录！',
                    okValue: '确定',
                    ok: function () { }
                }).showModal();
                return false;
            }

            localStorage.removeItem('quest_all_id')
        }

        function CancelBack() {
            localStorage.removeItem('quest_all_id');
            $('#hdfAllID').val('');

            $('input[type=checkbox]').each(function (k, v) {
                $(v).prop('checked', false);
            })
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <span>未选题目列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <!--<li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>-->
                            <li>
                                <asp:HiddenField runat="server" ID="hdfAllID" Value="" />
                            </li>
                            <li>
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="add" OnClientClick="return AddBack();"
                                    OnClick="btnAdd_Click"><i></i><span>添加</span></asp:LinkButton></li>
                            <li>
                                <a href="javascript:;" class="all" onclick="return CancelBack();">
                                    <i></i><span>取消</span></a></li>
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
                            <th width="8%">选择
                            </th>
                            <th align="center">题型
                            </th>
                            <th align="left">题目
                            </th>
                            <th align="center">分值
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" did='<%#Eval("ID")%>' CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                        </td>
                        <td align="center">
                            <%#Enum.GetName(typeof(EnumCollection.questions_type), Eval("type"))%>
                        </td>
                        <td>
                            <%#Eval("title")%>
                        </td>
                        <td align="center">
                            <%#Eval("score","{0:F0}")%>
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

