app.factory("AnalyticsResource", AnalyticsResource);

AnalyticsResource.$inject = ["$resource"];

function AnalyticsResource($resource) {
    return $resource("/api/apianalytics/",
        null,
        {
            GetPageVisits: {
                method: "GET",
                url: "/api/apianalytics/getpagevisits",
                headers: { "Authorization": `Bearer ${localStorage.getItem("tokenKey")}` }
            },
            GetAveragePageStayDurations: {
                method: "GET",
                url: "/api/apianalytics/getaveragepagestaydurations",
                isArray: true,
                headers: { "Authorization": `Bearer ${localStorage.getItem("tokenKey")}` }
            },
            SavePageStayDuration: {
                method: "POST",
                url: "/api/apianalytics/savepagestayduration",
                headers: { "Authorization": `Bearer ${localStorage.getItem("tokenKey")}` }
            },
            SavePageVisit: {
                method: "PUT",
                url: "/api/apianalytics/savepagevisit",
                headers: { "Authorization": `Bearer ${localStorage.getItem("tokenKey")}` }
            }
        });
}