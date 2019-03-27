<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3d.aspx.cs" Inherits="Appoa.Manage.admin.common._3d" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>三维模型资源预览</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="app">
        <model-obj src='<%=path %>'></model-obj>
    </div>
    </form>
    <script src="../js/vue.js"></script>
    <script src="../js/vue-3d-model.min.js"></script>
    <script>
        new Vue({
            el: '#app'
        })
    </script>
</body>
</html>
