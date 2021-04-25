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
            CreateMap<CiudadanoCreateDto, Ciudadano>();
            CreateMap<Ciudadano, CiudadanoDto>();
            CreateMap<DataCollection<Ciudadano>, DataCollection<CiudadanoDto>>();

            CreateMap<DiaCreateDto, Dia>();
            CreateMap<Dia, DiaDto>();
            CreateMap<DataCollection<Dia>, DataCollection<DiaDto>>();

            CreateMap<TareaCreateDto, Tarea>();
            CreateMap<Tarea, TareaDto>();
            CreateMap<DataCollection<Tarea>, DataCollection<TareaDto>>();

            CreateMap<EjecutarTareaCreateDto, EjecutarTarea>();
            CreateMap<EjecutarTarea, EjecutarTareaDto>();
            CreateMap<DataCollection<EjecutarTarea>, DataCollection<EjecutarTareaDto>>();
        }
    }
}
