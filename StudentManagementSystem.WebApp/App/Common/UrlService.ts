module App {
    "use strict";

    export class UrlService {
        BaseUrl: string;
        SigninUrl: string;
        PermissionUrl: string;
        RegisterUrl: string;        
        SideMenuUrl: string;
        ProfileUrl:string;
        ChangePasswordUrl: string;

        constructor() {
            var baseUrl = "";
            //baseUrl = "/ShoppersZone";
            var baseApi = baseUrl + "/api";
            this.BaseUrl = baseUrl;

            this.SigninUrl = baseUrl + "/token";
            this.PermissionUrl = baseApi + "/Permission";
            this.RegisterUrl = baseApi + "/Account/Register";
            this.SideMenuUrl = baseApi + "/SideMenu";
            this.ProfileUrl = baseApi + "/Account/GetUserInfo";
            this.ChangePasswordUrl = baseApi + "/Account/ChangePassword";
        
            //business
            this.BarcodeImage = baseApi + "/BarcodeImage";

            this.Fee = baseApi + "/Fee";
            this.FeeQuery = baseApi + "/FeeQuery";
            this.FeeQueryBarcode = this.FeeQuery + "/Barcode";
            this.FeeQueryData = this.FeeQuery + "/Data";
            this.FeeQueryCount = this.FeeQuery + "/Count";
            this.FeeQueryReport = this.FeeQuery + "/Report";
            
            this.StudentQuery = baseApi + "/StudentQuery";
            this.Student = baseApi + "/Student";
            this.StudentQueryData = this.StudentQuery + "/Data";
            this.StudentQueryCount = this.StudentQuery + "/Count";
            this.StudentQueryReport = this.StudentQuery + "/Report";
            this.StudentHistoryQuery = baseApi + "/StudentHistoryQuery";

            this.Collection = baseApi + "/Collection";
            this.CollectionQuery = baseApi + "/CollectionQuery";
            this.CollectionQueryData = this.CollectionQuery + "/Data";
            this.CollectionQueryCount = this.CollectionQuery + "/Count";
            this.CollectionQueryReport = this.CollectionQuery + "/Report";
            this.CollectionDetail = baseApi + "/CollectionDetail";
            this.CollectionDetailQuery = baseApi + "/CollectionDetailQuery";

            this.Payment = baseApi + "/Payment";
            this.PaymentQuery = baseApi + "/PaymentQuery";
            this.PaymentQueryData = this.PaymentQuery + "/Data";
            this.PaymentQueryCount = this.PaymentQuery + "/Count";
            this.PaymentQueryReport = this.PaymentQuery + "/Report";
            this.Dropdown = baseApi + "/Dropdown";
           
        }

        private FeeQuery: string;
        FeeQueryBarcode: string;
        FeeQueryData: string;
        FeeQueryCount: string;
        FeeQueryReport: string;
        Fee: string;
        StudentQuery: string;
        Student: string;
        StudentHistoryQuery: string;
        StudentQueryData: string;
        StudentQueryCount: string;
        StudentQueryReport: string;
        BarcodeImage: string;
        Collection: string;
        CollectionQuery: string;
        CollectionDetail: string;
        CollectionDetailQuery: string;
        CollectionQueryData: string;
        CollectionQueryCount: string;
        CollectionQueryReport: string;
        Payment: string;
        PaymentQuery: string;
        PaymentQueryData: string;
        PaymentQueryCount: string;
        PaymentQueryReport: string;
        Dropdown: string;
        
    }

    angular.module("app").service("UrlService", UrlService);
}