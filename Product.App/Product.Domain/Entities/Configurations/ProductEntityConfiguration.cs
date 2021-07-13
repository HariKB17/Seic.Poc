using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Domain.Entities.Configurations
{
    public class ProductEntityConfiguration :IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(product => product.ProductId);

            builder.Property(product => product.ProductName)
                .HasColumnName("Name");

        }
    }
}
