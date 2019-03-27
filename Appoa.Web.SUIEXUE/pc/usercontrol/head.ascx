<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="head.ascx.cs" Inherits="Appoa.Manage.pc.usercontrol.head" %>
<div id="hd">
    <div class="wp">
        <div class="logo">
            <a href="/pc/index.aspx">
                <img src="skin/images/logo.jpg" alt=""></a>
        </div>
        <div id="nav">
            <ul>
                <li>
                    <a href='about_us.aspx'>关于我们</a>
                </li>
                <li>
                    <a href='service_item.aspx'>服务项目</a>
                </li>
                <li>
                    <a href='news_list.aspx'>新闻动态</a>
                </li>
                <li>
                    <a href='case_list.aspx'>客户案例</a>
                </li>
                <li>
                    <a href='contact_us.aspx'>联系我们</a>
                </li>
            </ul>
        </div>
        <div class="tel">0371-88813995</div>
    </div>
</div>
<script src="skin/js/jquery.js"></script>
<script>
    var url = window.location.pathname;
    var urlArr = url.split('/');
    $.each($('#nav a'), function (k, v) {
        if (urlArr[urlArr.length - 1] == $(v).attr('href')) {
            $(v).addClass('mycur');
        } else if (urlArr[urlArr.length - 1] == 'news_info.aspx') {
            if ($(v).attr('href') == 'news_list.aspx') {
                $(v).addClass('mycur');
            }
        } else if (urlArr[urlArr.length - 1] == 'case_info.aspx') {
            if ($(v).attr('href') == 'case_list.aspx') {
                $(v).addClass('mycur');
            }
        }
    })

</script>
