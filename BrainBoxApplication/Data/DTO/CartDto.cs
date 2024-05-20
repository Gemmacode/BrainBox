using BrainBoxApplication.Models.Entity;

namespace BrainBoxApplication.Data.DTO
{
    public class CartDto
    {
        
        public Guid ProductId { get; set; }
        public List<Product> Products { get; set; }
        
       

    }
}
