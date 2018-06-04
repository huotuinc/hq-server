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
    }
};