using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class ModuloNotificacionesConfiguration : IEntityTypeConfiguration<ModuloNotificaciones>
    {
        public void Configure(EntityTypeBuilder<ModuloNotificaciones> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("ModuloNotificaciones");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(e => e.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(2000);

            builder.HasOne(p => p.TipoNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdTipoNotificacionFk);

            builder.HasOne(p => p.Radicados)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdRadicadoFk);

            builder.HasOne(p => p.EstadoNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdEstadoNotificacionFk);

            builder.HasOne(p => p.HiloRespuestaNtfs)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdHiloRespuestaFk);

            builder.HasOne(p => p.Formatos)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdFormatoFk);

            builder.HasOne(p => p.TipoRequerimientos)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdRequerimientoFk);
        }
    }
}