using INDIMIN.Model.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Database.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasMany(e => e.UserRoles)
                         .WithOne(e => e.Role)
                         .HasForeignKey(e => e.RoleId)
                         .IsRequired();

            entityBuilder.HasData(
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ojo",
                    NormalizedName = "Ojo"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Bruja",
                    NormalizedName = "Bruja"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ciudadano",
                    NormalizedName = "Ciudadano"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "Administrador"
                }
            );
        }
    }
}
