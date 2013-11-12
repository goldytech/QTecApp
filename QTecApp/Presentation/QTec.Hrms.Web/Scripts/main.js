require.config({
    baseUrl: '../app',
    urlArgs: 'v=1.0'
});

require(
    [
        'animations/listAnimations',
        'app',
        'directives/wcUnique',
        'directives/wcOverlay',
        'directives/wcFocus',
        'directives/wcjqDatePicker',
        'directives/wchrmsMenu',
        'services/dataService',
        'services/modalService',
        'services/configService',
        'filters/nameCityStateFilter',
        'controllers/navbarController',
        'controllers/personal/employeesController',
        'controllers/personal/employeeEditController',
        'controllers/security/menuController'
        
    ],
    function () {
        angular.bootstrap(document, ['QTec']);
    });
