'use strict';
define(['app'], function(app) {
    app.controller('MenuController', ['$scope', function ($scope) {
        var items = [{ name: 'City', id: '1' },
        { name: 'Country', id: '2' },
        { name: 'Others', id: '3' }];
        $scope.menuItems = items;
    }]);
});
