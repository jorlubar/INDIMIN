using System.Reflection.PortableExecutable;

namespace INDIMIN.Model
{
    public class EjecutarTarea
    {
        public int EjecutarTareaId { get; set; }
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }
        public int CiudadanoId { get; set; }
        public Ciudadano Ciudadano { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; }
    }
}
