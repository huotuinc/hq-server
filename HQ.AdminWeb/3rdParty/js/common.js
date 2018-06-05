function addSuccessCallback() {
    hot.loading.show();
    setTimeout(function () {
        hot.loading.close();
        hot.tip.success('添加成功...', function () {
            _addSuccessCallback();
        }, 800);
    }, 1000);
}

function _addSuccessCallback() {
    window.location.href = window.location.href;
}

function updateSuccessCallback() {
    hot.loading.show();
    setTimeout(function () {
        hot.loading.close();
        hot.tip.success('修改成功，正在刷新...', function () {
            _updateSuccessCallback();
        }, 700);
    }, 1000);
}

function _updateSuccessCallback() {
    window.location.href = window.location.href;
}

function showError(errinfo) {
    hot.tip.error(errinfo);
}


function showConfirm(content, callback) {
    layer.confirm(content, { title: '提醒', icon: 1, btn: ['确定', '取消'] }, function () {
        callback();
    });
}

/**
 * 助手方法
 * */
var hqUtils = {
    showConfirm: function (content, callback) {
        layer.confirm(content, { title: '提醒', icon: 1, btn: ['确定', '取消'] }, function () {
            callback();
        });
    },
    newTab: function (url, title) {
        if (top.newTab) {
            top.newTab(url, title);
            return;
        }
        window.location.href = url;
    },
    showGallery: function (selectCallback) {//显示图片库
        var host = window.location.host;
        if (host.indexOf('.') != -1) {
            host = host.substr(host.indexOf('.') + 1);
        }
        layer.open({
            type: 2,
            title: "图片库",
            shadeClose: true,
            shade: 0.8,
            closeBtn: 1,
            area: ['920px', '640px'],
            content: "/3rdParty/Widget/Picture/gallery.html?customerId=0&isMult=false&domain=" + host + "&t=1.2",
            end: function (index, layero) {
                var jsonStr = $("#js_cms_picture_value").val();
                var jsonObj = JSON.parse(jsonStr);
                selectCallback(jsonObj[0].bigPicUri);
            }
        });
    }
};