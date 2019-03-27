/**设置本地存储值**/
function setStorage(key, val) {
    localStorage.setItem(key, val);
}

/**获取本地存储值**/
function getStorage(key) {
    var val = localStorage.getItem(key);
    return val;
}

/**删除本地存储值**/
function delStorage(key) {
    localStorage.removeItem(key);
}

if (!sessionStorage.getItem('recommend') || sessionStorage.getItem('recommend') == '0' || sessionStorage.getItem('recommend') == '') {
    sessionStorage.setItem('recommend', getUrlParam('recommend') || '0');
}


/**去登录**/
function gotologin() {
    setStorage('backurl', window.location.href);
    window.location.href = 'login.html';
}

/**登录后回跳**/
function gotoback() {
    var backurl = getStorage('backurl');
    if (backurl) {
        window.location.href = backurl;
    } else {
        window.location.href = 'index.html';
    }
    //window.location.href = 'index.html';
}

/**是否登录**/
function islogin() {
    //    var userExpiry = getStorage("userExpiry");
    //    if (userExpiry) {
    //        var exp = new Date(userExpiry);
    //        var dt = new Date();
    //        var timespan = dt.getTime() - exp.getTime();

    //        if (0 <= timespan && timespan < 7200000) {
    var enInfo = getStorage("userInfo");
    if (enInfo) {
        var userInfo = JSON.parse(decodeURIComponent(enInfo));

        if (userInfo && userInfo.id > 0) {
            return userInfo;
        } else {
            return null;
        }
    }
    else {
        return null;
    }
    //        }
    //        else if (timespan >= 7200000) {
    //            localStorage.removeItem("userInfo");
    //            localStorage.setItem("userExpiry", dt);
    //            return null;
    //        }
    //    } else {
    //        return null;
    //    }
}

/**获取用户关系树**/
function getUserTree() {
    var enTree = getStorage("userTree");
    if (enTree) {
        var userTree = JSON.parse(decodeURIComponent(enTree));

        if (userTree && userTree.id > 0) {
            return userTree;
        } else {
            return null;
        }
    }
    else {
        return null;
    }
}

/**获取用户认证信息**/
function getUserOAuths() {
    var userOAuths = getStorage("userOAuths");
    if (userOAuths) {

        var userOAuths = decodeURIComponent(userOAuths);
        if (userOAuths && userOAuths != "") {
            userOAuths = JSON.parse(userOAuths);
            if (userOAuths != null && userOAuths.id > 0) {
                return userOAuths;
            } else {
                return null;
            }
        } else {
            return null;
        }
    }
    else {
        return null;
    }
}

/**滚动条监听**/
function scrollLoad() {
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop(); //滚动条距离顶部的高度
        var scrollHeight = $(document).height(); //当前页面的总高度
        var windowHeight = $(this).height(); //当前可视的页面高度

        if (scrollHeight != windowHeight) {
            //滚动条在顶部
            if (scrollTop <= 0) {
                pageIndex = 1;
                getData();
            }

            //距离顶部+当前高度 >=文档总高度 即代表滑动到底部
            if (scrollTop + windowHeight >= scrollHeight) {
                pageIndex++;
                getData();
            }
        }
    });
}

/**格式化手机号**/
function formatPhone(phone) {
    if (phone.length == 11) {
        var start = phone.substr(0, 3);
        var end = phone.substr(7, 4);
        return start + "****" + end;
    } else {
        return "";
    }
}

/**格式化日期**/
function formatData(dataStr, symbol) {
    if (dataStr) {
        dataStr = dataStr.toString();
        dataStr = dataStr.substr(0, 10);
        dataStr = dataStr.replace(/\//g, symbol);
    }
    return dataStr;
}

/**只许输入数字**/
function inputnumbers(obj) {
    obj.value = obj.value.replace(/\D/g, '');
}

//扩展Number类型，可以直接格式化成货币格式
//参数：保留小数位数，货币符号，整数部分千位分隔符，小数分隔符
//默认格式 (2, "￥", ",", ".")
Number.prototype.formatMoney = function (places, symbol, thousand, decimal) {
    places = !isNaN(places = Math.abs(places)) ? places : 2;
    symbol = symbol !== undefined ? symbol : "￥";
    thousand = thousand || ",";
    decimal = decimal || ".";
    var number = this,
		negative = number < 0 ? "-" : "",
		i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
		j = (j = i.length) > 3 ? j % 3 : 0;
    return symbol + negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "");
};

