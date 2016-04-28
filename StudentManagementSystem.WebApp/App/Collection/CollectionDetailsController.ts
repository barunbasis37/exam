module App {

    export class CollectionDetailsController {

        SearchService: SearchService;
        SaveService: SaveService;
        Url: UrlService;
        SearchRequest: SearchRequest;
        IsUpdateMode: boolean;
        Models: Object[];
        Model: CollectionDetail;
        Parent: Collection;
        Fees:Fee[];
        Fee: Fee;
        Dropdown: Object;
        DropdownService: DropdownService;
        CommandUrl: string;
        QueryUrl: string;
        private stateService: angular.ui.IStateService;
        private stateParams: angular.ui.IStateParamsService;

        static $inject: string[] = ["$location", "UrlService", "SearchService", "SaveService","DropdownService", "$state", "$stateParams"];

        constructor(private $location: angular.ILocationService, url: UrlService, search: SearchService, save: SaveService, dropdownService: DropdownService, $state: angular.ui.IStateService,  $stateParams: angular.ui.IStateParamsService) {
            this.Url = url;
            this.SearchService = search;
            this.SaveService = save;
            this.stateService = $state;
            this.stateParams = $stateParams;
            this.Dropdown = new Object();
            this.DropdownService = dropdownService;
            this.Activate();
        }

        Activate() {
            this.IsUpdateMode = false;
            this.Models = [];
            this.Model = new CollectionDetail();
            this.Fees = [];
            this.Fee = new Fee();
            this.CommandUrl = this.Url.CollectionDetail;
            this.QueryUrl = this.Url.CollectionDetailQuery;
            var collection = this.stateParams["Collection"];
            if (collection != undefined) {
                this.Parent = collection;
                this.Model.CollectionId = collection.Id;
                this.SearchRequest = new SearchRequest("", "Modified", "False", this.Model.CollectionId);
            } else {
                alert("Invalid purchase");
                this.stateService.go('root.collection');
            }
            this.Search();
            this.LoadDropdown("fee");
            this.LoadDropdown('student');
        }

        Search(): void {
            var self = this;
            var successCallback = (response: SearchResponse): void => {
                console.log(response);
                self.Models = response.Models;
                self.Parent.Total = 0;

                for (var i = 0; i < self.Models.length; i++) {
                    var m = self.Models[i];
                    self.Parent.Total += parseFloat(m["Total"]);
                }
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.QueryUrl).then(<any>successCallback, errorCallback);
        }

        SearchProduct(): void {
            var self = this;
            var successCallback = (response: SearchResponse): void => {
                console.log(response);
                self.Fees = <any>(response.Models);                
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };
            self.SearchService.Search(self.SearchRequest, self.Url.FeeQueryData).then(<any>successCallback, errorCallback);
        }

        Save(): void {
            var self = this;
            var successCallback = (response: BaseResponse): void => {
                self.Activate();
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };

            self.SaveService.Save(self.Model, self.CommandUrl).then(<any>successCallback, errorCallback);
        }

        Update(): void {
            var self = this;
            var successCallback = (response: BaseResponse): void => {
                self.Activate();
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };

            self.SaveService.Update(self.Model, self.CommandUrl).then(<any>successCallback, errorCallback);
        }

        Edit(p: CollectionDetail): void {
            this.Model = p;
            this.IsUpdateMode = true;
        }

        Delete(id: string): void {
            var self = this;
            var successCallback = (response: BaseResponse): void => {
                self.Activate();
            };
            var errorCallback = (error: any): void => {
                console.log(error);
            };
            self.SaveService.Delete(id, self.CommandUrl).then(successCallback, errorCallback);
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

        Select(p : Fee): void {
            console.log(p);
            this.Model.FeeId = p.Id;
            this.Fee = p;
            this.Model.Price = p.Amount;
            console.log(this.Model);
        }
    }
    angular.module("app").controller("CollectionDetailsController", CollectionDetailsController);

}