var App;
(function (App) {
    "use strict";
    var UrlService = (function () {
        function UrlService() {
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
        return UrlService;
    })();
    App.UrlService = UrlService;
    angular.module("app").service("UrlService", UrlService);
})(App || (App = {}));
//# sourceMappingURL=UrlService.js.map