using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.DataAccess.Interfaces;
using Product.Domain.Entities;

namespace Product.Domain.DataAccess
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductAttributeRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductAttribute>> RetrieveAllAsync(int productId)
        {
            return await _dbContext.ProductAttributes
                .Include(productAttribute => productAttribute.AttributeType)
                .AsNoTracking()
                .Where(productAttribute => productAttribute.ProductId == productId)
                .ToListAsync();
        }
    }
}
