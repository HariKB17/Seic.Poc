namespace Product.Domain.Entities
{
    /// <summary>
    /// Product Attribute
    /// </summary>
    public class ProductAttribute
    {
        /// <summary>
        /// Product Attribute Id
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Attribute Type Id 
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// Product Attribute Value
        /// </summary>
        public string AttributeValue { get; set; }

        /// <summary>
        /// Attribute Type
        /// </summary>
        public virtual AttributeType AttributeType { get; set; }

        /// <summary>
        /// Product 
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
