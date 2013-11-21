'use strict';
define(['app'], function(app) {
    app.controller('EmployeePersonalController', ['$scope', '$rootScope', 'dataService', 'EmployeeDataService', '$routeParams', function ($scope, $rootScope, dataService, employeePersonalDataservice,$routeParams) {

        $scope.personal={};
        $scope.designations = [];
        $scope.saveEmployeePersonalDetails = function () {
            $rootScope.$broadcast("updatepersonalinfo", $scope.personal);
        };

        init();
        /// acts like constructor
        function init() {
            getDesignations();

            //check for query string if found then load the corresponding data
            if (!angular.isUndefined($routeParams.employeeId)) {
                getEmployeePersonalInfo($routeParams.employeeId);
            }
        }
        
        // gets the employee personal info
        function getEmployeePersonalInfo(id) {
            employeePersonalDataservice.getPersonalDataforEmployee(id).then(function (empPersonalInfo) {
                if (!angular.isObject(empPersonalInfo)) {
                    alert("Invalid Employee");
                    $location.path('/employees'); // TODO redirect to 404 page
                    return -1;
                }
                if (angular.isString(empPersonalInfo.data.exceptionMessage)) {
                    alert(empPersonalInfo.data.exceptionMessage); // TODO redirect to ERROR page
                    return -1;
                }
                $scope.personal = empPersonalInfo.data;
                // do the broadcast 
                $rootScope.$broadcast("updatepersonalinfo", $scope.personal); //TODO separate out it as other function
               return 1; //success
            }, processError);
        }
        
        // when promise is rejected or faulted
        function processError() {
            alert("Unable to reach the service end point");
        }

        function getDesignations() {
            dataService.getDesignations().then(function(designations) {
                $scope.designations = designations;
            });
        }
    }]);
});