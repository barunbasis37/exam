using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model
{
    public class Student : Entity
    {
        [Required]
        [Index("IX_StdName")]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [Index("IX_StdPhone", IsUnique = true)]
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [StringLength(300)]
        public string Remarks { get; set; }
        public double Due { get; set; }
    }
}
