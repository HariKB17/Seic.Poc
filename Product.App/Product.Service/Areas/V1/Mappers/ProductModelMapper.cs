using System;
using System.Collections.Generic;
using System.Linq;
using Product.Domain.Common;
using Product.Service.Areas.V1.Mappers.Interfaces;
using Product.Service.Areas.V1.Models;
using Product.Service.Common;
using Product.Service.Common.Http;

namespace Product.Service.Areas.V1.Mappers
{
    /// <summary>
    /// Maps entity of type <see cref="Domain.Entities.Product"/> to <see cref="ProductModel"/>
    /// </summary>
    public class ProductModelMapper : IProductModelMapper
    {
        public GenericResponseModel<List<ProductModel>> Map(IMethodResponse<List<Domain.Entities.Product>> @from, object context = null)
        {
            if (@from == null) throw new ArgumentNullException(nameof(@from));

            var response = new GenericResponseModel<List<ProductModel>>();
            //To Build Messages from Method Response object
            response.Build(@from);
            if (@from.ReturnValue != null)
            {
                response.Data = @from.ReturnValue
                    .Select(Map).ToList();
            }
            return response;
        }

        public GenericResponseModel<ProductModel> Map(IMethodResponse<Domain.Entities.Product> @from, object context = null)
        {
            if (@from == null) throw new ArgumentNullException(nameof(@from));

            var response = new GenericResponseModel<ProductModel>();
            response.Build(@from);
            if (@from.ReturnValue != null)
            {
                response.Data = Map(@from.ReturnValue);
            }
            return response;
        }

        private ProductModel Map(Domain.Entities.Product product)
        {
            return new ProductModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                AverageCustomerRating = product.AverageCustomerRating,
                PricePerItem = product.PricePerItem
            };
        }
    }
}
