using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model
{
    public class Fee : Entity
    {
        [Required]
        [Index("IX_FeeName")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
