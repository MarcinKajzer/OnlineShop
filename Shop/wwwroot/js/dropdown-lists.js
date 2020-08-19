let method = 'GET';
let url = '../Product/GetCategories';
let data = { gender: $("#Gender").val() };
let dataType = 'json';
let callback = function (categories) {
    $.each(categories, function (i, cat) {
        $("#Category").append('<option value="' + cat.value + '">' + cat.text + '</option>');
    });
}

$(document).ready(function () {
    $("#Gender").change(function () {
        $("#Category").empty();
        AjaxCall(method, url, data, dataType, callback)
    })
});