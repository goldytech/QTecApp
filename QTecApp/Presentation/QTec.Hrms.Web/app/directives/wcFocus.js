'use strict';
define(['app'], function(app) {
    app.directive('qtecFocus', ['$timeout','$parse', function($timeout,$parse) {
        return {
            link: function(scope, element, attrs) {
                var model = $parse(attrs.qtecFocus);
                scope.$watch(model, function(value) {
                 if (value === true) {
                        $timeout(function() {
                            element[0].focus();
                        });
                    }
                });
            }
        };
    }]);
});