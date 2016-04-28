using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;


namespace StudentManagementSystem.ViewMod
{
    public class PaymentViewModel : BaseViewModel
    {
        public PaymentViewModel(Payment x) : base(x)
        {
            this.StudentId = x.StudentId;
            this.Amount = x.Amount;
            this.Memo = x.Memo;
            this.PayBy = x.PayBy;
            this.Remarks = x.Remarks;
        }
        public string StudentId { get; set; }
        public double Amount { get; set; }
        public string Memo { get; set; }
        public string PayBy { get; set; }
        public string Remarks { get; set; }
        
    }
}
