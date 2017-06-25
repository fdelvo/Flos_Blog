angular.module("FlosBlogApp").controller("AnalyticsController", AnalyticsController);

AnalyticsController.$inject = [
    "$scope", "AnalyticsResource", "$interval"
];

function AnalyticsController($scope, AnalyticsResource, $interval) {
    $scope.pageVisit = new AnalyticsResource();
    $scope.newStay = new AnalyticsResource();
    var start = Date.now();
    window.onbeforeunload = function () {
        $scope.pageVisit.Link = location.href;
        $scope.pageVisit.TimeSpentOnPage = Math.abs(Date.now() - start);
        $scope.pageVisit.$SavePageVisit(function () {
            console.log("Page visit saved.");
        },
            function (responses) {
                console.log(response);
            });
    };
    $scope.PageVisit = function () {
        start = Date.now();
    };
    $scope.GetPageVisits = function() {
        $scope.pageVisits = AnalyticsResource.GetPageVisits();
    };
}