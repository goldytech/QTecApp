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
        'services/employeepersonalService',
        'services/languageService',
        'services/modalService',
        'services/configService',
        'filters/nameCityStateFilter',
        'filters/fluencyFilter',
        'controllers/navbarController',
        'controllers/personal/employeesController',
        'controllers/personal/employeeEditNewController',
        'controllers/personal/employeePersonalController',
        'controllers/personal/employeeLanguagesController',
        'controllers/personal/employeeEditController',
        'controllers/security/menuController'
        
    ],
    function () {
        angular.bootstrap(document, ['QTec']);
    });
