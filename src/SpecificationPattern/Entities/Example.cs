using Business.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.Entities
{
    public class Example : Entity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public OtherExample OtherExample { get; set; }
    }
}
