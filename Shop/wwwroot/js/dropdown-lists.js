$(document).ready(function () {
    $("#Gender").change(function () {
        $("#Category").empty();
        $.ajax({
            type: 'GET',
            url: '../Product/GetCategories',
            dataType: 'json',
            data: { gender: $("#Gender").val() },
            success: function (categories) {
                $.each(categories, function (i, cat) {
                    $("#Category").append('<option value="' + cat.value + '">' + cat.text + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve categories.' + ex);
            }
        });
        return false;
    })
});