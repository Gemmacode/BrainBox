using System.ComponentModel.DataAnnotations;

namespace BrainBoxApplication.Data.DTO
{
    public class ProductDto : AddProductDto
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductQuantity { get; set; }
        public string Cart { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        
    }

    public class AddProductDto
    {
        [Key]
        public Guid ProductId { get; set; }
    }
}
