using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.ViewMod
{
    public class StudentViewModel :BaseViewModel
    {
        public StudentViewModel(Student s) : base(s)
        {
            this.Name = s.Name;
            this.Address = s.Address;
            this.Phone = s.Phone;
            this.DepartmentId = s.DepartmentId;
            this.Remarks = s.Remarks;
            this.Due = s.Due;

        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DepartmentId { get; set; }
        public string Remarks { get; set; }
        public double Due { get; set; }
    }
}
