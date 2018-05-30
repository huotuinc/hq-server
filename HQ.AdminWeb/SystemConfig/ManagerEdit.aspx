<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerEdit.aspx.cs" Inherits="HQ.AdminWeb.SystemConfig.ManagerEdit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>操作员编辑</title>
    <link href="../3rdParty/css/bootstrap.min.css" rel="stylesheet" />
    <link href="http://resali.huobanplus.com/cdn/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/animate.min.css" rel="stylesheet">
    <link href="http://resali.huobanplus.com/cdn/hotui/css/style.min-1.0.8.css" rel="stylesheet">
    <!--checkbox-->
    <link href="http://resali.huobanplus.com/cdn/hotui/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"
        rel="stylesheet">

    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="/3rdParty/js/jquery.provincesCity.js?20180407"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.5/bootstrap.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/layer/3.1.0/layer.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-utils.js"></script>
    <script src="http://resali.huobanplus.com/cdn/hotui/js/v2/bootstrap.hot.extra-init.js"></script>

    <link href="../3rdParty/bootstrap/js/plugins/jedate/jedate.css" rel="stylesheet" />
    <script src="../3rdParty/bootstrap/js/plugins/jedate/jedate.js"></script>


    <script src="/3rdParty/js/common.js"></script>
    <script type="text/javascript">
        function _addSuccessCallback() {
            window.location.href = 'ManagerList.aspx';
        }
    </script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5><span></span>操作员编辑</h5>

                        <div class="ibox-tools">
                            <a href="ManagerList.aspx">
                                <button type="button" class="btn btn-success">返回列表</button>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form id="Form1" method="post" class="form-horizontal" runat="server">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">登录账号:</label>
                                <div class="col-sm-10">
                                    <input id="txtLoginName" type="text"
                                        class="form-control input-sm input-s " runat="server" />

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">登录密码:</label>
                                <div class="col-sm-10">
                                    <input id="txtLoginPassword" type="password"
                                        class="form-control input-sm input-s " runat="server" />

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">重复登录密码:</label>
                                <div class="col-sm-10">
                                    <input id="txtLoginPasswordConfirm" type="password"
                                        class="form-control input-sm input-s " />

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">菜单分配:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <button type="button" class="btn btn-info" id="btnSelectMenu">设置</button>
                                        <input type="hidden" id="hidAuthMenus" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">状态:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Text="启用" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="锁定" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group  form-inline">
                                <label class="col-sm-2 control-label">备注</label>
                                <div class="col-sm-10">
                                    <div class="input-group">
                                        <textarea id="txtIntro" type="text" class="form-control" style="width: 320px; height: 80px;" runat="server"></textarea>
                                    </div>
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
        menuSelector.init();
    })
    var isEidtMode = '<%=this.CurrentId>0?1:0%>';
    var editHandler = {
        _flgSubmitIng: false,
        init: function () {
        },
        save: function () {
            if ($('#txtLoginName').val().length == 0) {
                $('#txtLoginName').focus();
                hot.tip.error("请输入登录名");
                return false;
            }
            if ($('#txtLoginPassword').val().length == 0 && isEidtMode == '0') {
                hot.tip.error("请输入密码");
                return false;
            }
            if ($('#txtLoginPassword').val() != $('#txtLoginPasswordConfirm').val()) {
                hot.tip.error("两次密码输入不一致");
                return false;
            }
            $('#btnSave').click();
        }
    }

    function getModalAdapteHeight(flgBottomMenu) {
        var winHeight = $(window).height();
        var _offset = 20;
        var _areaHeight = winHeight - _offset - 30;
        var _ifrHeight = _areaHeight - 85;
        if (flgBottomMenu) {
            _ifrHeight -= 20;
        }
        return { offset: _offset, area: _areaHeight, iframe: _ifrHeight };
    }

    var menuSelector = {
        _modal: null,
        _current: null,
        init: function () {
            this._modal = new modal();
            var adapteHeight = getModalAdapteHeight(true);
            var content = '<iframe style="margin:-8px 0px 0px -10px;" id="ifrModal" width="350px" height="550px" frameborder="0" src="MenuAssign.aspx?rnd=' + Math.random() + '" />';
            this._modal.init('选择菜单', content, function () {
                menuSelector.selectComplete();
            }, { maxWidth: 1000, area: ['380px', '590px'], offset: adapteHeight.offset + 'px' });
            $('#btnSelectMenu').click(function () {
                menuSelector.showModal();
            });
        },
        showModal: function () {
            this._modal.show();
        },
        closeModal: function () {
            this._modal.hide();
        },
        selectComplete: function () {
            var ifrModal = $('#ifrModal').get(0);
            if (!ifrModal.contentWindow) {
                hot.tip.error('选择页面异常');
                return false;
            }
            var selected = ifrModal.contentWindow.getSelected();
            this.setMenusId(selected);
            this.closeModal();
        },
        setMenusId: function (ids) {
            $('#hidAuthMenus').val(ids);
        },
        getMenusId: function () {
            return $('#hidAuthMenus').val().split('|');
        }
    };
</script>
</html>
