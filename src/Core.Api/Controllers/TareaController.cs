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
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _TareaService;
        public TareaController(ITareaService TareaService)
        {
            _TareaService = TareaService;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<TareaDto>>> GetAll(int page, int take = 20)
        {
            return await _TareaService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDto>> GetById(int id)
        {
            return await _TareaService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TareaCreateDto model)
        {
            var result = await _TareaService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.TareaId },
                result
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TareaUpdateDto model)
        {
            await _TareaService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _TareaService.Remove(id);
            return NoContent();
        }
    }
}