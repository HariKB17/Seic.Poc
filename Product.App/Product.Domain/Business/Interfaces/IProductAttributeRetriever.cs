using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain.Common;
using Product.Domain.Entities;

namespace Product.Domain.Business.Interfaces
{
    public interface IProductAttributeRetriever
    {
        /// <summary>
        /// Retrieve <see cref="Entities.ProductAttribute"/> list for a product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Method Response List of Product attributes</returns>
        Task<IMethodResponse<List<ProductAttribute>>> RetrieveAllAsync(int productId);

    }
}
