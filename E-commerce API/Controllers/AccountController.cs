
using Core.Entiies.Identity;
using E_commerce_API.Errors;
using Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDTO
            {
                Email = login.Email,
                Token = "token",
                DisplayName = user.DisplayName
            };

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            var user = new AppUser
            {
                DisplayName = register.DisplayName,
                Email = register.Email,
                UserName = register.DisplayName,
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDTO
            {
                Email = user.Email,
                Token = "Token",
                DisplayName = user.DisplayName,
            };
        }
    }
}
