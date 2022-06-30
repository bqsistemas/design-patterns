using AsynchronousProgramming.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming.Services
{
    public interface IAsyncMicrosoftService
    {
        Task<IEnumerable<StockPrice>> GetDataMicrosoft();
    }
}
