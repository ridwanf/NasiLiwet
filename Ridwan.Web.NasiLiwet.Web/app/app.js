'use strict';

var liwetApp = angular.module('liwetApp', ['ngRoute']);

//config
liwetApp.config(["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/Home", {
            templateUrl: "/app/views/home.html",
            controller: "HomeController"
        })
         .when("/Home/Product", {
             templateUrl: "/app/views/product.html",
             controller: "ProductController"
         })
        
         .when("/Home/CaraPenyajian", {
             templateUrl: "/app/views/caraPenyajian.html",
             controller: "CaraPenyajianController"
         })
        .when("/Home/About", {
            templateUrl: "/app/views/about.html",
            controller: "AboutController"
        })
        .when("/Home/Contact", {
            templateUrl: "/app/views/contact.html",
            controller: "ContactController"
        })
        .otherwise({
            redirectTo: "/Home"
        });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);
