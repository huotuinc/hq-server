<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerList.aspx.cs" Inherits="HQ.AdminWeb.SystemConfig.ManagerList" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>操作员管理</title>
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
                                   
                                    <label class=" control-label">账号名：</label>
                                    <input type="text" class="form-control" name="loginname" id="loginname" runat="server"
                                        placeholder="关键字" style="width: 200px;" />
                                </div>

                                <span onclick="listHandler.search(1)" class="btn btn-success btn-sm">搜索</span>
                                <span onclick="listHandler.searchAll()" class="btn btn-success btn-sm">显示所有</span>

                                <a href="ManagerEdit.aspx?action=add"><span class="btn btn-info btn-sm" style="float: right;">+添加操作员</span></a>
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
                            <table class="table table-bordered table-hover table-center report-table">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>账号</th>
                                        <th>状态</th>
                                        <th>创建时间</th>
                                        <th>备注</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1 + pageSize*(pageIndex-1)%></td>
                                                <td><%#Eval("LoginName") %>
                                                </td>
                                                <td>
                                                    <%#Eval("IsLocked").ToString()=="False"?"<span style='color:green;'>启用</span>":"<span style='color:red;'>锁定</span>" %>
                                                </td>
                                                <td>
                                                    <%#Eval("CreateTime") %>
                                                </td>
                                                <td><%#Eval("Remark") %>
                                                </td>
                                                <td>
                                                    <a class="btn btn-myGreen btn-xs" href="ManagerEdit.aspx?id=<%#Eval("ManagerId") %>">编辑</a>
                                                </td>
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

    <script type="text/javascript" th:inline="javascript">
        var listUrl = '/SystemConfig/ManagerList.aspx';
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
            },
            newTab: function (url, title) {
                if (top.newTab) {
                    top.newTab(url, title);
                    return;
                }
                window.location.href = url;
            }
        }
    </script>
</body>
</html>

