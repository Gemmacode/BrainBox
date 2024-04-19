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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Carts.ToListAsync();
        }

       
        [HttpPost]
        public async Task<ActionResult<Cart>> AddToCart(Cart item)
        {
            _context.Carts.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCart), new { id = item.ProductId }, item);
        }

       
        [HttpDelete("{productId}")]
        public async Task<ActionResult> RemoveFromCart(Guid productId)
        {
            var item = await _context.Carts.FindAsync(productId);
            if (item != null)
            {
                _context.Carts.Remove(item);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

    }
}
