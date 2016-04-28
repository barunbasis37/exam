using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;


namespace StudentManagementSystem.ViewMod
{
    public class FeeViewModel :BaseViewModel
    {
        public FeeViewModel(Fee f) : base(f)
        {
            this.Name = f.Name;
            this.Amount = f.Amount;
        }
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}
