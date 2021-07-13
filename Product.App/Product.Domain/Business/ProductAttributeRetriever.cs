using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain.Business.Interfaces;
using Product.Domain.Common;
using Product.Domain.DataAccess.Interfaces;
using Product.Domain.Entities;

namespace Product.Domain.Business
{
    public partial class ProductAttributeRetriever : IProductAttributeRetriever
    {
        private readonly IProductAttributeRepository _productAttributeRepository;

        public ProductAttributeRetriever(IProductAttributeRepository productAttributeRepository)
        {
            _productAttributeRepository = productAttributeRepository;
        }
       
        public async Task<IMethodResponse<List<ProductAttribute>>> RetrieveAllAsync(int productId)
        {
            return new MethodResponse<List<ProductAttribute>>()
            {
                ReturnValue = await _productAttributeRepository.RetrieveAllAsync(productId)
            };
        }
    }
}
