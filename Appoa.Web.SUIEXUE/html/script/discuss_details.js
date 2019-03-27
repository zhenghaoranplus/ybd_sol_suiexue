var id = getUrlParam('id');
var pageIndex = 1;
var pageSize = 10;
var tuid = 0;
var did = 0;
var rid = 0;

GetCourseArticleInfo();
getData();
scrollLoad();

sharedesc = $('title').text();
getInfo();

//回复按钮点击事件
function toreply(obj) {
    tuid = $(obj).attr('tuid');
    if (tuid == islogin().id) {
        dialogTips('不能回复自己');
        return;
    }
    did = $(obj).attr('eid');
    rid = 0;

    var to_nick_name = $(obj).parents().find('.username span').html();
    $('.inputtxt input').attr('iseval', 'false');
    $('.inputtxt input').attr('placeholder', '回复' + to_nick_name + '：');
    $('.inputtxt input').focus();
}

//回复列表点击事件
function toreply2reply(obj) {
    tuid = $(obj).attr('tuid');
    did = $(obj).parent().parent().find('.toreply input').attr('eid');
    rid = $(obj).attr('rid');
    if (tuid == islogin().id) {
        doDelEval({ id: rid, user_id: islogin().id });
    } else {
        var to_nick_name = $(obj).find('label').html();
        $('.inputtxt input').attr('iseval', 'false');
        $('.inputtxt input').attr('placeholder', '回复' + to_nick_name + '：');

        $('.inputtxt input').focus();
    }
}

//删除评论
function delEval(obj) {
    var eval_uid = $(obj).attr('tuid');
    if (eval_uid != islogin().id) {
        return false;
    }
    var eid = $(obj).attr('eid');
    doDelEval({ id: eid, user_id: islogin().id });
}

//执行删除操作
function doDelEval(data) {
    dialogConfirmFun('确定要删除此评论吗？', function () {
        sendAjaxSetFunc(
                data,
                '/tools/business_handler.ashx?action=DelEvaluate',
                function (result) {
                    layer.closeAll();
                    if (parseInt(result.code, 10) == 200) {
                        pageIndex = 1;
                        getData();
                    } else {
                        dialogMsg(result.message);
                    }
                })
    });
}

//讨论内容区域点击事件(清空回复状态)
$('.comments .title,.discuss_list').click(function () {
    $('.inputtxt input').attr('iseval', 'true');
    $('.inputtxt input').attr('placeholder', '在此输入评论...');
    tuid = $('.comments').attr('tuid');
    did = 0;
    rid = 0;
    $('.inputtxt input').blur();
})

//获得焦点时，滚动到底部
$('#plcontents').focus(function () {
    setTimeout(function () {
        document.body.scrollTop = document.body.scrollHeight;
    }, 300);
})

//发送按钮点击事件
$('.replybtn input').click(function () {
    var iseval = $('.inputtxt input').attr('iseval');
    if (iseval == 'true') {
        doEvaluate();
    } else if (iseval == 'false') {
        doReply();
    }
})

//讨论详情
function GetCourseArticleInfo() {
    if (islogin()) {
        sendAjaxSetFuncAsync(
            false,
            { id: id },
            '/tools/business_handler.ashx?action=GetCourseArticleInfo',
            function (result) {
                if (parseInt(result.code, 10) == 200) {
                    var obj = result.data[0];

                    var user_id = obj.user_id;
                    var avatar = obj.avatar;
                    var nick_name = obj.nick_name;
                    var title = obj.title;
                    var contents = obj.contents;
                    var add_time = obj.add_time;
                    var eval_count = obj.eval_count;
                    var imgList = obj.imgList;
                    var videoList = obj.videoList;

                    $('.question_title').html(title);
                    $('.discuss_text').html(contents);
                    if (user_id == 0) {
                        $('.from i').hide();
                        $('.from span:eq(0)').html('');
                        $('.from span:eq(1)').html('');
                    } else {
                        $('.from i img').attr('src', avatar);
                        $('.from span:eq(0)').html(nick_name);
                        $('.from span:eq(1)').html(add_time);
                    }

                    $('.message_num').html(eval_count);
                    $('.comments .title span').html('(' + eval_count + '条)');
                    $('.comments').attr('tuid', user_id);
                    tuid = user_id;


                    if (imgList && imgList.length > 0) {
                        var htmls = '';
                        $.each(imgList, function (k, v) {
                            htmls += ['<img src="' + v['original_path'] + '">'].join('');
                        })
                        $('.img_video').html(htmls);
                    }
                    else if (videoList && videoList.length > 0) {
                        var htmls = '';
                        $.each(videoList, function (k, v) {
                            htmls += ['<video src="' + v['original_path'] + '" controls="controls" width="100%"></video>'].join('');
                        })
                        $('.img_video').html(htmls);
                    }
                } else {
                    dialogMsg(result.message);
                }
            })
    } else {
        dialogMsgFun('您还没有登录，请先去登录', gotologin);
    }
}

