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
    public interface ICiudadanoService
    {
        Task<DataCollection<CiudadanoDto>> GetAll(int page, int take);
        Task<CiudadanoDto> GetById(int id);
        Task<CiudadanoDto> Create(CiudadanoCreateDto model);
        Task Update(int id, CiudadanoUpdateDto model);
        Task Remove(int id);
    }
    public class CiudadanoService : ICiudadanoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CiudadanoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<CiudadanoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CiudadanoDto>>(
                await _context.Ciudadanos.OrderByDescending(x => x.CiudadanoId)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<CiudadanoDto> GetById(int id)
        {
            return _mapper.Map<CiudadanoDto>(
                await _context.Ciudadanos.SingleAsync(x => x.CiudadanoId == id)
            );
        }

        public async Task<CiudadanoDto> Create(CiudadanoCreateDto model)
        {
            var entry = new Ciudadano
            {
                Nombre = model.Nombre
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<CiudadanoDto>(entry);
        }

        public async Task Update(int id, CiudadanoUpdateDto model)
        {
            var entry = await _context.Ciudadanos.SingleAsync(x => x.CiudadanoId == id);
            entry.Nombre = model.Nombre;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(new Ciudadano
            {
                CiudadanoId = id
            });

            await _context.SaveChangesAsync();
        }
    }
}
