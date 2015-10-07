/// <reference path="../angular.js" />
/// <reference path="Module.js" />
/// <reference path="Service.js" />


app.controller("projectController", function ($scope, $http) {

    $scope.editMode = false;
    $scope.newMode = false;

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
    $scope.saveProject = function () {
        var project = {
            projectCode: $scope.projectCode,
            projectName: $scope.projectName,
        };
        $http.post("/api/Project/", project).success(function (data) {
            $scope.getAll();
            $scope.newMode = false;
        });
    };

    // Display blank Project form
    $scope.showNewForm = function () {
        $scope.newMode = true;
        $scope.projectCode = "";
        $scope.projectName = "";
    };


    // Method to PUT
    $scope.updateProject = function () {
        var project = {
            projectId: $scope.projectId,
            projectCode: $scope.projectCode,
            projectName: $scope.projectName,
        };
        $http.put("/api/Project/" + project.projectId, project).success(function (data) {
            $scope.getAll();
            $scope.editMode = false;
        });
    };

    // Method to DELETE

});


