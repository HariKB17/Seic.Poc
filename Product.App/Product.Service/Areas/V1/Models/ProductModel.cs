namespace Product.Service.Areas.V1.Models
{
    /// <summary>
    /// Product Summary Model
    /// </summary>
    public class ProductModel
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
    }
}
