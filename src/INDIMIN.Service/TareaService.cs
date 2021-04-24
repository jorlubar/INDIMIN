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
    public interface ITareaService
    {
        Task<DataCollection<TareaDto>> GetAll(int page, int take);
        Task<TareaDto> GetById(int id);
        Task<TareaDto> Create(TareaCreateDto model);
        Task Update(int id, TareaUpdateDto model);
        Task Remove(int id);
    }
    public class TareaService : ITareaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TareaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<TareaDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<TareaDto>>(
                await _context.Tareas.OrderByDescending(x => x.TareaId)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<TareaDto> GetById(int id)
        {
            return _mapper.Map<TareaDto>(
                await _context.Tareas.SingleAsync(x => x.TareaId == id)
            );
        }

        public async Task<TareaDto> Create(TareaCreateDto model)
        {
            var entry = new Tarea
            {
                Nombre = model.Nombre
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<TareaDto>(entry);
        }

        public async Task Update(int id, TareaUpdateDto model)
        {
            var entry = await _context.Tareas.SingleAsync(x => x.TareaId == id);
            entry.Nombre = model.Nombre;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(new Tarea
            {
                TareaId = id
            });

            await _context.SaveChangesAsync();
        }
    }
}
