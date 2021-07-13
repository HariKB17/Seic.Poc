namespace Product.Domain.Entities
{
    /// <summary>
    /// Attribute Type lookup
    /// </summary>
    public class AttributeType
    {
        /// <summary>
        /// Attribute Type Id
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// Attribute Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

    }
}
