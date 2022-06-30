﻿using SpecificationPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.Specifications
{
    public class GenderSpecification : BaseSpecification<Example>
    {
        public override Expression<Func<Example, bool>> Criteria()
        {
            return x => x.Gender == "Male";
        }
    }
}
