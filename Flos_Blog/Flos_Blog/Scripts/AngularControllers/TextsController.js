app.controller("TextsController", TextsController);

TextsController.$inject = [
    "$scope", "TextsResource"
];

function TextsController($scope, TextsResource) {
    $scope.newText = new TextsResource();
    $scope.newStay = new TextsResource();
    $scope.newShare = new TextsResource();
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
    $scope.GetTextsForAdmin = function () {
        $scope.texts = TextsResource.TextsForAdmin({ page: 0, pageSize: 10 },
            function (response) {
                console.log(response);
            },
            function () {
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
            $scope.newStay = {
                id: getValueAtIndex(5),
                duration: Math.abs(Date.now() - start)
            }
            $scope.newStay.$SaveTextStayDuration(function(response) {
                console.log(response);
            }, function() {
                console.log(response);
            });
        });
        
    };
    $scope.TextShared = function() {
        $scope.newShare = {
            id: getValueAtIndex()
        }
        $scope.newShare.$TextShared(function(response) {
            console.log(response);
        }, function() {
            console.log(response);
        });
    }
    function getValueAtIndex (index) {
        const str = window.location.href;
        console.log(str.split("/")[index]);
        return str.split("/")[index];
    };
}