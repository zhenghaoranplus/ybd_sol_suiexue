<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="word_voice_edit.aspx.cs" Inherits="Appoa.Manage.admin.course.word_voice_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>资源编辑</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <script src="../js/common.js"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var id = getUrlParam('id');
        var chapter = getUrlParam('chapter');

        $(function () {
            $('.zoomify').zoomify();

            $("#rbtnGroup").click(function () {
                changeDisplay();
            });

            changeDisplay();

            if (id && id.toString() != '0') {
                getData();
            } else {
                var htmls = [
                    '<div class="wordlist">',
                    '<input type="text" class="word_name" placeholder="单词或词组" />',
                    '<input type="text" class="word_nature" placeholder="词性" />',
                    '<input type="text" class="word_translate" placeholder="翻译" />',
                    '<input type="text" class="word_sort" placeholder="排序" value="1" onkeydown="return checkNumber(event);" />',
                    '</div>'
                ].join('');

                $('#lists').html(htmls);
            }
        });

        function changeDisplay() {
            var gp = $("input[name='rbtnGroup']:checked").val();
            if (gp == '3') {
                $('#share_user').show();
                $('#school_list').hide();
            } else if (gp == '2') {
                $('#share_user').hide();
                $('#school_list').show();
            } else {
                $('#share_user').hide();
                $('#school_list').hide();
            }
        }

        /**获取url中的参数**/
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg); //匹配目标参数
            if (r != null) return decodeURI(r[2]);
            return null; //返回参数值
        }

        //创建下一组
        function create(obj) {
            var htmls = [
                '<div class="wordlist">',
                '<input type="text" class="word_name" placeholder="单词或词组" />',
                '<input type="text" class="word_nature" placeholder="词性" />',
                '<input type="text" class="word_translate" placeholder="翻译" />',
                '<input type="text" class="word_sort" placeholder="排序" value="1" onkeydown="return checkNumber(event);" />',
                '<a href="javasript:;" onclick="deldiv(this)">删除</a>',
                '</div>'
            ].join('');

            $('#lists').append(htmls);
        }

        //删除这一组
        function deldiv(obj) {
            $(obj).parent().remove();
        }

        //保存
        function save() {
            var group = $("input[name='rbtnGroup']:checked").val();
            var title = $.trim($('#txttitle').val());
            var userids = '';
            var words = '';
            var school = 0;
            var school_name = '';

            if (!title) {
                alert('请输入资源标题');
                return;
            }

            //学校
            if (group == 2) {
                var ddlSchool = document.getElementById('ddlSchool');
                var index = ddlSchool.selectedIndex;
                school = ddlSchool.options[index].value;
                school_name = ddlSchool.options[index].text;
            }

            //分享用户
            if (group == '3') {
                $('input[type=checkbox]:checked').each(function (k, v) {
                    userids += ',' + $(v).val() + ',';
                })
            }

            //单词列表
            var wordarr = new Array();
            $('#lists .wordlist').each(function (k, v) {
                var list = $(v).children('input');
                if ($(list[0]).val() != '') {
                    var obj = {
                        word_name: $(list[0]).val(),
                        word_nature: $(list[1]).val(),
                        word_translate: $(list[2]).val(),
                        word_sort: $(list[3]).val()
                    };
                    wordarr.push(obj);
                }
            })

            if (wordarr.length == 0) {
                alert('请填写单词或词组');
                return false;
            }

            words = JSON.stringify(wordarr);

            var data = {
                action: 'saveWordVoice',
                id: id,
                group: group,
                school: school,
                school_name: school_name,
                chapter: chapter,
                title: title,
                userids: userids,
                words: words
            };

            $.ajax({
                type: 'post',
                url: '/tools/ajax_action.ashx',
                data: data,
                dataType: 'json',
                success: function (result) {
                    if (parseInt(result.code, 10) == 200) {
                        alert(result.message);
                        window.location.href = 'resource_list.aspx?chapter=' + chapter;
                    } else {
                        alert(result.message);
                    }
                },
                error: function () {
                    alert('通信错误');
                }
            })
        }

        function getData() {
            if (id) {
                var data = {
                    action: 'getWordVoice',
                    id: id
                };

                $.ajax({
                    type: 'post',
                    url: '/tools/ajax_action.ashx',
                    data: data,
                    dataType: 'json',
                    success: function (result) {
                        if (parseInt(result.code, 10) == 200) {

                            var obj = result.data;
                            if (obj) {
                                var title = obj.title;
                                var group_id = obj.group_id;
                                var school_id = obj.school_id;
                                var school_name = obj.school_name;
                                var share_user = obj.share_user;

                                //标题
                                $('#txttitle').val(title);

                                //分组
                                var gindex = group_id - 1;
                                var rbtnGroup = $('.multi-radio .boxwrap:eq(0) a:eq(' + gindex + ')');
                                rbtnGroup.addClass('selected').siblings().removeClass('selected');

                                $("input[name='rbtnGroup']").each(function (k, v) {
                                    if ($(v).val() == obj.group_id) {
                                        $(v).prop('checked', true);
                                    }
                                })

                                //学校
                                if (group_id == 2) {
                                    var ddlSchool = document.getElementById('ddlSchool');
                                    for (i = 0; i < ddlSchool.length; i++) {
                                        if (ddlSchool[i].value == school_id)
                                            ddlSchool[i].selected = true;
                                    }
                                    $('.single-select .boxwrap:eq(0) a.select-tit span').html(school_name);
                                }


                                //分享用户
                                if (group_id == 3) {
                                    var ckbUser = document.getElementById('ckbUser');
                                    for (i = 0; i < ddlSchool.length; i++) {
                                        if ($.contains(share_user, ',' + ckbUser[i].value + ',')) {
                                            ckbUser[i].checked = true;
                                            $('.multi-porp ul:eq(0) li:eq(' + i + ')').addClass('selected').siblings().removeClass('selected');
                                        }
                                    }
                                }

                                //单词列表
                                var wordlist = JSON.parse(obj.path);
                                var htmls = '';
                                $.each(wordlist, function (k, v) {
                                    htmls += [
                                        '<div class="wordlist">',
                                        '<input type="text" class="word_name" placeholder="单词或词组" value="' + v.word_name + '" />',
                                        '<input type="text" class="word_nature" placeholder="词性" value="' + v.word_nature + '" />',
                                        '<input type="text" class="word_translate" placeholder="翻译" value="' + v.word_translate + '" />',
                                        '<input type="text" class="word_sort" placeholder="排序" value="' + v.word_sort + '" onkeydown="return checkNumber(event);" />',
                                        '<a href="javasript:;" onclick="deldiv(this)">删除</a>',
                                        '</div>'
                                    ].join('');
                                })

                                $('#lists').html(htmls);

                                changeDisplay();
                            }
                        } else {
                            alert(result.message);
                        }
                    },
                    error: function () {
                        alert('通信错误');
                    }
                })
            }
        }

    </script>
    <style>
        .wordlist {
            padding-bottom: 1rem;
        }

            .wordlist input {
                margin-right: 1rem;
                padding: 5px 4px;
                min-height: 32px;
                line-height: 20px;
                border: 1px solid #eee;
                background: #fff;
                vertical-align: middle;
                color: #333;
                font-size: 100%;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
            }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a> <a href="../right.aspx"
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>章节管理</span>
            <i class="arrow"></i><a href="javascript:history.back(-1);">
                <span>资源信息管理</span></a> <i class="arrow"></i><span>添加资源信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">资源信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>当前课程</dt>
                <dd>
                    <span><%=course_name %></span>
                </dd>
            </dl>
            <dl>
                <dt>当前章节</dt>
                <dd>
                    <span><%=chapter_name %></span>
                </dd>
            </dl>
            <dl>
                <dt>分组</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rbtnGroup" runat="server"></asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>分类</dt>
                <dd>英文发音
                </dd>
            </dl>
            <dl id="share_user" style="display: none">
                <dt>用户</dt>
                <dd>
                    <div class="rule-multi-porp">
                        <asp:CheckBoxList ID="ckbUser" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                    </div>
                </dd>
            </dl>
            <dl id="school_list" style="display: none">
                <dt>学校</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlSchool" runat="server"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <section id="englishWord">
                <dl>
                    <dt>标题</dt>
                    <dd>
                        <input id="txttitle" class="input normal" />
                        <span class="Validform_checktip">*50字以内</span>
                    </dd>
                </dl>
                <dl>
                    <dt>单词或词组</dt>
                    <dd>
                        <section id="lists">
                        </section>
                        <a href="javascript:;" onclick="create(this);"><i></i><span>新增</span></a>
                    </dd>
                </dl>
            </section>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <input type="button" class="btn" value="提交保存" onclick="save();" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
