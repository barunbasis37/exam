// Install the angularjs.TypeScript.DefinitelyTyped NuGet package
var App;
(function (App) {
    "use strict";
    var M = App.Student;
    var StudentController = (function () {
        function StudentController($location, url, search, save, authService, $state, $stateParams) {
            this.$location = $location;
            this.Url = url;
            this.SearchService = search;
            this.SaveService = save;
            this.authService = authService;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Activate();
            // Arif Added Code - Start
            var acc = this.authService.AccountInfo;
            console.log(acc);
            if (acc && acc.IsAuth) {
                this.loadUser();
            }
            // Arif Added Code - End
        }
        StudentController.prototype.Activate = function () {
            this.IsUpdateMode = false;
            this.Models = [];
            this.Model = new M();
            this.TotalDue = 0;
            this.SearchRequest = new App.SearchRequest("", "Modified", "False", "");
            this.CommandUrl = this.Url.Student;
            this.QueryUrl = this.Url.StudentQueryData;
            this.Search();
        };
        StudentController.prototype.loadUser = function () {
            var self = this;
            self.User = this.authService.AccountInfo;
        };
        StudentController.prototype.Search = function () {
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.Models = response.Models;
                self.TotalDue = 0;
                for (var i = 0; i < self.Models.length; i++) {
                    self.TotalDue += self.Models[i].Due;
                }
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.QueryUrl).then(successCallback, errorCallback);
            var countSuccessCallback = function (response) {
                self.SearchRequest.TotalPage = Math.ceil(response.Data / 10);
            };
            var countErrorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.Url.StudentQueryCount).then(countSuccessCallback, countErrorCallback);
        };
        StudentController.prototype.Goto = function (page) {
            this.SearchRequest.Page = page;
            this.Search();
        };
        StudentController.prototype.Save = function () {
            var self = this;
            var successCallback = function (response) {
                self.Activate();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Save(self.Model, self.CommandUrl).then(successCallback, errorCallback);
        };
        StudentController.prototype.Update = function () {
            var self = this;
            var successCallback = function (response) {
                self.Activate();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Update(self.Model, self.CommandUrl).then(successCallback, errorCallback);
        };
        StudentController.prototype.Edit = function (p) {
            this.Model = p;
            this.IsUpdateMode = true;
        };
        StudentController.prototype.Delete = function (id) {
            var self = this;
            var successCallback = function (response) {
                self.Activate();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Delete(id, self.CommandUrl).then(successCallback, errorCallback);
        };
        StudentController.prototype.History = function (p) {
            var self = this;
            self.stateService.go('root.studenthistory', { student: { Id: p.Id, Name: p.Name, Address: p.Address, Phone: p.Phone, Company: p.DepartmentName } });
        };
        StudentController.prototype.Report = function () {
            var self = this;
            window.open(self.Url.StudentQueryReport, "_blank", "");
        };
        StudentController.$inject = ["$location", "UrlService", "SearchService", "SaveService", "AuthService", "$state", "$stateParams"];
        return StudentController;
    })();
    App.StudentController = StudentController;
    angular.module("app").controller("StudentController", StudentController);
})(App || (App = {}));
//# sourceMappingURL=StudentController.js.map