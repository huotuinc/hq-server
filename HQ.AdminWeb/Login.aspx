<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HQ.AdminWeb.Login" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <title>登录</title>

    <link href="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
</head>

<body class="gray-bg">

    <div class="middle-box text-center loginscreen  animated fadeInDown">
        <div>
            <div>

                <h1 style="font-size: 136px;" class="logo-name">login</h1>

            </div>

            <form class="m-t" method="post">
                <div class="form-group">
                    <select id="roleType" name="type" class="form-control">
                        <option value="0">管理员</option>
                        <option value="1">代理商</option>
                    </select>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" id="loginname" placeholder="用户名">
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" id="password" placeholder="密码">
                </div>

                <button type="button" class="btn btn-primary block full-width m-b" onclick="loginHelper.submit();">登 录</button>
                <div class="form-group" style="display: none" id="error">
                    <span class="text-danger">登录失败</span>
                </div>
            </form>
        </div>
    </div>
    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>
    <script>
        var loginHelper = {
            submit: function () {
                var loginname = $('#loginname').val();
                var password = $('#password').val();
                if (loginname == '') {
                    hot.tip.error('请输入账号名');
                    $('#loginname').focus();
                    return false;
                }
                if (password == '') {
                    hot.tip.error('请输入密码');
                    $('#password').focus();
                    return false;
                }
                hot.ajax("AjaxHandler.aspx", {
                            action: 'login',
                            loginname: loginname,
                            password: password,
                            roletype: $('#roleType').val()
                        }, function (data) {
                            if (data.resultCode == 1) {
                                layer.closeAll();
                                hot.tip.success('操作成功');
                                window.location.href = '/home.aspx';
                            } else {
                                hot.tip.error("登录失败：" + data.resultMsg);
                            }
                        }, function () {
                        }, "post", 100);
            }
        };
    </script>
</body>

</html>

