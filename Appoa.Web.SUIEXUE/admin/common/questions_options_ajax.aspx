<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questions_options_ajax.aspx.cs" Inherits="Appoa.Manage.admin.common.questions_options_ajax" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>题目信息添加</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Scripts/WebUploader/webuploader.min.js" type="text/javascript"></script>
    <script src="/Editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/uploader.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        var id = getUrlParam('id');
        var chapter = getUrlParam('chapter');
        var page = getUrlParam('page');
        var group_id = getUrlParam('group_id');
        var type_id = getUrlParam('type_id');

        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '700px',
                height: '350px',
                resizeType: 1,
                uploadJson: '/tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '/tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true,
                afterBlur: function () { this.sync(); }
            });

            $("#rbtnGroup").click(function () {
                $('input[type=text]').val('');
                $('textarea').val('');
                changeDisplay();
            });

            changeDisplay();

            if (id && id.toString() != '0') {
                getData();
            } else {
                var htmls = [
                    '<div class="optionlist">',
                    '<input type="hidden" class="options_id" value="0" />',
                    '<input type="text" class="options" placeholder="选项" />',
                    '<input type="text" class="options_contents" placeholder="选项内容" />',
                    '<input type="text" class="options_score" placeholder="分值" />',
                    '</div>'
                ].join('');

                $('#lists').html(htmls);
            }

        });

        function changeDisplay() {
            var gp = $("input[name='rbtnGroup']:checked").val();
            if (gp == '2') {
                $('.multi-radio:eq(1) .boxwrap a:eq(1)').hide();
                $('.multi-radio:eq(1) .boxwrap a:eq(2)').hide();
                $('.multi-radio:eq(1) .boxwrap a:eq(3)').hide();
                $('.multi-radio:eq(1) .boxwrap a:eq(4)').hide();
            } else {
                $('.multi-radio:eq(1) .boxwrap a:eq(1)').show();
                $('.multi-radio:eq(1) .boxwrap a:eq(2)').show();
                $('.multi-radio:eq(1) .boxwrap a:eq(3)').show();
                $('.multi-radio:eq(1) .boxwrap a:eq(4)').show();
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
                '<div class="optionlist">',
                '<input type="hidden" class="options_id" value="0" />',
                '<input type="text" class="options" placeholder="选项" />',
                '<input type="text" class="options_contents" placeholder="选项内容" />',
                '<input type="text" class="options_score" placeholder="分值" />',
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
            var type = $("input[name='rbtnType']:checked").val();
            var title = $.trim($('#txttitle').val());
            var score = $.trim($('#txtscore').val());
            var answers = $.trim($('#txtAnswers').val());
            var analysis = $.trim($('#txtanalysis').val());

            var options = '';

            if (!title) {
                alert('请输入题目');
                return;
            }
            if (!score) {
                alert('请输入分值');
                return;
            }
            if (!analysis) {
                alert('请输入解析');
                return;
            }

            if (type == '1' || type == '2' || type == '3') {
                //单词列表
                var optionArr = new Array();
                $('#lists .optionlist').each(function (k, v) {
                    var list = $(v).children('input');
                    if ($(list[0]).val() != '') {
                        var obj = {
                            options_id: $(list[0]).val(),
                            options: $(list[1]).val(),
                            options_contents: $(list[2]).val(),
                            options_score: $(list[3]).val() || 0
                        };
                        optionArr.push(obj);
                    }
                })

                if (optionArr.length == 0) {
                    alert('请填写选项');
                    return false;
                }

                options = JSON.stringify(optionArr);
            }

            var data = {
                action: 'saveQuestionOptions',
                id: id,
                group: group,
                type: type,
                chapter: chapter,
                title: title,
                score: score,
                answers: answers,
                analysis: encodeURIComponent(analysis),
                options: options
            };

            $.ajax({
                type: 'post',
                url: '/tools/ajax_action.ashx',
                data: data,
                dataType: 'json',
                success: function (result) {
                    if (parseInt(result.code, 10) == 200) {
                        if (page && page > 0) {
                            parent.jsprint(result.message, 'questions_list.aspx?chapter=' + chapter + '&page=' + page);
                        } else {
                            parent.jsprint(result.message, 'questions_list.aspx?chapter=' + chapter);
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

        function getData() {
            if (id) {
                var data = {
                    action: 'getQuestionOptions',
                    id: id
                };

                $.ajax({
                    type: 'post',
                    url: '/tools/ajax_action.ashx',
                    data: data,
                    dataType: 'json',
                    success: function (result) {
                        if (parseInt(result.code, 10) == 200) {
                            var list = result.data;

                            var htmls = '';
                            $.each(list, function (k, v) {
                                htmls += [
                                    '<div class="optionlist">',
                                    '<input type="hidden" class="options_id" value="' + v['id'] + '" />',
                                    '<input type="text" class="options" placeholder="选项" value="' + v['options'] + '" />',
                                    '<input type="text" class="options_contents" placeholder="选项内容" value="' + v['contents'] + '" />',
                                    '<input type="text" class="options_score" placeholder="分值" value="' + v['score'] + '" />',
                                    '<a href="javasript:;" onclick="deldiv(this)">删除</a>',
                                    '</div>'
                                ].join('');
                            })

                            $('#lists').html(htmls);

                            changeDisplay();
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
        .optionlist {
            padding-bottom: 1rem;
        }

            .optionlist input {
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
                class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="javascript:history.back(-1);">
                    <span>题目信息管理</span></a> <i class="arrow"></i><span>修改题目信息</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">题目信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>课程</dt>
                <dd>
                    <%=course_name %>
                </dd>
            </dl>
            <dl>
                <dt>章节</dt>
                <dd>
                    <%=chapter_name %>
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
                <dt>题型</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rbtnType" runat="server"></asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>题目</dt>
                <dd>
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*0-200" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*200字以内</span>
                </dd>
            </dl>
            <dl>
                <dt>分值</dt>
                <dd>
                    <asp:TextBox ID="txtscore" runat="server" CssClass="input normal" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*整数</span>
                </dd>
            </dl>
            <dl>
                <dt>答案</dt>
                <dd>
                    <asp:TextBox ID="txtAnswers" runat="server" CssClass="input normal" TextMode="MultiLine" datatype="*0-2000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*参考答案</span>
                </dd>
            </dl>
            <dl>
                <dt>选项</dt>
                <dd>
                    <section id="lists"></section>
                    <a href="javascript:;" onclick="create(this);"><i></i><span>新增</span></a>
                </dd>
            </dl>
            <dl>
                <dt>解析</dt>
                <dd>
                    <asp:TextBox ID="txtanalysis" runat="server" CssClass="input normal editor" datatype="*0-2000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <input name="btnSubmit" type="button" value="提交保存" class="btn" onclick="save()" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
