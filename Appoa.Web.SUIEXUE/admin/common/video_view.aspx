<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="video_view.aspx.cs" Inherits="Appoa.Manage.admin.common.video_view" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>音视频资源预览</title>
</head>
<body>
    <div align="center">
        <video src="<%=src %>" controls="controls" width="40%">
            您的浏览器不支持 video 标签。
        </video>
    </div>
</body>
</html>
