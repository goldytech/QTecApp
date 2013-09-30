'use strict';

define(['app'], function (app) {

    app.controller('EmployeesController', ['$scope', '$location', '$filter', 'dataService', 'modalService',
        function ($scope, $location, $filter, dataService, modalService) {

        $scope.employees = [];
        $scope.filteredEmployees = [];
        $scope.filteredCount = 0;
        $scope.orderby = 'lastName';
        $scope.reverse = false;

        //paging
        $scope.totalRecords = 0;
        $scope.pageSize = 10;
        $scope.currentPage = 1;

        init();

        function init() {
            createWatches();
            getEmployees();
        }

        function createWatches() {
            //Watch searchText value and pass it and the employees to nameCityStateFilter
            //Doing this instead of adding the filter to ng-repeat allows it to only be run once (rather than twice)
            //while also accessing the filtered count via $scope.filteredCount above
            $scope.$watch("searchText", function (filterText) {
                filterEmployees(filterText);
            });
        }

        $scope.pageChanged = function (page) {
            $scope.currentPage = page;
            getEmployees();
        };

        function getEmployees() {
            dataService.getEmployees($scope.currentPage - 1, $scope.pageSize)
            .then(function (data) {
                $scope.totalRecords = data.totalRecords;
                $scope.employees = data.results;
                filterEmployees(''); //Trigger initial filter
            }, function (error) {
                alert(error.message);
            });
        }

        function filterEmployees(filterText) {
            $scope.filteredEmployees = $filter("nameCityStateFilter")($scope.employees, filterText);
            $scope.filteredCount = $scope.filteredEmployees.length;
        }

        function getEmployeeById(id) {
            for (var i = 0; i < $scope.employees.length; i++) {
                var emp = $scope.employees[i];
                if (emp.employeeId === id) {
                    return emp;
                }
            }
        }        

        $scope.deleteEmployee = function (id) {
            var emp = getEmployeeById(id);
            var empName = emp.firstName + ' ' + emp.lastName;

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Employee',
                headerText: 'Delete ' + empName + '?',
                bodyText: 'Are you sure you want to delete this employee?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
               dataService.deleteEmployee(id).then(function () {
                    for (var i = 0; i < $scope.employees.length; i++) {
                        if ($scope.employees[i].id == id) {
                            $scope.employees.splice(i, 1);
                            break;
                        }
                    }
                    filterEmployees($scope.filterText);
                }, function (error) {
                    alert('Error deleting employee: ' + error.message);
                });
            });
        };

        $scope.ViewEnum = {
            Card: 0,
            List: 1
        };
            $scope.changeView = function (view) {
            switch (view) {
                case $scope.ViewEnum.Card:
                    $scope.listViewEnabled = false;
                    break;
                case $scope.ViewEnum.List:
                    $scope.listViewEnabled = true;
                    break;
            }
        };
            $scope.navigate = function (url) {
            $location.path(url);
        };
            $scope.setOrder = function (orderby) {
            if (orderby === $scope.orderby) {
                $scope.reverse = !$scope.reverse;
            }
            $scope.orderby = orderby;
        };

    }]);

});