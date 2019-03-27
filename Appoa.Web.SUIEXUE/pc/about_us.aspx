<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about_us.aspx.cs" Inherits="Appoa.Manage.pc.about_us" %>

<%@ Register Src="usercontrol/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/m_head.ascx" TagName="m" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/foot.ascx" TagName="foot" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>随E学-关于我们</title>
    <meta name="description" content="梧桐花,随意学" />
    <meta name="keywords" content="梧桐花,随意学" />
    <meta content="telephone=no" name="format-detection">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="renderer" content="webkit">
    <!--360默认急速模式打开-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0,user-scalable=no">
    <link rel="stylesheet" href="skin/css/cui.css">
    <link rel="stylesheet" href="skin/css/style.css">
    <link rel="stylesheet" href="skin/css/less.css">
    <style>
        .ul-customer li a b, .ul-customer li a img {
            display: inline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="head1" runat="server" />
        <!-- end #hd -->
        <div class="c"></div>
        <uc2:m ID="m1" runat="server" />
        <div class="c"></div>
        <div id="bd">
            <div id="ban-in" style="background-image: url(skin/images/14415956833641.jpg)">
                <div class="ban-bg"></div>
            </div>
            <div class="wp" id="whous">
                <div class="tit-i">
                    <h3>我们是谁</h3>
                    <h5>about <span>WEBTHINK</span></h5>
                </div>
                <div class="c"></div>
                <div class="about-info">
                    <%=contents %>
                </div>
            </div>
            <div class="c"></div>
            <div class="customer fix" id="ourcus">
                <div class="wp">
                    <div class="tit-i tit-i-1">
                        <h3>我们服务的客户</h3>
                        <h5>our <span>customer</span></h5>
                    </div>
                    <ul class="ul-customer">
                        <asp:Repeater ID="rptCustomer" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="javascript:void(0);" target="_blank">
                                        <b></b>
                                        <img src="<%#Eval("logo") %>" alt="<%#Eval("title") %>" width="234" height="87">
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="team" id="ourteam">
                <div class="wp">
                    <div class="tit-i">
                        <h3>我们的团队</h3>
                        <h5>our <span>team</span></h5>
                    </div>
                </div>
                <div class="flexslider">

                    <em></em>
                    <div class="flex-viewport" style="overflow: hidden; position: relative;">
                        <ul class="slides" style="width: 1400%; transition-duration: 0s; transform: translate3d(-9515px, 0px, 0px);">
                            <li class="clone" aria-hidden="true" style="width: 1903px; float: left; display: block;">
                                <div class="wp">
                                    <div class="txt">
                                        <h3 data-animate="fadeInDown" class="animated">课程设计团队</h3>
                                        <p data-animate="fadeInDown" class="animated">
                                        </p>
                                        <p class="animated fadeInDown" style="font-family: 微软雅黑, `Microsoft Yahei`; font-size: 14px; background-color: #FFFFFF;">
                                            严格把握教学大纲，提炼精彩教学片断；专业定位课程方向，协助教师策划教学内容；负责课程的推广及客户的开发与维护
                                        </p>
                                        <p></p>
                                    </div>
                                    <div class="pic">
                                        <img data-animate="fadeInDown" data-delay="0.5" class="animated" src="skin/images/o1.png" alt="" draggable="false">
                                        <img data-animate="fadeInUp" data-delay="0.8" class="animated" src="skin/images/o2.png" alt="" draggable="false">
                                        <img data-animate="fadeInUp" data-delay="1.2" class="animated" src="skin/images/o3.png" alt="" draggable="false">
                                        <img data-animate="fadeInDown" data-delay="1.5" class="animated" src="skin/images/o4.png" alt="" draggable="false">
                                    </div>
                                </div>
                            </li>
                            <li style="width: 1903px; float: left; display: block;" class="">
                                <div class="wp">
                                    <div class="txt">
                                        <h3 data-animate="fadeInDown" class="animated">摄影摄像团队</h3>
                                        <p data-animate="fadeInDown" class="animated">
                                        </p>
                                        <p class="animated fadeInDown" style="font-family: 微软雅黑, `Microsoft Yahei`; font-size: 14px; background-color: #FFFFFF;">
                                            专业的场景灯光布置，塑造教师形象；根据拍摄任务，制定详细的拍摄工作计划与时间安排；在完成拍摄任务的整个过程中，与拍摄小组的其他成员紧密协作；与教师沟通，以达到快速进入拍摄状态的效果
                                        </p>
                                        <p class="fadeInDown"></p>
                                    </div>
                                    <div class="pic">
                                        <img data-animate="fadeInLeft" data-delay="0.5" class="animated" src="skin/images/o5.png" alt="网思-网页设计" draggable="false" style="animation-delay: 0.5s;">
                                        <img data-animate="fadeInRight" data-delay="0.9" class="animated" src="skin/images/o6.png" alt="" draggable="false" style="animation-delay: 0.9s;">
                                    </div>
                                </div>
                            </li>
                            <li style="width: 1903px; float: left; display: block;" class="">
                                <div class="wp">
                                    <div class="txt">
                                        <h3 data-animate="fadeInDown" class="animated">视频制作团队</h3>
                                        <p data-animate="fadeInDown" class="animated">
                                        </p>
                                        <p class="animated fadeInDown" style="font-family: 微软雅黑, `Microsoft Yahei`; font-size: 14px; background-color: #FFFFFF;">
                                            根据课题元素加以视频特效剪辑，实现知识点完美呈现；集后期制作、影视技术为一体，既有其相对的独立操作技术，又有服务于数字内容开发的视觉技术。
                                        </p>
                                        <p class="fadeInDown"></p>
                                    </div>
                                    <div class="pic">
                                        <img data-animate="fadeInLeft" data-delay="0.5" class="animated" src="skin/images/o7.png" alt="" draggable="false" style="animation-delay: 0.5s;">
                                        <img data-animate="fadeInLeft" data-delay="0.8" class="animated" src="skin/images/o8.png" alt="" draggable="false" style="animation-delay: 0.8s;">
                                        <img data-animate="fadeInLeft" data-delay="1.2" class="animated" src="skin/images/o9.png" alt="" draggable="false" style="animation-delay: 1.2s;">
                                        <img data-animate="fadeInRight" data-delay="1.5" class="animated" src="skin/images/o10.png" alt="" draggable="false" style="animation-delay: 1.5s;">
                                        <img data-animate="fadeInDown" data-delay="1.8" class="animated" src="skin/images/o11.png" alt="" draggable="false" style="animation-delay: 1.8s;">
                                    </div>
                                </div>
                            </li>
                            <li style="width: 1903px; float: left; display: block;" class="">
                                <div class="wp">
                                    <div class="txt">
                                        <h3 data-animate="fadeInDown" class="animated">动画制作团队</h3>
                                        <p data-animate="fadeInDown" class="animated">
                                        </p>
                                        <p class="animated fadeInDown" style="font-family: 微软雅黑, `Microsoft Yahei`; font-size: 14px; background-color: #FFFFFF;">
                                            打造二维、三维模拟空间，使内容更直观；一方面独立地完成课程所需动画项目的策划、研发、制作，另一方面要配合其他项目内容实现动画效果；是数字出版内容视觉艺术传达的主要技术团队。
                                        </p>
                                        <p class="fadeInDown"></p>
                                    </div>
                                </div>
                                <div class="pic">
                                    <img data-animate="fadeInRight" data-delay="0.5" class="animated" src="skin/images/o18.png" alt="网思-网站建设" draggable="false" style="animation-delay: 0.5s;">
                                    <img data-animate="fadeInRight" data-delay="1.5" class="animated" src="skin/images/o21.png" alt="" draggable="false" style="animation-delay: 1.5s;">
                                    <img data-animate="fadeInLeft" data-delay="0.8" class="animated" src="skin/images/o19.png" alt="" draggable="false" style="animation-delay: 0.8s;">
                                    <img data-animate="fadeInLeft" data-delay="1.2" class="animated" src="skin/images/o20.png" alt="" draggable="false" style="animation-delay: 1.2s;">
                                    <img data-animate="fadeInLeft" data-delay="1.8" class="animated" src="skin/images/o22.png" alt="" draggable="false" style="animation-delay: 1.8s;">
                                </div>
                            </li>
                            <li style="width: 1903px; float: left; display: block;" class="">
                                <div class="wp">
                                    <div class="txt">
                                        <h3 data-animate="fadeInDown" class="animated">平台运维团队</h3>
                                        <p data-animate="fadeInDown" class="animated">
                                        </p>
                                        <p class="animated fadeInDown" style="font-family: 微软雅黑, `Microsoft Yahei`; font-size: 14px; background-color: #FFFFFF;">
                                            搭建专业数据库，在线共享平台；统计大数据，精准分析，方便管理；参与审核、优化公司平台系统以及各应用系统的体系架构；负责日常网络及平台系统管理维护。
                                        </p>
                                        <p class="fadeInDown"></p>
                                    </div>
                                    <div class="pic">
                                        <img data-animate="fadeInLeft" data-delay="0.5" class="animated" src="skin/images/o12.png" alt="" draggable="false" style="animation-delay: 0.5s;">
                                        <img data-animate="fadeInLeft" data-delay="1.2" class="animated" src="skin/images/o14.png" alt="" draggable="false" style="animation-delay: 1.2s;">
                                        <img data-animate="fadeInLeft" data-delay="0.8" class="animated" src="skin/images/o13.png" alt="" draggable="false" style="animation-delay: 0.8s;">
                                        <img data-animate="fadeInLeft" data-delay="1.5" class="animated" src="skin/images/o15.png" alt="" draggable="false" style="animation-delay: 1.5s;">
                                        <img data-animate="fadeInLeft" data-delay="1.8" class="animated" src="skin/images/o17.png" alt="" draggable="false" style="animation-delay: 1.8s;">
                                        <img data-animate="fadeInLeft" data-delay="2.2" class="animated" src="skin/images/o16.png" alt="" draggable="false" style="animation-delay: 2.2s;">
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <ul class="flex-direction-nav">
                        <li class="flex-nav-prev"><a class="flex-prev" href="#"></a></li>
                        <li class="flex-nav-next"><a class="flex-next" href="#"></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- end #bd -->
        <div class="c"></div>
        <!-- begin #fd -->
        <uc3:foot ID="foot1" runat="server" />

        <script type="text/javascript" src="skin/js/jquery.js"></script>
        <script type="text/javascript" src="skin/js/lib.js"></script>
        <link rel="stylesheet" href="skin/css/animate.css">
        <link rel="stylesheet" href="skin/css/flexslider.css">
        <script type="text/javascript" src="skin/js/flexslider.js"></script>
        <script>
            $('.team .flexslider').flexslider({
                animation: "slide",
                animationLoop: true,
                slideshow: false,
                prevText: "",
                nextText: "",
                controlNav: false,
                directionNav: true,
                pauseOnHover: true,
                slideshowSpeed: 3000,
                start: function (slider) {

                },
                before: function () {
                    $('.flexslider').resize();
                },
                after: function (slider) {
                    initState();
                    move();
                }
            });
            function initState() {
                $('.team .animated').each(function () {
                    var dataAnimate = $(this).data('animate');
                    $(this).removeClass(dataAnimate);
                })
            }
            function move() {
                var curSlide = $('.team .slides li.flex-active-slide');
                var h3 = curSlide.find('h3'),
                p = curSlide.find('p'),
                img = curSlide.find('img');
                h3.addClass(h3.data('animate'));
                p.addClass(p.data('animate'));
                img.each(function () {
                    $(this).addClass($(this).data('animate')).css({ 'animation-delay': $(this).data('delay') + 's' });
                })
            }
            $(window).load(function () {
                move();
            })
        </script>
    </form>
</body>
</html>
