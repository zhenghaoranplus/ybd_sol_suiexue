<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="currect_answer_list.aspx.cs" Inherits="Appoa.Manage.admin.classroom.currect_answer_list" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>答题记录管理</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <link href="../js/ios6switch.css" rel="stylesheet" type="text/css" />
    <script src="../js/ios6switch.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $('.is_truth').ios6switch({//是否显示
                switchoffText: "错误",
                switchonText: "正确",
                switchonColor: "Green",
                animateSpeed: 200,
                size: 18
            });

            $('.is_truth').change(function () {
                var id = $(this).attr('data_id');
                var check = $(this).attr('data_check');
                var q_score = $(this).attr('q_score');
                var scoreText = $(this).parent().parent().children().children('input[type=text]');
                var score = scoreText.val();
                if ($(this).is(':checked')) {
                    scoreText.val(parseInt(q_score, 10));
                } else {
                    scoreText.val(0);
                }

                score = scoreText.val()
                $.ajax({
                    type: 'Post',
                    url: '/tools/ajax_action.ashx',
                    data: { action: 'SetAnswerIsTruth', id: id, score: score },
                    success: function (data) {

                    }
                })
            });
        })

        function changescore(obj) {
            var id = $(obj).attr('data_id');
            var score = $(obj).val();
            $.ajax({
                type: 'Post',
                url: '/tools/ajax_action.ashx',
                data: { action: 'SetAnswerScore', id: id, score: score },
                success: function (data) {

                }
            })
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            题目：<%=question %>
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
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">选择
                            </th>
                            <th align="left">答题者
                            </th>
                            <th align="left">试题
                            </th>
                            <th align="left">题型
                            </th>
                            <th align="left" width="20%">答案
                            </th>
                            <th align="center">结果
                            </th>
                            <th align="left">分数
                            </th>
                            <th align="left">完成时间
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
                            <%#Eval("nick_name")%>
                        </td>
                        <td>
                            <%#Eval("q_name")%>
                        </td>
                        <td>
                            <%#Enum.GetName(typeof(EnumCollection.questions_type), Eval("q_type"))%>
                        </td>
                        <td>
                            <%#Convert.ToInt32(Eval("q_type")) <= 3 ? GetOptions(Eval("answer").ToString()) : Eval("answer").ToString() %>
                        </td>
                        <td align="center">
                            <input type="checkbox" data_id='<%#Eval("Id") %>' data_check='<%#Eval("is_truth") %>' q_score='<%#Eval("q_score") %>'
                                class="is_truth" <%#Eval("is_truth").ToString() == "1" ? "checked" : "" %> />
                        </td>
                        <td>
                            <input type="text" value="<%#Eval("score")%>" data_id='<%#Eval("Id") %>' q_score='<%#Eval("q_score") %>' onblur="changescore(this)" />
                        </td>
                        <td>
                            <%#Eval("add_time","{0:yyyy-MM-dd HH:mm:ss}")%>
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
