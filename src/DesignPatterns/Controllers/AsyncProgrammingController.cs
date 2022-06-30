using API.Services.Interfaces;
using AsynchronousProgramming.Services;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsyncProgrammingController : ControllerBase
    {
        private readonly IAsyncMicrosoftService _asyncMicrosoftService;
        private readonly ILogger<AsyncProgrammingController> _logger;

        public AsyncProgrammingController(
            IAsyncMicrosoftService asyncMicrosoftService,
            ILogger<AsyncProgrammingController> logger
            )
        {
            _asyncMicrosoftService = asyncMicrosoftService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetDataMicrosoft")]
        public async Task<IActionResult> DataMicrosoft()
        {
            var result = await _asyncMicrosoftService.GetDataMicrosoft();
            return Ok(result);
        }
    }
}
