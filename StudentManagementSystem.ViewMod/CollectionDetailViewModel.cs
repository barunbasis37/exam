using StudentManagementSystem.Model;

namespace StudentManagementSystem.ViewMod
{
    public class CollectionDetailViewModel: BaseViewModel
    {
        public CollectionDetailViewModel(CollectionDetail x):base(x)
        {
            this.Fee =  new FeeViewModel(x.Fee);
            this.Price = x.Price;
            this.FeeId = x.FeeId;
            this.CollectionId = x.CollectionId;
            this.Quantity = x.Quantity;
            this.Remarks = x.Remarks;
            this.Total = x.Total;
        }

        public FeeViewModel Fee { get; set; }

        public double Price { get; set; }

        public string FeeId { get; set; }

        public string CollectionId { get; set; }

        public int Quantity { get; set; }

        public string Remarks { get; set; }

        public double Total { get; set; }
    }
}