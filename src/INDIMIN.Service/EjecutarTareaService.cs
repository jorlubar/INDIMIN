using AutoMapper;
using INDIMIN.Model;
using INDIMIN.Model.DTOs;
using INDIMIN.Service.Commons;
using INDIMIN.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Linq;
using System.Threading.Tasks;

namespace INDIMIN.Service
{
    public interface IEjecutarTareaService
    {
        Task<DataCollection<EjecutarTareaDto>> GetAll(int page, int take);
        Task<EjecutarTareaDto> GetById(int id);
        Task<EjecutarTareaDto> Create(EjecutarTareaCreateDto model);
        Task Update(int id, EjecutarTareaUpdateDto model);
        Task Remove(int id);
    }
    public class EjecutarTareaService : IEjecutarTareaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EjecutarTareaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<EjecutarTareaDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<EjecutarTareaDto>>(
                await _context.EjecutarTareas.OrderByDescending(x => x.EjecutarTareaId)
                    .Include(x => x.Ciudadano)
                    .Include(x => x.Dia)
                    .Include(x => x.Tarea)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<EjecutarTareaDto> GetById(int id)
        {
            return _mapper.Map<EjecutarTareaDto>(
                await _context.EjecutarTareas
                    .Include(x => x.Ciudadano)
                    .Include(x => x.Dia)
                    .Include(x => x.Tarea)
                    .SingleAsync(x => x.EjecutarTareaId == id)
            );
        }

        public async Task<EjecutarTareaDto> Create(EjecutarTareaCreateDto model)
        {
            var entry = _mapper.Map<EjecutarTarea>(model);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<EjecutarTareaDto>(
                await GetById(entry.EjecutarTareaId)
            );
        }

        public async Task Update(int id, EjecutarTareaUpdateDto model)
        {
            var entry = await _context.EjecutarTareas.SingleAsync(x => x.EjecutarTareaId == id);

            entry.TareaId = model.TareaId;
            entry.CiudadanoId = model.CiudadanoId;
            entry.DiaId = model.DiaId;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(new EjecutarTarea
            {
                EjecutarTareaId = id
            });

            await _context.SaveChangesAsync();
        }
    }
}
