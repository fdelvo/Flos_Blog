app.factory("TextsResource", TextsResource);

TextsResource.$inject = ["$resource"];

function TextsResource($resource) {
    return $resource("/api/texts/",
        null,
        {
            GetTexts: {
                method: "GET",
                url: "/api/apitexts/gettexts",
                isArray: true,
                headers: { "Authorization": "Bearer " + localStorage.getItem("tokenKey") }
            },
            GetText: {
                method: "GET",
                url: "/api/apitexts/gettext",
                headers: { "Authorization": "Bearer " + localStorage.getItem("tokenKey") }
            },
            PostText: {
                method: "POST",
                url: "/api/apitexts/posttext",
                headers: { "Authorization": "Bearer " + localStorage.getItem("tokenKey") }
            },
            PutText: {
                method: "PUT",
                url: "/api/apitexts/puttext",
                headers: { "Authorization": "Bearer " + localStorage.getItem("tokenKey") }
            },
            DeleteText: {
                method: "DELETE",
                url: "/api/apitexts/deletetext",
                headers: { "Authorization": "Bearer " + localStorage.getItem("tokenKey") }
            }
        });
}