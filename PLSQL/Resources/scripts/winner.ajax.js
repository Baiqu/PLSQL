var ajax = {};
ajax.settings = {
    dataType: "text"
};
ajax.post = function (url, data, callback) {
    ajax.loading();
    try {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: url,
            data: data,
            success: function (result) {
                if (callback != undefined) {
                    callback(result);
                }
                ajax.loaded();
            },
            error: function (data, status, e) {
                alert("" + e);
            }
        });
    } catch (e) {
        alert(e);
    }

}

ajax.get = function (url, data, callback) {
    ajax.loading();
    $.get(url, data, function (result) {
        try {
            if (callback != undefined) {
                callback(result);
            }
        } catch (e) {
            alert(e);
        }
        ajax.loaded();
    });
}

ajax.getJSON = function (url, data, callback) {
    ajax.loading();
    $.getJSON(url, data, function (result) {
        try {
            if (callback != undefined) {
                callback(result);
            }
        } catch (e) {
            alert(e);
        }
        ajax.loaded();
    });
}



ajax.loading = function () {
    //if ($("#loadingView").length <= 0) {
    //    var loadView = $("<div></div>").attr({ "id": "loadingView" })
    //    .html("拼命加载中.....")
    //    .addClass("loadingView")
    //    .appendTo("body");
    //}
    //$("#loadingView").showMask(true);
}
ajax.loaded = function () {
    //$("#loadingView").hideMask();
}