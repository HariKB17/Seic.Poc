using System;
using System.Collections.Generic;
using System.Linq;
using Product.Domain.Common;
using Product.Domain.Entities;
using Product.Service.Areas.V1.Mappers.Interfaces;
using Product.Service.Areas.V1.Models;
using Product.Service.Common;
using Product.Service.Common.Http;

namespace Product.Service.Areas.V1.Mappers
{
    /// <summary>
    /// Maps entity of type <see cref="ProductAttribute"/> to <see cref="ProductAttributeModel"/>
    /// </summary>
    public class ProductAttributeModelMapper : IProductAttributeModelMapper
    {
        public GenericResponseModel<List<ProductAttributeModel>> Map(IMethodResponse<List<ProductAttribute>> @from, object context = null)
        {
            if (@from == null) throw new ArgumentNullException(nameof(@from));

            var response = new GenericResponseModel<List<ProductAttributeModel>>();
            //To Build Messages from Method Response object
            response.Build(@from);
            if (@from.ReturnValue != null)
            {
                response.Data = @from.ReturnValue
                    .Select(Map).ToList();
            }
            return response;
        }

        private ProductAttributeModel Map(ProductAttribute productAttribute)
        {
            return new ProductAttributeModel()
            {
                ProductId = productAttribute.ProductId,
                AttributeTypeId = productAttribute.AttributeTypeId,
                AttributeTypeName = productAttribute.AttributeType?.Name,
                AttributeTypeValue = productAttribute.AttributeValue
            };
        }
    }
}
