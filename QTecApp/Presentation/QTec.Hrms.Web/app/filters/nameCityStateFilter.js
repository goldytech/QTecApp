'use strict';

define(['app'], function (app) {
    app.filter('nameCityStateFilter', function () {
        return function (employees, filterValue) {
            if (!filterValue) return employees;

            var matches = [];
            filterValue = filterValue.toLowerCase();
            for (var i = 0; i < employees.length; i++) {
                var emp = employees[i];
                var empName = emp.firstName + ' ' + emp.lastName;
                if (emp.firstName.toLowerCase().indexOf(filterValue) > -1 ||
                    emp.lastName.toLowerCase().indexOf(filterValue) > -1 ||
                    empName.toLowerCase().indexOf(filterValue) > -1 ||
                    emp.designation.name.toLowerCase().indexOf(filterValue) > -1 
                    ) {

                    matches.push(emp);

                }
            }
            return matches;
        };
    });
});