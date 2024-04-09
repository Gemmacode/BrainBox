using BrainBoxApplication.Entity;

namespace BrainBoxApplication.Data.DTO
{
    public class CartDto
    {
        public Guid UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
