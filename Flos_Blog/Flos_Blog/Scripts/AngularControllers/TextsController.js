app.controller("TextsController", TextsController);

TextsController.$inject = [
    "$scope", "$rootScope", "TextsResource"
];

function TextsController($scope, $rootScope, TextsResource) {
    var page = 0;
    $scope.newText = new TextsResource();
    $scope.newStay = new TextsResource();
    $scope.newShare = new TextsResource();
    $scope.texts = [];
    var yearToSearchIn = new Date().getFullYear();
    $scope.year = new Date().getFullYear();
    $scope.yearsSinceRelease = getYearsSinceRelease();
    function getYearsSinceRelease() {
        const releaseYear = 2017;
        const currentYear = new Date().getFullYear();
        const years = [releaseYear];
        if (currentYear - releaseYear !== 0) {
            for (var i = 1; i < (currentYear - releaseYear)+1; i++) {
                const yearToAdd = releaseYear + i;
                years.push(yearToAdd);
            }
        }
        return years;
    };

    $scope.SetYear = function(year) {
        yearToSearchIn = year;
    };
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
    $scope.PublishText = function (id, t) {
        $scope.textToPublish = t;
        $scope.textToPublish.$PublishText({id: id}, 
            function(response) {
                console.log("Text Published");
                location.href = location.href;
            }, function(response) {
                $rootScope.status = response;
            });
    }
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
    $scope.GetTexts = function () {
        page = 0;
        $scope.texts = [];
        $scope.texts = TextsResource.GetTexts( { page: page, pageSize: 10 },
            function(response) {
                console.log("texts loaded");
            },
            function() {
                console.log("error");
            });
    };
    $scope.GetTextsByMonth = function (month) {
        $scope.texts = [];
        $scope.texts = TextsResource.GetTextsByMonth({ month: month, year: yearToSearchIn },
            function (response) {
                console.log("texts loaded");
            },
            function () {
                console.log("error");
            });
    };
    $scope.SearchText = function () {
        page = 0;
        $scope.texts = [];
        $scope.texts = TextsResource.SearchText({ query: $scope.search.query, page: page, pageSize: 10 },
            function (response) {
                console.log("texts loaded");
            },
            function (response) {
                console.log(response);
            });
    };
    $scope.More = function() {
        page++;
        var textsTemp;
        textsTemp = TextsResource.GetTexts({ page: page, pageSize: 10 },
            function (response) {
                console.log("temp texts loaded");
                $scope.texts = $scope.texts.concat(textsTemp);
            },
            function () {
                console.log("error");
            });

    };
    $scope.GetTextsForAdmin = function () {
        $scope.texts = TextsResource.TextsForAdmin(
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
    $scope.MeasureStayOnText = function() {
        var start = Date.now();
        window.addEventListener("beforeunload", function (e) {
            $scope.newStay.Id = getValueAtIndex(5);
            $scope.newStay.Duration = Math.abs(Date.now() - start);
            $scope.newStay.$SaveTextStayDuration(function(response) {
                console.log("stay duration saved");
            }, function(response) {
                console.log(response);
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
    $scope.PrintText = function() {
        Window.print();
    };
    $scope.ScrollToBottom = function() {
        window.scrollTo(0, document.body.scrollHeight);
    };
    function getValueAtIndex (index) {
        const str = window.location.href;
        console.log(str.split("/")[index]);
        return str.split("/")[index];
    };
}