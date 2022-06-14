using SpecificationCode;
using SpecificationCodeSample.Models;

namespace SpecificationCodeSample.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProducts(Specification<Product> specification);
    }
    public class ProductService : IProductService
    {
        private readonly IEnumerable<Product> products = new List<Product>()
            {
                new (1, "Product 1", "Nivea", 10, 10.9, 15.8),
                new (2, "Product 2", "Solgar", 12, 20, 41.99),
                new (3, "Product 3", "Solgar", 22, 12.90, 29.99),
                new (4, "Product 4", "Nutrefor", 7, 40, 12),
                new (5, "Product 5", "Nivea", 3, 69.99, 99.99),
                new (6, "Product 6", "Nutrefor", 6, 60, 12),
                new (7, "Product 7", "Nivea", 2, 39.89, 45.99),
                new (8, "Product 8", "Nivea", 9, 45.90, 79.99),
                new (9, "Product 9", "Nutrefor", 7, 90, 120),
                new (10, "Product 10", "Nivea", 1, 100, 12)
            };
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(products);
        }

        public async Task<IEnumerable<Product>> GetProducts(Specification<Product> specification)
        {
            return await Task.FromResult(products.Where(specification.Expression.Compile()));
        }
    }
}
