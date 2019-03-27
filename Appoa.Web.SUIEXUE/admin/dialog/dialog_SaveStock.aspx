<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_SaveStock.aspx.cs" Inherits="Appoa.Manage.admin.dialog.dialog_SaveStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>配置价格</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/JQuery/PCASClass.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        var api = top.dialog.get(window); //获取窗体对象
        var W = api.data;
        //页面加载完成执行
        $(function () {
            $('#price').change(function () {
                var price = $(this).parent().parent().find('#price').val();
                var id = $(this).parent().parent().find('.hidId').val();
                if (parseInt(id) > 0) {
                    $.ajax({
                        type: 'Post',
                        url: '/tools/ajax_action.ashx',
                        data: { action: 'UpdateSpec', id: id, price: price },
                        success: function (data) {
                            if (data != '1') {
                                alert('参数修改失败');
                            }
                        }
                    })
                }
            })
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->

        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="49%">规格信息
                        </th>
                        <th width="49%">价格
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <input type="hidden" class="hidId" value='<%#Eval("id")%>' />
                    <td align="center" width="64">
                        <%#Eval("name")%>
                    </td>
                    <td align="center" width="64">
                        <input type="text" name="price" id="price" value='<%#Eval("price", "{0:F2}")%>' class="input"
                            datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" " />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">暂无记录</td></tr>" : ""%>
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
