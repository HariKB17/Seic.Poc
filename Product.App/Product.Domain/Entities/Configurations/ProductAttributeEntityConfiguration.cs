using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Domain.Entities.Configurations
{
    public class ProductAttributeEntityConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("ProductAttribute");
            builder.HasKey(productAttribute => productAttribute.ProductAttributeId);

            builder.HasOne(productAttribute => productAttribute.Product)
                .WithMany(product => product.ProductAttributes)
                .HasForeignKey(product => product.ProductId)
                .IsRequired();


            builder.HasOne(productAttribute => productAttribute.AttributeType)
                .WithMany()
                .HasForeignKey(attributeType => attributeType.AttributeTypeId)
                .IsRequired();
        }
    }
}
