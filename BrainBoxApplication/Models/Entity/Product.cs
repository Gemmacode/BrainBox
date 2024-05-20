using BrainBoxApplication.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainBoxApplication.Models.Entity
{
    public class Product : BaseEntity
    {
        public Guid ProductId { get; set; }

        
        public string ProductName { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductType ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
       

    }
}
