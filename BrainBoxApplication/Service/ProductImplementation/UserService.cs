using AutoMapper;
using BrainBoxApplication.Data;
using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Entity;
using BrainBoxApplication.Service.Interface;

namespace BrainBoxApplication.Service.ProductImplementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly BrainBoxDbContext _dbContext;

        public UserService(IMapper mapper, BrainBoxDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<Product>(userDto);
            user.IsDeleted = false;
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return userDto;
        }


        //public void AddProductToCart(ProductDto product , UserDto user)
        //{
        //    if (Productincart.Any(p => string.Equals(p.Name, product.ProductName, StringComparison.OrdinalIgnoreCase)))
        //    {
        //        throw new InvalidOperationException("Product with similar name already exists in the cart.");
        //    }

        //    ProductsInCart.Add(product);
        //}

        //// View products in the cart
        //public IEnumerable<ProductDto> ViewProductsInCart() => ProductsInCart;

        //// Calculate total cost of all products in the cart
        //public decimal CalculateTotalCost() => ProductsInCart.Sum(p => p.Price);
    }
}
