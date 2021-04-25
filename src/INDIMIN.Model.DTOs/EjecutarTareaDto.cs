using System.ComponentModel.DataAnnotations;

namespace INDIMIN.Model.DTOs
{
    public class EjecutarTareaCreateDto
    {
        [Required]
        public int TareaId { get; set; }
        [Required]
        public int CiudadanoId { get; set; }
        [Required]
        public int DiaId { get; set; }
    }
    public class EjecutarTareaUpdateDto
    {
        [Required]
        public int TareaId { get; set; }
        [Required]
        public int CiudadanoId { get; set; }
        [Required]
        public int DiaId { get; set; }
    }
    public class EjecutarTareaDto
    {
        public int EjecutarTareaId { get; set; }
        public int TareaId { get; set; }
        public TareaDto Tarea { get; set; }
        public int CiudadanoId { get; set; }
        public CiudadanoDto Ciudadano { get; set; }
        public int DiaId { get; set; }
        public DiaDto Dia { get; set; }
    }
}
