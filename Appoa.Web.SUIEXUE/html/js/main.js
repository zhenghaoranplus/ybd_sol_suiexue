$(document).ready(function () {
    var rcourse_height = $(".r_course").width() / 1.77;
    $(".r_course .img,.r_course .img img").css("height", course_height);
    var course_height = $(".index_course li").width() / 1.77;
    $(".index_course li .img,.index_course li .img img").css("height", course_height);
    var coursebanner_width = $(".course_banner").width();
    $(".course_banner .pic,.course_banner .pic img").css("width", coursebanner_width);
    var coursebanner_height = $(".course_banner").width() / 1.77;
    $(".course_banner .pic,.course_banner .pic img").css("height", coursebanner_height);

    var classbanner_height = $(".class_ban").width() / 1.77;
    $(".class_ban .img,.class_ban .img img").css("height", classbanner_height);
    var video_height = $(".video_img").width() / 1.77;
    $(".video_img,.video_img img").css("height", video_height);
    //  var img_height = $(".uploadimg img").width(); 
    //  $(".uploadimg img").css("height",img_height);

    $(".index_course li:odd").addClass("oddli");
    //$(".course_classify dt").click(function () {
    //    $(this).parent().find("dd").show();
    //    $(this).parent().siblings().find("dd").hide();
    //});
    $(".course_list .all").click(function () {
        $(".allcourse,.overloay").show();
    });
    $(".overloay").click(function () {
        $(".allcourse,.overloay").hide();
    });
    /*搜索*/
    $(".search_type span").click(function (e) {
        e.preventDefault();
        $(this).parent().find(".type").toggle();
        window.setTimeout("method('nvul')", 5000);
    });
    $(".search_type li").click(function () {
        var _text = $(this).text();
        $(this).parent().parent().hide().siblings("span").text(_text);
        if ($(this).text() == '课程') {
            $('#keywords').attr('placeholder', '输入课程名查找');
            $('#hdType').val(1);
        } else if ($(this).text() == '资源') {
            $('#keywords').attr('placeholder', '输入资源名查找');
            $('#hdType').val(2);
        }
    })
    //$(".search_type li").click(function () {
    //    var _text = $(this).text();
    //    $(this).parent().parent().hide().siblings("span").text(_text);
    //    if ($(this).text() == '课程') {
    //        $('#index_search_form').attr('action', 'search_result.html');
    //        $('#keywords').attr('name', 'goodname');
    //        $('#keywords').attr('placeholder', '输入课程名查找');
    //    } else if ($(this).text() == '微课') {
    //        $('#index_search_form').attr('action', 'search_result2.html');
    //        $('#keywords').attr('name', 'storename');
    //        $('#keywords').attr('placeholder', '输入微课查找');
    //    }
    //});

    //$(".for_collection").click(function () {
    //    $(this).toggleClass("collected");
    //});
    /*课程详情*/
    $(".course_tab li:eq(0)").addClass("active");
    $(".course_content:eq(0)").show();
    $(".course_tab li").click(function () {
        $(this).addClass("active").siblings("li").removeClass("active");
        var index = $(this).index();
        $(".course_content").eq(index).show().siblings(".course_content").hide();
    });
    //$(".course_content dt").click(function () {
    //    $(this).parent().toggleClass("expand");
    //    $(this).parent().siblings().removeClass("expand");
    //    $(this).parent().find("dd").toggle();
    //    $(this).parent().siblings().find("dd").hide();
    //});
    /*提交答题弹窗*/
    $(".submit_answer").click(function () {
        $(".submit_tips").show();
    });
    $(".submit_tips .btn1").click(function () {
        $(".submit_tips").hide();
    });
    $(".rank li:eq(0)").addClass("li1");
    $(".rank li:eq(1)").addClass("li2");
    $(".rank li:eq(2)").addClass("li3");
    /*课堂详情*/
    $(".class_ewm").click(function () {
        $(".class_code").show();
        $(".overloay").show();
    });
    $(".QR_code").click(function () {
        $(".class_code").show();
        $(".overloay").show();
    });
    $(".overloay").click(function () {
        $(".class_code").hide();
        $(".overloay").hide();
    });
    $(".chapter li:odd").addClass("li");
    $(".videoul li:odd").addClass("li");

    $(".release").click(function () {
        $(".publish").show();
        $(".release").hide();
    });
    $(".close_publish").click(function () {
        $(".publish").hide();
        $(".release").show();
    });
    //$(".tasklist .list h2").click(function () {
    //    $(this).parent().addClass("expand");
    //    $(this).parent().siblings().removeClass("expand");
    //    $(this).parent().find("ul").show();
    //    $(this).parent().siblings().find("ul").hide();
    //});
    /*商城*/
    $(".mall_tab li:eq(0)").addClass("active");
    $(".mall_product:eq(0)").show();
    $(".mall_tab li").click(function () {
        $(this).addClass("active").siblings("li").removeClass("active");
        var index = $(this).index();
        $(".mall_product").eq(index).show().siblings(".mall_product").hide();
    });
    //$(".product-tab li:eq(0)").addClass("hover");
    //$(".j-content:eq(0)").show();
    //$(".product-tab li").click(function () {
    //    $(this).addClass("hover").siblings("li").removeClass("hover");
    //    var index = $(this).index();
    //    $(".j-content").eq(index).show().siblings(".j-content").hide();
    //});
    $(".product-tabbar li:eq(0)").addClass("hover");
    $(".product_content:eq(0)").show();
    $(".product-tabbar li").click(function () {
        $(this).addClass("hover").siblings("li").removeClass("hover");
        var index = $(this).index();
        $(".product_content").eq(index).show().siblings(".product_content").hide();
    });
    /*弹窗选择商品规格*/
    //$(".shopping_cart .addcart").click(function () {
    //    $(".specification,.overloay").show();
    //});
    $(".overloay,.closecart").click(function () {
        $(".specification,.overloay").hide();
    });
    //$(".iteminfo_parameter .color").click(function () {
    //    $(this).addClass("tb-selected");
    //    $(this).siblings().removeClass("tb-selected");
    //});
    $(".iteminfo_parameter .size").click(function () {
        $(this).addClass("tb-selected");
        $(this).siblings().removeClass("tb-selected");
    });
    //$(".confirmbtn").click(function () {
    //    $(".specification,.overloay").hide();
    //    $(".add_success").show();
    //});
    /*购物车数字增加、减少*/
    $(".add").click(function () {
        $(this).parent().find('input').val(function (index, value) {
            value++;
            return value;
        });
    })
    $(".reduce").click(function () {
        $(this).parent().find('input').val(function (index, value) {
            value--;
            value = value < 0 ? 0 : value;
            return value;
        });
    })
    /*购物车*/
    $(".edit_cart").click(function () {
        $(this).hide();
        $(".shop-total .total,.shop-total .topay").hide();
        $(".shop-total .del,.finish").show();
    });
    $(".finish").click(function () {
        $(this).hide();
        $(".shop-total .total,.shop-total .topay,.edit_cart").show();
        $(".shop-total .del").hide();
    });
    /*签到*/
    //$(".tosignin").click(function () {
    //    $(this).removeClass("tosignin");
    //    $(this).find("span").hide();
    //    $(this).find("em").show();
    //    $(".signin_success,.overloay").show();
    //});
    $(".overloay").click(function () {
        $(".signin_success,.overloay").hide();
    });
    /*我的收藏*/
    //$(".collect_bottom .edit").click(function () {
    //    $(".collectlist .list").addClass("editlist");
    //    $(this).hide();
    //    $(this).parent().find(".manage_favaorites").show();
    //});
    /*全选*/
    $("#checkall").click(function () {
        if ($(this).prop("checked") == true) { //如果全选按钮被选中
            $(".co-check").prop('checked', true); //所有按钮都被选中
        } else {
            $(".co-check").prop('checked', false); //else所有按钮不全选
        }
    });
    /*我的分销*/
    $(".my_distribution .tab li:eq(0)").addClass("hover");
    $(".distribution_content:eq(0)").show();
    $(".my_distribution .tab li").click(function () {
        $(this).addClass("hover").siblings("li").removeClass("hover");
        var index = $(this).index();
        $(".distribution_content").eq(index).show().siblings(".distribution_content").hide();
    });
    /*设置*/
    $(".service_tel").click(function () {
        $(".service_hottel").show();
    });
    $(".cancel_tel").click(function () {
        $(".service_hottel").hide();
    });
    $(".clear_cache").click(function () {
        $(".clearcache").show();
    });
    $(".cancel_clear").click(function () {
        $(".clearcache").hide();
    });


    /*顶部固定*/
    $.fn.smartFloat = function () {
        var position = function (element) {
            var top = element.position().top, pos = element.css("position");
            $(window).scroll(function () {
                var scrolls = $(this).scrollTop();
                if (scrolls > top) {
                    if (window.XMLHttpRequest) {
                        element.css({
                            position: "fixed",
                            top: 0
                        });
                    } else {
                        element.css({
                            top: scrolls
                        });
                    }
                } else {
                    element.css({
                        position: pos,
                        top: top
                    });
                }
            });
        };
        return $(this).each(function () {
            position($(this));
        });
    };
    //绑定
    $(".product-tabbar").smartFloat();
});

//$(function () {
//    //获取短信验证码
//    var validCode = true;
//    $(".msgs").click(function () {
//        var time = 60;
//        var code = $(this);
//        if (validCode) {
//            validCode = false;
//            code.addClass("msgs1");
//            var t = setInterval(function () {
//                time--;
//                code.html(time + "秒");
//                if (time == 0) {
//                    clearInterval(t);
//                    code.html("重新获取");
//                    validCode = true;
//                    code.removeClass("msgs1");

//                }
//            }, 1000)
//        }
//    })
//})
