'use strict';

define(['app'], function (app) {

    app.controller('EmployeeEditController', ['$scope', '$location', '$routeParams', '$timeout',  'dataService', 'modalService',
        function ($scope, $location, $routeParams, $timeout, dataService, modalService) {

        var employeeID = ($routeParams.employeeID) ? parseInt($routeParams.employeeID) : 0,
            timer;

        $scope.employee;
        $scope.title = (employeeID > 0) ? 'Edit' : 'Add';
        $scope.buttonText = (employeeID > 0) ? 'Update' : 'Add';
        $scope.firstName;
        $scope.lastName;
        $scope.companyemail;
        $scope.updateStatus = false;
        $scope.errorMessage = '';
        $scope.opened = false;
        $scope.previousDate = '';
        $scope.percentageDone = 0;
        $scope.dateOptions = {
            'year-format': "'yy'",
            'starting-day': 1
        };
        $scope.open = function () {
            $timeout(function () {
                $scope.opened = true;
            });
        };

        init();

        function init() {
            if (employeeID > 0) {
                dataService.getEmployee(employeeID).then(function (employee) {
                    if (!angular.isObject(employee)) {
                        alert("Invalid Employee");
                        $location.path('/employees');
                        return 0;
                    }
                    if (angular.isString(employee.data.exceptionMessage)) {
                        $scope.errorMessage = 'Error occurred and it has been logged';
                        return 0;
                    }
                    $scope.employee = employee;
                }, processError);
            } else {
                dataService.newEmployee().then(function (employee) {
                    $scope.employee = employee;
                });
                
            }
            getDesignations();
        }
        $scope.updateDate = function (date) {
            alert(date);
        };
        $scope.progress = function (percentDone) {
            $scope.percentageDone = percentDone;
        };
         
        $scope.done = function (files, data) {

            $scope.percentageDone = 100;

        };

            $scope.error = function(files, type, msg) {
                $scope.errorMessage = "Upload error: " + msg;

            };
            
            $scope.uploadFinished = function (e, data) {
                $scope.percentageDone = 100;
            };
        function getDesignations() {
            dataService.getDesignations().then(function (designations) {
                $scope.designations = designations;
            }, processError);
        }

        $scope.isDesignationSelected = function (employeeDesignationId, designationId) {
            return employeeDesignationId === designationId;
        };

        $scope.saveEmployee = function () {
            if ($scope.editForm.$valid) {
                if (employeeID === 0) //comparing the query string of employeeID
                {
                    dataService.insertEmployee($scope.employee).then(processSuccess, processError);
                }
                else {
                    dataService.updateEmployee($scope.employee).then(processSuccess, processError);
                }
            }
        };

        $scope.deleteEmployee = function () {
            var empName = $scope.employee.firstName + ' ' + $scope.employee.lastName;
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Employee',
                headerText: 'Delete ' + empName + '?',
                bodyText: 'Are you sure you want to delete this employee?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                dataService.deleteEmployee($scope.employee.id).then(function () {
                    $location.path('/employees');
                }, processError);
            });
        };

        function processSuccess() {
            $scope.updateStatus = true;
            startTimer();
        }

        function processError(error) {
            $scope.errorMessage = error.message;
            startTimer();
        }

        function startTimer() {
            timer = $timeout(function () {
                $timeout.cancel(timer);
                $scope.errorMessage = '';
                $scope.updateStatus = false;
            }, 3000);
        }

            var getEmail = function() {
                if (angular.isString($scope.firstName) && angular.isString($scope.lastName)) {
                    $scope.companyemail = $scope.firstName + '.' + $scope.lastName + "@quipment.in";
                    
                } else {
                    $scope.companyemail = null;
                }
            };

            $scope.$watch('firstName', getEmail, true);
            $scope.$watch('lastName', getEmail, true);

        }]);

});