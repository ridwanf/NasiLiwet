'use strict';

liwetApp.controller('HomeController', ["$scope", "$http", function ($scope, $http) {
    $scope.data = [];

    $http.get("/api/product?isRandom=true")
        .then(function (result) {
            //successful
            angular.copy(result.data, $scope.data);
        },
            function () {
                //error
            }
        );

}]);