using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model
{
    public class Department : Entity
    {
        [Required]
        [Index("IX_StdName")]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
