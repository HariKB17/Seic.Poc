using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Domain.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for <see cref="Entities.ProductAttribute"/> Repository
    /// </summary>
    public interface IProductAttributeRepository
    {
        /// <summary>
        /// Retrieve <see cref="Entities.ProductAttribute"/> list for a product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>List of Product attributes</returns>
        Task<List<Entities.ProductAttribute>> RetrieveAllAsync(int productId);

    }
}
