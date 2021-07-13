using System.Collections.Generic;

namespace Product.Domain.Entities
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// PricePerItem
        /// </summary>
        public decimal? PricePerItem { get; set; }

        /// <summary>
        /// Average Customer Rating
        /// </summary>
        public decimal? AverageCustomerRating { get; set; }

        /// <summary>
        /// Is Archived
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Product Attribute list
        /// </summary>
        public virtual List<ProductAttribute> ProductAttributes { get; set; }

    }
}
