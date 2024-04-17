using BrainBoxApplication.Entity;

namespace BrainBoxApplication.Data.DTO
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
