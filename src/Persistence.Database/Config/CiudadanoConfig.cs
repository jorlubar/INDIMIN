using INDIMIN.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Config
{
    public class CiudadanoConfig
    {
        public CiudadanoConfig(EntityTypeBuilder<Ciudadano> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
