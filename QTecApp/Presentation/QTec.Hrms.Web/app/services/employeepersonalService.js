'use strict';
define(['app'], function (app) {
    app.factory('EmployeePersonalDataService', ['$http', '$q', function ($http, $q) {
        var employeePersonalDataService = {};
        var baseurl = '/apiv2/EmpPersonalInfo/';

        employeePersonalDataService.getPersonalDataforEmployee = function (id) {
            return $http({ method: 'GET', url: baseurl + id }).
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