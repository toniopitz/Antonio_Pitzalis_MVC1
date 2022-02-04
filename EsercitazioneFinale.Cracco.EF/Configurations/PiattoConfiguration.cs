using EsercitazioneFinale.Cracco.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercitazioneFinale.Cracco.EF
{
    internal class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();
            builder.Property(p => p.Tipo).IsRequired();

            builder.HasOne(p=>p.Menu).WithMany(m=>m.Piatti).HasForeignKey(p=>p.MenuId);
        }
    }
}