using BrainBoxApplication.Models.Enums;

namespace BrainBoxApplication.Models.Entity
{
    public class Product : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public decimal ProductPrice { get; set; }
                     
        public ProductCategory ProductCategory { get; set; }

    }
}
