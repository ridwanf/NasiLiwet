

liwetApp.controller('ContactController', ["$scope", "$http", "$window", function ($scope, $http, $window) {
    $scope.newContact = {};

    $scope.submit = function() {
        debugger;
        $http.post("/api/product", $scope.newContact)
            .then(function(result) {
                alert("success send email");
                $window.location = "/Home/Product";
            },
                function() {
                    alert("cannot send email");
                }
            );
    };
}]);