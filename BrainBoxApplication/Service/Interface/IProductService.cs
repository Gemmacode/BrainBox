using BrainBoxApplication.Data.DTO;
using System.Threading.Tasks;

namespace BrainBoxApplication.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDto> AddProduct(ProductDto productDto);
        Task<ProductDto> GetProductById(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task AddProductToCart(Guid userId, Guid productId);
        Task<string> UpdateProduct(Guid id, ProductDto productDto);
        Task<bool> SoftDeleteProduct(Guid id);
        Task<bool> HardDeleteProduct(Guid id);
        Task<bool> ProductExist(Guid id);
        Task<bool> DoWeHaveProduct();

    }
}
