namespace Product.Service.Areas.V1.Models
{
    /// <summary>
    /// Product Summary Model
    /// </summary>
    public class ProductAttributeModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Attribute Type Id
        /// </summary>
        public int AttributeTypeId { get; set; }


        /// <summary>
        /// Attribute Type Name
        /// </summary>
        public string AttributeTypeName { get; set; }

        /// <summary>
        /// Attribute Type Value
        /// </summary>
        public string AttributeTypeValue { get; set; }
    }
}
