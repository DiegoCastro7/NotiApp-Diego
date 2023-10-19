using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class RolVsMaestroConfiguration : IEntityTypeConfiguration<RolVsMaestro>
    {
        public void Configure(EntityTypeBuilder<RolVsMaestro> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("RolVsMaestros");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.ModulosMaestros)
            .WithMany(p => p.RolVsMaestros)
            .HasForeignKey(p => p.IdMaestroFk);

            builder.HasOne(p => p.Roles)
            .WithMany(p => p.RolVsMaestro)
            .HasForeignKey(p => p.IdRolFk);
        }
    }
}