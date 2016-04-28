// Install the angularjs.TypeScript.DefinitelyTyped NuGet package
var App;
(function (App) {
    "use strict";
    var CollectionController = (function () {
        function CollectionController($location, url, search, save, authService, dropdown, $state, $stateParams) {
            this.$location = $location;
            this.Url = url;
            this.SearchService = search;
            this.SaveService = save;
            this.authService = authService;
            this.DropdownService = dropdown;
            this.IsUpdateMode = false;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Activate();
            var acc = this.authService.AccountInfo;
            if (acc && acc.IsAuth) {
                this.loadUser();
            }
        }
        CollectionController.prototype.Activate = function () {
            console.log('i m in CollectionController');
            this.Models = [];
            // this.Suppliers = [];
            this.Dropdown = new Object();
            this.Model = new App.Collection();
            this.TotalCollection = 0;
            this.SearchRequest = new App.SearchRequest("", "Modified", "False", "");
            this.Search();
            this.LoadDropdown("student");
        };
        CollectionController.prototype.loadUser = function () {
            var self = this;
            self.User = this.authService.AccountInfo;
        };
        CollectionController.prototype.LoadDropdown = function (name) {
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.Dropdown[name] = response.Models;
                console.log(self.Dropdown);
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.DropdownService.Load(name).then(successCallback, errorCallback);
        };
        CollectionController.prototype.Search = function () {
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.Models = response.Models;
                self.TotalCollection = 0;
                for (var i = 0; i < self.Models.length; i++) {
                    self.TotalCollection += self.Models[i].Total;
                }
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.Url.CollectionQueryData).then(successCallback, errorCallback);
            var countSuccessCallback = function (response) {
                self.SearchRequest.TotalPage = Math.ceil(response.Data / 10);
            };
            var countErrorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.Url.CollectionQueryCount).then(countSuccessCallback, countErrorCallback);
        };
        CollectionController.prototype.Goto = function (page) {
            this.SearchRequest.Page = page;
            this.Search();
        };
        CollectionController.prototype.Save = function () {
            var _this = this;
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.Model = new App.Collection();
                _this.Search();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Save(self.Model, self.Url.Collection).then(successCallback, errorCallback);
        };
        CollectionController.prototype.Update = function () {
            var _this = this;
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.IsUpdateMode = false;
                self.Model = new App.Collection();
                _this.Search();
            };
            var errorCallback = function (error) {
                console.log(error);
                _this.Search();
            };
            self.SaveService.Update(self.Model, self.Url.Collection).then(successCallback, errorCallback);
        };
        CollectionController.prototype.Edit = function (p) {
            this.Model = p;
            this.IsUpdateMode = true;
        };
        CollectionController.prototype.Delete = function (id) {
            var _this = this;
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.IsUpdateMode = false;
                self.Model = new App.Collection();
                _this.Search();
            };
            var errorCallback = function (error) {
                console.log(error);
                _this.Search();
            };
            self.SaveService.Delete(id, self.Url.Collection).then(successCallback, errorCallback);
        };
        CollectionController.prototype.AddDetail = function (p) {
            var self = this;
            self.stateService.go('root.collectiondetails', { collection: { Id: p.Id, Memo: p.Memo, Total: p.Total } });
        };
        CollectionController.prototype.UpdateDate = function () {
            var object = this.SearchRequest['Start'];
            if (object) {
                this.SearchRequest.StartDate = object.toDateString();
            }
            var object1 = this.SearchRequest['End'];
            if (object1) {
                this.SearchRequest.EndDate = object1.toDateString();
            }
            console.log(this.SearchRequest);
        };
        CollectionController.prototype.Report = function () {
            var self = this;
            window.open(self.Url.CollectionQueryReport, "_blank", "");
        };
        CollectionController.$inject = ["$location", "UrlService", "SearchService", "SaveService", "AuthService", "DropdownService", "$state", "$stateParams"];
        return CollectionController;
    })();
    App.CollectionController = CollectionController;
    angular.module("app").controller("CollectionController", CollectionController);
})(App || (App = {}));
//# sourceMappingURL=CollectionController.js.map