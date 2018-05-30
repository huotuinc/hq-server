<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HQ.AdminWeb.Home" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="renderer" content="webkit">
    <title>好券管理后台</title>
    <link href="/3rdParty/css/bootstrap.min.css" rel="stylesheet" />
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
</head>

<body class="fixed-sidebar full-height-layout gray-bg">
    <div id="wrapper">
        <!--左侧导航开始-->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <div class="nav-close">
                <i class="fa fa-times-circle"></i>
            </div>
            <div class="sidebar-collapse">
                <ul class="nav" id="side-menu">
                    <li class="nav-header">
                        <span class="block m-t-xs"></span>
                        <div class="dropdown profile-element">
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#" aria-expanded="false">
                                <span class="clear">
                                    <span class="block m-t-xs"><strong class="font-bold">admin</strong><b
                                        class="caret"></b></span>
                                </span>
                            </a>
                            <ul class="dropdown-menu animated fadeInDown m-t-xs">
                                <li><a href="javascript:modifyPassword();">修改密码</a>
                                </li>
                                <li class="divider"></li>
                                <li><a href="javascript:logout();">安全退出</a>
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-edit"></i><span class="nav-label">会员管理</span><span
                            class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="javascript:;">会员列表</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">等级管理</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-edit"></i><span class="nav-label">代理商管理</span><span
                            class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="javascript:;">代理商列表</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-edit"></i><span class="nav-label">佣金管理</span><span
                            class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="javascript:;">佣金流水</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">日报表</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">月报表</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-edit"></i><span class="nav-label">多多客管理</span><span
                            class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="javascript:;">推广订单管理</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">应用管理</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">广告位管理</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">分类管理</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">主题管理</a>
                            </li>
                        </ul>
                    </li>

                    <li>
                        <a href="#"><i class="fa fa-edit"></i><span class="nav-label">系统管理</span><span
                            class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="javascript:;">基本配置</a>
                            </li>
                            <li><a class="J_menuItem" href="javascript:;">返利配置</a>
                            </li>
                            <li><a class="J_menuItem" href="SystemConfig/ManagerList.aspx">操作员管理</a>
                            </li>
                            <li><a class="J_menuItem" href="SystemConfig/ShortMessageTemplateList.aspx">短信模板管理</a>
                            </li>
                        </ul>
                    </li>

                </ul>
            </div>
        </nav>
        <!--左侧导航结束-->
        <!--右侧部分开始-->
        <div id="page-wrapper" class="gray-bg dashbard-1">
            <div class="row content-tabs">
                <button class="navbar-minimalize roll-nav roll-left">
                    <i class="fa fa-bars"></i>
                </button>
                <button class="roll-nav roll-left J_tabLeft" style="margin-left: 40px">
                    <i class="fa fa-backward"></i>
                </button>
                <nav class="page-tabs J_menuTabs" style="margin-left: 80px;">
                    <div class="page-tabs-content">
                    </div>
                </nav>
                <button class="roll-nav roll-right J_tabRight">
                    <i class="fa fa-forward"></i>
                </button>
                <div class="btn-group roll-nav roll-right">
                    <button class="dropdown J_tabClose" data-toggle="dropdown">
                        关闭操作<span class="caret"></span>

                    </button>
                    <ul role="menu" class="dropdown-menu dropdown-menu-right">
                        <li class="J_tabShowActive"><a>定位当前选项卡</a>
                        </li>
                        <li class="divider"></li>
                        <li class="J_tabCloseAll"><a>关闭全部选项卡</a>
                        </li>
                        <li class="J_tabCloseOther"><a>关闭其他选项卡</a>
                        </li>
                    </ul>
                </div>
                <a href="login.html" th:href="@{/logout}" class="roll-nav roll-right J_tabExit"><i
                    class="fa fa fa-sign-out"></i>退出</a>
            </div>
            <div class="row J_mainContent" id="content-main">
                <iframe class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0"
                    seamless></iframe>
            </div>
        </div>
        <!--右侧部分结束-->
    </div>

    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/hplus.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/contabs.min.js"></script>

    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/pace/pace.min.js"></script>

    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils-0.2.js"></script>

    <script type="text/javascript" th:inline="javascript">
        var baseUrl = /*[[@{/}]]*/ "/";
        var logined = /*[[${logined}]]*/'0';

        function newTab(url, name) {
            var index = false;
            $(".page-tabs-content .J_menuTab").each(function () {
                var dataId = $(this).attr("data-id");
                if (dataId == url) {
                    index = true;
                    $(this).click();
                    return false;
                }
            })
            if (!index) {
                var s = '<a href="javascript:;" class="active J_menuTab" data-id="' + url + '">' + name + ' <i class="fa fa-times-circle"></i></a>';
                $(".J_menuTab").removeClass("active");
                var r = '<iframe class="J_iframe" width="100%" height="100%" src="' + url + '" frameborder="0" data-id="' + url + '" seamless></iframe>';
                $(".J_mainContent").find("iframe.J_iframe").hide().parents(".J_mainContent").append(r);
                var o = layer.load();
                $(".J_mainContent iframe:visible").load(function () {
                    layer.close(o)
                }),
                    $(".J_menuTabs .page-tabs-content").append(s);
            }
        }
        //newTab(baseUrl + "Desktop.aspx", "桌面");

        function logout() {
            hot.ajax("AjaxHandler.aspx", { action: 'logout' }, function (ret) {
                window.location.href = 'Login.aspx';
            }, function (err) {
                hot.tip.error(err.statusText);
            }, "post", 300);
        }

        function modifyPassword() {
            newTab("/SystemConfig/ModifyPassword.aspx", "修改密码");
            $('.fadeInDown').hide();
        }
    </script>
</body>

</html>
