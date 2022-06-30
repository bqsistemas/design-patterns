using AsynchronousProgramming.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming.Services
{
    public class AsyncMicrosoftService : IAsyncMicrosoftService
    {
        public async Task<IEnumerable<StockPrice>> GetDataMicrosoft()
        {
            string apiUrl = Environment.GetEnvironmentVariable("API_URL_ASYNC");
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync($"{apiUrl}/MSFT");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);
            }
        }
    }
}
