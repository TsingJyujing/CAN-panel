//函数别名定义
function alert(obj) {
    $.alert(obj);
}

function returnRaw(data) {
    return data;
}

var console = {
    log: function (str_in) {
        $.print(str_in);
    },
};

var print = function (str_in) {
    $.print(str_in);
};