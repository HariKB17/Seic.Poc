using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Product.Domain.Common;
using Product.Service.Areas.V1.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Product.Domain.Business.Interfaces;
using Product.Service.Areas.V1.Mappers.Interfaces;
using AutoFixture;
using Product.Service.Areas.V1.Models;
using Product.Service.Common;

namespace Product.Service.UnitTests.Areas.V1
{
    [TestFixture]
    [Category("ControllerTests_ProductV1")]
    public class ProductControllerTest
    {
        private readonly Fixture _autoFixture = new Fixture();
        private Mock<IProductRetriever> _productRetrieverMock;
        private Mock<IProductModelMapper> _productModelMapperMock;

        private ProductsController _productsController;
        [SetUp]
        public void SetUp()
        {
            _productRetrieverMock = new Mock<IProductRetriever>();
            _productModelMapperMock = new Mock<IProductModelMapper>();
            _productsController = new ProductsController();
        }

        [Test]
        public async Task products_get_products_action_should_return_valid_result()
        {
            var methodResponse = new MethodResponse<List<Domain.Entities.Product>>()
            { ReturnValue = new List<Domain.Entities.Product>() };

            _productRetrieverMock.Setup(retriever => retriever.RetrieveAllAsync())
                .ReturnsAsync(methodResponse);

            _productModelMapperMock.Setup(mapper => mapper.Map(methodResponse, null))
                .Returns(new GenericResponseModel<List<ProductModel>>()
                { Data = _autoFixture.Create<List<ProductModel>>() });

            var okResult = await _productsController.GetProducts(_productRetrieverMock.Object, _productModelMapperMock.Object);

            _productRetrieverMock.Verify(retriever => retriever.RetrieveAllAsync(), Times.Once);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(okResult);
            });
        }

        [Test]
        public async Task products_get_products_action_should_throw_exceptions_if_any()
        {
            //throwing some random exception
            _productRetrieverMock.Setup(retriever => retriever.RetrieveAllAsync())
                .Throws<KeyNotFoundException>();

            Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _productsController.GetProducts(_productRetrieverMock.Object, _productModelMapperMock.Object));
        }

    }
}
