app.controller("TextsController", TextsController);

TextsController.$inject = [
    "$scope", "$rootScope", "TextsResource"
];

function TextsController($scope, $rootScope, TextsResource) {
    $scope.newText = new TextsResource();
    $scope.newStay = new TextsResource();
    $scope.newShare = new TextsResource();
    $scope.CreateText = function() {
        $scope.newText.$PostText(
            function(response) {                
                $rootScope.status = "Text published.";
                location.href = location.href;
            },
            function(response) {
                $rootScope.status = response;
            });
    };
    $scope.DeleteText = function(id) {
        TextsResource.DeleteText({ id: id },
            function (response) {
                $rootScope.status = "Text deleted.";
                location.href = location.href;
            },
            function (response) {
                $rootScope.status = response;
            });
    };
    $scope.EditText = function() {
        $scope.text.$PutText({ id: getValueAtIndex(5)},
            function() {
            $rootScope = "Text edited.";
            location.href = location.href;
        }, function(response) {
            $rootScope = response;
        });
    };
    $scope.GetTexts = function() {
        $scope.texts = TextsResource.GetTexts( { page: 0, pageSize: 10 },
            function(response) {
                console.log("texts loaded");
            },
            function() {
                console.log("error");
            });
    };
    $scope.GetTextsForAdmin = function () {
        $scope.texts = TextsResource.TextsForAdmin({ page: 0, pageSize: 10 },
            function (response) {
                console.log("texts loaded");
            },
            function () {
                $rootScope.status = response;
            });
    };
    $scope.GetText = function() {
        $scope.text = TextsResource.GetText( { id: getValueAtIndex(5)},
            function(response) {
                console.log("text loaded");
            },
            function() {
                console.log("error");
            })};
    $scope.MeasureStayOnPage = function() {
        var start = Date.now();
        window.addEventListener("beforeunload", function (e) {
            $scope.newStay.id = getValueAtIndex(5);
            $scope.newStay.duration = Math.abs(Date.now() - start);
            $scope.newStay.$SaveTextStayDuration(function(response) {
                console.log("stay duration saved");
            }, function() {
                console.log("error");
            });
        });
        
    };
    $scope.ShareText = function() {
        $scope.newShare.id = getValueAtIndex(5);
        $scope.newShare.$TextShared(function(response) {
            console.log("text shared");
        }, function() {
            console.log("error");
        });
    }
    function getValueAtIndex (index) {
        const str = window.location.href;
        console.log(str.split("/")[index]);
        return str.split("/")[index];
    };
}