using System.ComponentModel.DataAnnotations;

namespace INDIMIN.Model.DTOs
{
    public class TareaCreateDto
    {
        [Required]
        public string Nombre { get; set; }
    }
    public class TareaUpdateDto
    {
        [Required]
        public string Nombre { get; set; }
    }
    public class TareaDto
    {
        public int TareaId { get; set; }
        public string Nombre { get; set; }
    }
}