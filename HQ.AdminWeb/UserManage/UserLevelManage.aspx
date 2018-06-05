<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLevelManage.aspx.cs" Inherits="HQ.AdminWeb.UserManage.UserLevelManage" %>

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
        <!--list-->
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins m-b-none">
                    <div class="ibox-content p-xxs no-top-border">
                        <div class="panel-body">
                            <table class="table table-bordered table-hover table-center report-table">
                                <thead>
                                    <tr>
                                        <td colspan="6" style="text-align: right;">
                                            <input id="AddLevel" class="btn-group" type="button" value="添加等级" /></td>
                                    </tr>
                                    <tr>
                                        <th>会员等级</th>
                                        <th>等级名称</th>
                                        <th>升级条件</th>
                                        <th>等级描述</th>
                                        <th>升级模式</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody id="js-LevelBody">
                                    <tr>
                                        <td>等级1
                                        </td>
                                        <td>普通会员
                                        </td>
                                        <td>升级条件
                                        </td>
                                        <td>普通会员
                                        </td>
                                        <td>升级模式
                                        </td>
                                        <td>
                                            <a class="btn btn-myGreen btn-xs" href="javascript:void(0);" data-id="0">编辑</a>&nbsp;&nbsp;
                                            <a class="btn btn-myGreen btn-xs" href="javascript:void(0);" data-id="0">删除</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="js-addlevel" style="display: none;">
        <div class="ibox-content">
            <input id="LevelId" type="hidden" value="0" />
            <div class="form-group form-inline">
                <label class="col-sm-2 control-label" style="width: 100px; text-align: right;">添加类型:</label>
                <div>
                    <input name="LevelType" type="radio" class="radio" value="0" />普通会员&nbsp;
                    <input name="LevelType" type="radio" class="radio" value="1" />代理商&nbsp;
                    <input name="LevelType" type="radio" class="radio" value="2" />运营商&nbsp;
                    <input name="LevelType" type="radio" class="radio" value="3" />军团长&nbsp;
                    <input name="LevelType" type="radio" class="radio" value="4" />分公司
                </div>
            </div>
            <div class="hr-line-dashed" style="margin: 8px 0px;"></div>
            <div class="form-group form-inline">
                <label class="col-sm-2 control-label" style="width: 100px; text-align: right;">等级名称:</label>
                <div>
                    <input id="LevelName" class="form-control input-sm" type="text" style="width: 300px;" />
                </div>
            </div>

            <div class="hr-line-dashed" style="margin: 8px 0px;"></div>
            <div data-class="buddy" class="form-group form-inline">
                <label class="col-sm-2 control-label" style="width: 100px; text-align: right;">升级条件:</label>
                <div>
                    <p data-class="user"><span>平台注册用户</span></p>
                    <p data-class="company"><span>系统开通</span></p>
                    <p data-class="belonguser">直接下线(不限等级)>=<input id="BelongOneNum" style="border: 0px; border-bottom: #000000 1px solid; text-align: center; width: 80px;" type="text" />人</p>
                    <p data-class="belongbuddy" style="padding-left: 100px;">直接下线代理商>=<input id="BuddyBelongOne" style="border: 0px; border-bottom: #000000 1px solid; text-align: center; width: 80px;" type="text" />人,</p>
                    <p data-class="belongbuddy" style="padding-left: 100px;">且下下线代理商>=<input id="BuddyBelongTwo" style="border: 0px; border-bottom: #000000 1px solid; text-align: center; width: 80px;" type="text" />人</p>
                    <p data-class="belongbuddy" style="padding-left: 100px;"><span style="font-size: 25px; font-weight: bolder; color: red;">或</span></p>
                    <p data-class="belongbuddy" style="padding-left: 100px;">直接下线>=<input id="BelongOneOrderNum" style="border: 0px; border-bottom: #000000 1px solid; text-align: center; width: 80px;" type="text" />人下单</p>

                </div>
            </div>
            <div data-class="buddy" class="hr-line-dashed" style="margin: 8px 0px;"></div>
            <div class="form-group form-inline">
                <label class="col-sm-2 control-label" style="width: 100px; text-align: right;">升级模式:</label>
                <div>
                    <input name="LevelModel" class="radio" type="radio" value="0" />手动&nbsp;
                    <input name="LevelModel" class="radio" type="radio" value="1" />自动
                </div>
            </div>
            <div class="hr-line-dashed" style="margin: 8px 0px;"></div>
            <div class="form-group  form-inline">
                <label class="col-sm-2 control-label" style="width: 100px; text-align: right;">备注:</label>
                <div>
                    <textarea id="txtIntro" class="form-control" style="height: 80px; width: 300px;"></textarea>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-4 col-sm-offset-2" style="padding-left: 25px;">
                    <input id="saveLevel" class="btn btn-primary btn-success" type="button" value="保 存" />
                </div>
            </div>
        </div>
    </div>

    <!--基础框架js-->
    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/content.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils-0.2.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>
