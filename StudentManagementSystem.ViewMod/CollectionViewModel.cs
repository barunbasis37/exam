using StudentManagementSystem.Model;

namespace StudentManagementSystem.ViewMod
{
    public class CollectionViewModel : BaseViewModel
    {
        public CollectionViewModel(Collection x) : base(x)
        {
            this.Id = x.Id;
            this.Memo = x.Memo;
            this.StudentId = x.StudentId;
            this.Student = x.Student;
            this.Remarks = x.Remarks;
            this.Total = x.Total;
        }

        public double Total { get; set; }

        public string Memo { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public string Remarks { get; set; }


    }
}