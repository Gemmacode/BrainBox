using AutoMapper;
using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BrainBoxApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductDto productDto)
        {
            await _productService.AddProduct(productDto);
            return Ok(productDto);
        }

        [HttpPost("Add-Product-Cart")]
        public async Task<ActionResult> AddProductToCart (Guid userId, Guid productId)
        {
            await _productService.AddProductToCart(userId, productId);
            return Ok();
        }

        [HttpGet("Get-By-Id")]

        public async Task<IActionResult> GetProduct(Guid id)
        {
            var productExist = await _productService.ProductExist(id);
            if (productExist == false)
            {
                return NotFound("Product does not exist");
            }
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAllProducts()
        {
            var doWeHaveProducts = await _productService.DoWeHaveProduct();
            if (doWeHaveProducts == false)
            {
                return NotFound("No Product found");
            }
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }


        [HttpPut("Update-Product")]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto, Guid id)
        {
            var productExist = await _productService.ProductExist(id);
            if (productExist == false)
            {
                return NotFound("Product does not exist");
            }
            await _productService.UpdateProduct(id, productDto);
            return Ok("Product updated successfully");
        }

        [HttpDelete("Soft-Delete-Product")]
        public async Task<IActionResult> SoftDeleteProduct(Guid id)
        {
            var productExist = await _productService.ProductExist(id);
            if (productExist == false)
            {
                return NotFound("Product does not exist");
            }
            await _productService.SoftDeleteProduct(id);
            return Ok("Product Deleted Successfully");
        }

        [HttpDelete("Hard-Delete-Product")]
        public async Task<IActionResult> HardDeleteProduct(Guid id)
        {
            var productExist = await _productService.ProductExist(id);
            if (productExist == false)
            {
                return NotFound("Customer does not exist");
            }
           await _productService.HardDeleteProduct(id);
            return Ok("Customer Deleted Successfully");
        }











    }
}