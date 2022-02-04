using EsercitazioneFinale.Cracco.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercitazioneFinale.Cracco.EF
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).IsRequired();

            builder.HasMany(m => m.Piatti).WithOne(p => p.Menu).HasForeignKey(p => p.MenuId);
        }
    }
}