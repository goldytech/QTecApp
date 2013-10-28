'use strict';
define(['app'], function(app) {
    app.directive('jqdatepicker', [], function() {
        return {
            // Enforce the angularJS default of restricting the directive to
            // attributes only
            restrict: 'A',
            // Always use along with an ng-model
            require: '?ngModel',
            // This method needs to be defined and passed in from the
            // passed in to the directive from the view controller
            scope: {
                close: '&'        // Bind the close function we refer to the right scope
            },
            link: function (scope, element, attrs, ngModel) {
                if (!ngModel) return;
                alert(ngModel);
                var optionsObj = {};

                optionsObj.dateFormat = 'MM yy';
                optionsObj.changeMonth = true;
                optionsObj.changeYear = true;
                optionsObj.showButtonPanel = true;
                var updateModel = function (dateTxt) {
                    scope.$apply(function () {
                        // Call the internal AngularJS helper to
                        // update the two way binding
                        ngModel.$setViewValue(dateTxt);
                    });
                };

                optionsObj.onClose = function (dateTxt, picker) {
                    updateModel(dateTxt);
                    if (scope.close) {
                        scope.$apply(function () {
                            scope.close({ date: dateTxt });
                        });
                    }
                };

                ngModel.$render = function () {
                    // Use the AngularJS internal 'binding-specific' variable
                    element.datepicker('setDate', ngModel.$viewValue || '');
                };
                element.datepicker(optionsObj);
            }
        };
    });
});