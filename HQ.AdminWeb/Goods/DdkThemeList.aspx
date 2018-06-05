<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DdkThemeList.aspx.cs" Inherits="HQ.AdminWeb.Goods.DdkThemeList" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>多多客主题管理</title>
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

                                    <label class=" control-label">名称</label>
                                    <input type="text" class="form-control" id="txtkeyword" runat="server"
                                        placeholder="关键字" style="width: 200px;" />
                                </div>

                                <span onclick="listHandler.search(1)" class="btn btn-success btn-sm">搜索</span>
                                <span onclick="listHandler.searchAll()" class="btn btn-success btn-sm">显示所有</span>

                                <label id="spLastSyncTime" class="control-label" style="padding-left: 10px;"></label>

                                <a href="javascript:listHandler.syncThemes();"><span class="btn btn-info btn-sm" style="float: right;">同步所有主题</span></a>

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
                                        <th>图片</th>
                                        <th>名称</th>
                                        <th>主题id</th>
                                        <th>商品数</th>
                                        <%--<th>操作</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1 + pageSize*(pageIndex-1)%></td>
                                                <td>
                                                    <img src="<%#Eval("ImageUrl") %>" style="width: 375px; height: auto;" />
                                                </td>
                                                <td>
                                                    <%#Eval("Name") %>
                                                </td>
                                                <td><%#Eval("ThemeId") %>
                                                </td>

                                                <td>
                                                    <%#Eval("GoodsNum") %>
                                                    <span class="spUpdateTime" style="display: none;"><%# Eval("UpdateTime") %></span>
                                                </td>
                                                <%--  <td>
                                                    <a class="btn btn-myGreen btn-xs" href="javascript:;">查看</a>
                                                </td>--%>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <p style="float: left; margin: 20px 0;">
                                共
                            <%=this.recordCount %>
                                条记录，当前第
                            <%=this.pageIndex %>
                                /
                            <%=this.pageCount %>
                                ，每页20条记录
                            </p>
                            <ul style="float: right;" class="pagination pagination-split">
                            </ul>
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
        var listUrl = '/Goods/DdkThemeList.aspx';
        var totalPage = <%=this.pageCount%>;
    </script>

    <script type="text/javascript">
        $(function () {
            var pageinate = new hot.paging(".pagination", parseInt($("input[name=pageIndex]").val()), totalPage, 7);
            pageinate.init(function (p) {
                listHandler.search(p);
            });

            if ($('.spUpdateTime:first').length > 0) {
                $('#spLastSyncTime').html('上次同步时间：' + $('.spUpdateTime:first').html());
            }
        });

        var listHandler = {
            search: function (pageIndex) {
                $("input[name=pageIndex]").val(pageIndex);
                $("#searchForm").submit();
            },
            searchAll: function () {
                window.location.href = listUrl;
            },
            syncThemes: function () {
                hqUtils.showConfirm('点击确定将从拼多多拉取所有主题（含官方&自定义）', function () {
                    hot.ajax("DdkThemeList.aspx?action=sync", {}, function (data) {
                        if (data.resultCode == 1) {
                            layer.closeAll();
                            hot.tip.success('同步成功');
                            setTimeout(function () {
                                location.href = location.href;
                            }, 1200);
                        } else {
                            hot.tip.error("同步失败:" + data.resultMsg);
                        }
                    }, function () {
                    }, "post", 100);
                });
            }
        }
    </script>
</body>
</html>
