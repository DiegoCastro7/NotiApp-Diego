using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class SubmodulosConfiguration : IEntityTypeConfiguration<Submodulos>
    {
        public void Configure(EntityTypeBuilder<Submodulos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("Submodulos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.NombreSubmodulo)
            .IsRequired()
            .HasMaxLength(80);
        }
    }
}