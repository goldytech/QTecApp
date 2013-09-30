
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
        'services/dataService',
        'services/modalService',
        'filters/nameCityStateFilter',
        'controllers/navbarController',
        'controllers/personal/employeesController',
        'controllers/personal/employeeEditController'
        
    ],
    function () {
        angular.bootstrap(document, ['QTec']);
    });
