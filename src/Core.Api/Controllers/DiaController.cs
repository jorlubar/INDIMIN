using Core.Api.Commons;
using INDIMIN.Model.DTOs;
using INDIMIN.Service;
using INDIMIN.Service.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaController : ControllerBase
    {
        private readonly IDiaService _DiaService;
        public DiaController(IDiaService DiaService)
        {
            _DiaService = DiaService;
        }

        [Authorize(Roles = RoleHelper.Administrador + "," + RoleHelper.Ojo + "," + RoleHelper.Bruja)]
        [HttpGet]
        public async Task<ActionResult<DataCollection<DiaDto>>> GetAll(int page, int take = 20)
        {
            return await _DiaService.GetAll(page, take);
        }

        [Authorize(Roles = RoleHelper.Administrador + "," + RoleHelper.Ojo + "," + RoleHelper.Bruja)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaDto>> GetById(int id)
        {
            return await _DiaService.GetById(id);
        }

        [Authorize(Roles = RoleHelper.Administrador)]
        [HttpPost]
        public async Task<ActionResult> Create(DiaCreateDto model)
        {
            var result = await _DiaService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.DiaId },
                result
            );
        }

        [Authorize(Roles = RoleHelper.Administrador)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DiaUpdateDto model)
        {
            await _DiaService.Update(id, model);
            return NoContent();
        }

        [Authorize(Roles = RoleHelper.Administrador)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _DiaService.Remove(id);
            return NoContent();
        }
    }
}