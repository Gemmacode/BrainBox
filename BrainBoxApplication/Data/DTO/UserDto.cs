namespace BrainBoxApplication.Data.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public IEnumerable<ProductDto> ProductsInCart { get; set; }

    }
}
