using Business.IModels;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface ILearnerService
    {
        ILearner GetCurrentLearner();
    }
}
