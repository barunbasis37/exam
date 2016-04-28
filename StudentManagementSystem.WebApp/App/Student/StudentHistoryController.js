var App;
(function (App) {
    var StudentHistoryController = (function () {
        function StudentHistoryController($location, url, search, save, dropdownService, $state, $stateParams) {
            this.$location = $location;
            this.Url = url;
            this.SearchService = search;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Dropdown = new Object();
            this.DropdownService = dropdownService;
            this.Activate();
        }
        StudentHistoryController.prototype.Activate = function () {
            this.Model = new App.StudentHistory();
            this.Student = new App.Student();
            var student = this.stateParams["student"];
            if (student != undefined) {
                this.Student = student;
                this.SearchRequest = new App.SearchRequest("", "Modified", "False");
                this.SearchRequest.Id = student.Id;
            }
            else {
                alert("Invalid student");
                this.stateService.go('root.student');
            }
            this.QueryUrl = this.Url.StudentHistoryQuery;
            this.Search();
        };
        StudentHistoryController.prototype.Search = function () {
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
        StudentHistoryController.prototype.LoadDropdown = function (name) {
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
        StudentHistoryController.$inject = ["$location", "UrlService", "SearchService", "SaveService", "DropdownService", "$state", "$stateParams"];
        return StudentHistoryController;
    })();
    App.StudentHistoryController = StudentHistoryController;
    angular.module("app").controller("StudentHistoryController", StudentHistoryController);
})(App || (App = {}));
//# sourceMappingURL=StudentHistoryController.js.map