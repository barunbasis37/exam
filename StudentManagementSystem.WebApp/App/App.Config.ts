module App {
    "use strict";

    export class AppConfig {

        static $inject = ["$stateProvider", "$urlRouterProvider"];

        constructor($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) {
            console.log("I am in config constructor.");
            $urlRouterProvider.otherwise("/");
            $stateProvider
                .state("root", {
                    abstract: true,
                    url: "",
                    template: "<div ui-view class=\"container-fluid slide\"></div>"
                })
                .state("root.home", {
                    url: "/",
                    templateUrl: "partials/home/home.tpl.html",
                    controller: "HomeController",
                    controllerAs:"vm"                    
                })
                  
                .state("root.signin", {
                    url: "/signin",
                    templateUrl: "partials/account/signin.tpl.html",
                    controller: "SigninController",
                    controllerAs: "vm"
                })
                .state("root.register", {
                    url: "/register",
                    templateUrl: "partials/account/register.tpl.html",
                    controller: "RegisterController",
                    controllerAs: "vm"
                })
                .state("root.profile", {
                    url: "/profile",
                    templateUrl: "partials/account/profile.tpl.html",
                    controller: "ProfileController",
                    controllerAs: "vm"
                })
                .state("root.denied", {
                    url: "/denied",
                    template: '<h1>Access Denied <a ui-sref="root.home"> back to home </a></h1>'
                })

                //business states
                .state("root.fees", {
                    url: "/fees",
                    templateUrl: "partials/fees/fees.tpl.html",
                    controller: "FeesController",
                    controllerAs: "vm"
                })
                .state("root.student", {
                    url: "/student",
                    templateUrl: "partials/student/student.tpl.html",
                    controller: "StudentController",
                    controllerAs: "vm"
                })
                .state("root.studenthistory", {
                    url: "/student-history",
                    params: {supplier: null},
                    templateUrl: "partials/student/student-history.tpl.html",
                    controller: "StudentHistoryController",
                    controllerAs: "vm"
                })
                .state("root.collection", {
                    url: "/collection",
                    templateUrl: "partials/collection/collections.tpl.html",
                    controller: "CollectionController",
                    controllerAs: "vm"
                })
                .state("root.collectiondetails", {
                    url: "/collection-details",
                    params: {purchase: null},
                    templateUrl: "partials/collection/collection-details.tpl.html",
                    controller: "CollectionDetailsController",
                    controllerAs: "vm"
                })
                .state("root.payments", {
                    url: "/payments",
                    templateUrl: "partials/payment/payments.tpl.html",
                    controller: "PaymentsController",
                    controllerAs: "vm"
                })
                ;
            $urlRouterProvider.otherwise("/");
        }
    }
    angular.module("app", ["ngResource","ngAnimate", "ui.router","ui.bootstrap", "LocalStorageModule"]);
    angular.module("app").config(AppConfig);    
}