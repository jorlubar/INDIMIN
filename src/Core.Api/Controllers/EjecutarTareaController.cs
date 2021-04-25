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
    public class EjecutarTareaController : ControllerBase
    {
        private readonly IEjecutarTareaService _EjecutarTareaService;
        public EjecutarTareaController(IEjecutarTareaService EjecutarTareaService)
        {
            _EjecutarTareaService = EjecutarTareaService;
        }

        [Authorize(RoleHelper.Bruja)]
        [HttpGet]
        public async Task<ActionResult<DataCollection<EjecutarTareaDto>>> GetAllByDia(int diaId, int page, int take = 20)
        {
            return await _EjecutarTareaService.GetAllByDia(diaId, page, take);
        }

        [Authorize(Roles = RoleHelper.Ojo)]
        [HttpGet]
        public async Task<ActionResult<DataCollection<EjecutarTareaDto>>> GetAll(int page, int take = 20)
        {
            return await _EjecutarTareaService.GetAll(page, take);
        }

        [Authorize(Roles = RoleHelper.Ojo)]
        [HttpGet("{id}")]
        public async Task<ActionResult<EjecutarTareaDto>> GetById(int id)
        {
            return await _EjecutarTareaService.GetById(id);
        }

        [Authorize(Roles = RoleHelper.Ojo)]
        [HttpPost]
        public async Task<ActionResult> Create(EjecutarTareaCreateDto model)
        {
            var result = await _EjecutarTareaService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.EjecutarTareaId },
                result
            );
        }

        [Authorize(Roles = RoleHelper.Ojo)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EjecutarTareaUpdateDto model)
        {
            await _EjecutarTareaService.Update(id, model);
            return NoContent();
        }

        [Authorize(Roles = RoleHelper.Ojo)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _EjecutarTareaService.Remove(id);
            return NoContent();
        }
    }
}