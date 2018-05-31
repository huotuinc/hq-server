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
 2、修改gallery.html 里面的引用js和css路径,让其路径是可用状态;以下仅是例子,一般支付把Picture文件夹copy到项目工程中,里面的引用一般不需要重新引用:
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