$(function () {
   
});

$(document).ready(function () {
    //LoadExportApiWordBtn();
    setTimeout("LoadExportApiWordBtn()", 1);
});

//加载自定义导出按钮
function LoadExportApiWordBtn() {
    var btn = "<a style='margin-left: 10px;" +
        "color: #fff;" +
        "background-color: DeepPink;" +
        "border-color: DeepPink;" +
        "display: inline-block;" +
        "padding: 6px 12px;" +
        "margin-bottom: 0;" +
        "font-size: 14px;" +
        "font-weight: 400;" +
        "line-height: 1.3;" +
        "text-align: center;" +
        "white-space: nowrap;" +
        "vertical-align: middle;" +
        "-ms-touch-action: manipulation;" +
        "touch-action: manipulation;" +
        "cursor: pointer;" +
        "-webkit-user-select: none;" +
        "-moz-user-select: none;" +
        "-ms-user-select: none;" +
        "user-select: none;" +
        "background-image: none;" +
        "border: 1px solid transparent;" +
        "border-radius: 4px;" +
        "flex: 1;" +
        "max-width: 66px;" +
        "text-decoration: none;" +
        "font-family: sans-serif;'" +
        "onclick='ExportApiWord()'" +
        "role='button'>" +
        "<font color='Yellow'><b>导出</b></font>" +
        "</a>";
    $(".topbar-wrapper").append(btn);
}

function ExportApiWord() {
    alert("ExportApiWord!");
    //$.ajax({
    //    type: "get",
    //    url: "/api/Swagger/ExportApiWord",
    //    data: { },
    //    async: false,
    //    success: function (data) {
    //        debugger;
    //    }
    //});

    var url = '/api/Swagger/ExportApiWord';
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);    // 也可以使用POST方式，根据接口
    xhr.responseType = "blob";  // 返回类型blob
    // 定义请求完成的处理函数，请求前也可以增加加载框/禁用下载按钮逻辑
    xhr.onload = function () {
        // 请求完成
        if (this.status === 200) {
            // 返回200
            var blob = this.response;
            var reader = new FileReader();
            reader.readAsDataURL(blob);  // 转换为base64，可以直接放入a表情href
            reader.onload = function (e) {
                // 转换完成，创建一个a标签用于下载
                var a = document.createElement('a');
                a.download = 'Titan.Blog.WebAPP API文档.docx';
                a.href = e.target.result;
                $("body").append(a);  // 修复firefox中无法触发click
                a.click();
                $(a).remove();
            }
        }
    };
    // 发送ajax请求
    xhr.send();
}