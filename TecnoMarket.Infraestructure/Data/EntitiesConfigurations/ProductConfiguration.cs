using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoMarket.Core.Entities;

namespace TecnoMarket.Infraestructure.Data.EntitiesConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(10,2);

            builder.Property(x => x.UserCreator);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x=>x.CategoryId)
                .HasConstraintName("FK_Products_Category_CategoryId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now);

            var product1 = new Product
            {
                Id = 1,
                Name = "Razor Handset",
                Description = "8D Sound, Surround",
                Price = 2500.00m,
                CreationDate = DateTime.Now,
                UserCreator = "Admin",
                CategoryId = 1,
                StatuId = (int)EnumsStatus.Status.Active,

            };

            var product2 = new Product
            {
                Id = 2,
                Name = "MSI Optix G271",
                Description = "144hz, 1920x1080FHD, 1ms",
                Price = 17000.00m,
                CreationDate = DateTime.Now,
                UserCreator = "Admin",
                CategoryId = 2,
                StatuId = (int)EnumsStatus.Status.Active,

            };

            var product3 = new Product
            {
                Id = 3,
                Name = "HP Pavilion Gaming 15",
                Description = "16 Gb RAM, GTX 1660 6GB, I5-10470H",
                Price = 40000.00m,
                CreationDate = DateTime.Now,
                UserCreator = "Admin",
                CategoryId = 3,
                StatuId = (int)EnumsStatus.Status.Active,

            };

            builder.HasData(product1,product2,product3);
        }
    }
}
