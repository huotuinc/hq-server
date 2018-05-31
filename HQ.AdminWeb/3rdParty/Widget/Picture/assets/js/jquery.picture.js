/**
 +-------------------------------------------------------------------
 * jQuery jPicture- 火图科技图片库插件新版
 +-------------------------------------------------------------------
 * @version 1.0.0
 * @since 2016/08/17
 * @author xhl <supper@9126.org> <http://www.9126.org/>
 +-------------------------------------------------------------------

 ======================================================== 使用说明 ================================================================
 1、使用该插件时需要调用该目录下的gallery.html页面资源,并且需要带上两个参数；以下使用layer.js弹出调用图片库方式例子如下：
         layer.open({
                type: 2,
                title: "图片库",
                shadeClose: true,
                shade: 0.8,
                closeBtn:1,
                area: ['920px', '640px'],
                content: "/3rdParty/Widget/Picture/gallery.html?customerId="+customerId+"&isMult=false",
                //btn:["确定"],
                end: function(index, layero){
                    var jsonStr=$("#js_cms_picture_value").val();
                    alert(jsonStr);
                }
        });
    1，content参数中是layer.js弹出请求的地址,该地址中需要两个参数
        a,customerId    ---->商户ID
        b,isMult        ---->是否可以选择多张图片
        c,uploaderUri   ---->图片上传数据服务配置,参数已经内置,只需要获得对应的参数即可并且调用mallapi 的上传图片api
          参数:images        --->图片列表json字符串
               customerId    -->商户号
               groupId       -->所属分组ID
        d,height: 0,//0表示自动,-1表示正方形
        e,width: 0,//0表示自动,-1表示正方形
    2,mallapi上传图片api接口:
        请求方式->POST
        请求地址->api.xxx.com/gallery/uploadImage 
        请求参数->images ->图片对象json系列化字符串,customerId->商户号，groupId->所属分组ID
 2、修改photo.html 里面的引用js和css路径,让其路径是可用状态;以下仅是例子:
    <link rel="stylesheet" href="http://resali.huobanplus.com/cdn/bootstrap/3.3.6/css/bootstrap.min.css">
    <link href="assets/libs/layer/skin/layer.css" rel="stylesheet" />
    <link href="assets/libs/JGrid/theme/Jackson_skin_gray.css" rel="stylesheet" />

    <script src="http://resali.huobanplus.com/cdn/jquery/2.2.4/jquery.min.js"></script>
    <script src="http://resali.huobanplus.com/cdn/bootstrap/3.3.6/bootstrap.min.js"></script>
    <script src="assets/libs/jquery.nicescroll.min.js"></script>
    <script src="assets/libs/arttemplate/template.js"></script>
    <script src="assets/libs/JGrid/jquery.JGrid.js"></script>
    <script src="assets/libs/layer/layer.js"></script>
    <script src="assets/libs/layer/extend/layer.ext.js"></script>
    <script src="assets/js/jquery.picture.js?t=1.0"></script>
    <script src="assets/libs/megapix-image.js"></script>
    <script src="assets/libs/jquery.jqueue.js"></script>
    <script src="assets/libs/zeroclip/ZeroClipboard.js"></script>
 
 ======================================================== 返回值说明 ================================================================
 返回值说明:
 该图库使用layer.js 弹出方式来体现,弹出窗口后选择一张图片或者多张图片,点击确认后,会把选中的值绑定到父窗口#js-photo-selectvalue 输入框中,没有会创建,有则修改里面的值
 弹出回调后只需要获得这个值即可,里面的值格式如下（标准的json格式,拿到值后需要转成json对象来处理选择的图片值）:
 [
   {
        "thumbPicUri":"/resource/images/photo/3447/20160323172012.png",
        "thumbPicUrl":"http://res.huobanj.cn/resource/images/photo/3447/20160323172012.png",
        "smallPicUri":"/resource/images/photo/3447/20160323172012.png",
        "smallPicUrl":"http://res.huobanj.cn/resource/images/photo/3447/20160323172012.png",
        "bigPicUri":"/resource/images/photo/3447/20160323172012.png",
        "bigPicUrl":"http://res.huobanj.cn/resource/images/photo/3447/20160323172012.png",
        "ID":3066
    },
   {
        "thumbPicUri":"/resource/images/photo/3447/20160323172012.png",
        "thumbPicUrl":"http://res.huobanj.cn/resource/images/photo/3447/20160323172012.png",
        "smallPicUri":"/resource/images/photo/3447/20160323172012.png",
        "smallPicUrl":"http://res.huobanj.cn/resource/images/photo/3447/20160323172012.png",
        "bigPicUri":"/resource/images/photo/3447/20160323172012.png",
        "bigPicUrl":"http://res.huobanj.cn/resource/images/photo/3447/20160323172012.png",
        "ID":3067
    }
 ]
 */
