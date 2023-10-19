using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class GenericosVsSubmodulosConfiguration : IEntityTypeConfiguration<GenericosVsSubmodulos>
    {
        public void Configure(EntityTypeBuilder<GenericosVsSubmodulos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("GenericosVsSubmodulos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.PermisosGenericos)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdGenericosFk);

            builder.HasOne(p => p.MaestrosVsSubmodulos)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdSubmodulosFk);

            builder.HasOne(p => p.Roles)
            .WithMany(p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdRolFk);
        }
    }
}