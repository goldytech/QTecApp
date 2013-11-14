'use strict';
define(['app'], function (app) {
    app.factory('LanguageDataService', ['$http',  function ($http) {
        var languageDataService = {};
        var baseUrl = '/api/languages/';
        languageDataService.getLanguages = function () {
            return $http({ method: 'GET', url: baseUrl }).
                success(function (data, status, headers, config) {
                    return data;
                }).
                error(function (data, status, headers, config) {
                    return data;
                });
        };

        return languageDataService;
    }]);
});






