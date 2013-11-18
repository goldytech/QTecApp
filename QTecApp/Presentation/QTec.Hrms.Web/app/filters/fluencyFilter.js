'use strict';
define(['app'], function(app) {
    app.filter('languageFluency', function() {
        var languagefluencyFilter = function (input) {
            var fluency = parseInt(input);
            if (fluency === 0) {
                return 'Beginner';
            }
            if (fluency === 1) {
                return 'Intermediate';
            }
            if (fluency === 2) {
                return 'Expert';
            }
            return null;
        };
        return languagefluencyFilter;
    });
});