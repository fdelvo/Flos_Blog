const app = angular.module("FlosBlogApp", ["ngResource", "ngSanitize", "ui.tinymce"]);

app
.filter('html',function($sce){
    return function(input){
        return $sce.trustAsHtml(input);
    }
});
