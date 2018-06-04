<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsCatEdit.aspx.cs" Inherits="HQ.AdminWeb.Goods.GoodsCatEdit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>分类编辑</title>
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


    <script src="/3rdParty/js/common.js?201806041631xxx"></script>
    <script type="text/javascript">
        function _addSuccessCallback() {
            window.location.href = 'GoodsCatList.aspx';
        }
    </script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5><span></span>分类编辑</h5>

                        <div class="ibox-tools">
                            <a href="GoodsCatList.aspx">
                                <button type="button" class="btn btn-success">返回列表</button>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form id="Form1" method="post" class="form-horizontal" runat="server">
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">分类id:</label>
                                <div class="col-sm-10">
                                    <input id="txtCatId" type="text"
                                        class="form-control only-num" runat="server" />

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">所属分类:</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="dllParentId" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">分类名:</label>
                                <div class="col-sm-10">
                                    <input id="txtCatName" type="text"
                                        class="form-control input-sm" runat="server" />

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">分类图片:</label>
                                <div class="col-sm-10">
                                    <div class="input-group">
                                        <div id="uploadpicCover" style="width: 168px; height: 168px; border: 0px solid #ccc; float: left; background: #efefef; line-height: 168px; text-align: center; color: #ccc;">
                                            未上传                           
                                        </div>
                                        <div style="margin-left: 10px; float: left; line-height: 180px;">
                                            <a id="uploadpic">
                                                <button type="button" class="btn btn-info">上传</button></a>
                                            <span style="color: #ccc;">建议大小：168*168</span>
                                        </div>
                                        <input type="hidden" runat="server" id="hidCatIcon" />
                                    </div>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group form-inline">
                                <label class="col-sm-2 control-label">状态:</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
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
    })
    var isEidtMode = '<%=this.CurrentId>0?1:0%>';
    var editHandler = {
        _flgSubmitIng: false,
        init: function () {
            this.initUpload();
        },
        save: function () {
            if ($('#txtCatId').val().length == 0) {
                $('#txtCatId').focus();
                hot.tip.error("请输入分类id(来自第三方平台)");
                return false;
            }
            if ($('#txtCatName').val().length == 0) {
                $('#txtCatName').focus();
                hot.tip.error("请输入分类名");
                return false;
            }
            $('#btnSave').click();
        },
        initUpload: function () {
            this.previewImg();
            $('#uploadpic').click(function () {
                editHandler.selectPic();
            });
        },
        previewImg: function () {
            var _pic = $('#hidCatIcon').val();
            if (_pic != "") {
                $('#uploadpicCover').html('<img src="' + _pic + '" style="width:168px;height:168px;" />');
            }
        },
        selectPic: function () {
            hqUtils.showGallery(function (pic) {
                $('#hidCatIcon').val(pic);
                editHandler.previewImg();
            });
        }
    }
</script>
</html>
