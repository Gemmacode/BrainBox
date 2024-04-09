using AutoMapper;
using BrainBoxApplication.Data;
using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Entity;
using BrainBoxApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace BrainBoxApplication.Service.ProductImplementation
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly BrainBoxDbContext _db;

        public ProductService(IMapper mapper, BrainBoxDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            if (await _db.Products.AnyAsync(p => p.ProductName == productDto.ProductName))
            {
                throw new InvalidOperationException("A product with the same name already exists.");
            }

            var product = _mapper.Map<Product>(productDto);
            product.IsDeleted = false;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
            return productDto;
        }

        public async Task AddProductToCart(Guid userId, Guid productId)
        {
            var existingCartItem = await _db.CartItemss
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (existingCartItem != null)
            {
                throw new InvalidOperationException("Product already exists in the cart.");
            }

            var cartItem = new CartItem { UserId = userId, ProductId = productId };
            await _db.AddAsync(cartItem);
            await _db.SaveChangesAsync();
        }



        public async Task<ProductDto> GetProductById(Guid id)
        {
            var product = await _db.Products.FindAsync(id);
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _db.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

        
    

    public async Task<string> UpdateProduct(Guid id, ProductDto productDto)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                product.UpdatedAt = DateTime.UtcNow;
                _mapper.Map(productDto, product);
                await _db.SaveChangesAsync();
                return "Customer updated successfully";
            }
            else
            {
                throw new ArgumentException("Customer not Found");
            }

        }

        public async Task<bool> HardDeleteProduct(Guid id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SoftDeleteProduct(Guid id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                product.IsDeleted = true;
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DoWeHaveProduct()
        {
            return await _db.Products.AnyAsync();

        }

        public async Task<bool> ProductExist(Guid id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}



