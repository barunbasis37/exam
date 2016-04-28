module App{
    export class StudentHistoryController {

        SearchService: SearchService;
        Url: UrlService;
        SearchRequest: SearchRequest;
        Model: StudentHistory;
        Dropdown: Object;
        DropdownService: DropdownService;
        QueryUrl: string;
        Student: Student;

        private stateService: angular.ui.IStateService;
        private stateParams: angular.ui.IStateParamsService;

        static $inject: string[] = ["$location", "UrlService", "SearchService", "SaveService", "DropdownService", "$state", "$stateParams"];

        constructor(private $location: angular.ILocationService, url: UrlService, search: SearchService, save: SaveService, dropdownService: DropdownService, $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {
            this.Url = url;
            this.SearchService = search;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Dropdown = new Object();
            this.DropdownService = dropdownService;
            this.Activate();
        }

        Activate() {
            this.Model = new StudentHistory();
            this.Student = new Student();
            var student = this.stateParams["student"];
            if (student != undefined) {
                this.Student = student;
                this.SearchRequest = new SearchRequest("", "Modified", "False");
                this.SearchRequest.Id = student.Id;
            } else {
                alert("Invalid student");
                this.stateService.go('root.student');
            }
            this.QueryUrl = this.Url.StudentHistoryQuery;
            this.Search();       
        }

        Search(): void {
            var self = this;
            var successCallback = (response: SearchResponse): void => {
                console.log(response);
                this.Model = (response.Data);
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.QueryUrl).then(<any>successCallback, errorCallback);
        }           

        LoadDropdown(name: string): void {
            var self = this;
            var successCallback = (response: SearchResponse): void => {
                console.log(response);
                self.Dropdown[name] = response.Models;
                console.log(self.Dropdown);
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };

            self.DropdownService.Load(name).then(<any>successCallback, errorCallback);
        }
    }
    angular.module("app").controller("StudentHistoryController", StudentHistoryController);

}