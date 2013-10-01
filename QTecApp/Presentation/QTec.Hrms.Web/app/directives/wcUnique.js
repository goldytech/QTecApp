'use strict';

define(['app'], function (app) {

    app.directive('qtecUnique', ['dataService', function (dataService) {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                element.bind('blur', function (e) {
                    if (!ngModel || !element.val()) return;
                    var currentValue = element.val();
                    dataService.checkUniqueValue(currentValue)
                        .then(function (unique) {
                            //Ensure value that being checked hasn't changed
                            //since the Ajax call was made
                            if (currentValue == element.val()) {
                                ngModel.$setValidity('unique', !unique);
                            }
                        }, function () {
                            //Probably want a more robust way to handle an error
                            //For this demo we'll set unique to false though
                            ngModel.$setValidity('unique', false);
                        });
                });
            }
        }
    }]);

});