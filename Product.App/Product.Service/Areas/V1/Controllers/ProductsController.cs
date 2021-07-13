using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Product.Domain.Business.Interfaces;
using System;
using Product.Service.Areas.V1.Mappers.Interfaces;
using Product.Domain.Business;
using Product.Service.Common;
using System.Collections.Generic;
using Product.Service.Areas.V1.Models;

namespace Product.Service.Areas.V1.Controllers
{
    [Route("api/products")]
    [ApiVersion("1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponseModel<List<ProductModel>>), 200)]
        [ProducesResponseType(typeof(GenericResponseModel<List<ProductModel>>), 500)]

        public async Task<IActionResult> GetProducts([FromServices] IProductRetriever productRetriever,
            [FromServices] IProductModelMapper modelMapper)
        {
            if (productRetriever == null)
                throw new ArgumentNullException(nameof(productRetriever));

            if (modelMapper == null)
                throw new ArgumentNullException(nameof(modelMapper));

            var products = await productRetriever.RetrieveAllAsync();
            return Ok(modelMapper.Map(products));
        }

        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(GenericResponseModel<ProductModel>), 200)]
        [ProducesResponseType(typeof(GenericResponseModel<ProductModel>), 500)]
        public async Task<IActionResult> GetProduct(int productId, 
            [FromServices] IProductRetriever productRetriever,
            [FromServices] IProductModelMapper modelMapper)
        {
            if (productRetriever == null)
                throw new ArgumentNullException(nameof(productRetriever));

            if (modelMapper == null)
                throw new ArgumentNullException(nameof(modelMapper));

            var product = await productRetriever.RetrieveAsync(productId);
            return Ok(modelMapper.Map(product));
        }

        /// <summary>
        /// Get Product attributes by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{productId}/productAttributes")]
        [ProducesResponseType(typeof(GenericResponseModel<List<ProductAttributeModel>>), 200)]
        [ProducesResponseType(typeof(GenericResponseModel<List<ProductAttributeModel>>), 500)]
        public async Task<IActionResult> GetProductAttributes(int productId, 
            [FromServices] IProductAttributeRetriever productAttributeRetriever,
            [FromServices] IProductAttributeModelMapper modelMapper)
        {
            if (productAttributeRetriever == null)
                throw new ArgumentNullException(nameof(productAttributeRetriever));

            if (modelMapper == null)
                throw new ArgumentNullException(nameof(modelMapper));

            var product = await productAttributeRetriever.RetrieveAllAsync(productId);
            return Ok(modelMapper.Map(product));
        }
    }
}
