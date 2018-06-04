<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsCatList.aspx.cs" Inherits="HQ.AdminWeb.Goods.GoodsCatList" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>商品分类管理</title>
    <link href="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/datetimepick/daterangepicker.css" rel="stylesheet" />
    <link href="/3rdParty/css/common.css" rel="stylesheet" />
    <style type="text/css">
        .cat1 {
            font-weight: bold;
            font-size: 14px;
        }

        .cat2 {
        }

        .p0 {
            background: #ffffdd;
        }
    </style>
</head>

<%
    int rootTotal = 0, subTotal = 0, rootEffectTotal = 0, subEffectTotal = 0;
    foreach (var item in this.AllCates)
    {
        if (item.ParentId == 0)
        {
            rootTotal++;
            if (item.Status == 1) rootEffectTotal++;
        }
        else
        {
            subTotal++;
            if (item.Status == 1) subEffectTotal++;
        }
    }
%>

<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight tooltip-demo">
        <!--search-->
        <form role="form" id="searchForm" class="search-panel" method="get">
            <div class="row">
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <div class="form-inline">
                                <input type="hidden" id="plattype" runat="server" value="0" />

                                <div class="form-group m-r-sm">
                                    <label class=" control-label">拼多多分类</label>
                                    <label class=" control-label">【大类<%=rootTotal %>个(启用<%=rootEffectTotal %>个)，子类<%=subTotal %>个(启用<%=subEffectTotal %>个)】</label>
                                </div>
                                <%--<div class="form-group m-r-sm">
                                    <label class=" control-label">所属平台：</label>
                                    <input type="text" class="form-control" name="loginname" id="loginname" runat="server"
                                        placeholder="关键字" style="width: 200px;" />
                                </div>
                                <span onclick="listHandler.search(1)" class="btn btn-success btn-sm">搜索</span>
                                <span onclick="listHandler.searchAll()" class="btn btn-success btn-sm">显示所有</span>--%>
                                <a href="GoodsCatEdit.aspx?action=add"><span class="btn btn-info btn-sm" style="float: right;">+添加分类</span></a>

                                <span class="btn btn-info btn-sm" style="float: right; margin-right: 15px;" id="btnBatchExplor">导出</span>&nbsp;&nbsp;

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
                            <table class="table table-bordered table-hover table-center data-table">
                                <thead>
                                    <tr>
                                        <th>分类名称</th>
                                        <th>图片</th>
                                        <th>分类id</th>
                                        <th>显示顺序</th>
                                        <th>状态</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        foreach (var item in this.AllCates)
                                        {%>
                                    <tr class="trCat p<%=item.ParentId %>">
                                        <td class="txt80 productcag<%=item.LevelNo %> " style="text-align: left;">
                                            <%=item.LevelNo== 2 ?"&nbsp;&nbsp;&nbsp;&nbsp;└ ":"" %>
                                            <span class="cat<%=item.LevelNo %>"><%=item.Name %></span>
                                        </td>
                                        <td>
                                            <%= string.IsNullOrEmpty( item.Icon)?"":"<img src=\""+item.Icon+"\" style=\"width:84px;height:84px;\" />" %>
                                        </td>
                                        <td>
                                            <%=item.Id %>
                                        </td>
                                        <td>
                                            <img src="/3rdParty/images/icon_asc.gif"
                                                onclick="listHandler.sortUp(<%=item.Id %>);"
                                                style="cursor: pointer;" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <img src="/3rdParty/images/icon_desc.gif"
                                                onclick="listHandler.sortDown(<%=item.Id %>);"
                                                style="cursor: pointer;" />
                                        </td>
                                        <td>
                                            <%=item.Status==1?"<span style='color:green;'>启用</span>":"<span style='color:red;'>停用</span>" %>
                                        </td>
                                        <td>
                                            <a class="btn btn-myGreen btn-xs" href="GoodsCatEdit.aspx?id=<%=item.Id %>">编辑</a>
                                            <a class="btn btn-myRed btn-xs" href="javascript:listHandler.del(<%=item.Id %>)">删除</a>
                                        </td>
                                    </tr>
                                    <%}
                                    %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--批量导出-->
    <div id="batchExplorModal" class="modal-content-tag">
        <form id="export_form" action="?action=export" method="post">
            <div class="form-inline">
                <div class="form-group">
                    <span style="color: #666;">导出当前查询条件下的所有数据</span>
                </div>
            </div>
        </form>
    </div>
    <%=this.jsSegmentOut %>

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
        var listUrl = '/Goods/GoodsCatList.aspx';
        var totalPage = <%=this.pageCount%>;
    </script>

    <script type="text/javascript">
        $(function () {
            //导出初始化
            var batchExplorModal = $("#batchExplorModal").modal("批量导出", function () {
                $("#export_form").submit();
            });
            $("#btnBatchExplor").click(function () {
                batchExplorModal.show();
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
            },
            sortUp: function (catid) {
                this.sort(catid, 2);
            },
            sortDown: function (catid) {
                this.sort(catid, 1);
            },
            sort: function (catid, type) {
                var plattype = $('#plattype').val();
                hot.ajax("GoodsCatList.aspx?action=swap", { catid: catid, type: type, plattype: plattype }, function (data) {
                    if (data.resultCode == 1) {
                        //hot.tip.success("操作成功，等待刷新");
                        setTimeout(function () {
                            location.href = location.href;
                        }, 50);
                    } else {
                        hot.tip.error(data.resultMsg);
                    }
                }, function () {
                }, "post", 100);
            },
            del: function (id) {
                var plattype = $('#plattype').val();
                hqUtils.showConfirm('确定删除？', function () {
                    hot.ajax("GoodsCatList.aspx?action=del", { id: id, plattype: plattype }, function (data) {
                        if (data.resultCode == 1) {
                            layer.closeAll();
                            hot.tip.success('删除成功');
                            setTimeout(function () {
                                location.href = location.href;
                            }, 1200);
                        } else {
                            hot.tip.error("删除失败");
                        }
                    }, function () {
                    }, "post", 100);
                });
            }
        }
    </script>
</body>
</html>
