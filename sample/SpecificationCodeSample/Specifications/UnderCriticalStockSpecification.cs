using SpecificationCode;
using SpecificationCodeSample.Models;

namespace SpecificationCodeSample.Specifications
{
    public class UnderCriticalStockSpecification : Specification<Product>
    {
        public UnderCriticalStockSpecification(int criticalStock) : base(x=>x.Quantity < criticalStock)
        {
        }
    }
}
