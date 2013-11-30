'use strict';
define(['app'], function (app) {
    app.factory('EmployeeDataService', ['$http', '$q', function ($http, $q) {
        var employeePersonalDataService = {};
        var baseurl = '/api/employees/';

        employeePersonalDataService.getPersonalDataforEmployee = function (id) {
            return $http({ method: 'GET', url: baseurl + id + '/personal'}).
                                                        success(function (data, status, headers, config) {
                                                         //   alert(status);
                                                       // this callback will be called asynchronously
                                                       // when the response is available
                                                       // alert(headers);
                                                       return data;
                                                    }).
                                                      error(function (data, status, headers, config) {
                                                            // called asynchronously if an error occurs
                                                            // or server returns response with an error status.
                                                       return data;
                                           });
        };

        employeePersonalDataService.getLanguagesforEmployee = function (id) {
            return $http({ method: 'GET', url: baseurl + id + '/languages' }).
                                                        success(function (data, status, headers, config) {
                                                          //  alert(status);
                                                            // this callback will be called asynchronously
                                                            // when the response is available
                                                            // alert(headers);
                                                            return data;
                                                        }).
                                                      error(function (data, status, headers, config) {
                                                          // called asynchronously if an error occurs
                                                          // or server returns response with an error status.
                                                          return data;
                                                      });
        };
        
        employeePersonalDataService.saveEmployee = function (employeeInfo) {
            return $http({ method: 'PUT', url: baseurl + employeeInfo.employeePersonalInfo.employeeId ,data:employeeInfo}).
                                                        success(function (data, status, headers, config) {
                                                            alert(status);
                                                            // this callback will be called asynchronously
                                                            // when the response is available
                                                            // alert(headers);
                                                            return data;
                                                        }).
                                                      error(function (data, status, headers, config) {
                                                          // called asynchronously if an error occurs
                                                          // or server returns response with an error status.
                                                          return data;
                                                      });
        };
        return employeePersonalDataService;


    }]);
});