//Для использования данного плагина нужно иметь JQuery
(function (namespace) {
    if ($) {
        //Некоторые методы этого объекта нужно вызывать, когда страница загружена.
        namespace.ajax = {
            request: function (data, successCallback) {
                $.ajax({
                    url: "AjaxEngineHandler.ashx",
                    type: "POST",
                    data: data,
                    success: successCallback
                });
            },
            repeatedRequest: function (data, minInterval, stopCallback) {
                data.repeated = true;
                var repeatedFunction = function () {
                    var startTime = Date.now();
                    Engine.ajax.request(data, function (response) {
                        var endTime = Date.now();
                        if (response === "stop")
                            stopCallback();
                        else {
                            if (endTime - startTime < minInterval) {
                                setTimeout(repeatedFunction, minInterval - (endTime - startTime));
                            } else
                                repeatedFunction();
                        }
                    });
                }
                repeatedFunction();
            }
        };
    } else {
        throw new Error("Для использования плагина Engine должен быть установлен JQuery");
    }
})(window.Engine = window.Engine || {});