/**弹出消息框**/
function dialogMsg(contents) {
    layer.open({
        content: contents,
        btn: '我知道了',
        shadeClose: false,
        yes: function () {
            layer.closeAll();
        }
    });
}

/**弹出消息框(跳页)**/
function dialogMsgUrl(contents, url) {
    layer.open({
        content: contents,
        btn: ['我知道了'],
        shadeClose: false,
        yes: function () {
            window.location.href = url;
        }
    });
}

/**弹出消息框(回调函数)**/
function dialogMsgFun(contents, funStr) {
    layer.open({
        content: contents,
        btn: ['我知道了'],
        shadeClose: false,
        yes: function () {
            funStr();
        }
    });
}

/**弹出询问框(回调函数)**/
function dialogConfirmFun(contents, funStr) {
    layer.open({
        content: contents,
        btn: ['确定', '取消'],
        shadeClose: false,
        yes: function () {
            funStr();
        },
        no: function () {
            layer.closeAll();
        }
    });
}

/**弹出询问框(回调函数)(自定义标题按钮)**/
function dialogConfirmFunCustom(contents, yesStr, noStr, yesfun, nofun) {
    layer.open({
        content: contents,
        btn: [yesStr, noStr],
        shadeClose: false,
        yes: function () {
            yesfun();
        },
        no: function () {
            nofun();
        }
    });
}

/**弹出2秒消失的提示**/
function dialogTips(contents) {
    layer.open({
        content: contents,
        skin: 'msg',
        time: 2 //2秒后自动关闭
    });
}

/**弹出自定义秒数消失的提示**/
function dialogTipsTime(contents, time) {
    layer.open({
        content: contents,
        skin: 'msg',
        time: time //time秒后自动关闭
    });
}

/**弹出loading层(可带文字)**/
function dialogLoadingText(contents) {
    if (contents && contents != '') {
        layer.open({
            type: 2,
            shadeClose: false,
            content: contents
        });
    } else {
        layer.open({
            type: 2,
            shadeClose: false
        });
    }
}

/**弹出页面层**/
function dialogHtml(htmls) {
    if (htmls && htmls != '') {
        layer.open({
            type: 1,
            content: htmls,
            anim: 'up',
            style: 'position:fixed; left:0;top:0; width: 100%; height: 100%; padding:10px 0; border:none;'
        });
        return true;
    } else {
        return false;
    }
}

/**获取url中的参数**/
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg); //匹配目标参数
    if (r != null) return decodeURI(r[2]);
    return null; //返回参数值
}

/**是否是微信浏览器**/
function isWechatBrowser() {
    var ua = navigator.userAgent.toLowerCase();

    if (ua.match(/MicroMessenger/i) == "micromessenger") {
        return true;
    } else {
        return false;
    }
}

//请求成功后直接刷新页面
function sendAjaxReload(postData, sendUrl) {
    $.ajax({
        type: "post",
        url: sendUrl,
        data: postData,
        dataType: "json",
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.closeAll();
            dialogTips("通信错误");
        },
        success: function (result) {
            if (parseInt(result.code, 10) == 200) {
                window.location.reload();
            } else {
                dialogTips(result.message);
            }
        }
    });
}

//请求成功后跳转页面
function sendAjaxRedirectUrl(postData, sendUrl, redirectUrl) {
    $.ajax({
        type: "post",
        url: sendUrl,
        data: postData,
        dataType: "json",
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.closeAll();
            dialogTips("通信错误");
        },
        success: function (result) {
            if (parseInt(result.code, 10) == 200) {
                window.location.href = redirectUrl;
            } else {
                dialogTips(result.message);
            }
        }
    });
}

//请求成功后回调函数
function sendAjaxSetFunc(postData, sendUrl, Func) {
    $.ajax({
        type: "post",
        url: sendUrl,
        data: postData,
        dataType: "json",
        success: function (result) {
            Func(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.closeAll();
            dialogTips("通信错误");
        }
    });
}

//请求成功后回调函数
function sendAjaxSetFuncAsync(flag, postData, sendUrl, Func) {
    $.ajax({
        type: "post",
        url: sendUrl,
        data: postData,
        dataType: "json",
        async: flag,
        success: function (result) {
            Func(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.closeAll();
            dialogTips("通信错误");
        }
    });
}

//请求成功后执行函数并携带对象
function sendAjaxSetFuncObj(postData, sendUrl, Func, obj) {
    $.ajax({
        type: "post",
        url: sendUrl,
        data: postData,
        dataType: "json",
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.closeAll();
            dialogTips("通信错误");
        },
        success: function (result) {
            Func(result, obj);
        }
    });
}