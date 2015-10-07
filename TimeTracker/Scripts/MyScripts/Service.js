/// <reference path="../angular.js" />
/// <reference path="Module.js" />

app.service('crudService', function ($http) {
    //Get single record
    this.get = function (employeeId) {
        return $http.get("/api/Employee/" + employeeId);
        }
    }
)
