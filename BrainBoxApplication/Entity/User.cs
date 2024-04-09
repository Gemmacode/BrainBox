using BrainBoxApplication.Data.DTO;

namespace BrainBoxApplication.Entity
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }    
        public string Email { get; set; }
       public string Address { get; set; }
        public string Phonenumber { get; set; }
        public ICollection<CartItem> Cart { get; set; }
        public IEnumerable<ProductDto> ProductsInCart { get; set; }


    }
}
