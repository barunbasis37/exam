using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model
{
    public class Collection : Entity
    {
        public string Memo { get; set; }
        public double Total { get; set; }
        [Required]
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<CollectionDetail> PurchaseDetails { get; set; }
        
    }
}
