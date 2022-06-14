using System.Linq.Expressions;

namespace SpecificationCode
{
    public interface ISpecification<in T>
    {
        bool IsSatisfied(T obj);
    }
}
