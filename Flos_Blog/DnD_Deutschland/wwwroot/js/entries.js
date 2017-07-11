const getEntry = function (e) {
    console.log($(e).attr("id"));
    /*$.ajax({
            type: "GET",
            url: `/api/entries/getentrybytitle/${title}`,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
        .done(function (data) {
            $(`#entry-${title}`).val(data.entryTitle);
        })
        .fail(function () {

        })
        .always(function () {

        });*/
};

$(document).ready(function () {
    $("article[id^='entry-']").each(getEntry());
});