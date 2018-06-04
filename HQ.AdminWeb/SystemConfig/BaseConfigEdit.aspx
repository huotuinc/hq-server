<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseConfigEdit.aspx.cs" Inherits="HQ.AdminWeb.SystemConfig.BaseConfigEdit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>基本配置</title>
    <link href="../3rdParty/css/bootstrap.min.css" rel="stylesheet" />
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <!--checkbox-->
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">

    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="/3rdParty/js/jquery.provincesCity.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>
    <script src="/3rdParty/js/common.js"></script>
    <script type="text/javascript">
        function _addSuccessCallback() {

        }
    </script>
</head>
<body class="gray-bg">
    <form id="Form1" method="post" class="form-horizontal" runat="server">
        <div class="wrapper wrapper-content animated fadeInRight">

            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5><span></span>基本设置</h5>
                        </div>
                        <div class="ibox-content">

                            <label>短信参数：</label>
                            <p style="height: 5px;"></p>

                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">provider:</label>
                                <div class="col-sm-10">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlSmsProvider" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Text="创蓝" Value="chuanglan|http://smssh1.253.com/msg/send/json"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">Account:</label>
                                <div class="col-sm-10">
                                    <input id="txtSmsAccount" type="text" class="form-control input-sm" runat="server" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">Password:</label>
                                <div class="col-sm-10">
                                    <input id="txtSmsPassword" type="text" class="form-control input-sm" runat="server" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <label>其他参数：</label>
                            <p style="height: 5px;"></p>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">主域名:</label>
                                <div class="col-sm-10">
                                    <input id="txtMainDomain" type="text" class="form-control input-sm" runat="server" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">微信AppId:</label>
                                <div class="col-sm-10">
                                    <input id="txtWxAppId" type="text" class="form-control input-sm" runat="server" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">微信AppSecret:</label>
                                <div class="col-sm-10">
                                    <input id="txtWxAppSecret" type="text" class="form-control input-sm" runat="server" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

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

                        </div>
                    </div>

                </div>

            </div>

        </div>
    </form>
</body>
<script>
    $(function () {
        editHandler.init();
    })

    var editHandler = {
        _flgSubmitIng: false,
        init: function () {
            this.previewQrcode();
            this.previewShareIcon();
        },
        save: function () {
            if ($('#txtMainDomain').val().length == 0) {
                hot.tip.error("请输入主域名");
                $('#txtMainDomain').focus();
                return false;
            }
            $('#btnSave').click();
        }
    }
</script>
</html>
