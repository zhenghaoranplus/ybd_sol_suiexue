var pageIndex = 1;
var pageSize = 10;

var id = getUrlParam('id');
$('.questions a').attr('href', 'questions.html?cid=' + id);
var uid = 0;
if (islogin()) {
    uid = islogin().id;
} else {
    uid = 0;
}

GetCourseInfo();
GetCourseChapter();

getData();
if ($('.course_content:eq(2)').css('display') == 'block') {
    scrollLoad();
}

function GetCourseInfo() {
    sendAjaxSetFuncAsync(false, { id: id, user_id: uid }, '/tools/business_handler.ashx?action=GetCourseInfo', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var obj = result.data[0];
            var cover = obj.cover;
            var name = obj.name;
            var info = obj.info;
            var qrcode = obj.qrcode;
            var is_collection = obj.is_collection;

            $('.course_banner .pic img').attr('src', cover);
            $('title,.course_name h2,.class_code h1').html(name);
            $('.text').html(info);
            $('.course_name .QR_code .code img,.class_code .ewmcode img').attr('src', qrcode);

            if (is_collection > 0) {
                $('.for_collection').addClass('collected');
            } else {
                $('.for_collection').removeClass('collected');
            }
        } else {
            dialogMsg(result.message);
        }
    })
}

//收藏、取消收藏
$(".for_collection").click(function () {
    if (uid == 0) {
        dialogMsgFun('您还没有登录，请先去登录', gotologin);
    } else {
        if ($(this).hasClass('collected')) {//已收藏，则取消收藏
            sendAjaxSetFunc({ group: 1, user_id: uid, data_id: id }, '/tools/business_handler.ashx?action=CancelColletion', function (result) {
                if (parseInt(result.code, 10) == 200) {
                    $('.for_collection').removeClass('collected');
                } else {
                    $('.for_collection').addClass('collected');
                    dialogMsg(result.message);
                }
            })
        } else {//未收藏，收藏
            sendAjaxSetFunc({ group: 1, user_id: uid, data_id: id }, '/tools/business_handler.ashx?action=DoColletion', function (result) {
                if (parseInt(result.code, 10) == 200) {
                    $('.for_collection').addClass('collected');
                } else {
                    $('.for_collection').removeClass('collected');
                    dialogMsg(result.message);
                }
            })
        }
    }
})

//章节数据
function GetCourseChapter() {
    dialogLoadingText('加载中');
    sendAjaxSetFuncAsync(false, { id: id, user_id: uid }, '/tools/business_handler.ashx?action=GetCourseChapter', function (result) {
        layer.closeAll();
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';

            $.each(list, function (k, v) {
                htmls += [
                    '<dl>',
                    '<dt>' + v['title'] + '<i></i></dt>',
                    '<dd>',
                    '' + SetChapterHtml(v['resourceList']) + '',
                    //'' + SetTestHtml(v['exa_entity']) + '',
                    '</dd>',
                    '</dl>'
                ].join('');
            })

            $('#course_chapter').html(htmls);
            $(".course_content dl:eq(0)").addClass("expand");
            $(".course_content dd:eq(0)").show();

            $(".course_content dt").click(function () {
                $(this).parent().toggleClass("expand");
                //$(this).parent().siblings().removeClass("expand");
                $(this).parent().find("dd").toggle();
                //$(this).parent().siblings().find("dd").hide();
            });
        } else {
            dialogMsg(result.message);
        }
    })
}

//拼接章节html
function SetChapterHtml(childrenList) {
    var htmls = '';
    $.each(childrenList, function (k, v) {
        var classname = '';
        var url = '';
        if (parseInt(v['type'], 10) == 1) {//图文资源
            classname = 't3';
            url = 'article_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 2) {//文档资源
            classname = 't2';
            //url = v['path'];
            url = 'doc_detail.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 3) {//音频资源
            classname = 't7';
            url = 'video_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 4) {//视频资源
            classname = 't1';
            url = 'video_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 5) {//试卷资源
            classname = 't6';
            url = 'test.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 6) {//3D资源
            classname = 't4';
            url = '3d.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 7) {//问题讨论
            classname = 't5';
            url = 'discuss_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 8) {//试卷资源
            classname = 't6';
            url = 'questionnaire.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 9) {//单词音频资源
            classname = 't8';
            url = 'voice_detail.html?method=click&id=' + v['id'];
        }

        htmls += [
            '<div class="list">',
            //'<h3>' + v['title'] + '</h3>',
            '<ul>',
            //'' + SetResourceHtml(childrenList) + '',
            '<li class="' + classname + '"><a href="' + url + '">' + v['title'] + '</a></li>',
            '</ul>',
            '</div>',
        ].join('');
    })
    return htmls;
}

