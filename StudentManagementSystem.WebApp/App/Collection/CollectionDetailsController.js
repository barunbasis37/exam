var App;
(function (App) {
    var CollectionDetailsController = (function () {
        function CollectionDetailsController($location, url, search, save, dropdownService, $state, $stateParams) {
            this.$location = $location;
            this.Url = url;
            this.SearchService = search;
            this.SaveService = save;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Dropdown = new Object();
            this.DropdownService = dropdownService;
            this.Activate();
        }
        CollectionDetailsController.prototype.Activate = function () {
            this.IsUpdateMode = false;
            this.Models = [];
            this.Model = new App.CollectionDetail();
            this.Fees = [];
            this.Fee = new App.Fee();
            this.CommandUrl = this.Url.CollectionDetail;
            this.QueryUrl = this.Url.CollectionDetailQuery;
            var collection = this.stateParams["Collection"];
            if (collection != undefined) {
                this.Parent = collection;
                this.Model.CollectionId = collection.Id;
                this.SearchRequest = new App.SearchRequest("", "Modified", "False", this.Model.CollectionId);
            }
            else {
                alert("Invalid purchase");
                this.stateService.go('root.collection');
            }
            this.Search();
            this.LoadDropdown("fee");
            this.LoadDropdown('student');
        };
        CollectionDetailsController.prototype.Search = function () {
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.Models = response.Models;
                self.Parent.Total = 0;
                for (var i = 0; i < self.Models.length; i++) {
                    var m = self.Models[i];
                    self.Parent.Total += parseFloat(m["Total"]);
                }
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.QueryUrl).then(successCallback, errorCallback);
        };
        CollectionDetailsController.prototype.SearchProduct = function () {
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                self.Fees = (response.Models);
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.Url.FeeQueryData).then(successCallback, errorCallback);
        };
        CollectionDetailsController.prototype.Save = function () {
            var self = this;
            var successCallback = function (response) {
                self.Activate();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Save(self.Model, self.CommandUrl).then(successCallback, errorCallback);
        };
        CollectionDetailsController.prototype.Update = function () {
            var self = this;
            var successCallback = function (response) {
                self.Activate();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Update(self.Model, self.CommandUrl).then(successCallback, errorCallback);
        };
        CollectionDetailsController.prototype.Edit = function (p) {
            this.Model = p;
            this.IsUpdateMode = true;
        };
        CollectionDetailsController.prototype.Delete = function (id) {
            var self = this;
            var successCallback = function (response) {
                self.Activate();
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SaveService.Delete(id, self.CommandUrl).then(successCallback, errorCallback);
        };
        CollectionDetailsController.prototype.LoadDropdown = function (name) {
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
        CollectionDetailsController.prototype.Select = function (p) {
            console.log(p);
            this.Model.FeeId = p.Id;
            this.Fee = p;
            this.Model.Price = p.Amount;
            console.log(this.Model);
        };
        CollectionDetailsController.$inject = ["$location", "UrlService", "SearchService", "SaveService", "DropdownService", "$state", "$stateParams"];
        return CollectionDetailsController;
    })();
    App.CollectionDetailsController = CollectionDetailsController;
    angular.module("app").controller("CollectionDetailsController", CollectionDetailsController);
})(App || (App = {}));
//# sourceMappingURL=CollectionDetailsController.js.map