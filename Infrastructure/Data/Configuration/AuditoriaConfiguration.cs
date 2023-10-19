using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("Auditorias");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.NombreUsuario)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e => e.DescAccion)
            .IsRequired()
            .HasColumnType("int");
        }
    }
}