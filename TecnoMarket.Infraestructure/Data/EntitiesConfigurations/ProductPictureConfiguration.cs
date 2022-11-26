using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMarket.Core.Entities;

namespace TecnoMarket.Infraestructure.Data.EntitiesConfigurations
{
    public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductsPictures");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("FK_PricturesProducts_Products_ProductId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
