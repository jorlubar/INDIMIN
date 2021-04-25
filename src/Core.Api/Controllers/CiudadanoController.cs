using Core.Api.Commons;
using INDIMIN.Model.DTOs;
using INDIMIN.Service;
using INDIMIN.Service.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize(Roles = RoleHelper.Ojo)]
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadanoController : ControllerBase
    {
        private readonly ICiudadanoService _ciudadanoService;
        public CiudadanoController(ICiudadanoService ciudadanoService)
        {
            _ciudadanoService = ciudadanoService;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<CiudadanoDto>>> GetAll(int page, int take = 20)
        {
            return await _ciudadanoService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadanoDto>> GetById(int id)
        {
            return await _ciudadanoService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CiudadanoCreateDto model)
        {
            var result = await _ciudadanoService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.CiudadanoId },
                result
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CiudadanoUpdateDto model)
        {
            await _ciudadanoService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _ciudadanoService.Remove(id);
            return NoContent();
        }
    }
}