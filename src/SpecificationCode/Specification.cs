using System.Linq.Expressions;

namespace SpecificationCode
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }

        protected Specification(Expression<Func<T, bool>> expression) => Expression = expression;

        public bool IsSatisfied(T obj) => Expression.Compile()(obj);
    }

    internal class AndOperator : ISpecificationOperator
    {
        public Specification<T> Combine<T>(Specification<T> left, Specification<T> right)
        {
            Expression<Func<T, bool>> resultExpression;
            ParameterExpression param = left.Expression.Parameters.First();
            if (ReferenceEquals(param, right.Expression.Parameters.First()))
            {

                var expression = Expression.AndAlso(left.Expression.Body, right.Expression.Body);
                resultExpression = Expression.Lambda<Func<T, bool>>(expression, param);
            }
            else
            {
                var expression = Expression.AndAlso(left.Expression.Body, Expression.Invoke(right.Expression, param));
                resultExpression = Expression.Lambda<Func<T, bool>>(expression, param);
            }

            return new DynamicSpecification<T>(resultExpression);
        }
    }

    public static class OperatorExtensions
    {
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            return new AndOperator().Combine(left, right);
        }
    }

    public class DynamicSpecification<T> : Specification<T>
    {
        public DynamicSpecification(Expression<Func<T, bool>> expression)
          : base(expression)
        {
        }
    }

}
