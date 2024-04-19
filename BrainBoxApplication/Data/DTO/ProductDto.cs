using BrainBoxApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BrainBoxApplication.Data.DTO
{
    public class ProductDto : AddProductDto
    {
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalCost { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }

    public class AddProductDto
    {
        [Key]
        public Guid ProductId { get; set; }
    }
}
