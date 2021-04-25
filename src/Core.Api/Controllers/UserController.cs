using Core.Api.Commons;
using INDIMIN.Model.DTOs;
using INDIMIN.Model.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize(Roles = RoleHelper.Administrador)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserRegisterDto model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, RoleHelper.Ciudadano);

            if (!result.Succeeded)
            {
                throw new Exception("No se pudo crear el usuario.");
            }

            return Ok();
        }
    }
}