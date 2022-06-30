using SpecificationPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.Specifications
{
    public class WithOtherEntitySpecification : BaseSpecification<Example>
    {
        private readonly string other;

        public WithOtherEntitySpecification(string other)
        {
            this.other = other;
        }
        public override Expression<Func<Example, bool>> Criteria()
        {
            return x => x.OtherExample.Name == other;
        }
    }
}
