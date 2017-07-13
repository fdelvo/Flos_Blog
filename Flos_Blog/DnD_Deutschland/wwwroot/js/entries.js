$(document).ready(function () {
    $("article[id^='entry-']").each(function () {
        var keyword = this.id.substring(6);
        $.ajax({
            type: "GET",
            url: `/api/entries/getentrybytitle/${keyword}`,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function (data) {
                $(`#entry-${keyword}`).append(`<h2>${data.entryTitle}</h2><p>${data.entryContent}</p>`);
            })
            .fail(function () {

            })
            .always(function () {

            });
    });
});