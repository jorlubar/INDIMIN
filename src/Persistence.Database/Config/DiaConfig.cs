using INDIMIN.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Config
{
    public class DiaConfig
    {
        public DiaConfig(EntityTypeBuilder<Dia> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
