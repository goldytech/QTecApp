'use strict';
define(['app'], function(app) {
    app.controller('EmployeeEditNewController', ['$scope', '$routeParams','EmployeeDataService', function ($scope, $routeParams,employeeDataService) {
        $scope.title = '';
        var employeeInfo = {};
        init();
        $scope.$on('updatepersonalinfo', function(event, personal) {
            employeeInfo.employeePersonalInfo = personal;
        });
        
        $scope.$on('updateEmployeeLanguages', function (event, employeeLanguages) {
            employeeInfo.employeeLanguages = employeeLanguages;
        });

        $scope.saveEmployee = function () {
            employeeDataService.saveEmployee(employeeInfo).then(function (data,status) {
              //  alert(data);
            });
        };

        function init() {
            var employeeId = ($routeParams.employeeID) ? parseInt($routeParams.employeeID) : 0;
            $scope.title = (employeeId > 0) ? 'Edit' : 'Add';
        }
    }]);
});