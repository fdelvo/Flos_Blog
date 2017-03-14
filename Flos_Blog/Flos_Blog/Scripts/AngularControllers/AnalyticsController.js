angular.module("FlosBlogApp").controller("AnalyticsController", AnalyticsController);

AnalyticsController.$inject = [
    "$scope", "AnalyticsResource"
];

function AnalyticsController($scope, AnalyticsResource) {
    $scope.pageVisit = new AnalyticsResource();
    $scope.newStay = new AnalyticsResource();
    $scope.PageVisit = function () {
        var start = Date.now();
        window.addEventListener("beforeunload", function (e) {
            $scope.pageVisit.Link = location.href;
            $scope.pageVisit.TimeSpentOnPage = Math.abs(Date.now() - start);
            $scope.pageVisit.$SavePageVisit(function () {
                console.log("Page visit saved.");
            }, function (responses) {
                console.log(response);
            });
        });
    };
    $scope.GetPageVisits = function() {
        $scope.pageVisits = AnalyticsResource.GetPageVisits();
    };
}