'use strict';
define(['app'], function(app) {
    app.controller('EmployeeLanguagesController', ['$scope', '$routeParams', function($scope, $routeParams) {

        // for language object binded to form
        $scope.language = {};
        
        // for binding the grid in the form
        $scope.employeeLanguages = [];

        // for filling the drop down list of language
        $scope.languagesMaster = [];
        
        function init() {
            
        }
    }
    ]);
});