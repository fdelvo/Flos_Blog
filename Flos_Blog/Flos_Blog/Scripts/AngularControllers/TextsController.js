app.controller("TextsController", TextsController);

TextsController.$inject = [
    "$scope", "TextsResource"
];

function TextsController($scope, TextsResource) {
    $scope.newText = new TextsResource();
    $scope.CreateText = function() {
        $scope.newText.$PostText(
            function(response) {
                console.log(response);
            },
            function(response) {
                console.log(response);
            });
    };
    $scope.GetTexts = function() {
        $scope.texts = TextsResource.GetTexts( { page: 0, pageSize: 10 },
            function(response) {
                console.log(response);
            },
            function() {
                console.log(response);
            });
    };
    $scope.GetText = function() {
        $scope.text = TextsResource.GetText( { id: getValueAtIndex(5)},
            function(response) {
                console.log(response);
            },
            function() {
                console.log(response);
            })};
    $scope.MeasureStayOnPage = function() {
        var start = Date.now();
        window.addEventListener("beforeunload", function (e) {
            return Math.abs(Date.now() - start);
        });
    };
    function getValueAtIndex (index) {
        const str = window.location.href;
        console.log(str.split("/")[index]);
        return str.split("/")[index];
    };
}