using SpecificationCode;
using SpecificationCodeSample.Models;

namespace SpecificationCodeSample.Specifications
{
    public class UnderSalePriceSpecification : Specification<Product>
    {
        public UnderSalePriceSpecification(double price) : base(x => x.SalePrice < price)
        {
        }
    }
}
