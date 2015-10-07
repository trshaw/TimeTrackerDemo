/// <reference path="../angular.js" />
/// <reference path="Module.js" />
/// <reference path="Service.js" />


app.controller("loginController", function ($scope, $http) {

    // Experimenting with POST to login
    $scope.login = function () {
        var email = {email: $scope.email}
        $http.post("/api/Login/", email).success(function (data) {
            $scope.employeeId = data.employeeId;
            $scope.firstName = data.firstName;
            $scope.lastName = data.lastName;
            $scope.email = data.email;
            $scope.phoneNumber = data.phoneNumber;
            $scope.isManager = data.isManager;
            $scope.timeEntries = data.timeEntries;
        });
    };

});


