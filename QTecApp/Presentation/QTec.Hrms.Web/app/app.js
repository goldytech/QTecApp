
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

            

            $routeProvider
                .when('/employees', route.resolve('Customers', 'employees/'))
                .when('/customerorders/:customerID', route.resolve('CustomerOrders', 'employees/'))
                .when('/customeredit/:customerID', route.resolve('CustomerEdit', 'employees/'))
                .when('/orders', route.resolve('Orders', 'orders/'))
                .when('/about', route.resolve('About'))
                .otherwise({ redirectTo: '/employees' });

    }]);

    

    return app;
});





