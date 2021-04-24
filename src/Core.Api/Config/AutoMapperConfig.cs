using AutoMapper;
using INDIMIN.Model;
using INDIMIN.Model.DTOs;
using INDIMIN.Service.Commons;

namespace Core.Api.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Ciudadano, CiudadanoDto>();
            CreateMap<DataCollection<Ciudadano>, DataCollection<CiudadanoDto>>();

            CreateMap<Dia, DiaDto>();
            CreateMap<DataCollection<Dia>, DataCollection<DiaDto>>();

            CreateMap<Tarea, TareaDto>();
            CreateMap<DataCollection<Tarea>, DataCollection<TareaDto>>();
        }
    }
}
