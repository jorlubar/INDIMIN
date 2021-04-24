using INDIMIN.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Config
{
    public class TareaConfig
    {
        public TareaConfig(EntityTypeBuilder<Tarea> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
