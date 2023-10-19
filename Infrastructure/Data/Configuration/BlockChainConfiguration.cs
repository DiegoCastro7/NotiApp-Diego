using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("BlockChains");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(e => e.HashGenerado)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(p => p.Auditorias)
            .WithMany(p => p.BlockChains)
            .HasForeignKey(p => p.IdAuditoriaFk);

            builder.HasOne(p => p.TipoNtfs)
            .WithMany(p => p.BlockChains)
            .HasForeignKey(p => p.IdNotificacionFk);

            builder.HasOne(p => p.HiloRespuestaNtfs)
            .WithMany(p => p.BlockChains)
            .HasForeignKey(p => p.IdHiloRespuestaFk);
        }
    }
}