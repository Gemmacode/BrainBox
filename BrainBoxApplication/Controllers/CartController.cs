using BrainBoxApplication.Data;
using BrainBoxApplication.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainBoxApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly BrainBoxDbContext _context;

        public CartController(BrainBoxDbContext context)
        {
            _context = context;

        }

        [HttpPost("AddToCart")]
        public async Task<ActionResult> AddToCart( Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            var cart = await _context.Carts
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.ProductId == productId);

            if (cart == null)
            {
                cart = new Cart { Products = new List<Product>() };
                _context.Carts.Add(cart);
            }
            
            if (cart != null)
            {
                // Product already exists in the cart
                return Conflict("Product already exists in the cart.");
            }           
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Cart/UserId
        [HttpGet("{productId}")]
        public async Task<ActionResult<Cart>> GetCart(Guid productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Products)                
                .FirstOrDefaultAsync(c => c.ProductId == productId);

            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            return cart;
        }

        // GET: api/Cart/TotalCost/UserId
        [HttpGet("TotalCost/{productId}")]
        public async Task<ActionResult<decimal>> GetTotalCost(Guid productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Products)               
                .FirstOrDefaultAsync(c => c.ProductId == productId);

            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            decimal totalCost = cart.Products.Sum(item => item.ProductPrice * item.Quantity);
            return totalCost;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        //{
        //    return await _context.Carts.ToListAsync();
        //}


        //[HttpPost]
        //public async Task<ActionResult<Cart>> AddToCart(Cart item)
        //{
        //    _context.Carts.Add(item);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetCart), new { id = item.ProductId }, item);
        //}


        //[HttpDelete("{productId}")]
        //public async Task<ActionResult> RemoveFromCart(Guid productId)
        //{
        //    var item = await _context.Carts.FindAsync(productId);
        //    if (item != null)
        //    {
        //        _context.Carts.Remove(item);
        //        await _context.SaveChangesAsync();
        //    }
        //    return Ok();
        //}

    }
}
