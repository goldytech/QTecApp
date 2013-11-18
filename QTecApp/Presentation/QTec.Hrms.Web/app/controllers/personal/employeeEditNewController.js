'use strict';
define(['app'], function(app) {
    app.controller('EmployeeEditNewController', ['$scope', '$routeParams', function ($scope, $routeParams) {
        $scope.title = '';
        init();
        $scope.$on('updatepersonalinfo', function(event, personal) {
            alert(personal.firstName);
        });
        
        $scope.$on('updateEmployeeLanguages', function (event, employeeLanguages) {
            for (var i = 0; i < employeeLanguages.length; i++) {
                alert(employeeLanguages[i].languageId);
            }
        });

        function init() {
            var employeeId = ($routeParams.employeeID) ? parseInt($routeParams.employeeID) : 0;
            $scope.title = (employeeId > 0) ? 'Edit' : 'Add';
        }
    }]);
});