const app = angular.module("FlosBlogApp", ["ngResource", "ngSanitize", "ui.tinymce"]);

app.
  filter("htmlToPlaintext", function () {
      return function (text) {
          return text ? String(text).replace(/<[^>]+>/gm, '') : '';
      };
  }
);
