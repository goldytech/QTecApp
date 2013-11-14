'use strict';
define(['app'], function(app) {
    app.controller('EmployeeLanguagesController', ['$scope', '$routeParams', 'LanguageDataService','EmployeeDataService', function ($scope, $routeParams,languageDataService,employeePersonalDataservice) {

        // for language object binded to form
        $scope.language = {};
        
        // for binding the grid in the form
        $scope.employeeLanguages = [];

        // for filling the drop down list of language
        $scope.languagesMaster = [];

        $scope.addLanguage = function () {

            // Boolean variable to check availability of record
            var available = false;

            // Check weather record is available or not. If record is available then update record
            for (var m = 0; m < $scope.employeeLanguages.length; m++) {
                if ($scope.employeeLanguages[m].languageId === $scope.language.languageId) {
                    $scope.employeeLanguages[m] = $scope.language;
                    available = true;
                }
            }

            // If record is not available then add it
            if (!available) {

                // the language that is suppose to be added in the table as new row
                var languageToBeAdded = {};
                languageToBeAdded.employeeId = 1;
                languageToBeAdded.fluency = $scope.language.fluency;
                var lang = {};
                var langid = $scope.language.languageId;
                lang.languageId = langid;
                lang.name = $scope.languagesMaster[langid].name;
                languageToBeAdded.language = lang;
                
                //$scope.languagesKnown.employee = $scope.employee;
                $scope.employeeLanguages.push(languageToBeAdded);
            }

            
        };

        init();
        function init() {
            getLanguages();
            if (!angular.isUndefined($routeParams.employeeId)) {
                getEmployeeLanguages($routeParams.employeeId);
            }

        }
        
        function getLanguages() {
            languageDataService.getLanguages().then(function (languages) {
                $scope.languagesMaster = languages.data;
            });
        }
        

        
        // gets the employee languages
        function getEmployeeLanguages(id) {
            employeePersonalDataservice.getLanguagesforEmployee(id).then(function (empLanguages) {
                if (!angular.isObject(empLanguages)) {
                    alert("Invalid Employee");
                    $location.path('/employees'); // TODO redirect to 404 page
                    return -1;
                }
                if (angular.isString(empLanguages.data.exceptionMessage)) {
                    alert(empLanguages.data.exceptionMessage); // TODO redirect to ERROR page
                    return -1;
                }
                $scope.employeeLanguages = empLanguages.data;
                return 1; //success
            }, processError);
        }
        
        // when promise is rejected or faulted
        function processError() {
            alert("Unable to reach the service end point");
        }
    }
    ]);
});