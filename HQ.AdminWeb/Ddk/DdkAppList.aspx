<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DdkAppList.aspx.cs" Inherits="HQ.AdminWeb.Ddk.DdkAppList" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>多多客应用管理</title>
    <link href="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/datetimepick/daterangepicker.css" rel="stylesheet" />
    <link href="/3rdParty/css/common.css" rel="stylesheet" />
</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight tooltip-demo">
        <!--search-->
        <form role="form" id="searchForm" class="search-panel" method="get">
            <input type="hidden" name="pageIndex" value="<%=pageIndex %>" />
            <div class="row">
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <div class="form-inline">
                                <div class="form-group m-r-sm">

                                    <label class=" control-label">多多客应用</label>
                                    <%-- <input type="text" class="form-control" name="loginname" id="loginname" runat="server"
                                        placeholder="关键字" style="width: 200px;" />--%>
                                </div>

                                <%--<span onclick="listHandler.search(1)" class="btn btn-success btn-sm">搜索</span>
                                <span onclick="listHandler.searchAll()" class="btn btn-success btn-sm">显示所有</span>--%>

                                <a href="DdkAppEdit.aspx?action=add"><span class="btn btn-info btn-sm" style="float: right;">+添加应用</span></a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </form>
        <!--search-->

        <!--list-->
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins m-b-none">
                    <div class="ibox-content p-xxs no-top-border">
                        <div class="panel-body">
                            <table class="table table-bordered table-hover table-center">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>ClientId</th>
                                        <th>ClientSecret</th>
                                        <th>是否主应用</th>
                                        <th>状态</th>
                                        <th>绑定的代理商</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1%></td>
                                                <td><%#Eval("ClientId") %>
                                                </td>
                                                <td>
                                                    <%#Eval("ClientSecret") %>
                                                </td>
                                                <td>
                                                    <%#Eval("IsMain") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Status") %>
                                                </td>
                                                <td>
                                                    <%#Eval("BindAgentId") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--基础框架js-->
    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="/3rdParty/js/jquery.provincesCity.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/content.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <!--日期选择-->
    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/datetimepick/moment.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/datetimepick/daterangepicker.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils-0.2.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>

    <script src="/3rdParty/js/common.js"></script>
    <script type="text/javascript">
        var listUrl = '/Ddk/DdkAppList.aspx';
        var totalPage = <%=this.pageCount%>;
    </script>

    <script type="text/javascript">
        $(function () {
            var pageinate = new hot.paging(".pagination", parseInt($("input[name=pageIndex]").val()), totalPage, 7);
            pageinate.init(function (p) {
                listHandler.search(p);
            });
        });

        var listHandler = {
            search: function (pageIndex) {
                $("input[name=pageIndex]").val(pageIndex);
                $("#searchForm").submit();
            },
            searchAll: function () {
                window.location.href = listUrl;
            }
        }
    </script>
</body>
</html>
