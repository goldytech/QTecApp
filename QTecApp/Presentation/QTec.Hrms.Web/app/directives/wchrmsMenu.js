'use strict';
define(['app'],function(app) {
    app.directive('hrmsMenu',function() {
        return {
            restrict: 'E',
            templateUrl: '/app/partials/menu.html',
            controller: 'MenuController'

        };
    });
});