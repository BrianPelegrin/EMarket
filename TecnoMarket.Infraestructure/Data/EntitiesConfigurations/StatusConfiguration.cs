using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoMarket.Core.Entities;

namespace TecnoMarket.Infraestructure.Data.EntitiesConfigurations
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Statu>
    {
        public void Configure(EntityTypeBuilder<Statu> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Ignore(x => x.StatuId);

            builder.Property(x => x.UserCreator)
                .HasDefaultValue(DateTime.Now);

            var statu1 = new Statu
            {
                Id = 1,
                Description = "Activo",
                UserCreator = "Admin",
                CreationDate = DateTime.Now
            };

            var statu2 = new Statu
            {
                Id = 2,
                Description = "Inactivo",
                UserCreator = "Admin",
                CreationDate = DateTime.Now
            };

            builder.HasData(statu1,statu2);
        }
    }
}
