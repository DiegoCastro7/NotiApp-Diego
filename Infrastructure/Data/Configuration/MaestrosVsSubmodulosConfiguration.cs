using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class MaestrosVsSubmodulosConfiguration : IEntityTypeConfiguration<MaestrosVsSubmodulos>
    {
        public void Configure(EntityTypeBuilder<MaestrosVsSubmodulos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("MaestrosVsSubmodulos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.ModulosMaestros)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdMaestroFk);

            builder.HasOne(p => p.Submodulos)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdSubmodulosFk);
        }
    }
}