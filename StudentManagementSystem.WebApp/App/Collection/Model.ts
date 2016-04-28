module App {
    export class Collection extends Entity {
        constructor() {
            super();
        }
        Memo: string;
        Total: number;
        SupplierId: string;        
        Remarks: string;
    }

    export class CollectionDetail extends Entity {
        constructor() {
            super();
            this.Total = 0;
            this.Quantity = 0;
            this.Price = 0;
        }

        FeeId: string;
        CollectionId: string;
        Quantity: number;
        Price: number;
        Total: number;
        Remarks: string;
    }
}

    