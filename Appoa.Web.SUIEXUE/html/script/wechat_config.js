var ad = ''; var ts = ''; var ns = ''; var sa = '';
var sharedesc = '';
function getInfo() {
    if (isWechatBrowser()) {
        sendAjaxSetFuncAsync(false, { location: window.location.href }, '/tools/business_handler.ashx?action=GetWeChatInfo', function (result) {
            if (parseInt(result.code, 10) == 200) {
                var obj = result.data;
                ad = obj.appid;
                ts = obj.timestamp;
                ns = obj.noncestr;
                sa = obj.signature;
            } else {
                dialogMsg(result.message);
            }
        });

        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: ad, // 必填，公众号的唯一标识
            timestamp: ts, // 必填，生成签名的时间戳
            nonceStr: ns, // 必填，生成签名的随机串
            signature: sa,// 必填，签名，见附录1
            jsApiList: ['onMenuShareTimeline', 'onMenuShareAppMessage', 'onMenuShareQQ', 'onMenuShareWeibo', 'onMenuShareQZone', 'scanQRCode'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function () {
            var title = '梧桐花教育';
            var desc = sharedesc;
            var paramstr = '';
            var loca = window.location.href;
            if (islogin()) {
                if (loca.lastIndexOf('?') > 0) {
                    paramstr = '&recommend=' + getUserTree().code;
                } else {
                    paramstr = '?recommend=' + getUserTree().code;
                }
            } else {
                paramstr = '';
            }
            var link = loca + paramstr;
            var imgUrl = 'http://wth.51suiyixue.com/html/images/share_img.jpg';
            //获取“分享到朋友圈”按钮点击状态及自定义分享内容接口
            wx.onMenuShareTimeline({
                title: title, // 分享标题
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });

            //获取“分享给朋友”按钮点击状态及自定义分享内容接口
            wx.onMenuShareAppMessage({
                title: title, // 分享标题
                desc: desc, // 分享描述
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                type: 'link', // 分享类型,music、video或link，不填默认为link
                dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });

            //获取“分享到QQ”按钮点击状态及自定义分享内容接口
            wx.onMenuShareQQ({
                title: title, // 分享标题
                desc: desc, // 分享描述
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });

            //获取“分享到腾讯微博”按钮点击状态及自定义分享内容接口
            wx.onMenuShareWeibo({
                title: title, // 分享标题
                desc: desc, // 分享描述
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });

            //获取“分享到QQ空间”按钮点击状态及自定义分享内容接口
            wx.onMenuShareQZone({
                title: title, // 分享标题
                desc: desc, // 分享描述
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });
        })
    }
}

function scanQrcode() {
    if (isWechatBrowser()) {
        wx.scanQRCode({
            needResult: 1, // 默认为0，扫描结果由微信处理，1则直接返回扫描结果，
            scanType: ["qrCode"], // 可以指定扫二维码还是一维码，默认二者都有
            success: function (res) {
                window.location.href = res.resultStr; // 当needResult 为 1 时，扫码返回的结果
            }
        });
    }
}