'use strict';

define(['app'], function (app) {

    app.controller('NavbarController', ['$scope', '$location',  function ($scope, $location) {
        var appTitle = 'Employee Management';
        $scope.appTitle = appTitle;
        $scope.highlight = function (path) {
            return $location.path().substr(0, path.length) == path;
        }
    }]);

});