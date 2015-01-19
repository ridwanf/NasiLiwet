'use strict';

liwetApp.controller('ProductController', ["$scope", "$http", function ($scope, $http) {
    $scope.data = [];
    function chunk(arr, size) {
        var newArr = [];
        for (var i = 0; i < arr.length; i += size) {
            newArr.push(arr.slice(i, i + size));
        }
        return newArr;
    }


    $http.get("/api/product?isRandom=false")
        .then(function (result) {
            //successful
            angular.copy(result.data, $scope.data);
            $scope.chunkedData = chunk($scope.data, 3);

        },
            function () {
                //error
            }
        );

    //$scope.getDetail = function (id) {
    //    $http.get("/api/product/" + id)
    //        .then(function(result) {
    //            //successful
    //            angular.copy(result.data, $scope.detail);
    //        },
    //            function() {
    //                //error
    //            }
    //        );
        
    //    resolve:{
    //        detail:function () {
    //            return $scope.detail;
    //        }
    //    }
    //};


}]);