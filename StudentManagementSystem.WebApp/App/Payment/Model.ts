module App {
    export class Payment extends Entity {
        constructor() {
            super();
            this.PayBy = "Cash";
        }
        StudentId: string;
        Student: Student;
        Amount: number;
        PayBy: string;
        Remarks: string;
    }

}

    