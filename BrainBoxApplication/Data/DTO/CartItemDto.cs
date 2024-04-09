using BrainBoxApplication.Entity;

namespace BrainBoxApplication.Data.DTO
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public string Quantity { get; set; }
    } 
}
