<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="HQ.AdminWeb.SystemConfig.ModifyPassword" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>认证点编辑</title>
    <link href="../3rdParty/css/bootstrap.min.css" rel="stylesheet" />
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <!--checkbox-->
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"
        rel="stylesheet">

    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="/3rdParty/js/jquery.provincesCity.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>
    <script src="/3rdParty/js/common.js"></script>
    <script type="text/javascript">
        function updatePassCallback(flag,msg) {
            if (flag == 1) {
                hot.tip.success('修改成功');
            } else {
                hot.tip.error(msg);
            }
        }
    </script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5><span></span>密码修改</h5>
                    </div>
                    <div class="ibox-content">
                        <form id="Form1" method="post" class="form-horizontal" runat="server">
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">账号:</label>
                                <div class="col-sm-10">
                                    <input id="txtLoginName" type="text"
                                        class="form-control input-sm input-s " runat="server" disabled="disabled" />
                                </div>
                            </div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">原密码:</label>
                                <div class="col-sm-10">
                                    <input id="txtOldPass" type="text"
                                        class="form-control input-sm input-s " runat="server"/>
                                </div>
                            </div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">新密码:</label>
                                <div class="col-sm-10">
                                    <input id="txtNewPass" type="text"
                                        class="form-control input-sm input-s " runat="server" />
                                </div>
                            </div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">确认新密码:</label>
                                <div class="col-sm-10">
                                    <input id="txtNewPassConfirm" type="text"
                                        class="form-control input-sm input-s " runat="server"/>
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
<script>
    $(function () {
        editHandler.init();
    })

    var editHandler = {
        init: function () {
        },
        save: function () {
            if ($('#txtOldPass').val().length == 0) {
                hot.tip.error("请输入旧密码");
                return false;
            }
            if ($('#txtNewPass').val().length == 0) {
                hot.tip.error("请输入新密码");
                return false;
            }
            if ($('#txtNewPassConfirm').val().length == 0) {
                hot.tip.error("请输入确认新密码");
                return false;
            }
            if ($('#txtNewPass').val()!=$('#txtNewPassConfirm').val()) {
                hot.tip.error("两次新密码输入不一致");
                return false;
            }
            $('#btnSave').click();
        }
    }
</script>
</html>
