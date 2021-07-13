using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Domain.Business.Interfaces
{
    public interface IProductRetriever
    {
        /// <summary>
        /// Retrieve All <see cref="Product"/> list
        /// </summary>
        /// <returns>Method Response List of Products</returns>
        Task<Common.IMethodResponse<List<Entities.Product>>> RetrieveAllAsync();

        /// <summary>
        /// Retrieve <see cref="Product"/> details
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Method Response of product details</returns>
        Task<Common.IMethodResponse<Entities.Product>> RetrieveAsync(int productId);
    }
}
