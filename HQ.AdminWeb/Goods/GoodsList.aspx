<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="HQ.AdminWeb.Goods.GoodsList" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>商品列表</title>
    <link href="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/datetimepick/daterangepicker.css" rel="stylesheet" />
    <link href="/3rdParty/css/common.css" rel="stylesheet" />
    <style type="text/css">
        #index_goods_list .goods-list-div {
            margin: 0 30px 20px
        }

            #index_goods_list .goods-list-div .goods-item {
                width: 224px;
                margin-right: 20px;
                display: inline-block;
                background-color: #fff;
                margin-bottom: 20px;
                border: 1px solid #f2f2f2
            }

                #index_goods_list .goods-list-div .goods-item.hover, #index_goods_list .goods-list-div .goods-item:hover {
                    border: 1px solid #e3544c
                }

                #index_goods_list .goods-list-div .goods-item img {
                    width: 100%;
                    height: 224px;
                    cursor: pointer
                }

                #index_goods_list .goods-list-div .goods-item .goods-info {
                    padding: 10px;
                    width: 100%
                }

                    #index_goods_list .goods-list-div .goods-item .goods-info .goods-name {
                        font-size: 14px;
                        overflow: hidden;
                        text-overflow: ellipsis;
                        white-space: nowrap;
                        color: #333;
                        margin-bottom: 4px;
                        cursor: pointer
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .goods-name-double {
                        height: 41px;
                        font-size: 14px;
                        color: #333;
                        margin-bottom: 14px;
                        cursor: pointer;
                        overflow: hidden;
                        text-overflow: ellipsis;
                        display: -webkit-box;
                        -webkit-line-clamp: 2
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .item-height-20 {
                        height: 20px;
                        margin-bottom: 10px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .item-height-32 {
                        height: 32px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .text-with-decoration {
                        max-width: 88px;
                        overflow: hidden;
                        text-decoration: line-through
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .coupon-icon {
                        display: inline-block;
                        background-color: #e3544c;
                        color: #fff;
                        width: 21px;
                        height: 18px;
                        line-height: 16px;
                        border: 1px solid #e3544c;
                        text-align: center;
                        font-size: 12px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .discount-amount {
                        display: inline-block;
                        font-weight: 700;
                        color: #e3544c;
                        height: 18px;
                        line-height: 16px;
                        border: 1px solid #e3544c;
                        font-size: 12px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .right-text {
                        color: #999;
                        height: 18px;
                        float: right;
                        padding-top: 2px;
                        line-height: 18px;
                        font-size: 12px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .color-red {
                        color: #e3544c
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .price-title {
                        display: inline-block;
                        float: left;
                        color: #9c9c9c;
                        height: 20px;
                        line-height: 20px;
                        font-size: 14px;
                        padding-right: 4px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .price {
                        display: inline-block;
                        font-family: Helvetica;
                        font-weight: 700;
                        color: #e3544c;
                        height: 20px;
                        line-height: 20px;
                        font-size: 18px;
                        overflow: hidden
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .sold-quantity {
                        display: inline-block;
                        color: #9c9c9c;
                        height: 30px;
                        line-height: 30px;
                        font-size: 14px;
                        padding-right: 4px
                    }

                    #index_goods_list .goods-list-div .goods-item .goods-info .operate-btn {
                        width: 82px;
                        height: 30px;
                        line-height: 28px;
                        border: 1px solid #e3544c;
                        border-radius: 4px;
                        text-align: center;
                        display: inline-block;
                        float: right;
                        font-size: 16px;
                        color: #e3544c;
                        cursor: pointer;
                        user-select: none
                    }

                        #index_goods_list .goods-list-div .goods-item .goods-info .operate-btn:hover {
                            background: #e3544c;
                            color: #fff
                        }

                        #index_goods_list .goods-list-div .goods-item .goods-info .operate-btn.selected {
                            border-color: #dadada;
                            color: #999
                        }

                            #index_goods_list .goods-list-div .goods-item .goods-info .operate-btn.selected:hover {
                                background: #ababab;
                                color: #fff
                            }

                        #index_goods_list .goods-list-div .goods-item .goods-info .operate-btn.selecting i {
                            display: inline-block;
                            width: 14px;
                            height: 14px;
                            background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABGdBTUEAALGPC/xhBQAAAiFJREFUWAntVT1MFEEUfrMcPxJ+DDGix1HbmpBo7EyARMwqFrfEilBZW9BLR6uWVsQCEobCg0RtTGghoaK0k8NEQjQmBI/Enef7VvYy2WV/bul0J9mbt9/3vW/evN3ZIyrH/94BVbQB3z1v+JRaO8jvp767I1r/LOLlFElCTovPXGa+hQtxUZ/CBfiObPx82HGI5Z0LF5B3gSxdWUDZgbIDlaxjAr7pzdaJzDNWzsvx9cb7tJyDudmHis1zIudNTTc20rTgcj0CJrMsX7xpZfzG4Zz7KMkUHDTQIidJZ+O5CnCYgl0zUcUY0s2n7qRtghgYOGhwH+YgThu5CqiO3FxU6m8RYtZLPjUU8b3QOIgFCzj5gRY5IZ825/435IWFvsOT4w+yw/sZhttjA9dm1MpKK00XcrECmvXHHhHPO6prqarf7YVCzEeeN3BGvz4R0x0bb8eKdnvpyuR1rU/amARfvScThv0l6c3b2samtrnYI2BlXjOxa8h/YQsRw3iwe+iB9Hg/ygEDF10cOnjBE97RvFgBsrsbEEmrgzmacHV19UdPRU1L6z6HHGJg4ELMntte5942Fy/AZhPi0bXNb45SU7Lrj7gQA0uQp8K5PkQXOVT11hfBZy7iOsEKdaCTBbK0ZQFp78DtZt09yGphHl5OwWiSLlaAInUqZ7afmLslsZaU2BHO4iQD3tG8+Dvg8Cs517+jwsveB57ifVmffy//DwRmrRRoUf1VAAAAAElFTkSuQmCC) no-repeat;
                            background-size: 14px 14px;
                            background-position: 0 0;
                            margin-right: 6px;
                            position: relative;
                            top: 1px
                        }

                        #index_goods_list .goods-list-div .goods-item .goods-info .operate-btn.selecting:hover i {
                            background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABGdBTUEAALGPC/xhBQAAAYVJREFUWAntlrFOAkEURVkjCVESQsWH8AnaaEIHFTXxeyxt/AE6jBY01FJaGelsiL3aYILn6kwyM8uy42A5L7nMvPvuu7N5md3QaOTIE0icwHa77YBng06iTXobB4+BjXGq01FqI30nTq+7d+j67SEPUO8eocgPkCeQJxA1Ab42QzAHl3VvljRGO6zTRtcxXAHFBgzUyDoRYWJiuAG5NIpVzAFRE8DowZgds04xPwvNDTeFl0Zhe36zQ34xb4J7YOOdza1NzF6cDWmbh5xZ6sWwBRagLhYIWiWDWILmEbgD/bAHrg0eQVWo1t7R14eX5yislXJEa6CYlYoQ8F3wJEEQ4roVPTOjXe+qe5xjuvQKToKmB14crfY9R+JtqS2t1iuQ2Bsb8nvzoijeMDxHdGOEV+L2NlUUkx5AXhz4ynJR4RtNx34Hog3/KswPUIQj02013IY16WKFnuR6Q36+jNwd70wvUSPnf7Ak/8uVx5745PxTt77rDlwj+HJF/7SXp7xzeBP4Bhjoeq33FEdKAAAAAElFTkSuQmCC) no-repeat;
                            background-size: 14px 14px;
                            background-position: 0 0
                        }
    </style>
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

                                    <label class=" control-label">所属分类：</label>
                                    <select class="form-control input-sm" id="mainCatId" runat="server">
                                        <option value="-1">==所有==</option>
                                    </select>-
                                    <select class="form-control input-sm" id="subCatId" runat="server">
                                        <option value="-1">==所有==</option>
                                    </select>

                                    <label class=" control-label">名称：</label>
                                    <input type="text" class="form-control" id="keyword" runat="server"
                                        placeholder="关键字" style="width: 200px;" />

                                    <label class=" control-label">排序字段：</label>
                                    <select class="form-control input-sm" id="sortField" runat="server">
                                    </select>
                                    <label class=" control-label">排序方式：</label>
                                    <select class="form-control input-sm" id="sortType" runat="server">
                                        <option value="0">升序</option>
                                        <option value="1">降序</option>
                                    </select>
                                </div>

                                <span onclick="listHandler.search(1)" class="btn btn-success btn-sm">搜索</span>
                                <span onclick="listHandler.searchAll()" class="btn btn-success btn-sm">显示所有</span>

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
                        <div class="panel-body" id="index_goods_list">

                            <div class="goods-list-div">
                                <ul>
                                    <%--                           <li class="goods-item">
                                        <img src="http://t00img.yangkeduo.com/t09img/images/2018-06-04/2def394d13b11d2e85f58220cd845292.jpeg@750w_1l_50Q.src"><div class="goods-info">
                                            <p class="goods-name">蘭月星抽纸8包/18包/27包竹浆抽纸巾婴儿卫生纸纸餐巾纸整箱批发</p>
                                            <p class="item-height-20"><span class="coupon-icon">券</span><span class="discount-amount">￥4</span><span class="right-text">剩余15200张</span></p>
                                            <p class="item-height-20"><span class="price-title">价格</span><span class="price">￥7.90</span><span class="right-text text-with-decoration">原价￥11.90</span></p>
                                            <p class="item-height-20"><span class="price-title">赚取</span><span class="price">￥2.37</span><span class="right-text color-red">比率30%</span></p>
                                            <p style="margin-bottom: 8px;">
                                                <span class="sold-quantity">
                                                    销量3646</span><span class="operate-btn">查看商品</span>
                                                <span class="operate-btn selecting" style="display: none;"><i></i>选取</span>
                                            </p>
                                        </div>
                                    </li>--%>

                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <li class="goods-item">
                                                <img src="<%#Eval("GoodsThumbnailUrl") %>">
                                                <div class="goods-info">
                                                    <p class="goods-name"><%#Eval("GoodsName") %></p>
                                                    <p class="item-height-20"><span class="coupon-icon">券</span><span class="discount-amount">￥<%#Eval("CouponDiscount") %></span><span class="right-text">剩余<%#Eval("CouponRemainQuantity") %>张</span></p>
                                                    <p class="item-height-20"><span class="price-title">价格</span><span class="price">￥<%#Eval("CouponedPrice") %></span><span class="right-text text-with-decoration">原价￥<%#Eval("MinGroupPrice") %></span></p>
                                                    <p class="item-height-20"><span class="price-title">赚取</span><span class="price">￥<%#Eval("PromotionAmount") %></span><span class="right-text color-red">比率<%#Convert.ToInt32(Eval("PromotionRate"))/10 %>%</span></p>
                                                    <p style="margin-bottom: 8px;">
                                                        <span class="sold-quantity">销量<%#Eval("SoldQuantity") %></span>
                                                        <a href="http://mobile.yangkeduo.com/goods2.html?goods_id=<%#Eval("GoodsId") %>" target="_blank"><span class="operate-btn">查看商品</span></a>
                                                        <span class="operate-btn selecting" style="display: none;"><i></i>选取</span>
                                                    </p>
                                                </div>
                                            </li>

                                            <%--<li class="goods-item">
                                        <img src="http://t00img.yangkeduo.com/t09img/images/2018-06-04/2def394d13b11d2e85f58220cd845292.jpeg@750w_1l_50Q.src"><div class="goods-info">
                                            <p class="goods-name">蘭月星抽纸8包/18包/27包竹浆抽纸巾婴儿卫生纸纸餐巾纸整箱批发</p>
                                            <p class="item-height-20"><span class="coupon-icon">券</span><span class="discount-amount">￥4</span><span class="right-text">剩余15200张</span></p>
                                            <p class="item-height-20"><span class="price-title">价格</span><span class="price">￥7.90</span><span class="right-text text-with-decoration">原价￥11.90</span></p>
                                            <p class="item-height-20"><span class="price-title">赚取</span><span class="price">￥2.37</span><span class="right-text color-red">比率30%</span></p>
                                            <p style="margin-bottom: 8px;">
                                                <span class="sold-quantity">
                                                    销量3646</span><span class="operate-btn">查看商品</span>
                                                <span class="operate-btn selecting" style="display: none;"><i></i>选取</span>
                                            </p>
                                        </div>
                                    </li>--%>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </ul>
                            </div>


                            <div style="height: 5px; clear: both;"></div>
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
        var listUrl = '/Goods/GoodsList.aspx';
        var totalPage = <%=this.pageCount%>;
        var allSubCats = <%=this.SubCatJson%>;//{"Id":2156,"PlatType":0,"Name":"清洗季","ParentId":2048,"LevelNo":2,"Icon":"http://res.chinaswt.cn/resource/images/goodscat/0/2156.jpeg","SortNum":2156,"Status":1}
        var _subCatId = <%=this.GetQueryString("subCatId",0)%>;
    </script>

    <script type="text/javascript">
        $(function () {
            var pageinate = new hot.paging(".pagination", parseInt($("input[name=pageIndex]").val()), totalPage, 7);
            pageinate.init(function (p) {
                listHandler.search(p);
            });
            listHandler.init();
        });

        var listHandler = {
            init: function () {
                this.bindCats();
                $('#mainCatId').change(function () {
                    listHandler.bindCats();
                })
            },
            search: function (pageIndex) {
                $("input[name=pageIndex]").val(pageIndex);
                $("#searchForm").submit();
            },
            searchAll: function () {
                window.location.href = listUrl;
            },
            bindCats: function () {
                var _mainCatId = $('#mainCatId').val();
                if (parseInt(_mainCatId) <= 0) return;
                var $subCatId = $('#subCatId');
                $subCatId.empty();
                $subCatId.append("<option value='-1'>==所有==</option>");
                for (var i = 0; i < allSubCats.length; i++) {
                    if (allSubCats[i].LevelNo <= 1 || allSubCats[i].ParentId != _mainCatId) continue;
                    var selected = allSubCats[i].Id == _subCatId ? "selected='selected'" : "";
                    $subCatId.append("<option value='" + allSubCats[i].Id + "' " + selected + ">" + allSubCats[i].Name + "</option>");
                }
            }
        }
    </script>
</body>
</html>
