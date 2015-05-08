// 对Date的扩展，将 Date 转化为指定格式的String 
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1,                 //月份 
        "d+": this.getDate(),                    //日 
        "h+": this.getHours(),                   //小时 
        "m+": this.getMinutes(),                 //分 
        "s+": this.getSeconds(),                 //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds()             //毫秒 
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
//时间加一天
Date.prototype.AddDay = function (n) {
    //毫秒数
    var hm = this.getTime();
    //一天的毫秒数 * 天数
    var nDayHm = (1000 * 3600 * 24) * n;
    //第二天的毫秒数
    var resultHm = hm + nDayHm;
    return new Date(resultHm);
}

// 得到Param对象
Window.prototype.GetParam = function (fromId) {
    var iText = "#" + fromId + " input[type=text]";
    var pText = "#" + fromId + " input[type=password]";
    var sText = "#" + fromId + " select";
    var hText = "#" + fromId + " input[type=hidden]";
    var rText = "#" + fromId + " input[type='radio']:checked";
    var aText = "#" + fromId + " textarea";
    var ilist = $(iText).toArray();
    var plist = $(pText).toArray();
    var slist = $(sText).toArray();
    var hlist = $(hText).toArray();
    var rlist = $(rText).toArray();
    var alist = $(aText).toArray();
    ilist = ilist.concat(plist).concat(slist).concat(hlist).concat(rlist).concat(alist);
    if (ilist.length < 0) return null;
    var param = "{ "
    for (var i = 0; i < ilist.length; i++) {
        var attrName = ilist[i].name;
        var attrValue = ilist[i].value.replace(/\\/g, "\\\\").replace(/\n/g, "\\n").replace(/'/g, "\\'");
        if (attrName == "") continue;
        if (attrName == "__VIEWSTATE") continue;
        if (attrName == "__VIEWSTATEGENERATOR") continue;
        param += "'" + attrName + "'";
        param += " : ";
        param += "'" + attrValue + "'";
        param += " , ";
    }
    param = param.substr(0, param.length - 2);
    param += "}";
    var o = eval('(' + param + ')');
    return o;
}

Window.prototype.GetUrlStr = function (fromId) {
    var iText = "#" + fromId + " input[type=text]";
    var pText = "#" + fromId + " input[type=password]";
    var sText = "#" + fromId + " select";
    var hText = "#" + fromId + " input[type=hidden]";
    var rText = "#" + fromId + " input[type='radio']:checked";
    var ilist = $(iText).toArray();
    var plist = $(pText).toArray();
    var slist = $(sText).toArray();
    var hlist = $(hText).toArray();
    var rlist = $(rText).toArray();
    ilist = ilist.concat(plist).concat(slist).concat(hlist).concat(rlist);
    if (ilist.length < 0) return "";
    var urlstr = "";
    for (var i = 0; i < ilist.length; i++) {
        urlstr += ilist[i].name + "=" + ilist[i].value + "&";
    }
    urlstr = urlstr.substr(0, urlstr.length - 1);
    return urlstr;

}

//删除cookie
Window.prototype.DelCookie = function (name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    document.cookie = name + "=" + cval + "; expires=" + exp.toGMTString();
}

//得到cookie
Window.prototype.GetCookie = function (name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");

    if (arr = document.cookie.match(reg))

        return unescape(arr[2]);
    else
        return "";
}