//评论列表
function getData() {
    sendAjaxSetFuncAsync(
        false,
        { id: id, page_index: pageIndex, page_size: pageSize },
        '/tools/business_handler.ashx?action=GetCourseEvaluate',
        function (result) {
            if (parseInt(result.code, 10) == 200) {
                var list = result.data;
                if (list && list.length > 0) {
                    var html = '';
                    var count = list[0].count;
                    $('.message_num').html(count);
                    $('.comments .title span').html('(' + count + '条)');

                    $.each(list, function (k, v) {
                        html += [
                            '<div class="comment_list">',
                            '<div class="pic"><img src="' + v['avatar'] + '"></div>',
                            '<p class="username"><span>' + v['nick_name'] + '</span></p>',
                            '<span class="date">' + v['add_time'] + '</span>',
                            '<div class="txt" eid="' + v['id'] + '" tuid="' + v['user_id'] + '" onclick="delEval(this);">' + v['contents'] + '</div>',
                            '' + SetReplyHtml(v['replyList']) + '',
                            '<p class="toreply">',
                            '<input type="button" id="" eid="' + v['id'] + '" tuid="' + v['user_id'] + '" value="回复" onclick="toreply(this);">',
                            '</p>',
                            '</div>'
                        ].join('');
                    })

                    if (pageIndex == 1) {
                        $('#eval_contents').html(html);
                    } else {
                        $('#eval_contents').append(html);
                    }
                } else {
                    if (pageIndex == 1) {
                        $('#eval_contents').html('');
                    }
                }
            } else {
                dialogMsg(result.message);
            }
        })
}

//拼接回复列表
function SetReplyHtml(replyList) {
    var htmls = '';
    if (replyList && replyList.length > 0) {
        $.each(replyList, function (k, v) {
            htmls += [
                '<dl tuid="' + v['from_user_id'] + '" rid="' + v['id'] + '" onclick="toreply2reply(this)">',
                '<dt><label>' + v['from_nick_name'] + '</label><span>回复</span>' + v['to_nick_name'] + '：</dt>',
                '<dd>' + v['contents'] + '</dd>',
                '</dl>',
            ].join('');
        })

        htmls = '<div class="reply">' + htmls + '</div>';
    }

    return htmls;
}

//评论
function doEvaluate() {
    var contents = $.trim($('#plcontents').val());
    if (!contents) {
        dialogTips('请输入评论内容');
        return;
    }

    if (islogin()) {
        var data = {
            group: 1,
            user_id: islogin().id,
            parent_id: id,
            to_user_id: tuid,
            data_id: did,
            type: 1,
            reply_id: rid,
            contents: contents
        };

        sendAjaxSetFunc(
            data,
            '/tools/business_handler.ashx?action=DoEvaluate',
            function (result) {
                if (parseInt(result.code, 10) == 200) {
                    dialogTips('评论成功');
                    $('#plcontents').val('');
                    pageIndex = 1;
                    getData();
                    $('.comments .title,.discuss_list').click();
                } else {
                    dialogMsg(result.message);
                }
            })
    } else {
        dialogMsgFun('您还没有登录，请先去登录', gotologin);
    }
}

//回复
function doReply() {
    var contents = $.trim($('#plcontents').val());
    if (!contents) {
        dialogTips('请输入回复内容');
        return;
    }

    if (islogin()) {
        var data = {
            group: 1,
            user_id: islogin().id,
            parent_id: id,
            to_user_id: tuid,
            data_id: did,
            type: 2,
            reply_id: rid,
            contents: contents
        };

        sendAjaxSetFunc(
            data,
            '/tools/business_handler.ashx?action=DoEvaluate',
            function (result) {
                if (parseInt(result.code, 10) == 200) {
                    dialogTips('回复成功');
                    $('#plcontents').val('');
                    pageIndex = 1;
                    getData();
                    $('.comments .title,.discuss_list').click();
                } else {
                    dialogMsg(result.message);
                }
            })
    } else {
        dialogMsgFun('您还没有登录，请先去登录', gotologin);
    }
}