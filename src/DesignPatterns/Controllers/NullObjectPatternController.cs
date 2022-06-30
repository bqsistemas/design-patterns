using API.Services.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NullObjectPatternController : ControllerBase
    {
        private readonly ILearnerService _learnerService;
        private readonly ILogger<NullObjectPatternController> _logger;

        public NullObjectPatternController(
            ILearnerService learnerService,
            ILogger<NullObjectPatternController> logger
            )
        {
            _learnerService = learnerService;
            _logger = logger;
        }

        [HttpPost]
        [Route("PostGetCurrentLearner")]
        public IActionResult PostGetCurrentLearner()
        {
            var result = _learnerService.GetCurrentLearner();
            return Ok(result);
        }
    }
}
