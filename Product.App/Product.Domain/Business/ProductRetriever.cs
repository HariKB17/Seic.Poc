using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain.Business.Interfaces;
using Product.Domain.DataAccess.Interfaces;

namespace Product.Domain.Business
{
    public partial class ProductRetriever : IProductRetriever
    {
        private readonly IProductRepository _productRepository;

        public ProductRetriever(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Common.IMethodResponse<List<Entities.Product>>> RetrieveAllAsync()
        {
            return new Common.MethodResponse<List<Entities.Product>>()
            {
                ReturnValue = await _productRepository.RetrieveAllAsync()
            };
        }

        public async Task<Common.IMethodResponse<Entities.Product>> RetrieveAsync(int productId)
        {
            return new Common.MethodResponse<Entities.Product>()
            {
                ReturnValue = await _productRepository.RetrieveAsync(productId)
            };
        }
    }
}
