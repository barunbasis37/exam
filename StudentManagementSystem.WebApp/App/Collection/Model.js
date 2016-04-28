var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Collection = (function (_super) {
        __extends(Collection, _super);
        function Collection() {
            _super.call(this);
        }
        return Collection;
    })(App.Entity);
    App.Collection = Collection;
    var CollectionDetail = (function (_super) {
        __extends(CollectionDetail, _super);
        function CollectionDetail() {
            _super.call(this);
            this.Total = 0;
            this.Quantity = 0;
            this.Price = 0;
        }
        return CollectionDetail;
    })(App.Entity);
    App.CollectionDetail = CollectionDetail;
})(App || (App = {}));
//# sourceMappingURL=Model.js.map