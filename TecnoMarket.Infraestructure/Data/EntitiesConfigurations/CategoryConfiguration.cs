using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoMarket.Core.Entities;

namespace TecnoMarket.Infraestructure.Data.EntitiesConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(x=> x.Products)
                .WithOne(x=> x.Category)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now);

            var category = new Category
            {
                Id = 1,
                Description = "Accesorios",
                StatuId = (int)EnumsStatus.Status.Active,
                CreationDate = DateTime.Now,
                UserCreator = "Admin"
            };
            var category2 = new Category
            {
                Id = 2,
                Description = "Monitores",
                StatuId = (int)EnumsStatus.Status.Active,
                CreationDate = DateTime.Now,
                UserCreator = "Admin"
            };
            var category3 = new Category
            {
                Id = 3,
                Description = "Laptops",
                StatuId = (int)EnumsStatus.Status.Active,
                CreationDate = DateTime.Now,
                UserCreator = "Admin"
            };

            builder.HasData(category,category2,category3);

        }
    }
}
