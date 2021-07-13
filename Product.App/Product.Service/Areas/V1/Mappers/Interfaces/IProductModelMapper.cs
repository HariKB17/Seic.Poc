using System.Collections.Generic;
using Product.Domain.Common;
using Product.Service.Areas.V1.Models;
using Product.Service.Common;
using Product.Service.Common.Mappers;

namespace Product.Service.Areas.V1.Mappers.Interfaces
{
    public interface IProductModelMapper : 
        IClassMapper<IMethodResponse<List<Domain.Entities.Product>>, GenericResponseModel<List<ProductModel>>>,
        IClassMapper<IMethodResponse<Domain.Entities.Product>, GenericResponseModel<ProductModel>>
    {
    }
}
