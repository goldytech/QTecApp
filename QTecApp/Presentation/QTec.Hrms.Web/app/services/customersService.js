'use strict';

define(['app'], function (app) {

    //This handles retrieving data and is used by controllers. 3 options (server, factory, provider) with 
    //each doing the same thing just structuring the functions/data differently.

    //Although this is an AngularJS factory I prefer the term "service" for data operations
    app.factory('dataService', ['$http', '$q', function ($http, $q) {
        var serviceBase = '/api/Personal/',
            customers = null,
            customersFactory = {};

        customersFactory.getEmployees = function (pageIndex, pageSize) {
            return getPagedResource('employees', pageIndex, pageSize);
        };

        

        customersFactory.getDesignations = function () {
            return $http.get(serviceBase + 'designations').then(
                function (results) {
                    return results.data;
                });                
        }

        customersFactory.checkUniqueValue = function (id, property, value) {
            if (!id) id = 0;
            return $http.get(serviceBase + 'checkUnique/' + id + '?property=' + property + '&value=' + escape(value)).then(
                function (results) {
                    return results.data.status;
                });
        };

        customersFactory.insertEmployee = function (employee) {
            return $http.post(serviceBase + 'postEmployee', employee).then(function (results) {
                employee.id = results.data.id;
                return results.data;
            });
        };

        customersFactory.newEmployee = function () {
            return $q.when({});
        };

        customersFactory.updateEmployee = function (employee) {
            return $http.put(serviceBase + 'putEmployee/' + employee.id, employee).then(function (status) {
                return status.data;
            });
        };

        customersFactory.deleteEmployee = function (id) {
            return $http.delete(serviceBase + 'deleteEmployee/' + id).then(function (status) {
                return status.data;
            });
        };

        customersFactory.getEmployee = function (id) {
            //then does not unwrap data so must go through .data property
            //success unwraps data automatically (no need to call .data property)
            return $http.get(serviceBase + 'employeeById/' + id).then(function (results) {
               return results.data;
            });
        };

   

        function getPagedResource(baseResource, pageIndex, pageSize) {
            var resource = baseResource;
            resource += (arguments.length == 3) ? buildPagingUri(pageIndex, pageSize) : '';
            return $http.get(serviceBase + resource).then(function (data) {
                return {
                    totalRecords: parseInt(data.headers('X-InlineCount')),
                    results: data.data
                };
            });
        }

        function buildPagingUri(pageIndex, pageSize) {
            var uri = '?$top=' + pageSize + '&$skip=' + (pageIndex * pageSize);
            return uri;
        }
        

       

        return customersFactory;

    }]);

});