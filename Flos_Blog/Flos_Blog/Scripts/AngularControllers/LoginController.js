angular.module("FlosBlogApp").controller("LoginController", LoginController);

LoginController.$inject = [
    "$scope", "$http"
];

function LoginController($scope, $http) {
    const login = this;

   console.log("Test");

   $scope.LogIn = function () {
        $http({
            method: "POST",
            url: "/Token",
            data: `userName=${$scope.loginData.username}&password=${$scope.loginData.password}&grant_type=password`
        })
            .then(function (response) {
                localStorage.setItem("tokenKey", response.data.access_token);
                location.href = "/Admin/Index";
            },
                function (response) {
                    console.log(response);
                });
    };
}