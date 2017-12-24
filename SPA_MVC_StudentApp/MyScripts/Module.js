//Create angular module
var app = angular.module("ApplicationModule", ["ngRoute", "ui.grid", "ui.grid.resizeColumns","ui.grid.pagination"]);

//Create factory
app.factory("ShareData", function () {
    return { value: 0 };
});

//Create routeProvider

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    //debugger;
    $routeProvider.when('/showstudents',
        {
            templateUrl: 'ManageStudent/ShowAllStudent',
            controller: 'ShowStudentsController'
        });
    $routeProvider.when('/addstudent',
       {
           templateUrl: 'ManageStudent/AddStudent',
           controller: 'AddStudentController'
       });
    $routeProvider.when('/editstudent',
      {
          templateUrl: 'ManageStudent/EditStudent',
          controller: 'EditStudentController'
      });
    $routeProvider.when('/deletestudent',
      {
          templateUrl: 'ManageStudent/DeleteStudent',
          controller: 'DeleteStudentController'
      });
    $routeProvider.otherwise(
                       {
                           redirectTo: '/'
                       });


    $locationProvider.html5Mode(true).hashPrefix('!');
}]);