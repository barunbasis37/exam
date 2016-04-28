using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Model
{
    public class CollectionDetail : Entity
    {
        [Required]
        public string FeeId { get; set; }
        [ForeignKey("FeeId")]
        public Fee Fee { get; set; }
        [Required]
        public string CollectionId { get; set; }
        [ForeignKey("CollectionId")]
        public Collection Collection { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public string Remarks { get; set; }
    }
}