$.jUploader.setDefaults({
    cancelable: true,
    allowedExtensions: ['jpg', 'png'],
    messages: {
        upload: '上传',
        cancel: '取消',
        emptyFile: "{file} 为空，请选择一个文件.",
        invalidExtension: "{file} 后缀名不合法. 只有 {extensions} 是允许的.",
        onLeave: "文件正在上传，如果你现在离开，上传将会被取消。"
    }
});
var __upindex = null;
function __showTip(msg, icon) {
    if (__upindex != null) {
        layer.close(__upindex);
        __upindex = null;
    }
    __upindex = layer.load(2, {
        content: '<font style="color:#f96;">' + msg + '</font>',
        time: icon == 'success' ? 500 : 2000,
        shade: [0.4, '#393D49'],
        success: function (layero) {
            layero.css('padding-left', '30px');
            layero.find('.layui-layer-content').css({
                'padding-top': '40px',
                'width': '70px',
                'background-position-x': '16px'
            });
        }
    })
    //layer.load(msg);
}
var jBox = {
    tip: function (msg, icon) {
        __showTip(msg, icon);
    }
};

function uploadImageFile(buttonID, uploadPath, callback, retDomID, isThumbnail, tw, th) {
    if (typeof isThumbnail == 'undefined')
        isThumbnail = false;
    var p = "";
    if (isThumbnail)
        p = "&bt=1&tbw=" + tw + "&tbh=" + th;
    $.jUploader({
        button: buttonID, // 这里设置按钮id
        allowedExtensions: ['jpg', 'png'],
        action: '/UploadFileEidt.aspx?uploadtype=1&userid=' + uploadPath + '' + p, // 这里设置上传处理接口

        // 开始上传事件
        onUpload: function (fileName) {
            jBox.tip('正在上传 ' + fileName + ' ...', 'loading');
        },

        // 上传完成事件
        onComplete: function (fileName, response) {
            // response是json对象，格式可以按自己的意愿来定义，例子为： { success: true, fileUrl:'' }
            if (response.success) {
                jBox.tip('上传成功', 'success');
                var _domid = typeof (retDomID) != 'undefined' ? retDomID : 'txtReplyUrl1';

                $('#' + _domid).val(response.fileUrl);
                if (callback) {
                    callback(response.fileUrl);
                }
            } else {
                jBox.tip('上传失败', 'error');
            }
        },

        // 系统信息显示（例如后缀名不合法）
        showMessage: function (message) {
            jBox.tip(message, 'error');
        },

        // 取消上传事件
        onCancel: function (fileName) {
            jBox.tip(fileName + ' 上传取消。', 'info');
        }
    });
}

function uploadMusic(buttonID, uploadPath, callback) {
    $.jUploader({
        button: buttonID, // 这里设置按钮id
        allowedExtensions: ['mp3', 'wma'],
        action: '/UploadFileEidt.aspx?uploadtype=1&p=mucis&type=media&userid=' + uploadPath + '', // 这里设置上传处理接口

        // 开始上传事件
        onUpload: function (fileName) {
            jBox.tip('正在上传 ' + fileName + ' ...', 'loading');
        },

        // 上传完成事件
        onComplete: function (fileName, response) {
            // response是json对象，格式可以按自己的意愿来定义，例子为： { success: true, fileUrl:'' }
            if (response.success) {
                jBox.tip('上传成功', 'success');
                if (callback) {
                    callback(response.fileUrl);
                }
            } else {
                jBox.tip('上传失败', 'error');
            }
        },

        // 系统信息显示（例如后缀名不合法）
        showMessage: function (message) {
            jBox.tip(message, 'error');
        },

        // 取消上传事件
        onCancel: function (fileName) {
            jBox.tip(fileName + ' 上传取消。', 'info');
        }
    });
}






function uploadFile(buttonID, uploadPath, callback, exts) {
    ///<summary>
    ///文件上传，自定义类型
    ///</summary>
    ///<param name="buttonID" type="String">事件触发ID</param>
    ///<param name="uploadPath" type="String">上传文件所在文件夹名，一般都用用户id</param>
    ///<param name="callback" type="jQuery">回调函数function(v){}</param>
    ///<param name="exts" type="String">文件类型限制,默认支持['jpg'，'png','ico']</param>
    $.jUploader({
        button: buttonID, // 这里设置按钮id
        allowedExtensions: exts || ['jpg', 'png', 'ico'],
        action: '/UploadFileEidt.aspx?uploadtype=1&userid=' + uploadPath + '', // 这里设置上传处理接口

        // 开始上传事件
        onUpload: function (fileName) {
            jBox.tip('正在上传 ' + fileName + ' ...', 'loading');
        },

        // 上传完成事件
        onComplete: function (fileName, response) {
            // response是json对象，格式可以按自己的意愿来定义，例子为： { success: true, fileUrl:'' }
            if (response.success) {
                jBox.tip('上传成功', 'success');
                if (callback) {
                    callback(response.fileUrl);
                }
            } else {
                jBox.tip('上传失败', 'error');
            }
        },

        // 系统信息显示（例如后缀名不合法）
        showMessage: function (message) {
            jBox.tip(message, 'error');
        },

        // 取消上传事件
        onCancel: function (fileName) {
            jBox.tip(fileName + ' 上传取消。', 'info');
        }
    });
}