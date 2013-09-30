
'use strict';

define([], function () {

    var app = angular.module('QTec', ['ngRoute', 'ngAnimate', 'qtec.Directives', 'qtec.Animations', 'ui.bootstrap']);

    app.config(['$routeProvider',  '$controllerProvider', '$compileProvider', '$filterProvider', '$provide', '$httpProvider',
        function ($routeProvider, $controllerProvider, $compileProvider, $filterProvider, $provide, $httpProvider) {

            

            app.register =
            {
                controller: $controllerProvider.register,
                directive: $compileProvider.directive,
                filter: $filterProvider.register,
                factory: $provide.factory,
                service: $provide.service
            };

            

            $routeProvider.when('/', {
                templateUrl: '/Personal/Employees',
                controller: 'EmployeesController'
            });
            $routeProvider.when('/about', {
                templateUrl: '/Personal/About',
                controller: 'AboutController'
            });
            //$routeProvider.when('/QReports/EmpFilterRpt', {
            //    templateUrl: '/reports/EmployeeFilterReport',
            //    controller: 'empRptCtrlr'
            //});
            //$routeProvider.when('/detail/:id', {
            //    templateUrl: '/Home/Edit',
            //    controller: 'editCtrlr'
            //});
            //$routeProvider.when('/edit/:id', {
            //    templateUrl: '/Home/Edit',
            //    controller: 'editCtrl'
            //});
            //$routeProvider.when('/create', {
            //    templateUrl: '/Home/Edit',
            //    controller: 'editCtrlr'
            //});
            //$routeProvider.when('/delete/:id', {
            //    templateUrl: '/Home/Detail',
            //    controller: 'detailCtrl',
            //    isDeleteRequested: true
            //});
            $routeProvider.otherwise({
                redirectTo: '/'
            });

    }]);

    

    return app;
});





