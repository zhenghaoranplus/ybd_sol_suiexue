<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="service_item.aspx.cs" Inherits="Appoa.Manage.pc.service_item" %>

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
        .webset-pop .txt {
            font-size: 16px;
            width: 100%;
            text-indent: 32px;
            letter-spacing: 3px;
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
            <div id="ban-in" style="background-image: url(skin/images/14415956565984.jpg)">
                <div class="ban-bg"></div>
            </div>
            <div class="wp" id="webbuit">
                <div class="tit-i">
                    <h3>微课&MOOC开发</h3>
                    <h5>Micro-Course <span>Online</span></h5>
                </div>
                <div class="about-info">
                    <%=str %>
                </div>
                <ul class="ul-webset pr ul-show">
                    <li class="li1">
                        <div class="block">
                            <img src="skin/images/w1.png" alt="">
                            <img src="skin/images/w2.png" alt="">
                            <img src="skin/images/w3.png" alt="">
                            <img src="skin/images/w4.png" alt="">
                            <img src="skin/images/w5.png" alt="">
                            <img src="skin/images/w6.png" alt="">
                            <img src="skin/images/w7.png" alt="">
                            <img src="skin/images/w8.png" alt="">
                            <img src="skin/images/w9.png" alt="">
                        </div>
                        <h3>参赛微课</h3>
                        <a href="javascript:;" class="btn"></a>
                        <div class="webset-pop">
                            <div class="pad">
                                <h2>参赛微课<a href="javascript:void(0);" class="close"></a></h2>
                                <div class="txt">
                                    <%=str3 %>
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="li2">
                        <div class="block">
                            <img src="skin/images/q1.png" alt="">
                            <img src="skin/images/q2.png" alt="">
                            <img src="skin/images/q3.png" alt="">
                            <img src="skin/images/q4.png" alt="">
                            <img src="skin/images/q5.png" alt="">
                            <img src="skin/images/q6.png" alt="">
                        </div>
                        <h3>在线开放课程</h3>
                        <a href="javascript:void(0);" class="btn"></a>
                        <div class="webset-pop">
                            <h2>在线开放课程<a href="javascript:void(0);" class="close"></a></h2>
                            <div class="txt">
                                <%=str4 %>
                            </div>
                        </div>
                    </li>
                    <li class="li3">
                        <div class="block">
                            <img src="skin/images/d1.png" alt="">
                            <img src="skin/images/d2.png" alt="">
                            <img src="skin/images/d3.png" alt="">
                            <img src="skin/images/d4.png" alt="">
                            <img src="skin/images/d5.png" alt="">
                            <img src="skin/images/d6.png" alt="">
                            <img src="skin/images/d7.png" alt="">
                            <img src="skin/images/d8.png" alt="">
                            <img src="skin/images/d9.png" alt="">
                            <img src="skin/images/d10.png" alt="">
                            <img src="skin/images/d11.png" alt="">
                            <img src="skin/images/d12.png" alt="">
                            <img src="skin/images/d13.png" alt="">
                            <img src="skin/images/d14.png" alt="">
                        </div>
                        <h3>国家级精品课程</h3>
                        <a href="javascript:void(0);" class="btn"></a>
                        <div class="webset-pop">
                            <h2>国家级精品课程<a href="javascript:void(0);" class="close"></a></h2>
                            <div class="txt">
                                <%=str5 %>
                            </div>
                        </div>
                    </li>
                </ul>
                <div class="h50"></div>
            </div>
            <div class="c"></div>
            <div class="bg-blue fix" id="weiweb">
                <div class="wp">
                    <div class="tit-i">
                        <h3>立体化教材建设</h3>
                        <h5><span>multimedia</span> textbook</h5>
                    </div>
                    <div class="about-info">
                        <%=str1 %>
                    </div>
                    <ul class="ul-web fix">
                        <li class="li1">
                            <div class="block">
                                <img src="skin/images/n1.png" alt="">
                                <img src="skin/images/n2.png" alt="">
                                <img src="skin/images/n3.png" alt="">
                                <img src="skin/images/n4.png" alt="">
                            </div>
                            <h3>批量电子课件</h3>
                        </li>
                        <li class="li2">
                            <div class="block">
                                <img src="skin/images/n5.png" alt="">
                                <img src="skin/images/n6.png" alt="">
                            </div>
                            <h3>精彩教师讲授微课</h3>
                        </li>
                        <li class="li3">
                            <div class="block">
                                <img src="skin/images/n7.png" alt="">
                                <img src="skin/images/n8.png" alt="">
                                <img src="skin/images/n9.png" alt="">
                                <img src="skin/images/n10.png" alt="">
                                <img src="skin/images/n11.png" alt="">
                                <img src="skin/images/n12.png" alt="">
                            </div>
                            <h3>创意ＭＧ动画</h3>
                        </li>
                        <li class="li4">
                            <div class="block">
                                <img src="skin/images/n13.png" alt="">
                                <img src="skin/images/n14.png" alt="">
                            </div>
                            <h3>交互在线测试</h3>
                        </li>
                    </ul>
                    <!-- <img src="skin/images/img18.png" alt=""> -->
                </div>
            </div>
            <div class="wp" id="webmobel">
                <div class="tit-i">
                    <h3>智慧教室</h3>
                    <h5>wisdom <span>classroom</span></h5>
                </div>
                <div class="about-info">
                    <%=str2 %>
                </div>
                <div class="c"></div>
                <div class="web-con pr">
                    <ul class="ul-tab TAB_CLICK_SLIDE" id=".tab-show">
                        <li class="hover"><a href="javascript:void(0);">
                            <h3>智慧教室</h3>
                            <span>Wisdom classroom</span></a></li>
                        <li><a href="javascript:void(0);">
                            <h3>智慧录播室</h3>
                            <span>Wisdom studio</span></a></li>
                        <li><a href="javascript:void(0);">
                            <h3>互动教学</h3>
                            <span>Interactive teaching</span></a></li>
                    </ul>
                    <%--<div class="shou">
                        <img src="skin/images/shou.png" alt="">
                    </div>--%>
                    <div class="tab-con-box">
                        <div class="tab-show ">
                            <div class="tab-con">
                                <div data-animate="fadeInDown" class="txt animated">
                                    <p>针对校园信息化建设与教学、教务管理智慧化需求，整合录播、慕课、电子白板、虚拟教学、互动教学、环境控制、翻转课堂等教学相关功能，打造贯穿教室、课堂和管理的智慧教室整体解决方案。</p>
                                    <ul class="ul-icon">
                                        <li><b></b><span>无尘教学</span></li>
                                        <li><b></b><span>电子白板</span></li>
                                        <li><b></b><span>课堂管理</span></li>
                                        <li><b></b><span>教室管理</span></li>
                                        <li><b></b><span>场景化</span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="tab-show dn">
                            <div class="tab-con">
                                <div data-animate="fadeInDown" class="txt animated">
                                    <p>我们拥有视频分析、智能抠像、自动控制、智能融合等技术。</p>
                                    <ul class="ul-icon">
                                        <li><b></b><span>视频分析</span></li>
                                        <li><b></b><span>智能抠像</span></li>
                                        <li><b></b><span>自动控制</span></li>
                                        <li><b></b><span>智能融合</span></li>
                                        <li><b></b><span>动态捕捉</span></li>
                                        <li><b></b><span>离线编辑</span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="tab-show dn">
                            <div class="tab-con">
                                <div data-animate="fadeInDown" class="txt animated">
                                    <p>课堂互动教学与在线学习、课后复习与回顾，通过教学过程数据分析，为教师、学生及管理者提供教学与管理的数据参考，精准提高教、学质量。</p>
                                    <ul class="ul-icon">
                                        <li><b></b><span>课前预备</span></li>
                                        <li><b></b><span>课堂检测</span></li>
                                        <li><b></b><span>课堂互动</span></li>
                                        <li><b></b><span>实景应用</span></li>
                                        <li><b></b><span>师生交互</span></li>
                                        <li><b></b><span>兴趣化学习</span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="c"></div>
            <div class="service" id="servweb">
                <div class="wp">
                    <div class="tit-i tit-i-1">
                        <h3>服务流程</h3>
                        <h5>service process</h5>
                        <em></em>
                    </div>
                    <div class="about-info">
                        <p style="color: #95959c;">我们专业提供信息化教学一站式服务，从课程前期规划、教学设计、课程编排，到脚本撰写、影视拍摄、后期制作。梧桐花教育成立到现在，我们拥有了丰富的课程开发经验和成熟的智慧教育解决方案，来保证为您提供优质专业的服务。</p>
                        <p style="color: #95959c;">
                        </p>
                        <p style="text-align: justify; text-indent: 24.0pt;"><span></span></p>
                        <p></p>
                    </div>
                    <div class="process animate-box">
                        <div class="con">
                            <div class="pad">
                                <img src="skin/images/process_bg.png" alt="">
                                <div class="txt">
                                    <span class="s1">需求</span>
                                    <span class="s2">评估</span>
                                    <span class="s3">协议</span>
                                    <span class="s4">规划</span>
                                    <span class="s5">风格沟通</span>
                                    <span class="s6">课程设计</span>
                                    <span class="s7">设计修改/确认</span>
                                    <span class="s8">前期拍摄</span>
                                    <span class="s9">开发</span>
                                    <span class="s10">剪辑包装</span>
                                    <span class="s11">交付上线</span>
                                    <span class="s12">售后服务</span>
                                </div>
                                <div class="icon">
                                    <em class="q1"></em>
                                    <em class="q2"></em>
                                    <em class="q3"></em>
                                    <em class="q4"></em>
                                    <em class="q5"></em>
                                    <em class="q6"></em>
                                    <em class="q7"></em>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="solution" id="solution">
                <div class="wp">
                    <div class="tit-i">
                        <h3>课程类别</h3>
                        <h5>course category</h5>
                        <em></em>
                    </div>
                    <ul class="ul-solution">
                        <li class="li1" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span style="top: 0px;"></span><em>计算机</em></a></li>
                        <li class="li2" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span style="top: 0px;"></span><em>机械制造</em></a></li>
                        <li class="li3" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>文化艺术</em></a></li>
                        <li class="li4" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>护理专业</em></a></li>
                        <li class="li5" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>通识课程</em></a></li>
                        <li class="li6" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>学前教育</em></a></li>
                        <li class="li7" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span style="top: 0px;"></span><em>影视传媒</em></a></li>
                        <li class="li8" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span style="top: 0px;"></span><em>电工电子</em></a></li>
                        <li class="li9" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>汽车专业</em></a></li>
                        <li class="li10" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>教育专业</em></a></li>
                        <li class="li11" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>中职课程</em></a></li>
                        <li class="li12" style="left: 0px; top: 0px; opacity: 1;"><a href="javascript:;"><span></span><em>建筑工程</em></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- end #bd -->
        <div class="c"></div>
        <!-- begin #fd -->
        <uc3:foot ID="foot1" runat="server" />
        <script type="text/javascript" src="skin/js/jquery.js"></script>
        <link rel="stylesheet" href="skin/css/animate.css">
        <script type="text/javascript" src="skin/js/lib.js"></script>
        <link rel="stylesheet" href="skin/css/flexslider.css">
        <script type="text/javascript" src="skin/js/flexslider.js"></script>
        <script>
            var progressMove = false;

            function checkMhd() {
                isMobile = $('#m-hd').is(':visible');
            }

            $(window).resize(function () {
                var process = $('.process');
                checkMhd();
                if (isMobile) {
                    process.removeClass('animate-box');
                } else {
                    process.addClass('animate-box');
                }
            }).resize();

            $(window).scroll(function () {
                showWeb();
                showMobilephone();
                showProcess();
                showSolution();
            });

            function showWeb() {
                if (isScrolledIntoView('.ul-web')) {
                    $('.ul-web li').each(function (i) {
                        $(this).delay(i * 800).fadeIn(50, function () {
                            $(this).find('img').each(function (j) {
                                $(this).delay(j * 200).animate({ opacity: 1 });
                            })
                        });
                    })
                }
            }

            function showProcess() {
                if (isScrolledIntoView('.process')) {
                    $('.process .icon').each(function () {
                        $(this).find('em').each(function (i) {
                            $(this).delay(i * 500).animate({ opacity: 1 });
                        })
                    })
                }
            }

            function showMobilephone() {
                if (isScrolledIntoView('.tab-show')) {
                    $('.tab-show .pic').each(function () {
                        $(this).addClass($(this).data('animate'));
                    })
                    $('.tab-show .txt').each(function () {
                        $(this).addClass($(this).data('animate'));
                    })
                }

            }
            function showSolution() {
                if (isScrolledIntoView('.ul-solution', 300)) {
                    $(".ul-solution").each(function () {
                        $(".ul-solution li").animate({ left: 0, top: 0, opacity: 1 })
                    })
                }
            }

            $('.ul-webset li a.close').click(function () {
                $('.ul-webset li .webset-pop').css({
                    opacity: 0,
                    left: '-100%',
                    zIndex: -1
                });
            })
            $('.webset-pop .li2 a.close').click(function () {
                $('.webset-pop').hide();
            })
            $('.webset-pop .li3 a.close').click(function () {
                $('.webset-pop').hide();
            })

            $('.ul-txt li').click(function () {
                var txt = $(this).find('.txt-1');
                var _this = this;
                if (!txt.is(":visible")) {
                    $('.ul-txt li .txt-1').slideUp(500);
                    txt.stop(false, true).slideDown(function () {
                        $('.ul-txt li').removeClass('ok');
                        $(_this).addClass('ok');
                    });
                } else {
                    var _this = this;
                    txt.stop(false, true).slideUp(500, function () {
                        $('.ul-txt li').removeClass('ok');
                    });
                }
            });

            $('.ul-webset li .btn').click(function () {
                var webset_pop = $(this).parents('li').find('.webset-pop');
                webset_pop.css({ zIndex: 10 }).animate({
                    opacity: 1,
                    left: 0
                });
            });

            /*$(".ul-solution li").each(function (index, element) {
            if (index % 6 > 1) {
            $(this).css({ left: (index % 6 - 1) * 300 / (1 + Math.floor((index) / 6)) * 0.5,opacity: 0 });
            } else {
            $(this).css({ left: (index % 6 - 2) * 300 / (1 + Math.floor(index / 6)) * 0.5,opacity: 0 });
            }
            });*/

            $(document).ready(function (e) {

                $(".ul-solution li").hover(function () {
                    $(this).find("span").animate({ top: 5 }, 300)
                }, function () {
                    $(this).find("span").animate({ top: 0 }, 300)

                })
            });

            $('.web-con .flexslider').flexslider({
                animation: "slide",
                animationLoop: true,
                slideshow: false,
                prevText: "",
                nextText: "",
                controlNav: true,
                directionNav: true
            });
            $(".TAB_CLICK_SLIDE li").click(function () {
                var tab = $(this).parent(".TAB_CLICK_SLIDE");
                var con = tab.attr("id");
                var idx = tab.find("li").index(this);
                $(this).addClass('hover').siblings(tab.find("li")).removeClass('hover');
                $(con).eq(idx).show().siblings(con).hide();
                $('.web-con .flexslider').flexslider(idx);
            });
        </script>
    </form>
</body>
</html>
