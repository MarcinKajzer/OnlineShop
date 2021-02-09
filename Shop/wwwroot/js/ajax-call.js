function AjaxCall(requestMethod, url, data, dataType, callback) {
    $(document).ready(function () {
        $.ajax({
            type: requestMethod,
            url: url,
            data: data,
            dataType: dataType,
            success: function (result) {
                callback(result);
            },
            error: function (ex) {
                alert('Something went wrong.' + ex);
            }
        });
        return false;
    })
}