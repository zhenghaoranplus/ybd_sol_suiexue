var id = getUrlParam('id');
var pageIndex = 1;
var pageSize = 10;

GetRecommendList();
scrollLoad();
GetCategoryList();

function GetRecommendList() {
    var data = {
        category: id,
        page_index: pageIndex,
        page_size: pageSize
    };
    
    sendAjaxSetFunc(data, '/tools/business_handler.ashx?action=GetCrouseList', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';
            $.each(list, function (k, v) {
                htmls += [
                    '<div class="list">',
                    '<a href="course_details.html?id=' + v['id'] + '">',
                    '<div class="pic"><img src="' + v['cover'] + '"></div>',
                    '<h3>' + v['name'] + '</h3>',
                    '<div class="description">' + v['info'] + '</div>',
                    '</a>',
                    '</div>'
                ].join('');
            })

            if (pageIndex == 1) {
                $('.course_list .content').html(htmls);
            } else {
                $('.course_list .content').append(htmls);
            }
        } else {
            dialogMsg(result.message);
        }
    })
}

function GetCategoryList() {
    var data = {
        group: 1
    };

    sendAjaxSetFunc(data, '/tools/business_handler.ashx?action=GetCategoryList', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';
            $.each(list, function (k, v) {
                htmls += [
                    '<dl>',
                    '<dt><a href="course.html?id=' + v['id'] + '"><i><img src="' + v['img_src'] + '"></i>' + v['title'] + '<em></em></a></dt>',
                    '<dd>',
                    //'<ul>',
                    //'' + SetChildrenHtml(v['childrenList']) + '',
                    //'</ul>',
                    '</dd>',
                    '</dl>'
                ].join('');
            })

            if (pageIndex == 1) {
                $('.course_classify').html(htmls);
            } else {
                $('.course_classify').append(htmls);
            }

            $(".course_classify dt").click(function () {
                $(this).parent().find("dd").show();
                $(this).parent().siblings().find("dd").hide();
            });
        } else {
            dialogMsg(result.message);
        }
    })
}

function SetChildrenHtml(list) {
    var htmls = '';
    $.each(list, function (k, v) {
        htmls += [
            '<li><a href="course.html?id=' + v['id'] + '">' + v['title'] + '</a></li>'
        ].join('');
    })
    return htmls;
}

//检查搜索关键字是否为空
function checkkey() {
    var a = document.getElementById("keywords").value;
    if ("" == a.replace(/(^\s*)|(\s*$)/g, "")) {
        return document.getElementById("keywords").focus(), false;
    }

    return true;
}