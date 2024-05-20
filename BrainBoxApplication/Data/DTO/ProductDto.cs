using BrainBoxApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BrainBoxApplication.Data.DTO
{
    public class ProductDto 
    {
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public decimal ProductPrice { get; set; }      
        public int Quantity { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }

    public class AddProductDto : ProductDto
    {
       
        public Guid ProductId { get; set; }
    }
}
