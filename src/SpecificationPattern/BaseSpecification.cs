using SpecificationPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern
{
    public abstract class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public static readonly BaseSpecification<TEntity> All = new IdentitySpecification<TEntity>();
        public abstract Expression<Func<TEntity, bool>> Criteria();
        public BaseSpecification<TEntity> And(BaseSpecification<TEntity> specification)
        {
            if (this == All)
                return specification;
            if (specification == All)
                return this;

            return new AndSpecification<TEntity>(this, specification);
        }
        public BaseSpecification<TEntity> Or(BaseSpecification<TEntity> specification)
        {
            if (this == All || specification == All)
                return All;

            return new OrSpecification<TEntity>(this, specification);
        }
        public BaseSpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

    }
    internal sealed class IdentitySpecification<T> : BaseSpecification<T> where T : class
    {
        public override Expression<Func<T, bool>> Criteria()
        {
            return X => true;
        }
    }
    internal sealed class AndSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : class
    {
        private readonly BaseSpecification<TEntity> _left;
        private readonly BaseSpecification<TEntity> _right;

        public AndSpecification(BaseSpecification<TEntity> left, BaseSpecification<TEntity> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<TEntity, bool>> Criteria()
        {
            Expression<Func<TEntity, bool>> leftExpression = _left.Criteria();
            Expression<Func<TEntity, bool>> rightExpression = _right.Criteria();

            BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }
    internal sealed class OrSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : class
    {
        private readonly BaseSpecification<TEntity> _left;
        private readonly BaseSpecification<TEntity> _right;

        public OrSpecification(BaseSpecification<TEntity> left, BaseSpecification<TEntity> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<TEntity, bool>> Criteria()
        {
            Expression<Func<TEntity, bool>> leftExpression = _left.Criteria();
            Expression<Func<TEntity, bool>> rightExpression = _right.Criteria();

            BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(orExpression, leftExpression.Parameters.Single());
        }
    }
    internal sealed class NotSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : class
    {
        private readonly BaseSpecification<TEntity> _specification;

        public NotSpecification(BaseSpecification<TEntity> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<TEntity, bool>> Criteria()
        {
            Expression<Func<TEntity, bool>> expression = _specification.Criteria();

            UnaryExpression notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}
