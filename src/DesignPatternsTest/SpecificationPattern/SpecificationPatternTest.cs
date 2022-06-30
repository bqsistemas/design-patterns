using SpecificationPattern;
using SpecificationPattern.Entities;
using SpecificationPattern.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatternsTest.SpecificationPattern
{
    public class SpecificationPatternTest
    {
        [Fact]
        public void BuildSpecificationWithAnd()
        {
            var nameSpec = new ExampleSpecification();
            var genderSpec = new GenderSpecification();

            // name = "Hello World" and Gender = "Male"
            BaseSpecification<Example> specification = nameSpec.And(genderSpec);
        }
        [Fact]
        public void BuildSpecificationWithOr()
        {
            var nameSpec = new ExampleSpecification();
            var genderSpec = new GenderSpecification();

            // name = "Hello World" or Gender = "Male"
            BaseSpecification<Example> specification = nameSpec.Or(genderSpec);
        }
        [Fact]
        public void BuildSpecificationWithAll()
        {
            bool flag = false;
            var nameSpec = new ExampleSpecification();

            // name = "Hello World" and 1 = 1
            BaseSpecification<Example> specification = BaseSpecification<Example>.All;
            specification.And(nameSpec);

        }
        [Fact]
        public void BuildSpecificationWithOtherEntity()
        {
            var nameSpec = new WithOtherEntitySpecification("other");

            // OtherExample.Name = "other" and 1 = 1
            BaseSpecification<Example> specification = BaseSpecification<Example>.All;
            specification.And(nameSpec);

        }
    }
}
