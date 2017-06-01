$(document).ready(function () {
    const getEntriesForAdmin = function () {
        $.ajax({
                type: "GET",
                url: "/api/entries/getentries",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            })
            .done(function (data) {
                data.forEach(function (item, index) {
                    $("#data").append(
                        `<tr>
                            <td>${item.entryTitle}</td>
                            <td>${item.entryDate}</td>
                            <td>${item.entryAuthor}</td>
                            <td>
                                <a asp-controller='admin' asp-action='edit'>Edit</a>
                                <a id='delete-link'>Delete</a>
                            </td>
                        </tr>`
                    );
                });
            })
            .fail(function () {

            })
            .always(function () {

            });
    };

    $("#entry-form").submit(function (event) {
        const entryFormData = {
            EntryTitle: $("input[name=title]").val(),
            EntryContent: $("#content").val(),
            url: "/api/entries/postentry"
        };
        $.ajax({
            type: "POST",
            url: entryFormData.url,
            data: JSON.stringify(entryFormData),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function () {
                $("#entry-form").trigger("reset");
                getEntriesForAdmin();
            })
            .fail(function () {

            })
            .always(function () {

            });

        event.preventDefault();
    });

    $("#blog-entry-form").submit(function (event) {
        const blogEntryFormData = {
            BlogEntryTitle: $("input[name=title]").val(),
            BlogEntryContent: $("#content").val(),
            BlogEntryTags: $("input[name=tags").val().split(),
            url: "/api/entries/postblogentry"
        };
        $.ajax({
                type: "POST",
                url: blogEntryFormData.url,
                data: JSON.stringify(blogEntryFormData),
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

    $("#forum-entry-form").submit(function (event) {
        const forumEntryFormData = {
            ForumEntryTitle: $("input[name=title]").val(),
            ForumEntryContent: $("#content").val(),
            ForumEntryCategory: $("#category option:selected").text(),
            url: "/api/entries/postforumentry"
        };
        $.ajax({
                type: "POST",
                url: forumEntryFormData.url,
                data: JSON.stringify(forumEntryFormData),
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

    $("#entries-for-admin").on("load", getEntriesForAdmin());
});