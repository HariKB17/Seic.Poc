using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.DataAccess.Interfaces;

namespace Product.Domain.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Entities.Product>> RetrieveAllAsync()
        {
            return await _dbContext.Products.AsNoTracking()
                .OrderByDescending(product => product.AverageCustomerRating)
                .ToListAsync();
        }

        public async Task<Entities.Product> RetrieveAsync(int productId)
        {
            return await _dbContext.Products
                .FirstOrDefaultAsync(product => product.ProductId == productId);
        }
    }
}
