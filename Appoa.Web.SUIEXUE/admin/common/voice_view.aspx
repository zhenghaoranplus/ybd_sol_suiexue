<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="voice_view.aspx.cs" Inherits="Appoa.Manage.admin.common.voice_view" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>音视频资源预览</title>
    <link href="/scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript" charset="utf-8"></script>
    <script src="../js/common.js"></script>
    <style>
        #word_list {
            padding-left: 0.5rem;
            line-height: 3rem;
        }

            #word_list p span {
                padding-left: 3.5rem;
            }

            #word_list p img {
                width: 1rem;
                margin-right: 1rem;
            }
    </style>
</head>
<body>
    <div id="word_list">
    </div>
    <script>
        getData();

        /**获取url中的参数**/
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg); //匹配目标参数
            if (r != null) return decodeURI(r[2]);
            return null; //返回参数值
        }

        function getData() {
            var id = getUrlParam('id');
            $.ajax({
                type: 'post',
                dataType: 'json',
                data: { id: id },
                url: '/tools/business_handler.ashx?action=GetEnglishVoice',
                success: function (result) {
                    if (parseInt(result.code, 10) == 200) {
                        var list = result.data;

                        var htmls = '';

                        $.each(list, function (k, v) {
                            htmls += [
                                '<p>',
                                '<img src="/html/images/audio_player_120.png" alt="播放" />',
                                '<i>' + v['word_name'] + '</i>',
                                '<span>' + v['word_nature'] + '</span>',
                                '<span>' + v['word_translate'] + '</span>',
                                '<audio id="wordplay' + k + '" src="' + v['video_path'] + '" controls="controls" hidden></audio>',
                                '</p>'
                            ].join('');
                        })

                        $('#word_list').html(htmls);

                        $('#word_list p').click(function () {

                            var audioid = 'wordplay' + $(this).index();
                            var audio = document.getElementById(audioid);
                            if (audio != null) {
                                if (!audio.paused) {
                                    // 这个就是暂停
                                    audio.pause();
                                } else {
                                    // 这个就是播放
                                    audio.play();
                                }
                            }
                        })
                    } else {
                        alert(result.message);
                    }
                },
                error: function () {
                    alert('通信错误');
                }
            })
        }
    </script>
</body>
</html>