//拼接资源html
function SetResourceHtml(resourceList) {
    var htmls = '';
    $.each(resourceList, function (k, v) {
        var classname = '';
        var url = '';
        if (parseInt(v['type'], 10) == 1) {//图文资源
            classname = 't3';
            url = 'article_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 2) {//文档资源
            classname = 't2';
            url = v['path'];
        }
        if (parseInt(v['type'], 10) == 3) {//音频资源
            classname = 't7';
            url = 'video_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 4) {//视频资源
            classname = 't1';
            url = 'video_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 5) {//试卷资源
            classname = 't6';
            url = 'test.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 6) {//3D资源
            classname = 't4';
            url = 'javascript:;';
        }
        if (parseInt(v['type'], 10) == 7) {//问题讨论
            classname = 't5';
            url = 'discuss_details.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 8) {//试卷资源
            classname = 't6';
            url = 'questionnaire.html?method=click&id=' + v['id'];
        }
        if (parseInt(v['type'], 10) == 9) {//单词音频资源
            classname = 't8';
            url = 'voice_detail.html?method=click&id=' + v['id'];
        }
        htmls += '<li class="' + classname + '"><a href="' + url + '">' + v['title'] + '</a></li>';
    })
    return htmls;
}

function getData() {
    sendAjaxSetFuncAsync(false, { course_id: id, page_index: pageIndex, page_size: pageSize }, '/tools/business_handler.ashx?action=GetArticle', function (result) {
        if (parseInt(result.code, 10) == 200) {
            var list = result.data;
            var htmls = '';

            $.each(list, function (k, v) {
                htmls += [
                    '<div class="discuss_list">',
                    '<a href="discuss_details.html?id=' + v['id'] + '">',
                    '<div class="question_title">' + v['title'] + '</div>',
                    '<div class="discuss_text">' + v['contents'] + '</div>',
                    '<div class="img_video">',
                    '' + setImgHtml(v['imgList'], v['videoList']) + '',
                    '</div>',
                    '<div class="from">',
                    '<i><img src="' + v['avatar'] + '"></i><span>' + v['nick_name'] + '</span><span class="time">' + v['add_time'] + '</span>',
                    '<div class="message_num">' + v['eval_count'] + '</div>',
                    '</div>',
                    '</a>',
                    '<div class="del_discuss" aid="' + v['id'] + '" uid="' + v['user_id'] + '"></div>',
                    '</div>'
                ].join('');
            })

            $('#course_article').html(htmls);

            $('.del_discuss').click(function () {
                if (islogin()) {
                    var obj = this;
                    var uid = $(obj).attr('uid');
                    var aid = $(obj).attr('aid');
                    if (islogin().id != uid) {
                        dialogTips('此讨论不属于你');
                        return false;
                    }
                    dialogConfirmFun('确定要删除这个讨论吗？', function () {
                        var data = {
                            user_id: islogin().id,
                            article_id: aid
                        };

                        sendAjaxSetFuncAsync(true, data, '/tools/business_handler.ashx?action=DelArticle', function (result) {
                            layer.closeAll();
                            if (parseInt(result.code, 10) == 200) {
                                pageIndex = 1;
                                getData();
                            } else {
                                dialogMsg(result.message);
                            }
                        });
                    })
                } else {
                    dialogMsgFun('您还没有登录，请先去登录', gotologin);
                }
            })
        } else {
            dialogMsg(result.message);
        }
    })
}

function setImgHtml(imgList, videoList) {
    var htmls = '';
    if (imgList && imgList.length > 0) {
        $.each(imgList, function (k, v) {
            htmls += ['<img src="' + v['thumb_path'] + '">'].join('');
        })
    } else if (videoList && videoList.length > 0) {
        $.each(videoList, function (k, v) {
            htmls += ['<img src="' + v['thumb_path'] + '">'].join('');
        })
    }
    return htmls;
}