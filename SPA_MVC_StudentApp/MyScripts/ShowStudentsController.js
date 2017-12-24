app.controller("ShowStudentsController", function ($scope, $location,SPACRUDService, ShareData) {
    loadAllStudentRecords();
    var editTemplate = '<button class="btn primary" ng-click="grid.appScope.editstudent(row.entity.StudentId)">Edit</button>';
    var deleteTemplate = '<button class="btn primary" ng-click="grid.appScope.deletestudent(row.entity.StudentId)">Delete</button>';
   // $event.preventDefault();
    $scope.gridOptions = {
        paginationPageSizes: [10, 20, 30],
        paginationPageSize: 5,
        enableSorting: true,
        enableColumnResizing: true,
        enableFiltering: true,
        columnDefs: [

        { field: 'StudentId' },

        { field: 'Name', width : '10%'},

        { field: 'Email', width: '15%' },
        { field: 'Class', enableColumnResizing: false},
        { field: 'EnrollYear', enableColumnResizing: false },
        { field: 'City', enableSorting: false, enableColumnResizing: false },
        { field: 'Country', enableSorting: false, enableColumnResizing: false },
        { field: 'Edit',  cellTemplate: editTemplate, enableSorting: false, enableColumnResizing: false, enableFiltering: false, },
        { field: 'Delete', cellTemplate: deleteTemplate, enableSorting: false, enableColumnResizing: false, enableFiltering: false }
        ],
        onRegisterApi: function (gridApi) {

            $scope.grid1Api = gridApi;

        }
    };



    function loadAllStudentRecords()
    {
        //get student details from HTTP service via web api
        var tempGetStudents = SPACRUDService.getStudents(); 
        tempGetStudents.then(function (param) {

           // $scope.students = param.data;
            $scope.gridOptions.data = param.data;
        },
        function(errorparam){
            $scope.error = errorparam;
        });
    }

    // Edit a student 
    $scope.editstudent = function (StudentID) {
        ShareData.value = StudentID;
        $location.path("/editstudent");
    }

    //Delete a student
    $scope.deletestudent = function (StudentID) {
        ShareData.value = StudentID;
        $location.path("/deletestudent");
    }


});