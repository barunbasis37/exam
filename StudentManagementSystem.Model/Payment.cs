using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model
{
    public class Payment : Entity
    {
        [Required]
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public double Amount { get; set; }
        public string Memo { get; set; }
        [Required]
        public string PayBy { get; set; }
        public string Remarks { get; set; }
    }
}
