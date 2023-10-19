using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class TipoNotificacionesConfiguration : IEntityTypeConfiguration<TipoNotificaciones>
    {
        public void Configure(EntityTypeBuilder<TipoNotificaciones> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("TipoNotificaciones");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");
            
            builder.Property(e => e.NombreTipo)
            .IsRequired()
            .HasMaxLength(80);
        }
    }
}