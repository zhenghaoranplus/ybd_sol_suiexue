<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_detail.aspx.cs" Inherits="Appoa.Manage.admin.shop.order_detail" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>订单详情</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="javascript:history.back(-1);">
                    <span>订单列表</span></a> <i class="arrow"></i><span>订单详情</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">订单信息详情</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dd>
                    <div class="order-flow" style="width: 1000px">
                        <%if (model.status >= (int)EnumCollection.order_status.待发货 && model.status <= (int)EnumCollection.order_status.已完成)
                          { %>
                        <%if (model.status > (int)EnumCollection.order_status.待发货)
                          { %>
                        <div class="order-flow-left">
                            <a class="order-flow-input">已发货</a> <span>
                                <p class="name">
                                    已发货
                                </p>
                            </span>
                        </div>
                        <%}
                          else
                          { %>
                        <div class="order-flow-wait">
                            <a class="order-flow-input">待发货</a> <span>
                                <p class="name">
                                    尚未发货
                                </p>
                            </span>
                        </div>
                        <%}%>
                        <%if (model.status > (int)EnumCollection.order_status.待收货)
                          { %>
                        <div class="order-flow-arrive">
                            <a class="order-flow-input">已收货</a> <span>
                                <p class="name">
                                    已收货
                                </p>
                            </span>
                        </div>
                        <%}
                          else
                          { %>
                        <div class="order-flow-wait">
                            <a class="order-flow-input">待收货</a> <span>
                                <p class="name">
                                    尚未收货
                                </p>
                            </span>
                        </div>
                        <%}%>
                        <%if (model.status > (int)EnumCollection.order_status.待评价)
                          { %>
                        <div class="order-flow-arrive">
                            <a class="order-flow-input">已评价</a> <span>
                                <p class="name">
                                    已评价
                                </p>
                            </span>
                        </div>
                        <%}
                          else
                          { %>
                        <div class="order-flow-wait">
                            <a class="order-flow-input">待评价</a> <span>
                                <p class="name">
                                    尚未评价
                                </p>
                            </span>
                        </div>
                        <%}%>
                        <%if (model.status == (int)EnumCollection.order_status.已完成)
                          { %>
                        <div class="order-flow-right-arrive">
                            <a class="order-flow-input">已完成</a> <span>
                                <p class="name">
                                    已完成
                                </p>
                            </span>
                        </div>
                        <%}
                          else
                          { %>
                        <div class="order-flow-right-wait">
                            <a class="order-flow-input">未评价</a> <span>
                                <p class="name">
                                    尚未评价
                                </p>
                            </span>
                        </div>
                        <%}
                          }%>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>订单信息</dt>
                <dd>
                    <div class="table-container">
                        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="95%">
                            <tr>
                                <th width="20%">订单编号
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtorder_no" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">下单用户
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtuser_name" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>订单使用积分</th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtuse_point" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">订单金额
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtorder_amount" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">需付总金额
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtpayable_amount" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>运费</th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtexpress_money" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">收货人姓名
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtaccept_name" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">联系方式
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtmobile" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">收货地址
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtaddress" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">订单状态
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtstatus" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">订单留言
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtmessage" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">下单时间
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtadd_time" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">确认时间
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtconfirm_time" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">订单完成时间
                                </th>
                                <td>
                                    <div class="position">
                                        <span>
                                            <asp:TextBox ID="txtcomplete_time" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>物流信息</dt>
                <dd>
                    <div class="table-container">
                        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="95%">
                            <tr>
                                <th width="20%">物流公司名称
                                </th>
                                <td>
                                    <%--<div class="position">
                                        <asp:DropDownList ID="ddlExpress" runat="server">
                                            <asp:ListItem Value="yuantong" Selected="True">圆通速递</asp:ListItem>
                                            <asp:ListItem Value="yunda">韵达快递</asp:ListItem>
                                            <asp:ListItem Value="shunfeng">顺丰速运</asp:ListItem>
                                            <asp:ListItem Value="shentong">申通快递</asp:ListItem>
                                            <asp:ListItem Value="huitongkuaidi">汇通快递</asp:ListItem>
                                            <asp:ListItem Value="ems">EMS</asp:ListItem>
                                            <asp:ListItem Value="tiantian">天天快递</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>--%>
                                    <asp:TextBox ID="txtexpress_name" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">物流单号
                                </th>
                                <td>
                                    <div class="position">
                                        <asp:TextBox ID="txtexpress_no" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>订单商品</dt>
                <dd>
                    <asp:Repeater ID="rptOrderGoods" runat="server">
                        <HeaderTemplate>
                            <div class="table-container">
                                <table class="border-table" width="95%">
                                    <thead>
                                        <tr>
                                            <th width="25%">商品名称
                                            </th>
                                            <th width="25%">商品图片
                                            </th>
                                            <th width="10%">商品价格
                                            </th>
                                            <th width="10%">商品规格
                                            </th>
                                            <th width="10%">购买数量
                                            </th>
                                            <th width="10%">总价格
                                            </th>
                                            <th width="5%">评价信息
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="td_c">
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <%#Eval("goods_title") %>
                                </td>
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <img src='<%# string.IsNullOrEmpty(Eval("img_url").ToString()) ? "" : Eval("img_url").ToString()%>'
                                        alt="" width="90" />
                                </td>
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <%#Eval("goods_group").ToString() == "1" ? "&yen;" + Eval("goods_price", "{0:F2}") : Eval("goods_price", "{0:F0}") + "积分"%>
                                </td>
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <%#Eval("goods_spec").ToString()%>
                                </td>
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <%#Eval("quantity")%>
                                </td>
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <%#Eval("goods_group").ToString() == "1" ? "&yen;" + (Utils.StrToDecimal(Eval("goods_price").ToString(), 0M) * Utils.StrToDecimal( Eval("quantity").ToString(), 0M)).ToString("F2") : Utils.StrToInt(Eval("goods_price").ToString(), 0) * Utils.StrToInt( Eval("quantity").ToString(), 0) + "积分"%>
                                </td>
                                <td style="white-space: inherit; word-break: break-all; line-height: 20px;">
                                    <a class="evaluate" style="color: blue; cursor: pointer; display: <%# Eval("is_eval").ToString() == "1" ? "" : "none" %>" dataid="<%#Eval("id")%>">查看评价</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table></div>
                        </FooterTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnExpress" runat="server" OnClick="btnExpress_Click" class="btn"
                    Text="确认发货" />
                <asp:Button ID="btnSubmit" runat="server" Text="修改物流" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
