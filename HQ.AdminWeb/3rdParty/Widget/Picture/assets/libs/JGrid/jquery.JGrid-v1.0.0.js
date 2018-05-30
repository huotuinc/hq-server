(function ($) {
    $.extend({
        IsIntPositive: function (str) { return /^[0-9]*[1-9][0-9]*$/.test(str); },
        FormatString: function () { if (arguments.length == 0) return ''; if (arguments.length == 1) return arguments[0]; var args = $.CloneArray(arguments); args.splice(0, 1); return arguments[0].replace(/{(\d+)?}/g, function ($0, $1) { return args[parseInt($1)]; }); },
        CloneArray: function (arr) { var cloned = []; for (var i = 0, j = arr.length; i < j; i++) { cloned[i] = arr[i]; } return cloned; },
        __checkAll: function (ck, div) {
            _checkvalue = "";
            var $this = $("#" + div).data('Grid');
            $("#jackson-data-datatable-box-" + $this.name + " input[type=checkbox]").each(function (idx, item) {
                if (ck.checked) {
                    item.checked = ck.checked;
                    _checkvalue += item.id + ',';
                }
                else {
                    item.checked = ck.checked;
                    _checkvalue = "";
                }
            });
            $this.checkValue = _checkvalue.toString().substr(1, _checkvalue.length - 2);
            if (!($this.checkValue === undefined || $this.checkValue == '')) {
                var arr = $this.checkValue.split(',');
                if (arr != null && arr.length > 0) {
                    $this.checkCount = arr.length;
                }
            }
            $("#" + div).data('Grid', $this);
        },
        __check: function (ck, div) {
            var $this = $("#" + div).data('Grid');
            var _checkValue = "";
            if (ck != null) {
                if (document.getElementById(ck).checked) {
                    document.getElementById(ck).checked = false;
                    $(".jackson-data-datatable-box input[type=checkbox]").each(function (idx, item) {
                        if (item.checked) {
                            _checkValue += item.id + ',';
                        }
                    });
                }
                else {
                    document.getElementById(ck).checked = true;
                    $(".jackson-data-datatable-box input[type=checkbox]").each(function (idx, item) {
                        if (item.checked) {
                            _checkValue += item.id + ',';
                        }
                    });
                }
            }
            else {
                $(".jackson-data-datatable-box input[type=checkbox]").each(function (idx, item) {
                    if (item.checked) {
                        _checkValue += item.id + ',';
                    }
                });
            }
            var _tream = _checkValue.charAt(0);
            if (_tream == ',') {
                $this.checkValue = _checkValue.toString().substr(1, _checkValue.length - 2);
            }
            else {
                $this.checkValue = _checkValue.toString().substr(0, _checkValue.length - 1);
            }
            if (!($this.checkValue === undefined || $this.checkValue == '')) {
                var arr = $this.checkValue.split(',');
                if (arr != null && arr.length > 0) {
                    $this.checkCount = arr.length;
                }
            }
            $("#" + div).data('Grid', $this);
        },
        __checkRaido: function (ck, div) {
            var $this = $("#" + div).data('Grid');
            _checkvalue = "";
            if (ck != null) {
                if (document.getElementById(ck).checked) {
                    document.getElementById(ck).checked = false;
                }
                else {
                    document.getElementById(ck).checked = true;
                    _checkvalue += ck;
                }

            }
            else {
                $(".jackson-data-datatable-box input[type=radio]").each(function (idx, item) {
                    if (item.checked) {
                        _checkvalue += item.id;
                    }
                });
            }
            $this.checkValue = _checkvalue;
            if (!($this.checkValue === undefined || $this.checkValue == '')) {
                var arr = $this.checkValue.split(',');
                if (arr != null && arr.length > 0) {
                    $this.checkCount = arr.length;
                }
            }
            $("#" + div).data('Grid', $this);
        },
        __OnGridDelegate: function (div, rowObj) {
            var $this = $("#" + div).data('Grid');
            if (typeof $this.onClick === 'function') {
                if ($this != null && $this.Data!=null&&$this.Data.Rows!=null&&$this.Data.Rows[rowObj]) {
                    $this.onClick($this.Data.Rows[rowObj]);
                }
            }
            else {
                alert("It is not a valid executable method");
            }
        },
        __getGridData: function (obj) {
            //_body = "";//数据内容
            var _body = "";
            var div = obj.label;
            $.ajax({
                type: "GET",
                url: obj.url,
                contentType: "application/json;charset=utf-8",
                async: false,
                dataType: obj.dataType,
                data: { page: obj.page, pagesize: obj.pageSize, order: obj.order, t: Math.random() },                success: function (data) {
                    obj.Data = data;
                    obj.Currpage = obj.page;
                    if (data == null) {
                        if (obj.rows != null && obj.rows.length > 0) {
                            if (obj.showCheck || obj.showRadio||obj.showNumber) {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + (parseInt(obj.rows.length) + 1) + "\">没有数据</td></tr>";
                            }
                            else {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                            }
                        }
                    }
                    else if (data.Rows != null && data.Rows.length > 0) {
                        obj.TotalPage = data.PageCount;
                        obj.Total = data.Total;
                        var bgc = "";
                        if (obj.rows != null && obj.rows.length > 0) {
                            for (var i = 0; i < data.Rows.length; i++) {
                                var bgc = "";
                                for (var k = 0; k < obj.rows.length; k++) {
                                    if (typeof obj.rows[k].bgcolor == "function") {
                                        bgc = obj.rows[k].bgcolor(data.Rows[i][obj.rows[k].field], data.Rows[i]);
                                        if (bgc == undefined) {
                                            bgc = "";
                                        }
                                        break;
                                    } else {
                                        bgc = "";
                                    }
                                }
                                if (obj.doubleLine && (i + 1) % 2 == 0) {
                                    if (bgc != '') {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#f2f2f2\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#f2f2f2\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"#F5F8FA\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                } else {
                                    if (obj.showCheck) {
                                        _body += "<tr onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else if (obj.showRadio) {
                                        _body += "<tr onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else {
                                        _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                    }
                                }
                                if (obj.showCheck) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "')\" type='checkbox' id='" + data.Rows[i][obj.key] + "' value='" + data.Rows[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showRadio) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "')\" name='jackson-data-rows-radio' type='radio' id='" + data.Rows[i][obj.key] + "' value='" + data.Rows[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showNumber) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += (i + 1);
                                    _body += "</td>";
                                }
                                for (var j = 0; j < obj.rows.length; j++) {
                                    if (typeof obj.rows[j].formatter == "function") {
                                        if (obj.showCheck) {
                                            _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data.Rows[i][obj.rows[j].field], data.Rows[i]) + "</td>";
                                        }
                                        else {
                                            _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data.Rows[i][obj.rows[j].field], data.Rows[i]) + "</td>";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            if (data.Rows[i][obj.rows[j].field] == '') {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;</td>";
                                            }
                                            else {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data.Rows[i][obj.rows[j].field] + "</td>";
                                            }
                                            //_body += "<td align=\"" + obj.rows[j].align + "\">" + data.Rows[i][obj.rows[j].field] + "</td>";
                                        }
                                        else {
                                            if (data.Rows[i][obj.rows[j].field] == '') {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;</td>";
                                            }
                                            else {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data.Rows[i][obj.rows[j].field] + "</td>";
                                            }
                                            //_body += "<td align=\"" + obj.rows[j].align + "\">" + data.Rows[i][obj.rows[j].field] + "</td>";
                                        }
                                    }
                                }
                                _body += "</tr>";
                            }
                        }
                    }
                    else {//没有数据时
                        if (obj.rows != null && obj.rows.length > 0) {
                            if (obj.showCheck || obj.showRadio || obj.showNumber) {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + (parseInt(obj.rows.length) + 1) + "\">没有数据</td></tr>";
                            }
                            else {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                            }
                        }
                    }
                },
                error: function () {//没有数据时
                    if (obj.rows != null && obj.rows.length > 0) {
                        if (obj.showCheck || obj.showRadio || obj.showNumber) {
                            _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + (parseInt(obj.rows.length) + 1) + "\">没有数据</td></tr>";
                        }
                        else {
                            _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                        }
                    }
                }
            })
            $("#" + obj.label).data('Grid', obj);
            return _body;
        },
        __postGridData: function (obj) {
            var string = $("#" + obj.form).serialize() + "&page=" + obj.page + "&pagesize=" + obj.pageSize + "&order=" + obj.order + "&_=" + Math.random();
            var _body = "";//数据内容
            var div = obj.label;
            $.ajax({
                type: "POST",
                url: obj.url,
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                async: false,
                data: string,
                success: function (data) {
                    obj.Data = data;
                    obj.Currpage = obj.page;
                    if (data == null) {
                        if (obj.rows != null && obj.rows.length > 0) {
                            if (obj.showCheck || obj.showRadio || obj.showNumber) {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + (parseInt(obj.rows.length) + 1) + "\">没有数据</td></tr>";
                            }
                            else {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                            }
                        }
                    }
                    else if (data.Rows != null && data.Rows.length > 0) {
                        obj.TotalPage = data.PageCount;
                        obj.Total = data.Total;
                        if (obj.rows != null && obj.rows.length > 0) {
                            for (var i = 0; i < data.Rows.length; i++) {
                                var bgc = "";
                                for (var k = 0; k < obj.rows.length; k++) {
                                    if (typeof obj.rows[k].bgcolor == "function") {
                                        bgc = obj.rows[k].bgcolor(data.Rows[i][obj.rows[k].field], data.Rows[i]);
                                        if (bgc === undefined) {
                                            bgc = "";
                                        }
                                        break;
                                    } else {
                                        bgc = "";
                                    }
                                }
                                if (obj.doubleLine && (i + 1) % 2 == 0) {
                                    if (bgc != '') {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#f2f2f2\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#f2f2f2\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"#F5F8FA\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                } else {
                                    if (obj.showCheck) {
                                        _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else if (obj.showRadio) {
                                        _body += "<tr onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else {
                                        _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                    }
                                }
                                if (obj.showCheck) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__check('" + data.Rows[i][obj.key] + "','" + div + "')\" type='checkbox' id='" + data.Rows[i][obj.key] + "' value='" + data.Rows[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showRadio) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__checkRaido('" + data.Rows[i][obj.key] + "','" + div + "')\" name='jackson-data-rows-radio' type='radio' id='" + data.Rows[i][obj.key] + "' value='" + data.Rows[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showNumber) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += (i + 1);
                                    _body += "</td>";
                                }
                                for (var j = 0; j < obj.rows.length; j++) {
                                    if (typeof obj.rows[j].formatter == "function") {
                                        if (obj.showCheck) {
                                            _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data.Rows[i][obj.rows[j].field], data.Rows[i]) + "</td>";
                                        }
                                        else {
                                            _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data.Rows[i][obj.rows[j].field], data.Rows[i]) + "</td>";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            if (data.Rows[i][obj.rows[j].field] == '') {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;</td>";
                                            }
                                            else {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data.Rows[i][obj.rows[j].field] + "</td>";
                                            }
                                        }
                                        else {
                                            if (data.Rows[i][obj.rows[j].field] == '') {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;</td>";
                                            }
                                            else {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data.Rows[i][obj.rows[j].field] + "</td>";
                                            }
                                        }
                                    }
                                }
                                _body += "</tr>";
                            }
                        }
                    }
                    else {//没有数据时
                        if (obj.rows != null && obj.rows.length > 0) {
                            if (obj.showCheck || obj.showRadio || obj.showNumber) {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + (parseInt(obj.rows.length) + 1) + "\">没有数据</td></tr>";
                            }
                            else {
                                _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                            }
                        }
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {//没有数据时
                    if (obj.rows != null && obj.rows.length > 0) {
                        if (obj.showCheck || obj.showRadio || obj.showNumber) {
                            _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + (parseInt(obj.rows.length) + 1) + "\">没有数据</td></tr>";
                        }
                        else {
                            _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                        }
                    }
                }
            })
            $("#" + obj.label).data('Grid', obj);
            return _body;
        },
        __pagerGridHtml: function (obj) {
            var totalPages = obj.TotalPage; //计算总页码数
            var _htmlPager = "";//分页标签Html
            var currentPage = obj.Currpage;//当前页码
            var uppage = currentPage - 1;
            var nextpage = parseInt(currentPage + 1);
            var pageSize = obj.pageSize;//总页面大小
            var total = obj.Total;
            if (totalPages >= 1) {
                _htmlPager = "<div class=\"jackson-pager-box\"><span class=\"jackson-pager-left\" style='float:left;'>"
                _htmlPager += "共<b>" + total + "</b>条记录 当前<b class=\"jackson-pager-box-b\">" + currentPage + "</b>/<b class=\"jackson-pager-box-b\">" + totalPages + "</b class=\"jackson-pager-box-b\">页 每页<b>" + obj.pageSize + "</b>条记录";
                _htmlPager += "</span>";
                _htmlPager += "<ul class=\"jackson-pagination\" style='float:right'>"
                _htmlPager += "<li><a href=\"javascript:$.__goPage('1','" + pageSize + "','" + obj.label + "')\"' title='首页'>首页</a></li>";
                if (currentPage > 1) {//处理上一页的连接
                    _htmlPager += "<li><a href=\"javascript:$.__goPage('" + uppage + "','" + pageSize + "','" + obj.label + "')\" title='上一页'>&laquo;</a></li";
                }
                else {
                    _htmlPager += "<li class=\"disabled\" ><a href=\"javascript:void(0)\">&laquo;</a></li>";
                }
                var currint = obj.pagerCount / 2;//前后页码数
                var dif = (currentPage - (obj.pagerCount - 2));
                var count = dif > 0 ? dif : 1;
                for (var i = count ; i <= ((obj.pagerCount - 1) + count) ; i++) {
                    if (currentPage == i) {
                        _htmlPager += "<li class=\"active\"><a href=\"javascript:$.__goPage('" + (i) + "','" + pageSize + "','" + obj.label + "')\">" + (i) + "</a></li>";
                    }
                    else {
                        if (i <= totalPages) {
                            _htmlPager += "<li><a href=\"javascript:$.__goPage('" + (i) + "','" + pageSize + "','" + obj.label + "')\">" + (i) + "</a></li>";
                        }
                    }
                }
                if (currentPage < totalPages) {//处理下一页的链接
                    _htmlPager += "<li><a href=\"javascript:$.__goPage('" + nextpage + "','" + pageSize + "','" + obj.label + "')\">&raquo;</a></li>";
                }
                else {
                    _htmlPager += "<li class=\"disabled\"><a href='javascript:void(0)'>&raquo;</a></li>";
                }
                _htmlPager += "<li><a href=\"javascript:$.__goPage('" + totalPages + "','" + pageSize + "','" + obj.label + "')\" title='尾页'>尾页</a></li>";
                _htmlPager += "</ul></div><div style='clear:both'></div>";
            }
            return _htmlPager;
        },
        __pagerOut: function (pageSize, pageIndex, pageCount, recordCount, div) {
            pageSize = parseInt(pageSize, 10);
            pageIndex = parseInt(pageIndex, 10);
            pageCount = parseInt(pageCount, 10);
            recordCount = parseInt(recordCount, 10);

            if (pageIndex < 1)
                pageIndex = 1;
            if (pageIndex > pageCount)
                pageIndex = pageCount;

            function _getLink(text, enabled, pageSize, index, div) {
                if (enabled == false) {
                    var _nextHtml = "<a title=\"" + text + "\" class=\"jackson-pager-button\" style=\"filter:Alpha(Opacity=60);opacity:0.6;\" href=\"javascript:void(0)\"><span>" + text + "</span></a>";
                    return _nextHtml;
                }
                else {
                    var _nextHtml = "<a title=\"" + text + "\" class=\"jackson-pager-button\" onclick=\"$.__goPage('" + index + "','" + pageSize + "','" + div + "')\" href=\"javascript:void(0)\"><span>" + text + "</span></a>";
                    return _nextHtml;
                }
            }
            var html = [];
            html.push('<div class="jackson-data-rows-page">');
            html.push("<span class=\"jackson-data-rows-pageright\" style='float:left;'>");
            html.push($.FormatString('<div class="jackson-data-rows-page-msg">共{0}条记录，当前{1}/{2}页，每页{3}条记录</div>', recordCount, pageIndex, pageCount, pageSize));
            html.push("</span>");
            html.push("<span class=\"jackson-data-rows-pageleft\" style='float:right;'>");
            html.push(_getLink('首页', pageIndex > 1, pageSize, 1, div));
            html.push(_getLink('上一页', pageIndex > 1, pageSize, pageIndex - 1, div));
            html.push(_getLink('下一页', pageCount > 0 && pageIndex < pageCount, pageSize, pageIndex + 1, div));
            html.push(_getLink('未页', pageCount > 0 && pageIndex < pageCount, pageSize, pageCount, div));
            html.push('&nbsp;&nbsp;&nbsp;');
            html.push('第<input id="jackson-data-rows-page-current-' + div + '" class="jackson-data-rows-page-input-small" style="text-align:center;" type="text" value="' + (pageIndex > 0 ? pageIndex : '') + '" />页');
            html.push('&nbsp;');
            html.push($.FormatString('<a class="jackson-pager-button"' + (pageCount <= 1 ? ' style="filter:Alpha(Opacity=60);opacity:0.6;" href="javascript:void(0);"' : ' href="javascript:$.__Jump(\'{0}\',\'{1}\',\'{2}\',\'{3}\')"') + '><span>跳转</span></a>', "jackson-data-rows-page-current-" + div, pageSize, recordCount, div));
            html.push("</span>");
            html.push('</div>');
            return html.join('');
        },
        //排序 name:排序字段,type:0-不显示图标,0/1-默认Desc排序,2-默认asc排序
        __orderGrid: function (name, id, text, div) {
            var $this = $("#" + div).data('Grid');
            var type = $("#" + id).attr("jacksonrowsqx");
            if (type == '0') {//不显示图标
                $this.order = " order by " + name + " asc";
                //var page = (this.Total / this.pagesize) > parseInt(this.Total / this.pagesize) ? (parseInt(this.Total / this.pagesize) + 1) : (this.Total / this.pagesize);
                $this.goPage(1, $this.pagesize);
                $("#" + id).html("");
                $("#" + id).attr("jacksonrowsqx", "1");
                $("#" + id).append("<span class='jackson-data-row-icon-asc'>" + text + "</span>");
            }
            else if (type == '1')//显示降序图标
            {
                $this.order = " order by " + name + " desc";
                //var page = (this.Total / this.pagesize) > parseInt(this.Total / this.pagesize) ? (parseInt(this.Total / this.pagesize) + 1) : (this.Total / this.pagesize);
                $this.goPage(1, $this.pagesize);
                $("#" + id).attr("jacksonrowsqx", "2");
                $("#" + id).html("");
                $("#" + id).append("<span class='jackson-data-row-icon-desc'>" + text + "</span>");
            }
            else {//显示升序图标
                $this.order = " order by " + name + " asc";
                //var page = (this.Total / this.pagesize) > parseInt(this.Total / this.pagesize) ? (parseInt(this.Total / this.pagesize) + 1) : (this.Total / this.pagesize);
                $this.goPage(1, $this.pagesize);
                $("#" + id).attr("jacksonrowsqx", "1");
                $("#" + id).html("");
                $("#" + id).append("<span class='jackson-data-row-icon-asc'>" + text + "</span>");
            }

        },
        __Jump: function (current, pageSize, recordCount, div) {
            var index = $('#' + current).val();
            if ($.IsIntPositive(index) == false || parseInt(index) < 1 || parseInt(index) > recordCount) {
                $('#' + current).val('').focus();
                return;
            }
            $.__goPage(index, pageSize, div);
        },
        __createLoad: function (height, top, name) {
            var _html = "<div class='jackson-mask' id='jackson-mask-" + name + "' style='display:none;width:100%;height:" + height + "px; top:" + top + "px;'>";
            _html += "<div class=\'jackson-mark-body\' id=\'jackson-mark-body-" + name + "'\' style=\'margin-top:" + ((height - 60) / 2) + "px\'>";
            _html += "<span>请稍后...</span><br/>";
            _html += "</div></div>";
            return _html;
        },
        __goPage: function (page, pageSize, div) {
            var $this = $("#" + div).data('Grid');
            $this.page = page;
            var _height = 0;
            var _top = 0;
            var _top = $("#" + $this.label).offset().top;
            if ($("#jackson-grid-data-box-" + $this.name)[0]) {//等待窗体操作
                _height = $("#jackson-data-datatable-box-" + $this.name).height();
                $("#jackson-mask-" + $this.name).height(_height);
                $("#jackson-mask-" + $this.name).css("top", _top + "px");
                $("#jackson-mark-body-" + $this.name).css("margin-top", (_height - 60) / 2 + "px");
                $("#jackson-mask-" + $this.name).show();
            }
            else {//等待窗体操作
                var _mask = $.__createLoad(_height, _top, $this.name);
                $("#" + $this.label).append(_mask);
            }
            var shtml = '';
            if ($this.rows != null && $this.rows.length > 0) {
                shtml += "<div class=\"jackson-data-datatable-box\" id=\"jackson-data-datatable-box-" + $this.name + "\" style=\"height:" + $this.height + "px; width:" + ($this.width) + "\">";
                shtml += "<table width=\"100%\" border-collapse:collapse  cellpadding=\"0\" cellspacing=\"0\">";
                shtml += "<tbody>";
                shtml += "<tr class=\"jackson-data-rows-title\">";
                if ($this.showCheck) {
                    shtml += "<th align=\"center\"  width=\"40\" >";
                    shtml += "<input  type='checkbox' onclick=\"$.__checkAll(this,'" + div + "')\"/>";
                    shtml += "</th>";
                }
                if ($this.showRadio) {
                    shtml += "<th align=\"center\"  width=\"40\" >";
                    shtml += "选择";
                    shtml += "</th>";
                }
                if ($this.showNumber) {
                    shtml += "<th align=\"center\"  width=\"40\" >";
                    shtml += "序号";
                    shtml += "</th>";
                }
                for (var i = 0; i < $this.rows.length; i++) {
                    if ($this.showOrder) {//表头点击排序功能
                        var _id = "jackson-rows-title-" + $this.rows[i].field;
                        shtml += "<th style='cursor:pointer;' jacksonrowsqx='0' id='" + _id + "' onclick=\"$.__orderGrid('" + $this.rows[i].order + "','" + _id + "','" + $this.rows[i].title + "','"+div+"')\" align=\"" + $this.rows[i].align + "\" width=\"" + $this.rows[i].width + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + $this.rows[i].title + "</th>";
                    }
                    else {
                        shtml += "<th align=\"" + $this.rows[i].align + "\" width=\"" + $this.rows[i].width + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + $this.rows[i].title + "</th>";
                    }
                }
                shtml += "</tr>";//表格标题添加完成
                if ($this.method == 'GET') {//GET方式获取数据
                    shtml += $.__getGridData($this);
                    alert(shtml);
                }
                else if ($this.method == 'POST')//POST方式获取数据
                {
                    shtml += $.__postGridData($this);
                }
                //$("#jackson-mask").hide();
                shtml += "</tbody>";
                shtml += "</table>";
                shtml += "</div>";

                shtml = "<div id='jackson-grid-data-box-" + $this.name + "'>" + shtml;
                if ($this.pageDetail) {
                    shtml += $.__pagerGridHtml($this);
                }
                else {
                    shtml += $.__pagerOut($this.pageSize, $this.Currpage, $this.TotalPage, $this.Total, $this.label);
                }
                $("#" + $this.label).width($this.width);
                $("#jackson-grid-data-box-" + $this.name).remove();
                $('#' + $this.label).append(shtml);
                $("#jackson-mask-" + $this.name).hide($this.waitMove);//隐藏等待窗体
            }
            if (typeof $this.callback === "function") {
                $this.callback($this);
            }
        },
        //以下为没有分页加载
        __init: function (div) {
            var $this = $("#" + div).data('Grid');
            var _height = 0;
            var _top = 0;
            if ($("#jackson-grid-data-box")[0]) {//等待窗体操作
                var _top = $("#" + $this.label).offset().top;
                _height = $("#jackson-data-datatable-box table").height();
                $("#jackson-mask").height(_height);
                $("#jackson-mask").css("top", _top + "px");
                $("#jackson-mark-body").css("margin-top", (_height - 60) / 2 + "px");
                $("#jackson-mask").show();
            }
            else {//等待窗体操作
                var _mask = $.__createLoad(_height, _top, $this.name);
                $("#" + $this.label).append(_mask);
            }
            var shtml = "";
            if ($this.rows != null && $this.rows.length > 0) {
                shtml += "<div class=\"jackson-data-datatable-box\" style=\"height:" + $this.height + "px; width:" + ($this.width) + "\">";
                shtml += "<table width=\"100%\" border-collapse:collapse border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                shtml += "<tbody>";
                shtml += "<tr class=\"jackson-data-rows-title\">";
                if ($this.showCheck) {
                    shtml += "<th align=\"center\"  width=\"40\" >";
                    shtml += "<input  type='checkbox' onclick='$.__checkAll(this,\"" + div + "\")'/>";
                    shtml += "</th>";
                }
                if ($this.showRadio) {
                    shtml += "<th align=\"center\"  width=\"40\" >";
                    shtml += "选择";
                    shtml += "</th>";
                }
                if ($this.showNumber) {
                    shtml += "<th align=\"center\"  width=\"40\" >";
                    shtml += "序号";
                    shtml += "</th>";
                }
                for (var i = 0; i < $this.rows.length; i++) {
                    if (this.showOrder) {//表头点击排序功能
                        var _id = "jackson-rows-title-" + $this.rows[i].field;
                        shtml += "<th style='cursor:pointer;' jacksonrowsqx='0' id='" + _id + "' onclick=\"$__.orderGrid('" + $this.rows[i].order + "','" + _id + "','" + $this.rows[i].title + "')\" align=\"" + $this.rows[i].align + "\" width=\"" + $this.rows[i].width + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + $this.rows[i].title + "</th>";
                    }
                    else {
                        shtml += "<th align=\"" + $this.rows[i].align + "\" width=\"" + $this.rows[i].width + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + $this.rows[i].title + "</th>";
                    }
                }
                shtml += "</tr>";//表格标题添加完成
                if ($this.method == 'GET') {//GET方式获取数据
                    shtml += $.__initDataGetNoPage($this);
                }
                else if ($this.method == 'POST')//POST方式获取数据
                {
                    shtml += $.__initDataPostNoPage($this);
                }
                //shtml += $this.body;
                shtml += "</tbody>";
                shtml += "</table>";
                shtml += "</div>";

                shtml = "<div id='jackson-grid-data-box'>" + shtml;
                //shtml += $this.tablePage;
                $("#" + $this.label).width($this.width);
                $("#jackson-grid-data-box").remove();
                $('#' + $this.label).append(shtml);
                $("#jackson-mask").hide(1000);//隐藏等待窗体
            }
        },
        //GET访问数据方式(不翻页)
        __initDataGetNoPage: function (obj) {
            var _body = "";//数据内容
            var div = obj.label;
            $.ajax({
                type: "GET",
                url: obj.url,
                contentType: "application/json;charset=utf-8",
                dataType: obj.dataType,
                data: { t: Math.random(), order: obj.order },
                async: false,
                success: function (data) {
                    obj.Data = data;
                    if (data == null) {
                        if (obj.rows != null && obj.rows.length > 0) {
                            _body += "<tr><td style=\"word-wrap: break-word;word-break:break-all; \" class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                        }
                    }
                    else if (data.length > 0) {
                        if (obj.rows != null && obj.rows.length > 0) {
                            for (var i = 0; i < data.length; i++) {
                                var bgc = "";
                                for (var k = 0; k < obj.rows.length; k++) {
                                    if (typeof obj.rows[k].bgcolor == "function") {
                                        bgc = obj.rows[k].bgcolor(data.Rows[i][obj.rows[k].field], data.Rows[i]);
                                        if (bgc == undefined) {
                                            bgc = "";
                                        }
                                        break;
                                    } else {
                                        bgc = "";
                                    }
                                }
                                if (obj.doubleLine && (i + 1) % 2 == 0) {
                                    if (bgc != '') {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__.checkRaido('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#F5F8FA\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__checkRaido('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#F5F8FA\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"#F5F8FA\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                } else {
                                    if (obj.showCheck) {
                                        _body += "<tr onclick=\"$.__check('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else if (obj.showRadio) {
                                        _body += "<tr onclick=\"$.__checkRaido('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else {
                                        _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                    }
                                }
                                if (obj.showCheck) {
                                    _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__check()\" type='checkbox' id='" + data[i][obj.key] + "' value='" + data[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showRadio) {
                                    _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__check()\" name='jackson-data-rows-radio' type='radio' id='" + data[i][obj.key] + "' value='" + data[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showNumber) {
                                    _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align='center' width=\"40\" >";
                                    _body += (i + 1);
                                    _body += "</td>";
                                }
                                for (var j = 0; j < obj.rows.length; j++) {
                                    if (typeof obj.rows[j].formatter == "function") {
                                        if (obj.showCheck) {

                                            _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data[i][obj.rows[j].field], data[i]) + "</td>";
                                        }
                                        else {
                                            _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data[i][obj.rows[j].field], data[i]) + "</td>";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            if (data[i][obj.rows[j].field] != null && data[i][obj.rows[j].field].toString() != '') {
                                                _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data[i][obj.rows[j].field] + "</td>";
                                            }
                                            else {
                                                _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align=\"" + obj.rows[j].align + "\">&nbsp;</td>";
                                            }
                                        }
                                        else {
                                            if (data[i][obj.rows[j].field] != null && data[i][obj.rows[j].field].toString() != '') {
                                                _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data[i][obj.rows[j].field] + "</td>";
                                            }
                                            else {
                                                _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align=\"" + obj.rows[j].align + "\">&nbsp;</td>";
                                            }
                                        }
                                    }
                                }
                                _body += "</tr>";
                            }
                        }
                    }
                    else {//没有数据时
                        if (obj.rows != null && obj.rows.length > 0) {
                            _body += "<tr><td style=\"word-wrap: break-word;word-break:break-all; \" class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                        }
                    }
                },
                error: function () {//没有数据时
                    if (obj.rows != null && obj.rows.length > 0) {
                        _body += "<tr><td style=\"word-wrap: break-word;word-break:break-all; \" class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                    }
                }
            })
            return _body;
        },
        //POST访问数据方式(不翻页)
        __initDataPostNoPage: function (obj) {
            var string = $("#" + obj.form).serialize() + "&order=" + obj.order + "&t=" + Math.random();
            var _body = "";//数据内容
            var div = obj.label;
            $.ajax({
                type: "POST",
                url: obj.url,
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                async: false,
                data: string,
                success: function (data) {
                    obj.Data = data;
                    if (data == null) {
                        if (obj.rows != null && obj.rows.length > 0) {
                            _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                        }
                    }
                    else if (data.length > 0) {
                        if (obj.rows != null && obj.rows.length > 0) {
                            for (var i = 0; i < data.length; i++) {
                                var bgc = "";
                                for (var k = 0; k < obj.rows.length; k++) {
                                    if (typeof obj.rows[k].bgcolor == "function") {
                                        bgc = obj.rows[k].bgcolor(data.Rows[i][obj.rows[k].field], data.Rows[i]);
                                        if (bgc == undefined) {
                                            bgc = "";
                                        }
                                        break;
                                    } else {
                                        bgc = "";
                                    }
                                }
                                if (obj.doubleLine && (i + 1) % 2 == 0) {
                                    if (bgc != '') {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.__check('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.__checkRaido('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            _body += "<tr onclick=\"$.check('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#F5F8FA\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else if (obj.showRadio) {
                                            _body += "<tr onclick=\"$.checkRaido('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"#F5F8FA\" class=\"jackson-data-rows-datarow\">";
                                        }
                                        else {
                                            _body += "<tr bgcolor=\"#F5F8FA\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                        }
                                    }
                                } else {
                                    if (obj.showCheck) {
                                        _body += "<tr onclick=\"$.__check('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else if (obj.showRadio) {
                                        _body += "<tr onclick=\"$.__checkRaido('" + data[i][obj.key] + "','" + div + "');$.__OnGridDelegate('" + div + "','" + i + "')\" bgcolor=\"" + bgc + "\" class=\"jackson-data-rows-datarow\">";
                                    }
                                    else {
                                        _body += "<tr bgcolor=\"" + bgc + "\" onclick=\"$.__OnGridDelegate('" + div + "','" + i + "')\" class=\"jackson-data-rows-datarow\">";
                                    }
                                }
                                if (obj.showCheck) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__check()\" type='checkbox' id='" + data[i][obj.key] + "' value='" + data[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showRadio) {
                                    _body += "<td align='center' width=\"40\" >";
                                    _body += "<input onclick=\"$.__checkRaido()\" type='checkbox' id='" + data[i][obj.key] + "' value='" + data[i][obj.key] + "'>";
                                    _body += "</td>";
                                }
                                if (obj.showNumber) {
                                    _body += "<td style=\"word-wrap: break-word;word-break:break-all; \" align='center' width=\"40\" >";
                                    _body += (i + 1);
                                    _body += "</td>";
                                }
                                for (var j = 0; j < obj.rows.length; j++) {
                                    if (typeof obj.rows[j].formatter == "function") {
                                        if (obj.showCheck) {

                                            _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data[i][obj.rows[j].field], data[i]) + "</td>";
                                        }
                                        else {
                                            _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + obj.rows[j].formatter(data[i][obj.rows[j].field], data[i]) + "</td>";
                                        }
                                    }
                                    else {
                                        if (obj.showCheck) {
                                            if (data[i][obj.rows[j].field].toString() != '') {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data[i][obj.rows[j].field] + "</td>";
                                            }
                                            else {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;</td>";
                                            }
                                        }
                                        else {
                                            if (data[i][obj.rows[j].field].toString() != '') {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;&nbsp;&nbsp;&nbsp;" + data[i][obj.rows[j].field] + "</td>";
                                            }
                                            else {
                                                _body += "<td align=\"" + obj.rows[j].align + "\">&nbsp;</td>";
                                            }
                                        }
                                    }
                                }
                                _body += "</tr>";
                            }
                        }
                    }
                    else {//没有数据时
                        if (obj.rows != null && obj.rows.length > 0) {
                            _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                        }
                    }
                },
                error: function () {//没有数据时
                    if (obj.rows != null && obj.rows.length > 0) {
                        _body += "<tr><td class=\"jackson-data-rows-nodata\" align=\"center\" height='30' colspan=\"" + obj.rows.length + "\">没有数据</td></tr>";
                    }
                }
            })
            return _body;
        }
    });
    $.fn.Grid = function (options, callback) {
        var $element = $(this);
        var settings = {
            Data: "",//考虑摈弃
            name: $element.attr("id") + Math.random(),
            label: $element.attr("id"),   /*----------------------------------------------Dom标签ID********/
            checkValue: "",               /*----------------------------------------------选择的项目key值**/
            checkCount: 0,                /*----------------------------------------------选择的数量*******/
            order: "",                    /*----------------------------------------------排序方式*********/
            form: "form",                 /*----------------------------------------------请求数据表单*****/
            method: "POST",               /*----------------------------------------------请求数据模式*****/
            width: "100%",                /*----------------------------------------------宽度**/
            height: "auto",               /*----------------------------------------------高度**/
            waitMove: 0,//
            page: 1,                      /*----------------------------------------------页码**/
            pageSize: 20,                 /*----------------------------------------------页面大小**/
            showCheck: false,             /*----------------------------------------------是否显示复选框**/
            showOrder: false,             /*----------------------------------------------是否排序**/
            showRadio: false,             /*----------------------------------------------是否显示单选框**/
            doubleLine: true,            /*----------------------------------------------是否显示双行颜色**/
            pageDetail: false,            /*----------------------------------------------页码详情**/
            isPager: true,                /*----------------------------------------------是否分页模式**/
            TotalPage: 0,                 /*----------------------------------------------总页码数**/
            Total: 0,                     /*----------------------------------------------总记录数**/
            Currpage: 0,                  /*----------------------------------------------当前页码**/
            pagerCount: 10,               /*----------------------------------------------展示页码数**/
            rows: [],
            showNumber: true,             /*----------------------------------------------是否宣誓序号**/
            url: "",
            key: "",
            dataType: "json",                 /*----------------------------------------------请求格式**/
            callback:callback,
            onClick: function () { }     /*----------------------------------------------点击记录行激发的事件**/
        }
        var ops = $.extend(settings, options);
        $element.data('Grid', ops);
        var $this = ops;
        var div = $this.label;
        if ($this.isPager) {
            $.__goPage($this.page, $this.pageSize, $this.label);
        }
        else {
            $.__init(div);
        }
        if (typeof callback === "function") {
            callback($this);
        }
        $.fn.reLoad = function () {
            var $this = $(this);
            var obj = $this.data("Grid");
            if (obj.isPager) {
                $.__goPage("1", obj.pagesize,obj.label);
            }
            else {
                $.__init(obj.label);
            }
        }
        return $element;
    };
})(jQuery);
