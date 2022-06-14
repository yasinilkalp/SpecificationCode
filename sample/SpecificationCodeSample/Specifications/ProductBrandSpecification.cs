using SpecificationCode;
using SpecificationCodeSample.Models;

namespace SpecificationCodeSample.Specifications
{
    public class ProductBrandSpecification : Specification<Product>
    {
        public ProductBrandSpecification(string brandName) : base(x => x.BrandName == brandName)
        {
        }
    }

    public static class ProductBrandSpecificationExtension
    {
        public static bool EqualsBrandName(this Product product, string brandName)
        {
            var specification = new ProductBrandSpecification(brandName);
            bool result = specification.IsSatisfied(product);
            return result;
        }

        public static IEnumerable<Product> EqualsBrandName(this IEnumerable<Product> products, string brandName)
        {
            return products.Where(x => x.EqualsBrandName(brandName));
        }

        public static IQueryable<Product> EqualsBrandName(this IQueryable<Product> products, string brandName)
        {
            var specification = new ProductBrandSpecification(brandName);
            return products.Where(specification.Expression);
        }
    }
}
