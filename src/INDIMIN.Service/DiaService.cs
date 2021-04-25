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
    public interface IDiaService
    {
        Task<DataCollection<DiaDto>> GetAll(int page, int take);
        Task<DiaDto> GetById(int id);
        Task<DiaDto> Create(DiaCreateDto model);
        Task Update(int id, DiaUpdateDto model);
        Task Remove(int id);
    }
    public class DiaService : IDiaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DiaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<DiaDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<DiaDto>>(
                await _context.Dias.OrderBy(x => x.DiaId)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<DiaDto> GetById(int id)
        {
            return _mapper.Map<DiaDto>(
                await _context.Dias.SingleAsync(x => x.DiaId == id)
            );
        }

        public async Task<DiaDto> Create(DiaCreateDto model)
        {
            var entry = _mapper.Map<Dia>(model);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<DiaDto>(entry);
        }

        public async Task Update(int id, DiaUpdateDto model)
        {
            var entry = await _context.Dias.SingleAsync(x => x.DiaId == id);
            entry.Nombre = model.Nombre;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(new Dia
            {
                DiaId = id
            });

            await _context.SaveChangesAsync();
        }
    }
}