using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Domain.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for <see cref="Entities.Product"/> Repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieve All Products
        /// </summary>
        /// <returns>List of Products</returns>
        Task<List<Entities.Product>> RetrieveAllAsync();

        /// <summary>
        /// Retrieve <see cref="Product"/> details
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product details</returns>
        Task<Entities.Product> RetrieveAsync(int productId);
    }
}
