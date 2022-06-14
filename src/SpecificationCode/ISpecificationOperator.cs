namespace SpecificationCode
{
public interface ISpecificationOperator
{
    Specification<T> Combine<T>(Specification<T> left, Specification<T> right);
}

}
