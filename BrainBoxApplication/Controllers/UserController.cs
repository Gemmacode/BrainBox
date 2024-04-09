using AutoMapper;
using BrainBoxApplication.Data;
using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Entity;
using BrainBoxApplication.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainBoxApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {


        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        // private readonly Dictionary<int, int> _cart = new Dictionary<int, int>();
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        

        [HttpPost("Add-User")]
        public async Task<ActionResult<ProductDto>> AddUser(UserDto userDto)
        {
            await _userService.AddUser(userDto);
            return Ok(userDto);
        }


        //[HttpPost("add")]
        //public IActionResult AddToCart(int productid, int howManyproducts)
        //{

        //    if (_cart.ContainsKey(productId))
        //    {
        //        return BadRequest("Product is already in the cart");
        //    }


        //    _cart.Add(productId, howManyproducts);

        //    return Ok("Product added to cart successfully");

        //}
    }
}