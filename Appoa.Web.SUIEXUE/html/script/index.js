GetIndexAdR();
GetIndexCategory();
GetIndexRecommend();

$('.header-search').click(function () {
    window.location.href = 'search.html';
});

function GetIndexAdR() {
    sendAjaxSetFuncAsync(false, {}, '/tools/business_handler.ashx?action=GetIndexAdR', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';

            $.each(list, function (k, v) {
                var url = '';
                if (v['ad_data_url']) {
                    url = v['ad_data_url'];
                } else {
                    url = 'javascript:;';
                }

                htmls += [
                    '<li><a href="' + url + '"><img src="' + v['ad_data_img'] + '" alt=""></a></li>'
                ].join('');
            })

            $('.slide_box').html(htmls);

            var slide_height = $("#wrapper").width() / 1.77;
            $(".top-slider-wrapper .bx-viewport,.slide_box img").css("height", slide_height);
            if (list.length == 1) {
                $(".bxslider li").attr('style', 'float: left; list-style: none; position: relative; width: 100%;');
            } else {
                $(".bxslider").bxSlider({
                    auto: true
                });
            }
        } else {
            dialogMsg(result.message);
        }
    });
}

function GetIndexCategory() {
    sendAjaxSetFuncAsync(false, {}, '/tools/business_handler.ashx?action=GetIndexCategory', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';

            $.each(list, function (k, v) {
                htmls += [
                    '<li>',
                    '<a href="course.html?id=' + v['id'] + '">',
                    '<img src="' + v['img_src'] + '">',
                    '<span>' + v['name'] + '</span>',
                    '</a>',
                    '</li>'
                ].join('');
            })
            //index_nav_all.png

            htmls += [
                '<li>',
                '<a href="all_course.html">',
                '<img src="images/index_nav_all.png">',
                '<span>更多</span>',
                '</a>',
                '</li>'
            ].join('');

            $('.index-nav ul').html(htmls);
        } else {
            dialogMsg(result.message);
        }
    })
}

function GetIndexRecommend() {
    sendAjaxSetFuncAsync(false, {}, '/tools/business_handler.ashx?action=GetIndexRecommend', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';

            $.each(list, function (k, v) {
                if (k == 0) {
                    htmls += [
                        '<div class="r_course">',
                        '<a href="course_details.html?id=' + v['id'] + '">',
                        '<div class="img">',
                        '<img src="' + v['cover'] + '">',
                        '</div>',
                        '<div class="t"><span>' + v['name'] + '</span></div>',
                        '</a>',
                        '</div>',
                        '<ul>'
                    ].join('');
                } else {
                    htmls += [
                        '<li>',
                        '<a href="course_details.html?id=' + v['id'] + '">',
                        '<span class="img">',
                        '<img src="' + v['cover'] + '">',
                        '</span>',
                        '<p>' + v['name'] + '</p>',
                        '</a>',
                        '</li>'
                    ].join('');
                }
            })

            htmls = htmls + '</ul>';

            $('.index_course').html(htmls);
        } else {
            dialogMsg(result.message);
        }
    })
}