</body>
<script type="text/javascript">
    var levelListJson = "";
    $(function () {
        init();

        $("#AddLevel").click(function () {
            $("input[name='LevelModel'][value='0']").attr("checked", "checked");
            $("input[name='LevelType'][value='0']").attr("checked", "checked");
            $("p[data-class=user]").show();
            $("p[data-class=company]").hide();
            $("p[data-class=belonguser]").hide();
            $("p[data-class=belongbuddy]").hide();

            var layheight = '400px';
            layer.open({
                title: '添加等级',
                type: 1,
                skin: 'layui-layer-demo', //样式类名
                closeBtn: 0, //不显示关闭按钮
                anim: 2,
                area: ['500px', layheight], //宽高
                shadeClose: true, //开启遮罩关闭
                content: $(".js-addlevel")
            });
        });

        $("input[name='LevelType']").click(function () {
            if (this.checked) {
                if ($(this).val() == "0") {
                    $("p[data-class=user]").show();
                    $("p[data-class=company]").hide();
                    $("p[data-class=belonguser]").hide();
                    $("p[data-class=belongbuddy]").hide();
                    $("#layui-layer1").css("height", "400px");
                    $(".layui-layer-content").css("height", "368px");
                }
                else if ($(this).val() == "1") {
                    $("p[data-class=user]").hide();
                    $("p[data-class=company]").hide();
                    $("p[data-class=belonguser]").show();
                    $("p[data-class=belongbuddy]").hide();
                    $("#layui-layer1").css("height", "400px");
                    $(".layui-layer-content").css("height", "368px");
                }
                else if ($(this).val() == "2") {
                    $("p[data-class=user]").hide();
                    $("p[data-class=company]").hide();
                    $("p[data-class=belonguser]").hide();
                    $("p[data-class=belongbuddy]").show();
                    $("#layui-layer1").css("height", "500px");
                    $(".layui-layer-content").css("height", "468px");
                }
                else if ($(this).val() == "3" || $(this).val() == "4") {
                    $("p[data-class=user]").hide();
                    $("p[data-class=company]").show();
                    $("p[data-class=belonguser]").hide();
                    $("p[data-class=belongbuddy]").hide();
                    $("#layui-layer1").css("height", "400px");
                    $(".layui-layer-content").css("height", "368px");
                }
            }

        });

        $("#saveLevel").click(function () {
            var levelType = $("input[name='LevelType']:Checked").val();
            var LevelName = $("#LevelName").val();
            var belongOneNum = $("#BelongOneNum").val();
            var buddyBelongOne = $("#BuddyBelongOne").val();
            var buddyBelongTwo = $("#BuddyBelongTwo").val();
            var belongOneOrderNum = $("#BelongOneOrderNum").val();
            var levelModel = $("input[name='LevelModel']:Checked").val();
            var levelMemo = $("#txtIntro").val();
            var levelId = $("#LevelId").val();

            setTimeout(function () {
                var requestData = {
                    action: 'editlevel',
                    levelid: levelId,
                    leveltype: levelType,
                    levelname: LevelName,
                    onenum: belongOneNum,
                    belongone: buddyBelongOne,
                    belongtwo: buddyBelongTwo,
                    ordernum: belongOneOrderNum,
                    levelmodel: levelModel,
                    levelmemo: levelMemo
                }

                hot.ajax("/Handler/UserLevelHandler.ashx", requestData, function (json) {
                    if (json.code == 1) {
                        layer.msg(json.msg);
                        setTimeout(function () {
                            layer.closeAll();
                            location.href = location.href;
                        }, 1000);
                    } else {
                        layer.msg(json.msg);
                        setTimeout(function () {
                            layer.closeAll();
                            location.href = location.href;
                        }, 1000);
                    }
                }, function () { }, "post", 400);
            }, 300);
        });
    });

    function init() {
        setTimeout(function () {
            var requestData = {
                action: 'getlevel'
            }

            hot.ajax("/Handler/UserLevelHandler.ashx", requestData, function (json) {
                if (json.code == 200) {
                    levelListJson = json.list;
                    var html = "";
                    $("#js-LevelBody").html(html);
                    for (var i = 0; i < json.list.length; i++) {
                        var row = json.list[i];
                        var conditionHtml = row.UpgradeCondition[0].ConditionDecs;
                        if (row.LevelType == "1" || row.LevelType == "2") {
                            conditionHtml = "";
                            for (var j = 0; j < row.UpgradeCondition.length; j++) {
                                var Uprow = row.UpgradeCondition[j];
                                if (Uprow.ConditionType == "0") {
                                    if (conditionHtml == "") {
                                        conditionHtml = Uprow.ConditionDecs.replace('{Value}', Uprow.ConditionValue);
                                    }
                                    else {
                                        conditionHtml += ",且" + Uprow.ConditionDecs.replace('{Value}', Uprow.ConditionValue);
                                    }
                                }
                                else {
                                    conditionHtml += "<br /><span style=\"color:red;\">或</span><br />" + Uprow.ConditionDecs.replace('{Value}', Uprow.ConditionValue);
                                }
                            }
                        }
                        var modelHtml = row.LevelModel == "1" ? "自动" : "手动";
                        html += '<tr><td>等级' + (i + 1) + '</td><td>' + row.LevelName + '</td><td>' + conditionHtml + '</td><td>' + row.Remark + '</td><td>' + modelHtml + '</td>'
                            + '<td><a class="btn btn-myGreen btn-xs editlevel" href="javascript:void(0);" data-id="' + row.LevelId + '">编辑</a>&nbsp;&nbsp;'
                            + '<a class="btn btn-myGreen btn-xs dellevel" href="javascript:void(0);" data-id="' + row.LevelId + '">删除</a></td></tr>';
                    }

                    $("#js-LevelBody").html(html);
                    $(".editlevel").click(function () {
                        var levelId = $(this).attr("data-id");
                        for (var i = 0; i < levelListJson.length; i++) {
                            if (levelListJson[i].LevelId == levelId) {
                                var levelType = levelListJson[i].LevelType;
                                console.log(levelType);
                                var layheight = "400px";

                                if (levelType == "0") {
                                    $("p[data-class=user]").show();
                                    $("p[data-class=company]").hide();
                                    $("p[data-class=belonguser]").hide();
                                    $("p[data-class=belongbuddy]").hide();
                                }
                                else if (levelType == "1") {
                                    $("p[data-class=user]").hide();
                                    $("p[data-class=company]").hide();
                                    $("p[data-class=belonguser]").show();
                                    $("p[data-class=belongbuddy]").hide();
                                    for (var j = 0; j < levelListJson[i].UpgradeCondition.length; j++) {
                                        var Uprow = levelListJson[i].UpgradeCondition[j];
                                        if (Uprow.ConditionKey == "BelongOneNum") {
                                            $("#BelongOneNum").val(Uprow.ConditionValue);
                                        }
                                    }
                                }
                                else if (levelType == "2") {
                                    $("p[data-class=user]").hide();
                                    $("p[data-class=company]").hide();
                                    $("p[data-class=belonguser]").hide();
                                    $("p[data-class=belongbuddy]").show();

                                    for (var j = 0; j < levelListJson[i].UpgradeCondition.length; j++) {
                                        var Uprow = levelListJson[i].UpgradeCondition[j];
                                        if (Uprow.ConditionKey == "BuddyBelongOne") {
                                            $("#BuddyBelongOne").val(Uprow.ConditionValue);
                                        }
                                        else if (Uprow.ConditionKey == "BuddyBelongTwo") {
                                            $("#BuddyBelongTwo").val(Uprow.ConditionValue);
                                        }
                                        else if (Uprow.ConditionKey == "BelongOneOrderNum") {
                                            $("#BelongOneOrderNum").val(Uprow.ConditionValue);
                                        }
                                    }
                                    layheight = "500px";
                                }
                                else if (levelType == "3" || levelType == "4") {
                                    $("p[data-class=user]").hide();
                                    $("p[data-class=company]").show();
                                    $("p[data-class=belonguser]").hide();
                                    $("p[data-class=belongbuddy]").hide();
                                }

                                $("#LevelName").val(levelListJson[i].LevelName);
                                $("#txtIntro").val(levelListJson[i].Remark);
                                $("#LevelId").val(levelListJson[i].LevelId);
                                $("input[name='LevelModel'][value='" + levelListJson[i].LevelModel + "']").attr("checked", "checked");
                                $("input[name='LevelType'][value='" + levelType + "']").attr("checked", "checked");

                                layer.open({
                                    title: '添加等级',
                                    type: 1,
                                    skin: 'layui-layer-demo', //样式类名
                                    closeBtn: 0, //不显示关闭按钮
                                    anim: 2,
                                    area: ['500px', layheight], //宽高
                                    shadeClose: true, //开启遮罩关闭
                                    content: $(".js-addlevel")
                                });
                            }
                        }
                    });

                    $(".dellevel").click(function () {
                        var levelId = $(this).attr("data-id");
                        layer.confirm('您确定要删除该等级？', {
                            btn: ['确定', '再想想'] //按钮
                        }, function () {
                            var requestData = {
                                action: "dellevel",
                                levelid: levelId
                            }
                            hot.ajax("/Handler/UserLevelHandler.ashx", requestData, function (data) {
                                if (data.code == 1) {
                                    layer.msg(data.msg);
                                    setTimeout(function () {
                                        layer.closeAll();
                                        location.href = location.href;
                                    }, 1000);

                                } else {
                                    layer.msg(data.msg);
                                    setTimeout(function () {
                                        layer.closeAll();
                                        location.href = location.href;
                                    }, 1000);
                                }
                            }, function () {
                            }, "post", 100);
                        });      
                    });
                } else {
                    layer.msg(json.msg);
                    setTimeout(function () {
                        location.href = location.href;
                    }, 2000);
                }
            }, function () { }, "post", 400);
        }, 300);
    }

</script>
</html>