$.fn.extend({
    jPicture: function (options) {
        var $element = $(this);//自身Dom对象
        var self = this;
        var settings = {
            label: $element.attr("id"),//显示图片列表的id
            url: "http://api.devpdmall.com",//伙伴商城 mallAPI 根目录URI
            isMult: true,//是否可以选择多张图片
            customerId: "4471", //商户ID
            height: 0,//0表示自动,-1表示正方形
            width: 0,//0表示自动,-1表示正方形
            pageSize: "25",
            groupTemplate: "",//分组显示模版
            groupLabel: "",//分组显示标签ID
            photoTemplate:"",//显示图片库列表的模版
            array: []
        };
        var ops = $.extend(settings, options);
        $element.data('_picture', ops);
        self.init = function () {
            var $this = $(this).data('_picture');
            self.initGroupList();//加载分组列表信息
            self.initPhotoList();//加载图片库列表
            self.addFile();
            self.addSearch();
        };
        self.addSearch = function () {
            $("#js-button-search").click(function () {
                self.search();
            })
        }
        self.selectBind = function (option) {
            $(".js-picture-photo").unbind("click");
            var obj = $(".js-picture-photo");
            $.each(obj, function (item, dom) {
                $(dom).find(".image-box").click(function () {
                    var dataUrl = $(dom).data('url');
                    var thumbPicUri = $(dom).data('thumbpicuri');
                    var thumbPicUrl = $(dom).data('thumbpicurl');
                    var smallPicUri = $(dom).data('smallpicuri');
                    var smallPicUrl = $(dom).data('smallpicurl');
                    var bigPicUri = $(dom).data('bigpicuri');
                    var bigPicUrl = $(dom).data('bigpicurl');
                    var dataId = $(dom).data("id");
                    var imageSize = $(dom).data("size");
                    var imageObj = { size:imageSize, thumbPicUri: thumbPicUri, thumbPicUrl: thumbPicUrl, smallPicUri: smallPicUri, smallPicUrl: smallPicUrl, bigPicUri: bigPicUri, bigPicUrl: bigPicUrl, ID: dataId }
                    var width = imageSize.toString().substr(0, imageSize.toString().indexOf("x"));
                    var height = imageSize.toString().substr(imageSize.indexOf("x") + 1);
                    if (option.width > -1 || option.height > -1) {
                        if (option.width == -1 || option.height == -1) {
                            if (width != height) {
                                layer.msg("请选择正方形图片");
                                return;
                            }
                        } else {
                            if (option.width == 0) {
                                if (option.height > 0 && height != option.height) {
                                    layer.msg("请选择高度为" + option.height + "px的图片");
                                    return;
                                }
                            } else if (option.height == 0) {
                                if (option.width > 0 && width != option.width) {
                                    layer.msg("请选择宽度为" + option.width + "px的图片");
                                    return;
                                }
                            } else if (!(option.width == width && option.height == height)) {
                                layer.msg("请选择大小为" + option.width + "x" + option.height + "的图片");
                                return;
                            }
                        }
                    }
                    if (option.isMult) {
                        if (!$(dom).hasClass("image-checked")) {
                            pQueue.PutQueue(imageObj);
                            $(dom).addClass("image-checked");
                            //$(dom).find(".selected-style").css("display", "block");
                        } else {
                            pQueue.Delete(dataId);
                            $(dom).removeClass("image-checked");
                            //$(dom).find(".selected-style").css("display", "none");
                        }
                    } else {
                        $(".js-picture-photo ").removeClass("image-checked");
                        if (!$(dom).hasClass("image-checked")) {
                            pQueue.Empty();
                            pQueue.PutQueue(imageObj);
                            $(dom).addClass("image-checked");
                            //$(".picture-photo .selected-style").css("display", "none");
                            //$(dom).find(".selected-style").css("display", "block");
                        } else {
                            pQueue.PutQueue(imageObj);
                            $(dom).removeClass("image-checked");
                            //$(dom).find(".selected-style").css("display", "none");
                        }
                    }
                    //重新设置对象的array数据对象,用于后面获得
                    var $this = $element.data('_picture');
                    $this.array = pQueue.array;
                    $("#js-photo-selectvalue").val(JSON.stringify($this.array));
                    $element.data('_picture', ops);
                });
            });
        }
        self.addFile = function () {
            var $this = $element.data('_picture');
            $("#js-group-add").click(function () {
                layer.prompt({
                    title: '请输入分组名称',
                    formType: 0 //prompt风格，支持0-2
                }, function (name, index) {
                    var fileid = $("#js-picture-addFile").attr('data-fileid');
                    layer.close(index);
                    $.ajax({
                        type: "get",
                        dataType: "jsonp",
                        url: $this.url + '/gallery/addfile',//提交到一般处理程序请求数据
                        data: { customerId: $this.customerId, extenName: name, fileid: 0 },
                        success: function (data) {
                            if (data.code == 200) {
                                self.initGroupList();//加载分组列表信息
                            } else {
                                layer.msg(data.msg);
                            }
                        }
                    })
                });
            });
        },
        /*
        *@brief 加载分组列表
        */
        self.initGroupList = function () {
            var $this = $(this).data('_picture');
            $.ajax({
                type: "get",
                dataType: "jsonp",
                url: $this.url + '/gallery/GetGroupList',//提交到一般处理程序请求数据
                data: { customerId: $this.customerId, extenName: name, fileid: 0 },
                success: function (data) {
                    var _htmlTemplate = $this.groupTemplate;
                    if (data != null && data.code == 200) {
                        var render = template.compile(_htmlTemplate);
                        var _temHtml = render(data);
                        $("#" + $this.groupLabel).html(_temHtml)
                        self.searchByGroup();
                    } else {
                        layer.msg("加载分组信息失败");
                    }
                }
            })
        },
        /*
        *@brief 加载图片库列表
        */
        self.initPhotoList = function () {
            var $this = $(this).data('_picture');
            var grid = $("#"+$this.label).Grid({
                method: 'POST',//提交方式GET|POST
                showNumber: true,
                pageSize: ops.pageSize,
                pagerCount: 5,
                pageDetail: true,
                dataParam: {
                    customerId: $this.customerId,
                    groupId: $("#js-hot-group").attr("data-id"),//默认加载未分组
                    name: $("#js-keyword-name").val()//默认名称搜索为空字符串
                },
                dataType:"jsonp",
                url: $this.url + '/gallery/GetPhotoList?callback=?',//提交到一般处理程序请求数据
                isTemplate: true,            /*************************是否为模版方式***************/
                template: $this.photoTemplate,                  /*************************模版*************************/
                noneData: "<div style='height:100px;font-size:20px; line-height:100px; text-align:center;color:#cccccc;'>没有图片数据</div>",
                resolveTemplate: function (data,templates) {//第三方模版引擎解析方法(这里提供的是artTemplate模版引擎)
                    var templateHtml = templates;
                    var render = template.compile(templateHtml);
                    var _temHtml = render(data);
                    return _temHtml;
                }
            }, function () {
                self.selectBind($this);
            });
        },
        self.searchByGroup = function () {
            var obj = $(".js-ul-tooltip");
            obj.unbind("click");
            $.each(obj, function (item, dom) {
                $(dom).click(function () {
                    $(".js-ul-tooltip").removeClass("on");
                    var groupId = $(dom).data('id');
                    var groupName = $(dom).data("name");
                    $("#js-hot-group").html(groupName);
                    $("#js-hot-group").attr("data-id", groupId);
                    $("#js-hot-group").attr("data-name", groupName);

                    $(".js-batch-group-grouping").addClass("disabled");
                    $(".js-batch-group-remove").addClass("disabled");

                    if (groupId == 0) {
                        $(".js-change-group-name").addClass("disabled");
                        $(".js-remove-group").addClass("disabled");
                    } else {
                        $(".js-change-group-name").removeClass("disabled");
                        $(".js-remove-group").removeClass("disabled");
                    }
                    $("#js-select-all").attr("checked", false);
                    $(dom).addClass("on");
                    self.search();
                })
            })
        },
        self.search = function () {
            self.initPhotoList();
        },
        self.init();
        $.fn.RefreshByGroup = function () {
            self.initGroupList();
        }
        $.fn.RefreshByList = function () {
            self.initPhotoList();
        }
        var pQueue = {
            array: [],
            /**
             * @brief: 元素入队
             * @param: vElement元素列表,每个元素(必须包含ID唯一属性)
             * @return: 返回当前队列元素个数
             * @remark: 1.EnQueue方法参数可以多个
             * 2.参数为空时返回-1
             */
            PutQueue: function (vElement) {
                if (arguments == undefined && arguments.length == 0)
                    return -1; //元素入队
                for (var i = 0; i < arguments.length; i++) {
                    var _index = pQueue.FindIndex(arguments[i].ID);
                    if (_index == -1) {//不存在则新增
                        pQueue.array.push(arguments[i]);
                    }
                    else {//存在则修改
                        pQueue.PatchQueue(arguments[i]);
                    }
                }
                return pQueue.array.length;
            },
            /**
             *@brief:根据队列唯一ID来修改该队列元素信息
             *@param: vElement元素(必须包含ID唯一属性)
             *@return:返回队列修改后的元素
             */
            PatchQueue: function (vElement) {
                if (vElement==null||vElement.length == 0 || vElement.ID.length==0)
                    return null;
                else {
                    var Index = pQueue.FindIndex(vElement.ID);
                    return pQueue.array[Index];
                }
            },
            /**
             *@brief 队列物理删除
             */
            Delete: function (id) {
                for (var i = 0; i < pQueue.array.length; i++) {
                    if (pQueue.array[i] != null && pQueue.array[i].length != 0 && pQueue.array[i].ID.length != 0) {
                        if (pQueue.array[i].ID == id) {
                            pQueue.array.splice(i, 1);
                        }
                    }
                }
            },
            /**
             *@brief:根据队列唯一ID来修改该队列元素信息
             *@param: id(队列元素的唯一标识)
             *@return:返回队列修改后的元素
             */
            FindIndex: function (id) {
                for (var i = 0; i < pQueue.array.length; i++) {
                    if (pQueue.array[i] != null && pQueue.array[i].length != 0 && pQueue.array[i].ID.length != 0) {
                        if (pQueue.array[i].ID == id) {
                            return i;
                        }
                    }
                }
                return -1;
            },
            /**
             * @brief: 将队列置空
             */
            Empty: function () {
                pQueue.array.length = 0;
            },
        }
        return $element;
    }
});