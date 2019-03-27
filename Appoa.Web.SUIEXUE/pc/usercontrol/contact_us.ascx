<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact_us.ascx.cs" Inherits="Appoa.Manage.pc.usercontrol.contact_us" %>
<div class="row4 fix">
    <div class="wp">
        <div class="tit-i">
            <h3>联系我们</h3>
            <h5><span>contact</span> US</h5>
        </div>
        <div class="contact-l" style="width: 80%">
            <ul class="ul-contact">
                <li class="li1">郑州市高新区梧桐街北斗云谷C25幢</li>
                <li class="li2">
                    <p>业务咨询&nbsp;&nbsp;高老师：<a href="tel:13588889999">13253565360</a>&nbsp;&nbsp;<a href="http://wpa.qq.com/msgrd?v=3&uin=1101281902&site=qq&menu=yes" target="_blank">QQ：1101281902</a></p>
                    <p>课程开发咨询&nbsp;&nbsp;郭老师：<a href="tel:13333700662">13333700662</a>&nbsp;&nbsp;<a href="http://wpa.qq.com/msgrd?v=3&uin=583949521&site=qq&menu=yes" target="_blank">QQ：583949521</a>&nbsp;&nbsp;王老师：<a href="tel:15138683572">15138683572</a>&nbsp;&nbsp;<a href="http://wpa.qq.com/msgrd?v=3&uin=459246997&site=qq&menu=yes" target="_blank">QQ：459246997</a></p>
                    <p>平台服务咨询&nbsp;&nbsp;张老师：<a href="tel:18638589968">18638589968</a>&nbsp;&nbsp;<a href="http://wpa.qq.com/msgrd?v=3&uin=1072200735&site=qq&menu=yes" target="_blank">QQ：1072200735</a></p>
                </li>
            </ul>
        </div>
    </div>
</div>
<div class="map">
    <div class="map-s">
        <a href="javascript:void(0);" class="btn"><em></em>点击展开地图</a>
    </div>
    <div class="map-pop">
        <a href="javascript:void(0);" class="btn-down"></a>
        <div class="map-bg1"></div>
        <div class="map-bg2"></div>
        <div id="map" class="map-i" style="width: 100%; height: 100%;"></div>
    </div>
</div>
<script type="text/javascript" src="skin/js/jquery.js"></script>
<script type="text/javascript" src="skin/js/ditu.js"></script>
<script>
    $('.map .btn').click(function () {
        $('.map-pop').show();
        $(this).parents('.map').addClass('map-big-i');
        var winW = $(window).width();
        var winH = $(window).height();
        console.log(winH);
        if (winW < 768) {
            $('.map-pop').height($(window).height() - 50 - 80);
            $('.map-big-i').height($(window).height() - 50 - 80);
            $("html, body").animate({
                scrollTop: $(document).height()
            }, 1000);
        } else {

            $('.map-pop').height($(window).height() - 344);
            $('.map-big-i').height($(window).height() - 344);
            $("html, body").animate({
                scrollTop: $(document).height()
            }, 1000);
        }
        initMap();
    })
    $('.map .btn-down').click(function () {
        $('.map-pop').hide();
        $(this).parents('.map').removeClass('map-big-i');
        $('.map').height('107');
    })
</script>
<script type="text/javascript">
    //创建和初始化地图函数：
    function initMap() {
        createMap(); //创建地图
        setMapEvent(); //设置地图事件
        addMapOverlay(); //向地图添加覆盖物
    }

    function createMap() {
        map = new BMap.Map("map");
        map.centerAndZoom(new BMap.Point(113.550266, 34.80842), 17); //106.575711,29.531776
    }

    function setMapEvent() {
        map.enableScrollWheelZoom();
        map.enableKeyboard();
        map.enableDragging();
        map.enableDoubleClickZoom()
    }

    function addClickHandler(target, window) {
        target.addEventListener("click", function () {
            target.openInfoWindow(window);
        });
    }

    function addMapOverlay() {
        var markers = [{
            content: "",
            title: "",
            imageOffset: {
                width: -46,
                height: -21
            },
            position: {
                lat: 32.083644,
                lng: 118.801382
            }
        }];
        for (var index = 0; index < markers.length; index++) {
            var point = new BMap.Point(markers[index].position.lng, markers[index].position.lat);
            var marker = new BMap.Marker(point, {
                icon: new BMap.Icon("http://api.map.baidu.com/lbsapi/createmap/images/icon.png", new BMap.Size(20, 25), {
                    imageOffset: new BMap.Size(markers[index].imageOffset.width, markers[index].imageOffset.height)
                })
            });
            var label = new BMap.Label(markers[index].title, {
                offset: new BMap.Size(25, 5)
            });
            var opts = {
                width: 200,
                title: markers[index].title,
                enableMessage: false
            };
            var infoWindow = new BMap.InfoWindow(markers[index].content, opts);
            marker.setLabel(label);
            addClickHandler(marker, infoWindow);
            map.addOverlay(marker);
        };
    }
    //向地图添加控件
    function addMapControl() {
        var scaleControl = new BMap.ScaleControl({
            anchor: BMAP_ANCHOR_BOTTOM_LEFT
        });
        scaleControl.setUnit(BMAP_UNIT_IMPERIAL);
        map.addControl(scaleControl);
        var navControl = new BMap.NavigationControl({
            anchor: BMAP_ANCHOR_BOTTOM_LEFT,
            type: 0
        });
        map.addControl(navControl);
        var overviewControl = new BMap.OverviewMapControl({
            anchor: BMAP_ANCHOR_BOTTOM_RIGHT,
            isOpen: true
        });
        map.addControl(overviewControl);
    }
    var map;
</script>
