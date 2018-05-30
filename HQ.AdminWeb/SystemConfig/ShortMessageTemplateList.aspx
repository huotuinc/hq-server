<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortMessageTemplateList.aspx.cs" Inherits="HQ.AdminWeb.SystemConfig.ShortMessageTemplateList" %>

<!DOCTYPE html>
<html xmlns:th="http://www.thymeleaf.org">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>短信模板</title>
    <%--<link href="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">--%>
    <link href="../3rdParty/css/bootstrap.min.css" rel="stylesheet" />
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/datetimepick/daterangepicker.css" rel="stylesheet" />
    <link href="/3rdParty/css/common.css" rel="stylesheet" />
    <script src="../3rdParty/js/common.js"></script>
    
    <!--基础框架js-->
    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/content.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <!--日期选择-->
    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/datetimepick/moment.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/plugins/datetimepick/daterangepicker.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils-0.2.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>


    <style type="text/css">
        .defaultTag {
            font-size: 12px;
            margin: 5px 10px 5px 0px;
            height: 28px;
        }
    </style>
    <script type="text/javascript">
        function _addSuccessCallback() {
            window.location.href = 'SmsTemplateList.aspx';
        }
    </script>
</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight tooltip-demo">
        <div id="pnlList" runat="server">
        <form role="form" id="searchForm" class="search-panel" method="get">
            <div class="row">
                <div class="col-lg-12">
                    <div class="ibox">
                        <div class="ibox-content">
                            <div class="form-inline">
                                <a href="ShortMessageTemplateList.aspx?action=add" class="btn btn-success btn-sm">新增短信模板</a>
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
                                        <th>发送场景</th>
                                        <th>是否启用</th>
                                        <th>模板</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1%></td>
                                                <td><%#(HQ.Core.Enum.HQEnums.SmsSceneOptions)Convert.ToInt32(Eval("SceneType")) %>
                                                </td>
                                                <td><%#Eval("Status").ToString()=="1"?"<span style='color:green;'>有效</span>":"<span style='color:red;'>禁用</span>" %></td>
                                                <td><%#Eval("Template") %></td>
                                                </td>
                                                <td>
                                                    <a class="btn btn-myGreen btn-xs" href="?id=<%#Eval("id") %>">编辑</a>
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

        <!--detail-->
        <div class="row" id="pnlEdit" runat="server">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5><span></span>短信模板编辑</h5>
                        <div class="ibox-tools">
                            <a href="ShortMessageTemplateList.aspx">
                                <button type="button" class="btn btn-success">返回列表</button>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form id="Form1" method="post" class="form-horizontal" runat="server">
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">发送场景:</label>
                                <div class="col-sm-10">
                                    <!--SceneType-->
                                    <asp:DropDownList ID="dllSceneType" runat="server" OnSelectedIndexChanged="dllSceneType_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm">
                                        <asp:ListItem Text="请选择" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">状态:</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="不启用" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">可用标签:</label>
                                <div class="col-sm-10">
                                    <p class="form-control-static">
                                        <%
                                            foreach (System.Collections.Generic.KeyValuePair<string, string> kp in this.SenceMsgDataPropertys)
                                            {
                                                Response.Write(string.Format("<span class=\"form-control cursor-point defaultTag\"><font style='color:blue;'>{0}</font>&nbsp;&nbsp;<font style='color:#ccc;'>({1})</font></span>",
                                                    "{" + kp.Key + "}", kp.Value));
                                            }
                                        %>
                                    </p>
                                </div>
                            </div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">模板:</label>
                                <div class="col-sm-10">
                                    <textarea id="txtTemplate"
                                        class="form-control input-sm" style="width:350px;height:120px;" runat="server"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <button id="save" onclick="editHandler.save()" class="btn btn-primary btn-success" type="button">
                                        保 存
                                    </button>
                                    <div style="display: none;">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>

        </div>
    </div>

</body>
</html>

<script>
    $(function () {
        editHandler.init();
    })

    var editHandler = {
        init: function () {
        },
        save: function () {
            if ($('#dllSceneType').val()=='-1') {
                hot.tip.error("场景未选择");
                return false;
            }
            if ($('#txtTemplate').val().length == 0) {
                hot.tip.error("内容未输入");
                return false;
            }
            $('#btnSave').click();
        }
    }
</script>
