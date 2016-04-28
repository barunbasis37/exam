module App {
    export class Student extends Entity {
        constructor() {
            super();
        }
        Name: string;
        Address: string;
        Phone: string;
        DepartmentName: string;
        Remarks: string;
        Due:number;
    }

    export class StudentHistory {
        StudentId: string;
        Collection: Collection[];
        Payments: Payment[];

        constructor() {
            this.Collection = [];
            this.Payments = [];
        }
    }

}

    