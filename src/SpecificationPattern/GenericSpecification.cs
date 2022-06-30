using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern
{
    public class GenericSpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }
        
        public bool IsSatistiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
