const getEntryForAdmin = function (id) {
    $("#entry-form").hide();
    $("#entry-edit-form").show();
    $.ajax({
        type: "GET",
        url: `/api/entries/getentry/${id}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
        .done(function (data) {
            $("#entry-edit-form input[name=title]").val(data.entryTitle);
            $("#entry-edit-form input[name=entry-id]").val(data.entryId);
            $("#entry-edit-form input[name=created-date]").val(data.entryCreatedDate);
            $("#entry-edit-form input[name=last-edited-date]").val(data.entryLastEditedDate);
            $("#entry-edit-form input[name=author]").val(data.entryAuthor);
            $("#entry-edit-form input[name=keyword]").val(data.entryKeyword);
            $("#entry-edit-form #content").val(data.entryContent);
        })
        .fail(function () {

        })
        .always(function () {

        });
};

const deleteEntry = function (id) {
    $.ajax({
        type: "DELETE",
        url: `/api/entries/deleteentry/${id}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
        .done(function (data) {
            getEntriesForAdmin();
        })
        .fail(function () {

        })
        .always(function () {

        });
};

const getEntriesForAdmin = function () {
    $.ajax({
        type: "GET",
        url: "/api/entries/getentries",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
        .done(function (data) {
            $("#data").empty();
            data.forEach(function (item, index) {
                $("#data").append(
                    `<tr>
                            <td>${item.entryTitle}</td>
                            <td>${item.entryKeyword}</td>
                            <td>${item.entryCreatedDate}</td>
                            <td>${item.entryAuthor}</td>
                            <td>
                                <button onclick='getEntryForAdmin("${item.entryId}")'>Anzeigen/Bearbeiten</button>
                                <button onclick='deleteEntry("${item.entryId}")'>Löschen</button>
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
$(document).ready(function () {
    $("#entry-edit-form").hide();

    const entriesLocationHref = "/admin/entries";

    

    $("#entry-edit-form").submit(function (event) {
        const entryFormData = {
            EntryTitle: $("#entry-edit-form input[name=title]").val(),
            EntryKeyword: $("#entry-edit-form input[name=keyword]").val(),
            EntryId: $("#entry-edit-form input[name=entry-id]").val(),
            EntryContent: $("#entry-edit-form #content").val(),
            EntryCreatedDate: $("#entry-edit-form input[name=created-date]").val(),
            EntryAuthor: $("#entry-edit-form input[name=author]").val(),
            url: "/api/entries/putentry/" + $("#entry-edit-form input[name=entry-id]").val()
        };
        $.ajax({
            type: "PUT",
            url: entryFormData.url,
            data: JSON.stringify(entryFormData),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function (data) {
                $("#entry-edit-form").trigger("reset");
                $("#entry-edit-form").hide();
                $("#entry-form").show();
                getEntriesForAdmin();
            })
            .fail(function () {

            })
            .always(function () {

            });

        event.preventDefault();
    });

    $("#entry-form").submit(function (event) {
        const entryFormData = {
            EntryTitle: $("#entry-form input[name=title]").val(),
            EntryKeyword: $("#entry-form input[name=keyword]").val(),
            EntryContent: $("#entry-form #content").val(),
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