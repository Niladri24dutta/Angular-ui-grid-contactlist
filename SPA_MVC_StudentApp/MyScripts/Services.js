app.service("SPACRUDService", function ($http) {

    //Function to get all students
    this.getStudents = function () {

        return $http.get("/api/ManageStudentInfo");
    };

    //Function to get single student based on ID

    this.getStudent = function (id) {

        return $http.get("/api/ManageStudentInfo/" + id);

    };

});