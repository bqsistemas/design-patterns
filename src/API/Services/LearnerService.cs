using API.Services.Interfaces;
using BridgePattern;
using Business.Enums;
using Business.IModels;
using Business.Models;
using CommandPattern;
using CommandPattern.Commands;
using StrategyPattern.Models;
using StrategyPattern.Strategies.Comparer;
using StrategyPattern.Strategies.Invoice;
using StrategyPattern.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class LearnerService : ILearnerService
    {
        readonly LearnerRepo _repo = new LearnerRepo();
        public LearnerService()
        {
        }

        public ILearner GetCurrentLearner()
        {
            int learnerId = 0;

            return _repo.GetLearner(learnerId);
        }
    }

    class LearnerRepo
    {
        readonly IList<Learner> _learners = new List<Learner>();

        internal LearnerRepo()
        {
            _learners.Add(new Learner(1, "David", 83));
            _learners.Add(new Learner(2, "Julie", 72));
            _learners.Add(new Learner(3, "Scott", 92));
        }

        internal ILearner GetLearner(int id)
        {
            bool learnerExists = _learners.Any(l => l.Id == id);

            if (learnerExists)
                return _learners.FirstOrDefault(l => l.Id == id);

            return new NullLearner();
        }
    }
}
