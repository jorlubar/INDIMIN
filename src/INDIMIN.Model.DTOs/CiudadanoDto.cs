using System.ComponentModel.DataAnnotations;

namespace INDIMIN.Model.DTOs
{
    public class CiudadanoCreateDto
    {
        [Required]
        public string Nombre { get; set; }
    }

    public class CiudadanoUpdateDto
    {
        [Required]
        public string Nombre { get; set; }
    }

    public class CiudadanoDto
    {
        public int CiudadanoId { get; set; }
        public string Nombre { get; set; }
    }
}
