'use strict';
define(['app'], function(app) {
    app.controller('EmployeeLanguagesController', ['$scope', '$routeParams', 'LanguageDataService','EmployeeDataService','$rootScope', function ($scope, $routeParams,languageDataService,employeePersonalDataservice,$rootScope) {

        // for language object binded to form
        $scope.language = {};
        
        // for binding the grid in the form
        $scope.employeeLanguages = [];

        // for filling the drop down list of language
        $scope.languagesMaster = [];

        $scope.addLanguage = function () {

            // Boolean variable to check availability of record
             var available;

            // Check weather record is available or not. If record is available then update record
            available = Enumerable.From($scope.employeeLanguages).Any(function(x) {
                return x.languageName === getLanguageName($scope.language.languageId);
            });
            //for (var m = 0; m < $scope.employeeLanguages.length; m++) {
            //    if ($scope.employeeLanguages[m].languageId === $scope.language.languageId) {
            //        $scope.employeeLanguages[m] = $scope.language;
            //        available = true;
            //    }
            //}

            // If record is not available then add it
            if (!available) {

                // the language that is suppose to be added in the table as new row
                var languageToBeAdded = {};
                languageToBeAdded.employeeId = $scope.language.employeeId;
                languageToBeAdded.fluency = $scope.language.fluency;
                languageToBeAdded.languageId = $scope.language.languageId;
                languageToBeAdded.languageName = getLanguageName($scope.language.languageId);
                
               
                
                //$scope.languagesKnown.employee = $scope.employee;
                $scope.employeeLanguages.push(languageToBeAdded);
            }

            
        };

        $scope.reset = function() {
            //alert($scope.language.languageId);
            var selectedLanguage = Enumerable.From($scope.languagesMaster).Where(function(x) {
              return  x.languageId === $scope.language.languageId;
            });

            $scope.language.languageName = selectedLanguage.name;
        };

        $scope.selectLanguage = function (index) {
            $scope.language = $scope.employeeLanguages[index];
        };

        $scope.saveLanguage = function() {
            $rootScope.$broadcast("updateEmployeeLanguages", $scope.employeeLanguages);
        };
        
        $scope.deleteLanguage = function (index) {
            $scope.employeeLanguages.splice(index, 1);
        };

        init();
        function init() {
            getLanguages();
            if (!angular.isUndefined($routeParams.employeeId)) {
                getEmployeeLanguages($routeParams.employeeId);
            }

        }
        
        function getLanguageName(id) {
            for (var i = 0; i < $scope.languagesMaster.length; i++) {
                if ($scope.languagesMaster[i].languageId === id)
                    return $scope.languagesMaster[i].name;


            }
            return '';
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
                $scope.language.employeeId = $scope.employeeLanguages[0].employeeId;
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