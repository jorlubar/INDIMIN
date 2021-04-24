using System.ComponentModel.DataAnnotations;

namespace INDIMIN.Model.DTOs
{
    public class DiaCreateDto
    {
        [Required]
        public string Nombre { get; set; }
    }
    public class DiaUpdateDto
    {
        [Required]
        public string Nombre { get; set; }
    }
    public class DiaDto
    {
        public int DiaId { get; set; }
        public string Nombre { get; set; }
    }
}