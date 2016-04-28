using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.ViewMod
{
    public class StudentHistoryViewModel
    {
        public double CollectionTotal { get; set; }
        public double PaymentTotal { get; set; }
        public List<CollectionViewModel> Collections { get; set; }
        public List<PaymentViewModel> Payments { get; set; }
        public List<StudentHistoryDetailViewModel> Histories { get; set; }
    }
}
