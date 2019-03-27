<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resource_edit.aspx.cs" Inherits="Appoa.Manage.admin.course.resource_edit"
    ValidateRequest="false" %>

<%@ Import Namespace="Appoa.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>资源编辑</title>
    <link href="/Scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/JQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/Validform_v5.3.2/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/Scripts/artdialog/dialog-plus-min.js" type="text/javascript"></script>
    <script src="/Scripts/WebUploader/webuploader.min.js" type="text/javascript"></script>
    <script src="/Editor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/admin/js/uploader.js" type="text/javascript"></script>
    <script src="/admin/js/laymain.js" type="text/javascript"></script>
    <script src="/admin/js/layout.js" type="text/javascript"></script>
    <link href="../js/zoomify.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/zoomify.min.js" type="text/javascript"></script>
    <link href="../js/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../js/uploadify/jquery.uploadify.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            $('.zoomify').zoomify();
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "/tools/upload_ajax.ashx", swf: "/scripts/webuploader/uploader.swf" });
            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '700px',
                height: '350px',
                resizeType: 1,
                uploadJson: '/tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '/tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });

            $("#rbtnGroup,#rbtnType").click(function () {
                changeDisplay();
            });

            changeDisplay();

            $("#uploadify").uploadify({
                height: 32,
                swf: '../js/uploadify/uploadify.swf',
                uploader: '/tools/UploadHandler.ashx',
                width: 120,
                fileSizeLimit: 512000,
                removeCompleted: false,
                buttonText: '选择文件',
                queueSizeLimit: 5,
                fileTypeExts: '*.doc;*.docx;*.ppt;*.pptx;*.pdf;*.mp3;*.mp4;*.obj',
                fileTypeDesc: 'doc docx ppt pptx pdf mp3 mp4 obj',
                successTimeout: 1800,
                onUploadStart: function () {
                    console.group();
                    console.time();
                },
                onUploadSuccess: function (files, data, response) {
                    console.timeEnd();
                    console.groupEnd();
                    if (data == '') {
                        //data就是服务器输出的内容。     
                        $('#uploadify').uploadify('cancel', '*');   //取消所有上传的文件  
                    } else {
                        console.log(JSON.stringify(data));
                        getFile(data);
                    }
                }
            });

        });

        function changeDisplay() {
            var val = $("input[name='rbtnType']:checked").val();
            if (val == '1') {
                $('#articleResource').show();
                $('#otherResource').hide();
                $('#englishWord').hide();
            } else if (val == '9') {
                $('#articleResource').hide();
                $('#otherResource').hide();

                var htmls = [
                    '<div class="wordlist">',
                    '<input type="text" placeholder="单词或词组" />',
                    '<input type="text" placeholder="词性" />',
                    '<input type="text" placeholder="翻译" />',
                    '</div>'
                ].join('');

                $('#lists').html(htmls);

                $('#englishWord').show();
            } else {
                $('#articleResource').hide();
                $('#otherResource').show();
                $('#englishWord').hide();
            }

            var gp = $("input[name='rbtnGroup']:checked").val();
            if (gp == '3') {
                $('#share_user').show();
            } else {
                $('#share_user').hide();
            }
        }

        /**获取url中的参数**/
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg); //匹配目标参数
            if (r != null) return decodeURI(r[2]);
            return null; //返回参数值
        }

        function getFile(json) {
            var action = getUrlParam('action');
            if (action == 'Modify') {
                $('#hdfVal').val('');
                $('#txtpath').val('');
            }

            json = JSON.parse(json);
            var hdfVal = $.trim($('#hdfVal').val());
            hdfVal += json.fileName + '|';
            $('#hdfVal').val(hdfVal);

            var path = $.trim($('#txtpath').val());
            path += json.path + '|';
            $('#txtpath').val(path);
        }

        //创建下一组
        function create(obj) {
            var htmls = [
                '<div class="wordlist">',
                '<input type="text" placeholder="单词或词组" />',
                '<input type="text" placeholder="词性" />',
                '<input type="text" placeholder="翻译" />',
                '<a href="javasript:;" onclick="deldiv(this)">删除</a>',
                '</div>'
            ].join('');

            $('#lists').append(htmls);
        }

        //删除这一组
        function deldiv(obj) {
            $(obj).parent().remove();
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
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rbtnType" runat="server"></asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl id="share_user" style="display: none">
                <dt>用户</dt>
                <dd>
                    <div class="rule-multi-porp">
                        <asp:CheckBoxList ID="ckbUser" runat="server"></asp:CheckBoxList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>学校</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlSchool" runat="server"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <section id="articleResource">
                <dl>
                    <dt>标题</dt>
                    <dd>
                        <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                        <span class="Validform_checktip">*50字以内</span>
                    </dd>
                </dl>
                <dl>
                    <dt>内容</dt>
                    <dd>
                        <asp:TextBox ID="txtcontents" runat="server" CssClass="input normal editor" datatype="*0-4000" sucmsg=" "></asp:TextBox>
                    </dd>
                </dl>
            </section>
            <section id="otherResource">
                <dl>
                    <dt>路径</dt>
                    <dd>
                        <asp:HiddenField ID="hdfVal" runat="server" />
                        <asp:TextBox ID="txtpath" runat="server" Rows="10" Columns="50" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <input type="file" name="uploadify" id="uploadify" />
                    </dd>
                </dl>
            </section>
            <section id="englishWord">
                <dl>
                    <dt>标题</dt>
                    <dd>
                        <asp:TextBox ID="txtwordtitle" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox>
                        <span class="Validform_checktip">*50字以内</span>
                    </dd>
                </dl>
                <dl>
                    <dt>单词或词组</dt>
                    <dd>
                        <section id="lists">
                            <%--<div class="wordlist">
                                <input type="text" placeholder="单词或词组" />
                                <input type="text" placeholder="词性" />
                                <input type="text" placeholder="翻译" />
                            </div>--%>
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
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
