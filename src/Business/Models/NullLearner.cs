using Business.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class NullLearner : ILearner
    {
        public int Id => -1;

        public string UserName => "Just Browsing";

        public int CoursesCompleted => 0;
    }
}
