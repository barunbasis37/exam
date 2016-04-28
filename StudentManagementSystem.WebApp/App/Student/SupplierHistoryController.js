var App;
(function (App) {
    var SupplierHistoryController = (function () {
        function SupplierHistoryController($location, url, search, save, dropdownService, $state, $stateParams) {
            this.$location = $location;
            this.Url = url;
            this.SearchService = search;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Dropdown = new Object();
            this.DropdownService = dropdownService;
            this.Activate();
        }
        SupplierHistoryController.prototype.Activate = function () {
            this.Model = new SupplierHistory();
            this.Supplier = new Supplier();
            var supplier = this.stateParams["supplier"];
            if (supplier != undefined) {
                this.Supplier = supplier;
                this.SearchRequest = new App.SearchRequest("", "Modified", "False");
                this.SearchRequest.Id = supplier.Id;
            }
            else {
                alert("Invalid supplier");
                this.stateService.go('root.suppliers');
            }
            this.QueryUrl = this.Url.SupplierHistoryQuery;
            this.Search();
        };
        SupplierHistoryController.prototype.Search = function () {
            var _this = this;
            var self = this;
            var successCallback = function (response) {
                console.log(response);
                _this.Model = (response.Data);
            };
            var errorCallback = function (error) {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.QueryUrl).then(successCallback, errorCallback);
        };
        SupplierHistoryController.prototype.LoadDropdown = function (name) {
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
        SupplierHistoryController.$inject = ["$location", "UrlService", "SearchService", "SaveService", "DropdownService", "$state", "$stateParams"];
        return SupplierHistoryController;
    })();
    App.SupplierHistoryController = SupplierHistoryController;
    angular.module("app").controller("SupplierHistoryController", SupplierHistoryController);
})(App || (App = {}));
