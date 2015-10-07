/// <reference path="../angular.js" />
/// <reference path="Module.js" />
/// <reference path="Service.js" />


app.controller("employeeController", function ($scope, $http) {

    $scope.editMode = false;
    $scope.newMode = false;

    //Method to GET a single Employee using EmployeeID
    $scope.getOne = function (employeeId) {
        $scope.editMode = true;
        $scope.timeEntries = [];
        $http.get("/api/Employee/" + employeeId).success(function (data) {
            $scope.employeeId = data.employeeId;
            $scope.firstName = data.firstName;
            $scope.lastName = data.lastName;
            $scope.email = data.email;
            $scope.phoneNumber = data.phoneNumber;
            $scope.isManager = data.isManager;
            $scope.timeEntries = data.timeEntries;
        });
    };

    // Method to GET all employees
    $scope.getAll = function () {
        $scope.employees = [];
        $http.get("/api/Employee/").success(function (data) {
            $scope.employees = data;
        });
    };
    
    // Initialize the list of all employees
    $scope.getAll();

    // Method to POST
        $scope.saveEmployee = function () {
        var employee = {
            firstName: $scope.firstName,
            lastName: $scope.lastName,
            email: $scope.email,
            phoneNumber: $scope.phoneNumber,
            isManager: $scope.isManager
        };
        $http.post("/api/Employee/", employee).success(function (data) {
            $scope.getAll();
            $scope.newMode = false;
        });
    };

    // Display blank Employee form
        $scope.showNewForm = function () {
            $scope.newMode = true;
            $scope.firstName = "";
            $scope.lastName = "";
            $scope.email = "";
            $scope.phoneNumber = "";
            $scope.isManager = false;
        };


    // Method to PUT
    $scope.updateEmployee = function () {
        var employee = {
            employeeId: $scope.employeeId,
            firstName: $scope.firstName,
            lastName: $scope.lastName,
            email: $scope.email,
            phoneNumber: $scope.phoneNumber,
            isManager: $scope.isManager,
            isTerminated: $scope.isTerminated
        };
        $http.put("/api/Employee/" + employee.employeeId, employee).success(function (data) {
            $scope.getAll();
            $scope.editMode = false;
        });
    };

    // Method to DELETE
    // Nothing goes here -- employees are Terminated, and not deleted

    // TO DO
    // Implement isTerminated functionality

 });

        
