using BrainBoxApplication.Models.Entity;

namespace BrainBoxApplication.Data.DTO
{
    public class CartDto
    {
        public Guid CartId { get; set; } 
        public Guid ProductId { get; set; }
        public List<Product> Products { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
       

    }
}
