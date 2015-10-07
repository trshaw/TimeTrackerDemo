/// <reference path="../angular.js" />
/// <reference path="Module.js" />
/// <reference path="Service.js" />


app.controller("timeEntryController", function ($scope, $http) {

    $scope.editMode = false;

    //Method to GET a single Project using ProjectID
    $scope.getOne = function (projectId) {
        $scope.editMode = true;
        $http.get("/api/Project/" + projectId).success(function (data) {
            $scope.projectId = data.projectId;
            $scope.projectCode = data.projectCode;
            $scope.projectName = data.projectName;
        });
    };

    // Method to GET all projects
    $scope.getAll = function () {
        $scope.projects = [];
        $http.get("/api/Project/").success(function (data) {
            $scope.projects = data;
        });
    };

    // Initialize the list of all projects
    $scope.getAll();

    // Method to POST
    $scope.saveTimeEntry = function () {
        var timeEntry = {
            projectId: $scope.projectId,
            employeeId: $scope.employeeId,
            timeDuration: $scope.timeDuration,
            isBillable: $scope.isBillable,
            description: $scope.description
        };
        $http.post("/api/TimeEntry/", timeEntry).success(function (data) {
            $scope.getAll();
            $scope.newMode = false;
            $scope.projectId = "";
            $scope.projectCode = "";
            $scope.employeeId = "";
            $scope.timeDuration = "";
            $scope.isBillable = false;
            $scope.description = "";
        });
        $scope.editMode = false;
    };

    // Display blank Project form
    $scope.showNewForm = function () {
        $scope.newMode = true;
        $scope.projectCode = "";
        $scope.projectName = "";
    };


    // Method to PUT

    // Method to DELETE

});


