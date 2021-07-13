using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Domain.Entities.Configurations
{
    public class AttributeTypeEntityConfiguration : IEntityTypeConfiguration<AttributeType>
    {
        public void Configure(EntityTypeBuilder<AttributeType> builder)
        {
            builder.ToTable("AttributeType");
            builder.HasKey(attributeType => attributeType.AttributeTypeId);
        }
    }
}
