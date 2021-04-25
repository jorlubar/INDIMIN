using INDIMIN.Model.DTOs;
using INDIMIN.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IConfiguration _configuration;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (check.Succeeded)
            {
                return Ok(
                    GenerateToken(user)
                );
            }
            else
            {
                return BadRequest("Acceso no válido al sistema");
            }
        }

        private string GenerateToken(ApplicationUser user)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}