using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.ViewMod
{
    public class StudentHistoryDetailViewModel
    {

        public StudentHistoryDetailViewModel(CollectionViewModel vm)
        {
            this.Created = vm.Created;
            this.Total = vm.Total;
            this.Memo = vm.Memo;
            this.Type = "Collection";
        }

        public StudentHistoryDetailViewModel(PaymentViewModel vm)
        {
            this.Created = vm.Created;
            this.Total = vm.Amount;
            this.Memo = vm.Memo;
            this.Type = "Payment";
        }

        public DateTime Created { get; set; }
        public double Total { get; set; }
        public string Memo { get; set; }
        public string Type { get; set; }
    }
}

