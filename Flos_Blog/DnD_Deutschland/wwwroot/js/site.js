$(document).ready(function () {
    $("form").submit(function (event) {
        var formData = {
            EntryTitle: $('input[name=title]').val(),
            EntryContent: $('#content').val()
        };
        var url = "/api/entries";
        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(formData),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function () {

            })
            .fail(function () {

            })
            .always(function () {

            });

        event.preventDefault();
    });

    var data = function () {
        $.ajax({
            type: "GET",
            url: "/api/entries/getentries",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function (data) {
                data.forEach(function (item, index) {
                    $("#data").append(
                        "<tr><td>" + item.entryTitle + "</td><td>" + item.entryDate + "</td><td>" + item.entryAuthor + "</td><td><a asp-controller='admin' asp-action='edit'>Edit</a><a id='delete-link'>Delete</a></td></tr>"
                    )
                });
            })
            .fail(function () {

            })
            .always(function () {

            });
    };
    data();
});